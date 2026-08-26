// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Seed Letter Frequency
// Program prints the seven most frequency letters in the word list.
// ------------------------------------------------------------------------------------------------

Dictionary<char, int> letterFrequency = [];
foreach (char ch in File.ReadAllText ("./word_list.txt").ToLowerInvariant ())
   // Counting the letter frequency
   if (ch is >= 'a' and <= 'z')
      letterFrequency[ch] = letterFrequency.GetValueOrDefault (ch) + 1;
// Printing the seven most frequency letters
foreach (var item in letterFrequency.OrderByDescending (x => x.Value).ThenBy (x => x.Key).Take (7))
   Console.WriteLine ($"{item.Key,2} {item.Value}");