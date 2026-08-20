using Training26;

namespace training26;

class Program {
   static void Main (string[] args) {
      string? inputString = null;
      do {
         Console.Write ("Enter the brackets string \"[()]\": ");
         inputString = Console.ReadLine ();
      } while (string.IsNullOrEmpty (inputString));
      bool result = new BalancedBrackets ().IsBalanced (inputString);
      Console.WriteLine (result);
   }
}
