/*
 * @lc app=leetcode id=53 lang=csharp
 *
 * [53] Maximum Subarray
 *
 * https://leetcode.com/problems/maximum-subarray/description/
 *
 * algorithms
 * Easy (43.22%)
 * Total Accepted:    499.2K
 * Total Submissions: 1.2M
 * Testcase Example:  '[-2,1,-3,4,-1,2,1,-5,4]'
 *
 * Given an integer array nums, find the contiguous subarray (containing at
 * least one number) which has the largest sum and return its sum.
 * 
 * Example:
 * 
 * 
 * Input: [-2,1,-3,4,-1,2,1,-5,4],
 * Output: 6
 * Explanation: [4,-1,2,1] has the largest sum = 6.
 * 
 * 
 * Follow up:
 * 
 * If you have figured out the O(n) solution, try coding another solution using
 * the divide and conquer approach, which is more subtle.
 * 
 */
public class Solution {
    public int MaxSubArray(int[] nums)
    {
        int ret = int.MinValue;
        int s_i = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            s_i = Math.Max(s_i + nums[i], nums[i]);
            ret = Math.Max(ret, s_i);
        }

        return ret;
    }
    //F(n) = Max(F(n-1)+A[n], A[n])
}

// √ Accepted
//   √ 202/202 cases passed (96 ms)
//   √ Your runtime beats 86.31 % of csharp submissions
//   √ Your memory usage beats 53.77 % of csharp submissions (23.3 MB)

