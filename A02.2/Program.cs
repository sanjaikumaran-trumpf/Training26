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
   // Determine the LSB by checking whether the number is odd
   if (AskYesNo ("Is your number odd?")) guess |= 1;
   // Determine the remaining bits by asking for remainders using powers of 4
   for (int divisor = 4; divisor <= 64; divisor *= 4)
      guess |= AskRemainder ($"What is the remainder when divided by {divisor}?", 0, divisor - 1);
   // Determine the MSB by checking whether the number is at least 64.
   if (AskYesNo ("Is your number greater than or equal to 64?")) guess |= 64;
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

// Ask the user for a remainder and keep prompting until a valid value is entered.
int AskRemainder (string question, int min, int max) {
   while (true) {
      Write ($"{question} ({min} - {max}): ");
      if (int.TryParse (ReadLine (), out int value) && value >= min && value <= max) return value;
      PrintMsg ($"Please enter a number between {min} and {max}.", Red);
   }
}

void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}