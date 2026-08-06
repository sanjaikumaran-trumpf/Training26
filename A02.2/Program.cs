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

ConsoleKey playAgain;

do {
   int guess = 0;
   WriteLine ("Think of a number between 1 and 100.\n");
   bool isOdd = AskYesNo ("Is your number odd?");
   if (isOdd) guess |= 1;
   int remainder4 = AskNumber ("What is the remainder when divided by 4? (0 - 3): ", 0, 3);
   guess |= remainder4;
   int remainder16 = AskNumber ("What is the remainder when divided by 16? (0 - 15): ", 0, 15);
   guess |= remainder16;
   int remainder64 = AskNumber ("What is the remainder when divided by 64? (0 - 63): ", 0, 63);
   guess |= remainder64;
   bool greaterOrEqual64 = AskYesNo ("Is your number greater than or equal to 64?");
   if (greaterOrEqual64) guess |= 64;
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

int AskNumber (string question, int min, int max) {
   while (true) {
      Write (question);
      if (int.TryParse (ReadLine (), out int value) && value >= min && value <= max) return value;
      PrintMsg ($"Please enter a number between {min} and {max}.", Red);
   }
}

void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}