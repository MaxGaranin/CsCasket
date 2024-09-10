namespace LeetCode.TopInterview150._88_Merge_Sorted_Array;

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums1 = [1, 2, 3, 0, 0, 0];
        int[] nums2 = [2, 5, 6];

        var solution = new Solution();
        solution.Merge(nums1, nums2);

        Console.WriteLine(nums1);
    }
}