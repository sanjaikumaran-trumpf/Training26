// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Spelling Bee words solution finder
// A program that finds possible words using the provided letters from spelling bee game
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

string[] wordsList = File.ReadAllLines ("./word_list.txt");
string seed = GetLetters ();
var wordPoints = new List<(string Word, int Points, bool IsPangram)> ();
foreach (string word in wordsList)
   if (IsValidWord (seed, word)) {
      int points = word.Length > 4 ? word.Length : 1;
      bool isPangram = IsPangram (seed, word);
      // Add 7 bonus points for a panagram word
      wordPoints.Add ((word, isPangram ? points + 7 : points, isPangram));
   }
// Sort words by points from highest to lowest and words alphabetically for same points
wordPoints = [.. wordPoints.OrderByDescending (x => x.Points)];
int totalPoints = 0;
// Calculate total points and print the words with points and special word indicator
foreach (var item in wordPoints) {
   totalPoints += item.Points;
   if (item.IsPangram) ForegroundColor = Green;
   WriteLine ($"{item.Points,2}. {item.Word}");
   ResetColor ();
}
WriteLine ($"-------------\nTotal Points: {totalPoints}");

// Prompt the user to enter 7 letters and return them as a char array
string GetLetters () {
   while (true) {
      Write ("Enter the list of 7 letters (comma separated): ");
      IEnumerable<string> parts = (ReadLine () ?? "").Split (',').Select (s => s.Trim ().ToLower ());
      // Validate that exactly 7 single alphabetic letters were entered.
      string msg = parts.Distinct ().Count () != 7
                     ? "Error: You must enter exactly 7 distinct letters."
                     : parts.Any (s => s.Length != 1 || !char.IsLetter (s[0]))
                     ? "Error: Each item must be a single alphabet letter." : "";
      if (!string.IsNullOrEmpty (msg)) {
         WriteLine (msg);
         continue;
      }
      return string.Join ("", parts);
   }
}

// Return true if word has min 4 letters, contain first letter and use letters from the given list
bool IsValidWord (string seed, string word) => word.Length >= 4 && word.Contains (seed[0]) && word.All (seed.Contains);

// Return true if word contains all 7 of the given letters
bool IsPangram (string seed, string word) => word.Length >= 7 && word.Distinct ().Count () == 7;