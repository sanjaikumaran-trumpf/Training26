using Training26;

namespace training26;

class Program {
   static void Main (string[] args) {
      string? inputString = null;
      do {
         Console.Write ("Enter the list of temperature as CSV (30, 31, 29): ");
         inputString = Console.ReadLine ();
      } while (string.IsNullOrEmpty (inputString));
      string[] inputChars = inputString.Split (",");
      int[] inputNumbers = new int[inputChars.Length];
      for (int i = 0; i < inputChars.Length; i++) {
         inputNumbers[i] = int.Parse (inputChars[i]);
      }

      WaitForCoolerDay waitForCoolerDay = new ();
      int[] result = waitForCoolerDay.FirstCoolerDay (inputNumbers);
      Console.WriteLine (string.Join (", ", result));
   }
}
