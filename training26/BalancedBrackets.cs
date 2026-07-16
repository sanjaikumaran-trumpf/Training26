namespace Training26 {
   internal class BalancedBrackets {
      public bool IsBalanced (string bracketString) {
         char[] bracketsArray = bracketString.ToCharArray ();
         IList<char> stack = [];
         foreach (char bracket in bracketsArray) {
            int lastIndex = stack.Count - 1;
            char lastBracket = stack[lastIndex];
            if (bracket == '(' || bracket == '[' || bracket == '{') stack.Add (bracket);
            else if (bracket == ')' && lastBracket == '(') stack.RemoveAt (lastIndex);
            else if (bracket == ']' && lastBracket == '[') stack.RemoveAt (lastIndex);
            else if (bracket == '}' && lastBracket == '{') stack.RemoveAt (lastIndex);
         }
         return stack.Count == 0;
      }
   }
}
