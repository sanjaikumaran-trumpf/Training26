using Training26;

namespace training26;

class Program {
   static void Main (string[] args) {
      int[][] input = new int[3][];
      for (int i = 0; i < 3; i++) {
         string? inputString = null;
         do {
            Console.Write ($"Enter the row {i + 1} values in CSV (30, 31, 29): ");
            inputString = Console.ReadLine ();
         } while (string.IsNullOrEmpty (inputString));
         string[] inputChars = inputString.Split (",");
         int[] inputNumbers = new int[inputChars.Length];
         for (int j = 0; j < inputChars.Length; j++) {
            inputNumbers[j] = int.Parse (inputChars[j]);
         }
         input[i] = (inputNumbers);
      }
      MagicSquare magicSquare = new ();
      bool result = magicSquare.IsMagicSquareMatrix (input);
      Console.WriteLine ($"Result: {result}");
   }
}
