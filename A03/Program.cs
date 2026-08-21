// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Spelling Bee - Solution
// A program that finds possible words using the provided letters from spelling bee game
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

string[] wordsList = File.ReadAllLines ("./word_list.txt");
char[] seed = GetLetters ();
var wordPoints = new List<(string Word, int Points, bool IsPanagram)> ();
foreach (string word in wordsList)
   if (IsValidWord (seed, word)) {
      int points = word.Length > 4 ? word.Length : 1;
      bool isPanagram = IsPanagram (seed, word);
      // Add 7 bonus points for a panagram word
      wordPoints.Add ((word, isPanagram ? points + 7 : points, isPanagram));
   }
// Sort words by points from highest to lowest and words alphabetically for same points
wordPoints = wordPoints.OrderByDescending (x => x.Points).ThenBy (x => x.Word).ToList ();
int totalPoints = 0;
// Calculate total points and print the words with points and special word indicator
foreach (var item in wordPoints) {
   totalPoints += item.Points;
   PrintMsg ($"{item.Points,2}. {item.Word}", item.IsPanagram ? Green : White);
}
WriteLine ($"-------------\nTotal Points: {totalPoints}");

// Prompt the user to enter 7 letters and return them as a char array
char[] GetLetters () {
   while (true) {
      Write ("Enter the list of 7 letters (comma separated): ");
      string[] parts = (ReadLine () ?? "").Split (',').Select (s => s.Trim ()).ToArray (); ;
      // Validate that exactly 7 single alphabetic letters were entered.
      string msg = parts.Length != 7 ? "Error: You must enter exactly 7 letters." :
                     parts.Any (s => s.Length != 1 || !char.IsLetter (s[0])) ?
                     "Error: Each item must be a single alphabet letter." : "";
      if (!string.IsNullOrEmpty (msg)) {
         WriteLine (msg);
         continue;
      }
      return parts.Select (s => s[0]).ToArray ();
   }
}

// Return true if word has min 4 letters, contain first letter and use letters from the given list
bool IsValidWord (char[] seed, string word) => word.Length >= 4 && word.Contains (seed[0]) &&
                                                   word.All (c => seed.Contains (c));

// Return true if word contains all 7 of the given letters
bool IsPanagram (char[] seed, string word) => word.Length >= 7 &&
                                                    seed.All (c => word.Contains (c));

// Print a message in the specified colour
void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}