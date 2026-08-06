// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Guessing Game (Binary Remainder Method)
// Think of a number between 1 and 100.
// The computer determines the binary digits using remainder properties.
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

do {
   int guess = 0;
   WriteLine ("Think of a number between 1 and 100.\n");
   bool isOdd = AskYesNo ("Is your number odd?");
   if (isOdd) guess |= 1;
   int remainder4 = AskRemainder ("What is the remainder when divided by 4?", 0, 3);
   guess |= remainder4;
   int remainder16 = AskRemainder ("What is the remainder when divided by 16?", 0, 15);
   guess |= remainder16;
   int remainder64 = AskRemainder ("What is the remainder when divided by 64?", 0, 63);
   guess |= remainder64;
   bool greaterOrEqual64 = AskYesNo ("Is your number greater than or equal to 64?");
   if (greaterOrEqual64) guess |= 64;
   PrintMsg ($"Your number is {guess}!\n", Green);
} while (AskYesNo ("Do you want to play again?"));

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