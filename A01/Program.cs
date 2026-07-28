int randomNumber = new Random ().Next (1, 101);

while (true) {
   int userGuess = ReadInt ();
   if (userGuess < randomNumber)
      PrintColoured ("Your guess is too low", ConsoleColor.Cyan);
   else if (userGuess > randomNumber)
      PrintColoured ("Your guess is too high", ConsoleColor.Magenta);
   else {
      PrintColoured ("You guessed correctly", ConsoleColor.Green);
      break;
   }
}

int ReadInt () {
   while (true) {
      Console.Write ("Guess a number: ");
      if (int.TryParse (Console.ReadLine (), out int value))
         return value;
      else
         PrintColoured ("Enter a proper number!", ConsoleColor.Red);
   }
}

void PrintColoured (string text, ConsoleColor colour) {
   Console.ForegroundColor = colour;
   Console.WriteLine (text);
   Console.ResetColor ();
}