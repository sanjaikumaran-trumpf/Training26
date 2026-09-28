// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Parse Double
// Parse the double from the string
// ------------------------------------------------------------------------------------------------
const string InvalidDoubleMessage = "Invalid double number";
while (true) {
   Console.Write ("Enter the input string: ");
   string inputString = Console.ReadLine ()?.Trim () ?? "";
   try {
      Console.WriteLine ($"ParseDouble : {ParseDouble (inputString)}");
   } catch (Exception e) {
      Console.WriteLine ($"ParseDouble Error: {e.Message}");
   }
   Console.WriteLine ("\nPress any key to continue or Escape to exit.");
   if (Console.ReadKey (true).Key == ConsoleKey.Escape) break;
   Console.WriteLine ();
}

double ParseDouble (string input) {
   if (string.IsNullOrEmpty (input)) throw new ArgumentException (InvalidDoubleMessage);
   int pos = 0;
   int sign = 1;
   if (input[pos] == '+' || input[pos] == '-') {
      if (input[pos] == '-') sign = -1;
      pos++;
   }
   double value = 0;
   bool hasDigit = false;
   // Parse digits before decimal point
   while (pos < input.Length && IsDigit (input[pos])) {
      value = value * 10 + input[pos] - '0';
      hasDigit = true;
      pos++;
   }
   // Parse digits after decimal point
   if (pos < input.Length && input[pos] == '.') {
      pos++;
      double divisor = 10;
      while (pos < input.Length && IsDigit (input[pos])) {
         value += (input[pos] - '0') / divisor;
         divisor *= 10;
         hasDigit = true;
         pos++;
      }
   }
   if (!hasDigit) throw new ArgumentException (InvalidDoubleMessage);
   // Handle exponent notation
   int exponentSign = 1;
   if (pos < input.Length && (input[pos] == '+' || input[pos] == '-')) {
      if (input[pos] == '-') exponentSign = -1;
      pos++;
   }
   if (pos < input.Length && (input[pos] == 'e' || input[pos] == 'E')) {
      pos++;
      if (!(pos < input.Length) || !IsDigit (input[pos]))
         throw new ArgumentException (InvalidDoubleMessage);
      int exponent = 0;
      while (pos < input.Length) {
         if (!IsDigit (input[pos])) throw new ArgumentException (InvalidDoubleMessage);
         exponent = exponent * 10 + input[pos] - '0';
         pos++;
      }
      value *= Math.Pow (10, exponent * exponentSign);
   }
   // Any remaining character makes the input invalid.
   if (pos != input.Length) throw new ArgumentException (InvalidDoubleMessage);
   return value * sign;
}

bool IsDigit (char value) => value >= '0' && value <= '9';