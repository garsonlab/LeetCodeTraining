/*
 * @lc app=leetcode id=34 lang=csharp
 *
 * [34] Find First and Last Position of Element in Sorted Array
 *
 * https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
 *
 * algorithms
 * Medium (33.27%)
 * Total Accepted:    285.2K
 * Total Submissions: 857K
 * Testcase Example:  '[5,7,7,8,8,10]\n8'
 *
 * Given an array of integers nums sorted in ascending order, find the starting
 * and ending position of a given target value.
 * 
 * Your algorithm's runtime complexity must be in the order of O(log n).
 * 
 * If the target is not found in the array, return [-1, -1].
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [5,7,7,8,8,10], target = 8
 * Output: [3,4]
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [5,7,7,8,8,10], target = 6
 * Output: [-1,-1]
 * 
 */
public class Solution {
    public int[] SearchRange(int[] nums, int target)
    {
        int[] idxs = new[] {int.MaxValue, -1};
        MidSearchRange(ref nums, 0, nums.Length-1, target, ref idxs);

        if (idxs[1] == -1)
            idxs[0] = -1;
        return idxs;
    }

    private void MidSearchRange(ref int[] nums, int l, int r, int target, ref int[] idxs)
    {
        if (r < l)
            return;
        int mid = (l + r) / 2;
        if (nums[mid] == target)
        {
            if (mid < idxs[0])
                idxs[0] = mid;
            if (mid > idxs[1])
                idxs[1] = mid;
        }

        if(l == r)
            return;

        if(nums[mid] >= target)
            MidSearchRange(ref nums, l, mid-1, target, ref idxs);

        if(nums[mid] <= target)
            MidSearchRange(ref nums, mid+1, r, target, ref idxs);
    }
}

// √ Accepted
//   √ 88/88 cases passed (256 ms)
//   √ Your runtime beats 75 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (30.1 MB)

