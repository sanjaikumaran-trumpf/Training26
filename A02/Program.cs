// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Guessing Game
// A console-based game where the player tries to guess a randomly generated number within a given range.
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static System.ConsoleColor;

ConsoleKey playAgain;

do {
   int secretNumber = Random.Shared.Next (1, 101), userGuess;
   do {
      userGuess = ReadGuess ();
      var (msg, clr) = userGuess < secretNumber ? ("Your guess is low", Cyan) :
                       userGuess > secretNumber ? ("Your guess is high", Red) :
                                                  ("You guessed correctly!", Green);
      PrintMsg (msg, clr);
   } while (userGuess != secretNumber);
   WriteLine ("Press 'Y' to play again!");
   playAgain = ReadKey (true).Key;
} while (playAgain == ConsoleKey.Y);

int ReadGuess () {
   while (true) {
      Write ("Guess a number between 1 and 100: ");
      if (int.TryParse (ReadLine (), out int value) && value >= 1 && value <= 100) return value;
      PrintMsg ("Invalid input. Enter a number between 1 and 100", Red);
   }
}

void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}