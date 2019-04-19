/*
 * @lc app=leetcode id=152 lang=csharp
 *
 * [152] Maximum Product Subarray
 *
 * https://leetcode.com/problems/maximum-product-subarray/description/
 *
 * algorithms
 * Medium (28.87%)
 * Total Accepted:    201.2K
 * Total Submissions: 696.1K
 * Testcase Example:  '[2,3,-2,4]'
 *
 * Given an integer array nums, find the contiguous subarray within an array
 * (containing at least one number) which has the largest product.
 * 
 * Example 1:
 * 
 * 
 * Input: [2,3,-2,4]
 * Output: 6
 * Explanation: [2,3] has the largest product 6.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [-2,0,-1]
 * Output: 0
 * Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 * 
 */
public class Solution {
    public int MaxProduct(int[] nums) {
        int max = nums[0];
        int min = nums[0];
        int ret = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int tem = max;
            max = Math.Max(nums[i], Math.Max(nums[i] * max, nums[i] * min));
            min = Math.Min(nums[i], Math.Min(nums[i] * tem, nums[i] * min));
            ret = Math.Max(ret, max);
        }

        return ret;
    }
}

// √ Accepted
//   √ 184/184 cases passed (92 ms)
//   √ Your runtime beats 97.01 % of csharp submissions
//   √ Your memory usage beats 12.5 % of csharp submissions (22.5 MB)

