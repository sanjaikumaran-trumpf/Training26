using Training26;

namespace training26;

class Program {
   static void Main (string[] args) {
      bool result = new BalancedBrackets ().IsBalanced ("{()}");
      Console.WriteLine (result);
   }
}
