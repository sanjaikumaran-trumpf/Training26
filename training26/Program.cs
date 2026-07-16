using Training26;

namespace training26;

class Program {
   static void Main (string[] args) {
      int[][] case1 = [[2, 7, 6], [9, 5, 1], [4, 3, 8]], case2 = [[8, 1, 6], [3, 5, 7], [4, 9, 2]], case3 = [[8, 1, 6], [3, 5, 7], [4, 2, 9]];
      MagicSquare magicSquare = new ();
      bool case1Result = magicSquare.IsMagicSquareMatrix (case1);
      bool case2Result = magicSquare.IsMagicSquareMatrix (case2);
      bool case3Result = magicSquare.IsMagicSquareMatrix (case3);
      Console.WriteLine ($"Case 1: {case1Result}");
      Console.WriteLine ($"Case 2: {case2Result}");
      Console.WriteLine ($"Case 3: {case3Result}");
   }
}
