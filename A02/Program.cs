using static System.Console;
using static System.ConsoleColor;

string? playAgain;

do {
   int secretNumber = new Random ().Next (1, 101);
   int userGuess;
   do {
      userGuess = ReadGuess ();
      if (userGuess == secretNumber) PrintMsg ("You guessed correctly!", Green);
      else {
         bool isTooLow = userGuess < secretNumber;
         string message = isTooLow ? "Your guess is low" : "Your guess is high";
         PrintMsg (message, isTooLow ? Cyan : Magenta);
      }
   } while (userGuess != secretNumber);
   do {
      Write ("Do you want to play again? (y/n): ");
      playAgain = ReadLine ()?.ToLower ().Trim ();
      if (playAgain != "y" && playAgain != "n") {
         PrintMsg ("Invalid input. Please enter 'y' or 'n'", Red);
      }
   } while (playAgain != "y" && playAgain != "n");
} while (playAgain == "y");

int ReadGuess () {
   while (true) {
      Write ("Guess a number between 1 and 100: ");
      if (int.TryParse (ReadLine (), out int value) && value >= 1 && value <= 100) {
         return value;
      }
      PrintMsg ("Invalid input. Enter a number between 1 and 100", Red);
   }
}

void PrintMsg (string msg, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (msg);
   ResetColor ();
}