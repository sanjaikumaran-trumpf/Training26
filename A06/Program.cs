// ------------------------------------------------------------------------------------------------
// Training 2026
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// 8 X 8 Queens Problem
// Place 8 queens on an 8 X 8 chessboard so that no two queens attack each other.
// ------------------------------------------------------------------------------------------------
using static System.Console;

Write ("Press U to print only unique solutions or any key to print all: ");
bool printUniqueOnly = ReadKey ().Key == ConsoleKey.U;
const int BOARD_SIZE = 8;
List<int[]> solns = [];
int[] queensPos = new int[BOARD_SIZE];
Array.Fill (queensPos, -1);
Solve (queensPos, 0, solns);
OutputEncoding = System.Text.Encoding.UTF8;
for (int i = 0; i < solns.Count; i++) {
   WriteLine ($"\nSolution {i + 1} of {solns.Count}");
   PrintBoard (solns[i]);
   WriteLine ();
}

// Prints chess board and queens in the given places
void PrintBoard (int[] queens) {
   for (int i = 0; i < BOARD_SIZE; i++) {
      // Top / middle border
      Write (i == 0 ? "┌" : "├");
      for (int j = 0; j < BOARD_SIZE; j++)
         Write ("───" + (j == BOARD_SIZE - 1 ? (i == 0 ? "┐" : "┤") : (i == 0 ? "┬" : "┼")));
      WriteLine ();
      // Rows with and without queen
      for (int j = 0; j < BOARD_SIZE; j++)
         Write (queens[i] == j ? "│ ♛ " : "│   ");
      WriteLine ("│");
   }
   // Bottom
   Write ("└");
   for (int j = 0; j < BOARD_SIZE; j++)
      Write ("───" + (j == BOARD_SIZE - 1 ? "┘" : "┴"));
}

// Try to place a queen in the current row
// Recursively solve the remaining rows and backtrack if needed
void Solve (int[] queens, int row, List<int[]> solutions) {
   if (row == BOARD_SIZE) {
      var solution = (int[])queens.Clone ();
      if (!printUniqueOnly || IsUnique (solution))
         solutions.Add (solution);
      return;
   }
   for (int column = 0; column < BOARD_SIZE; column++) {
      if (IsSafe (queens, row, column)) {
         queens[row] = column;
         Solve (queens, row + 1, solutions);
         queens[row] = -1;
      }
   }
}

// Returns true if the position is safe to place the queen, else returns false
bool IsSafe (int[] queens, int row, int column) {
   for (int prevRow = 0; prevRow < row; prevRow++) {
      int prevCol = queens[prevRow];
      // Return false if same column or same diagonal
      if (prevCol == column || Math.Abs (prevRow - row) == Math.Abs (prevCol - column))
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
      int[] temp = new int[BOARD_SIZE];
      for (int i = 0; i < BOARD_SIZE; i++)
         temp[soln[i]] = BOARD_SIZE - i - 1;
      return temp;
   }

   bool Exists (int[] test) => solns.Any (a => a.SequenceEqual (test));
}