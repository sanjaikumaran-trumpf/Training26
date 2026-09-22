// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Parse Double
// Parse the double from the string
// ------------------------------------------------------------------------------------------------
while (true) {
   Console.Write ("Enter the input string: ");
   string inputString = Console.ReadLine () ?? "";
   try {
      Console.WriteLine (ParseDouble (inputString));
      Console.WriteLine ("Press Escape to exit");
      if (Console.ReadKey (true).Key == ConsoleKey.Escape) break;
   } catch (Exception e) {
      Console.WriteLine (e.Message);
   }
}

double ParseDouble (string input) {
   if (string.IsNullOrEmpty (input)) throw new ArgumentException ("Invalid double number");
   int pos = 0;
   int sign = 1;
   if (input[pos] == '+' || input[pos] == '-') {
      if (input[pos] == '-') sign = -1;
      pos++;
   }
   double value = 0;
   bool hasDigit = false;
   // Parse integers before decimal point
   while (pos < input.Length && input[pos] >= '0' && input[pos] <= '9') {
      value = value * 10 + (input[pos] - '0');
      hasDigit = true;
      pos++;
   }
   // Parse integers after decimal point
   if (pos < input.Length && input[pos] == '.') {
      pos++;
      double divisor = 10;
      while (pos < input.Length && input[pos] >= '0' && input[pos] <= '9') {
         value += (input[pos] - '0') / divisor;
         divisor *= 10;
         hasDigit = true;
         pos++;
      }
   }
   if (!hasDigit) throw new ArgumentException ("Invalid double number");
   // Handle exponent notation
   if (pos < input.Length && (input[pos] == 'e' || input[pos] == 'E')) {
      pos++;
      int exponentSign = 1;
      if (pos < input.Length && (input[pos] == '+' || input[pos] == '-')) {
         if (input[pos] == '-') exponentSign = -1;
         pos++;
      }
      if (pos >= input.Length || input[pos] < '0' || input[pos] > '9')
         throw new ArgumentException ("Invalid double number");
      int exponent = 0;
      while (pos < input.Length) {
         if (input[pos] < '0' || input[pos] > '9') throw new ArgumentException ("Invalid double number");
         exponent = exponent * 10 + (input[pos] - '0');
         pos++;
      }
      // Convert exponent notation to decimal value
      value *= Math.Pow (10, exponent * exponentSign);
   }
   return value * sign;
}