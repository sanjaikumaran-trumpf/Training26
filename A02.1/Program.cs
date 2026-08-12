// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Guessing Game (Computer Guesses - MSB First)
// Think of a number between 1 and 100.
// The computer determines the number one bit at a time (MSB → LSB).
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

do {
   int guess = 0;
   WriteLine ("Think of a number between 1 and 127.\n");
   for (int bit = 6; bit >= 0; bit--) {
      int currentNumber = guess | (1 << bit);
      if (AskYesNo ($"Is your number greater than or equal to {currentNumber}?")) guess = currentNumber;
   }
   var (msg, color) = guess < 1 ? ("Those answers don't match a number between 1 and 127.", Red) : ($"Your number is {guess}!\n", Green);
   PrintMsg (msg, color);
} while (AskYesNo ("Do you want to play again?"));

bool AskYesNo (string question) {
   while (true) {
      Write ($"{question} (Y/N): ");
      var result = ReadKey (true).Key switch { ConsoleKey.Y => true, ConsoleKey.N => false, _ => (bool?)null };
      var (msg, color) = result.HasValue ? (result.Value ? ("Y", Blue) : ("N", Magenta)) : ("Invalid input", Red);
      PrintMsg (msg, color);
      if (result.HasValue) return result.Value;
   }
}

void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}