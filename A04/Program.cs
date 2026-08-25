// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Spelling Bee Seeds
// A program that prints the first 7 high frequency letters in the word list
// ------------------------------------------------------------------------------------------------

Dictionary<char, int> frequency = [];
foreach (char letter in File.ReadAllText ("./word_list.txt"))
   if (letter is > 'a' and < 'z')
      frequency[letter] = frequency.GetValueOrDefault (letter) + 1;
var sortedLetters = frequency.OrderByDescending (x => x.Value).ThenBy (x => x.Key).Take (7);
foreach (var item in sortedLetters) Console.WriteLine ($"{item.Key,2} {item.Value}");