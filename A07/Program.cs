// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Parse Double
// Parse the double from the string
// ------------------------------------------------------------------------------------------------
using static System.Console;

string?[] inputs = ["12", "12.123", "12.03", ".02", "0.02", "0", "-12", "-12.12", "+12",
   "+12.12", "12.", "-.02", "+.02", "1e3", "1E3", "1.2e3", "1.2E+3", "1.2E-3", " 12", "12 ",
   " 12 ", "  12.12  ", "  12. 12  ", "", " ", "abc", "hello", "12abc", "abc12", "12.12.12",
   "..12", "12..12", ".", "-", "+", "--12", "++12", "12-", "12+", "1,2,3", "12 34", "1 2",
   "12a.3", "1e", "1e+", "1e-", "1e2.3", null, "nan"];
WriteLine ($"{"Input",-12}\t{"double.TryParse",-16}\t{"ParseDouble",-12}");
foreach (var str in inputs) {
   bool status = double.TryParse (str, out double result);
   WriteLine ($"{$"'{str}'",-12}\t{(status ? result : double.NaN),-16}\t{ParseDouble (str),-12}");
}

double ParseDouble (string? str) {
   str = str?.Trim ().Replace (",", "");
   if (string.IsNullOrEmpty (str)) return double.NaN;
   int pos = 0, sign = 1, strLen = str.Length;
   if (str[pos] == '+' || str[pos] == '-') if (str[pos++] == '-') sign = -1;
   double value = 0;
   bool hasDigit = false;
   // Parse digits before decimal point
   while (pos < strLen && IsDigit (str[pos])) {
      value = value * 10 + str[pos++] - '0';
      hasDigit = true;
   }
   // Parse digits after decimal point
   if (pos < strLen && str[pos] == '.') {
      pos++;
      double divisor = 10;
      while (pos < strLen && IsDigit (str[pos])) {
         value += (str[pos++] - '0') / divisor;
         divisor *= 10;
         hasDigit = true;
      }
   }
   if (!hasDigit) return double.NaN;
   // Handle exponent notation
   int exponentSign = 1;
   if (pos < strLen && (str[pos] == 'e' || str[pos] == 'E')) {
      pos++;
      if (pos < strLen && (str[pos] == '+' || str[pos] == '-'))
         if (str[pos++] == '-') exponentSign = -1;
      if (!(pos < strLen) || !IsDigit (str[pos])) return double.NaN;
      int exponent = 0;
      while (pos < strLen) {
         if (!IsDigit (str[pos])) return double.NaN;
         exponent = exponent * 10 + str[pos++] - '0';
      }
      value *= Math.Pow (10, exponent * exponentSign);
   }
   // Any remaining character makes the input invalid.
   if (pos != strLen) return double.NaN;
   return value * sign;

   bool IsDigit (char value) => value is >= '0' and <= '9';
}