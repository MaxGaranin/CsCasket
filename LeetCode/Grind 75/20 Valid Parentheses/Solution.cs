namespace LeetCode.Grind_75._20_Valid_Parentheses;

public class Solution {
    private char[] opens = ['(', '[', '{'];
    private char[] closes = [')', ']', '}'];

    public bool IsValid(string s) {
        var stack = new Stack();

        foreach (var ch in s) {
            if (opens.Contains(ch)) {
                stack.Push(ch);
            }
            else if (closes.Contains(ch)) {
                var val = stack.Pop();
                if (Match(val, ch) == false) {
                    return false;
                }
            }
            else {
                // Do not take into account other symbols
            }
        }

        return (stack.Count == 0);
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

    public class Stack {
        private List<char> _stack = new();
        private int _newIndex = 0;

        public int Count => _newIndex;

        public void Push(char val) {
            if (_stack.Count == _newIndex) {
                _stack.Add(val);
            }
            else {
                _stack[_newIndex] = val;
            }

            _newIndex++;
        }

        public char Pop() {
            if (_newIndex == 0) {
                // throw new Exception("Stack is empty");
                return '#';
            }

            var val = _stack[_newIndex - 1];
            _newIndex--;
            return val;
        }
    }
}