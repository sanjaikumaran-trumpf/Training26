namespace Training26 {
   internal class WaitForCoolerDay {
      public int[] FirstCoolerDay (int[] temperatures) {
         int numberOfDays = temperatures.Length;
         int[] result = new int[numberOfDays];
         for (int i = 0; i < numberOfDays; i++) {
            for (int j = i; j < numberOfDays; j++) {
               if (temperatures[i] > temperatures[j]) {
                  result[i] = j - i; break;
               }
            }
         }
         return result;
      }
   }
}
