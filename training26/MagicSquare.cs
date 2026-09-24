namespace Training26 {
   internal class MagicSquare {
      public bool IsMagicSquareMatrix (int[][] matrix) {
         int m = matrix.Length;
         int commonSum = 0;
         foreach (int number in matrix[0]) commonSum += number;
         // To check rows and columns
         for (int r = 0; r < m; r++) {
            int rowSum = 0;
            int colSum = 0;
            for (int c = 0; c < matrix[r].Length; c++) {
               rowSum += matrix[r][c];
               colSum += matrix[c][r];
            }
            if (rowSum != commonSum || colSum != commonSum) {
               return false;
            }
         }
         // To check diagonals
         int diagSumOne = 0;
         int diagSumTwo = 0;
         for (int i = 0; i < m; i++) {
            diagSumOne += matrix[i][i];
            diagSumTwo += matrix[i][m - 1 - i];
         }
         if (diagSumOne != commonSum || diagSumTwo != commonSum) {
            return false;
         }
         return true;
      }
   }
}
