/*
 * @lc app=leetcode id=33 lang=csharp
 *
 * [33] Search in Rotated Sorted Array
 *
 * https://leetcode.com/problems/search-in-rotated-sorted-array/description/
 *
 * algorithms
 * Medium (32.77%)
 * Total Accepted:    394K
 * Total Submissions: 1.2M
 * Testcase Example:  '[4,5,6,7,0,1,2]\n0'
 *
 * Suppose an array sorted in ascending order is rotated at some pivot unknown
 * to you beforehand.
 * 
 * (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).
 * 
 * You are given a target value to search. If found in the array return its
 * index, otherwise return -1.
 * 
 * You may assume no duplicate exists in the array.
 * 
 * Your algorithm's runtime complexity must be in the order of O(log n).
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [4,5,6,7,0,1,2], target = 0
 * Output: 4
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [4,5,6,7,0,1,2], target = 3
 * Output: -1
 * 
 */
public class Solution {
    public int Search(int[] nums, int target)
    {
        return MidSearch(ref nums, 0, nums.Length - 1, target);
    }

    private int MidSearch(ref int[] nums, int l, int r, int target)
    {
        if (r < l || (l == r && nums[l] != target))
            return -1;
        int mid = (l + r) / 2;
        if (nums[mid] == target)
            return mid;
        if (r - l == 1)
        {
            return nums[r] == target ? r : -1;
        }

        if (nums[l] < nums[mid])//一半有序、一半无序，判断好有序的一半、问题丢给无序的一半
        {
            if (nums[mid] > target && nums[l] <= target)
                return MidSearch(ref nums, l, mid - 1, target);
            else
                return MidSearch(ref nums, mid + 1, r, target);
        }
        else
        {
            if (nums[mid] < target && nums[r] >= target)
                return MidSearch(ref nums, mid + 1, r, target);
            else
                return MidSearch(ref nums, l, mid - 1, target);
        }
    }
}

// √ Accepted
//   √ 196/196 cases passed (92 ms)
//   √ Your runtime beats 99.62 % of csharp submissions
//   √ Your memory usage beats 78.38 % of csharp submissions (22.5 MB)

