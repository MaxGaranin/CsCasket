namespace LeetCode.Grind_75._20_Valid_Parentheses;

public class Solution2 {
    private char[] opens = ['(', '[', '{'];
    private char[] closes = [')', ']', '}'];

    public bool IsValid(string s)
    {
        var stack = new List<char>();

        foreach (var ch in s) {
            if (opens.Contains(ch)) {
                stack.Add(ch);
            }
            else if (closes.Contains(ch)) {
                if (stack.Count == 0)
                {
                    return false;
                }

                var val = stack[^1];

                if (!Match(val, ch)) {
                    return false;
                }

                stack.RemoveAt(stack.Count - 1);
            }
            else {
                // Do not take into account other symbols
            }
        }

        return stack.Count == 0;
    }

    private bool Match(char opened, char closed) {
        if (
            (opened == '(' && closed == ')') ||
            (opened == '[' && closed == ']') ||
            (opened == '{' && closed == '}')
        ) {
            return true;
        }

        return false;
    }
}