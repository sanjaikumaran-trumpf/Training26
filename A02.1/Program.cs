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

ConsoleKey playAgain;

do {
   int guess = 0;
   WriteLine ("Think of a number between 1 and 100.\n");
   for (int bit = 6; bit >= 0; bit--) {
      int currentNumber = guess | (1 << bit);
      if (currentNumber > 100) continue;
      if (AskYesNo ($"Is your number greater than or equal to {currentNumber}?")) guess = currentNumber;
   }
   PrintMsg ($"Your number is {guess}!\n", Green);
   WriteLine ("Press 'Y' to play again!\n");
   playAgain = ReadKey (true).Key;
} while (playAgain == ConsoleKey.Y);

bool AskYesNo (string question) {
   while (true) {
      Write ($"{question} (Y/N): ");
      switch (ReadKey (true).Key) {
         case ConsoleKey.Y:
            PrintMsg ("Y", Blue);
            return true;
         case ConsoleKey.N:
            PrintMsg ("N", Magenta);
            return false;
         default:
            PrintMsg ("Please enter Y or N.", Red);
            break;
      }
   }
}

void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}