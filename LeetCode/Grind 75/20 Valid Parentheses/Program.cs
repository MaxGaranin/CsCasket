namespace LeetCode.Grind_75._20_Valid_Parentheses;

public class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution2();

        // "()"
        // "()[]{}"
        // "(]"
        // "([])"
        // "]"
        var result = solution.IsValid("([])");

        Console.WriteLine(result);
    }
}
