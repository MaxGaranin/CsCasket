namespace LeetCode.TopInterview150._88_Merge_Sorted_Array;

public class Solution
{
    public void Merge(int[] nums1, int[] nums2)
    {
        Merge(nums1, nums1.Length, nums2, nums2.Length);
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = 0;
        int j = 0;
        int k = m;

        while (i < m || j < n)
        {
            if (nums1[i] < nums2[j])
            {
                nums1[k] = nums1[i];
                i++;
            }
            else
            {
                nums1[k] = nums2[j];
                j++;
            }

            k++;
        }
    }
}