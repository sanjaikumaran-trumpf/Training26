// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Guessing Game (Binary Remainder Method)
// The computer determines the number by asking questions about its binary bits and remainders
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

do {
   int guess = 0;
   WriteLine ("Think of a number between 0 and 127.\n");
   // Determine each binary bit using the remainder
   for (int divisor = 2; divisor <= 128; divisor *= 2) {
      int bit = divisor / 2;
      // True means this bit is 1, else bit is 0
      if (AskYesNo ($"Is the remainder when divided by {divisor} equal to {guess | bit}?"))
         guess |= bit;
   }
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