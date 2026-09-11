// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// 8 X 8 Queens Problem
// Place 8 queens on an 8 X 8 chessboard so that no two queens attack each other.
// ------------------------------------------------------------------------------------------------
using static System.Console;

// Prints chess board and queens in the given places
void PrintBoard (int[] queens) {
   OutputEncoding = System.Text.Encoding.UTF8;
   for (int i = 0; i < queens.Length; i++) {
      // Top / middle border
      Write (i == 0 ? "\u250C" : "\u251C");
      for (int j = 0; j < queens.Length; j++)
         Write (new string ('\u2500', 3) + (j == queens.Length - 1 ? (i == 0 ? "\u2510" : "\u2524") : (i == 0 ? "\u252C" : "\u253C")));
      WriteLine ();
      // Rows with and without queen
      for (int j = 0; j < queens.Length; j++)
         Write (queens[i] == j ? "\u2502 \u265B " : "\u2502   ");
      WriteLine ("\u2502");
   }
   // Bottom
   Write ("\u2514");
   for (int j = 0; j < queens.Length; j++)
      Write (new string ('\u2500', 3) + (j == queens.Length - 1 ? "\u2518" : "\u2534"));
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

// Try to place a queen in the current row
// Recursively solve the remaining rows and backtrack if needed
void Solve (int[] queens, int row, List<int[]> solutions) {
   if (row == queens.Length) {
      solutions.Add ((int[])queens.Clone ());
      return;
   }
   for (int column = 0; column < queens.Length; column++) {
      if (IsSafe (queens, row, column)) {
         queens[row] = column;
         Solve (queens, row + 1, solutions);
         queens[row] = -1;
      }
   }
}

List<int[]> slns = [];
int[] queens = new int[8];
Array.Fill (queens, -1);
Solve (queens, 0, slns);
for (int i = 0; i < slns.Count; i++) {
   WriteLine ($"Solution {i + 1} of {slns.Count}");
   PrintBoard (slns[i]);
   WriteLine ();
}