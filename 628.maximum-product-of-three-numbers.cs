/*
 * @lc app=leetcode id=628 lang=csharp
 *
 * [628] Maximum Product of Three Numbers
 *
 * https://leetcode.com/problems/maximum-product-of-three-numbers/description/
 *
 * algorithms
 * Easy (45.68%)
 * Total Accepted:    64.8K
 * Total Submissions: 141.6K
 * Testcase Example:  '[1,2,3]'
 *
 * Given an integer array, find three numbers whose product is maximum and
 * output the maximum product.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3]
 * Output: 6
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,2,3,4]
 * Output: 24
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The length of the given array will be in range [3,10^4] and all elements are
 * in the range [-1000, 1000].
 * Multiplication of any three numbers in the input won't exceed the range of
 * 32-bit signed integer.
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int MaximumProduct(int[] nums) {
        Array.Sort(nums);
        int len = nums.Length;
        int p1 = nums[0] * nums[1] * nums[len - 1];
        int p2 = nums[len - 1] * nums[len - 2] * nums[len - 3];
        return Math.Max(p1, p2);
    }
}

// √ Accepted
//   √ 83/83 cases passed (156 ms)
//   √ Your runtime beats 70.37 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (32.3 MB)

