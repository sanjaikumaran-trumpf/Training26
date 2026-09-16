// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// 8 X 8 Queens Problem
// Place 8 queens on an 8 X 8 chessboard so that no two queens attack each other.
// ------------------------------------------------------------------------------------------------
using static System.Console;

Write ("Press Y to print only unique solutions or any key to print all: ");
bool printUniqueOnly = ReadKey ().Key == ConsoleKey.Y;
int noOfQueens = 8;
List<int[]> slns = [];
int[] queens = new int[noOfQueens];
Array.Fill (queens, -1);
Solve (queens, 0, slns);
for (int i = 0; i < slns.Count; i++) {
   WriteLine ($"\nSolution {i + 1} of {slns.Count}");
   PrintBoard (slns[i]);
   WriteLine ();
}

// Prints chess board and queens in the given places
void PrintBoard (int[] queens) {
   OutputEncoding = System.Text.Encoding.UTF8;
   for (int i = 0; i < noOfQueens; i++) {
      // Top / middle border
      Write (i == 0 ? "\u250C" : "\u251C");
      for (int j = 0; j < noOfQueens; j++)
         Write (new string ('\u2500', 3) + (j == noOfQueens - 1 ? (i == 0 ? "\u2510" : "\u2524") : (i == 0 ? "\u252C" : "\u253C")));
      WriteLine ();
      // Rows with and without queen
      for (int j = 0; j < noOfQueens; j++)
         Write (queens[i] == j ? "\u2502 \u265B " : "\u2502   ");
      WriteLine ("\u2502");
   }
   // Bottom
   Write ("\u2514");
   for (int j = 0; j < noOfQueens; j++)
      Write (new string ('\u2500', 3) + (j == noOfQueens - 1 ? "\u2518" : "\u2534"));
}


// Try to place a queen in the current row
// Recursively solve the remaining rows and backtrack if needed
void Solve (int[] queens, int row, List<int[]> solutions) {
   if (row == noOfQueens) {
      var solution = (int[])queens.Clone ();
      if (!printUniqueOnly || IsUnique (solution))
         solutions.Add (solution);
      return;
   }
   for (int column = 0; column < noOfQueens; column++) {
      if (IsSafe (queens, row, column)) {
         queens[row] = column;
         Solve (queens, row + 1, solutions);
         queens[row] = -1;
      }
   }
}

// Returns true if the position is safe to place the queen, else returns false
bool IsSafe (int[] queens, int row, int column) {
   for (int previousRow = 0; previousRow < row; previousRow++) {
      int previousColumn = queens[previousRow];
      // Return false if same column or same diagonal
      if (previousColumn == column || Math.Abs (previousRow - row) == Math.Abs (previousColumn - column))
         return false;
   }
   return true;
}

// Return true only if the solution is unique under rotation and reflection
bool IsUnique (int[] solution) {
   var temp = solution;
   for (int i = 0; i < 4; i++)
      if (Exists (temp = Rotate (temp)) || Exists ([.. temp.Reverse ()])) return false;
   return true;
   int[] Rotate (int[] soln) {
      int[] temp = new int[noOfQueens];
      for (int i = 0; i < noOfQueens; i++)
         temp[soln[i]] = noOfQueens - i - 1;
      return temp;
   }
   bool Exists (int[] test) => slns.Any (a => a.SequenceEqual (test));
}