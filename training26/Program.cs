using Training26;

namespace training26;

class Program {
   static void Main (string[] args) {
      int[] temperatures = [30, 31, 29, 32, 28, 27, 30, 25];
      WaitForCoolerDay waitForCoolerDay = new ();
      int[] result = waitForCoolerDay.FirstCoolerDay (temperatures);
      Console.WriteLine (string.Join (", ", result));
   }
}
