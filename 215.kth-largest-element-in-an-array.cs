/*
 * @lc app=leetcode id=215 lang=csharp
 *
 * [215] Kth Largest Element in an Array
 
    Category	Difficulty	Likes	Dislikes
    algorithms	Medium (46.92%)	1889	159

    Tags
    Companies
    Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

    Example 1:

    Input: [3,2,1,5,6,4] and k = 2
    Output: 5
    Example 2:

    Input: [3,2,3,1,2,4,5,5,6] and k = 4
    Output: 4
    Note: 
    You may assume k is always valid, 1 ≤ k ≤ array's length.
 */
public class Solution {
    public int FindKthLargest(int[] nums, int k)
    {
        if (nums.Length <= 0)
            return -1;
        FastSort(nums, 0, nums.Length - 1, k-1);

        return nums[k-1];
    }

    private int FastSort(int[] nums, int low, int high, int k)
    {
        if (high <= low)
            return -1;

        int idx = SortUnit(nums, low, high);
        if (idx == k)
            return k;

        if (idx > k)
            return FastSort(nums, low, idx - 1, k);
        else
            return FastSort(nums, idx + 1, high, k);


        // int a = FastSort(nums, low, idx - 1, k);
        // if (a == k)
        //     return k;

        // return FastSort(nums, idx + 1, high, k);
    }

    private int SortUnit(int[] array, int low, int high)
    {
        int key = array[low];
        while (low < high)
        {
            while (array[high] <= key && high > low)
                --high;
            array[low] = array[high];
            while (array[low] >= key && high > low)
                ++low;
            array[high] = array[low];
        }
        array[low] = key;
        return high;
    }
}

// √ Accepted
//   √ 32/32 cases passed (124 ms)
//   √ Your runtime beats 46.5 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (23.6 MB)

