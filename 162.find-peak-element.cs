/*
 * @lc app=leetcode id=162 lang=csharp
 *
 * [162] Find Peak Element
 *
 * https://leetcode.com/problems/find-peak-element/description/
 *
 * algorithms
 * Medium (40.99%)
 * Total Accepted:    229.2K
 * Total Submissions: 558.6K
 * Testcase Example:  '[1,2,3,1]'
 *
 * A peak element is an element that is greater than its neighbors.
 * 
 * Given an input array nums, where nums[i] ≠ nums[i+1], find a peak element
 * and return its index.
 * 
 * The array may contain multiple peaks, in that case return the index to any
 * one of the peaks is fine.
 * 
 * You may imagine that nums[-1] = nums[n] = -∞.
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,3,1]
 * Output: 2
 * Explanation: 3 is a peak element and your function should return the index
 * number 2.
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,2,1,3,5,6,4]
 * Output: 1 or 5 
 * Explanation: Your function can return either index number 1 where the peak
 * element is 2, 
 * or index number 5 where the peak element is 6.
 * 
 * 
 * Note:
 * 
 * Your solution should be in logarithmic complexity.
 * 
 */
public class Solution {
    public int FindPeakElement(int[] nums) {
        int len = nums.Length;
        if (len == 1)
            return 0;

        int start = 0, end = len - 1, mid = 0;

        while (start <= end)
        {
            mid = (start + end) / 2;

            int left = mid > 0 ? nums[mid - 1] : int.MinValue;
            int right = mid < len - 1 ? nums[mid + 1] : int.MinValue;

            if (nums[mid] > left && nums[mid] > right)
                break;

            if (nums[mid] < left)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return mid;
    }
}

// √ Accepted
//   √ 59/59 cases passed (92 ms)
//   √ Your runtime beats 95.06 % of csharp submissions
//   √ Your memory usage beats 61.54 % of csharp submissions (22.4 MB)

