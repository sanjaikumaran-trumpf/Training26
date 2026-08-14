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
   WriteLine ("Think of a number between 0 and 127.\n");
   for (int bit = 6; bit >= 0; bit--)
      if (AskYesNo ($"Is your number greater than or equal to {guess | (1 << bit)}?"))
         // Add the current bit to guess using bitwise OR
         guess |= 1 << bit;
   PrintMsg ($"Your number is {guess}!\n", Green);
} while (AskYesNo ("Do you want to play again?"));

// Ask the user a Yes/No question and keep prompting until Y or N is entered.
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