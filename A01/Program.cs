using static System.Console;
using static System.ConsoleColor;

int randomNumber = new Random ().Next (1, 101);

while (true) {
   int userGuess = ReadInt ();
   if (userGuess < randomNumber) PrintColouredMsg ("Your guess is too low", Cyan);
   else if (userGuess > randomNumber) PrintColouredMsg ("Your guess is too high", Magenta);
   else {
      PrintColouredMsg ("You guessed correctly", Green);
      break;
   }
}

int ReadInt () {
   while (true) {
      Write ("Guess a whole number between 1 and 100: ");
      if (int.TryParse (ReadLine (), out int value)) return value;
      PrintColouredMsg ("Invalid input, Enter a proper number!", Red);
   }
}

void PrintColouredMsg (string text, ConsoleColor colour) {
   ForegroundColor = colour;
   WriteLine (text);
   ResetColor ();
}