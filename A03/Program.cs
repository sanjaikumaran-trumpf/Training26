using static System.Console;

string[] wordsList = File.ReadAllLines ("./word_list.txt");
char[] letters = GetLetters ();
string[] words = wordsList.Where (word => word.Contains (letters[0]) && word.Length >= 4 &&
                  word.All (c => letters.Contains (c))).OrderByDescending (word => word.Length)
                  .ToArray ();
int totalPoints = 0;
foreach (string word in words) {
   int points = 1, wordLength = word.Length;
   if (wordLength > 4) {
      points = wordLength;
      if (wordLength >= 7 && letters.All (c => word.Contains (c))) points += 7;
   }
   totalPoints += points;
   WriteLine ($"{points,-2} {word}");
}
WriteLine ($"------------------\nTotal Points: {totalPoints}");

char[] GetLetters () {
   while (true) {
      Write ("Enter the list of 7 letters (comma separated): ");
      string[] parts = (ReadLine () ?? "").Split (',');
      string msg = parts.Length != 7 ? "Error: You must enter exactly 7 letters." :
                     parts.Any (s => s.Trim ().Length != 1 || !char.IsLetter (s.Trim ()[0])) ?
                     "Error: Each item must be a single alphabet letter." : "";
      if (!string.IsNullOrEmpty (msg)) {
         WriteLine (msg);
         continue;
      }
      return parts.Select (s => s.Trim ()[0]).ToArray ();
   }
}