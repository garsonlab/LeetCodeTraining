/*
 * @lc app=leetcode id=136 lang=csharp
 *
 * [136] Single Number
 *
 * https://leetcode.com/problems/single-number/description/
 *
 * algorithms
 * Easy (59.28%)
 * Total Accepted:    430.8K
 * Total Submissions: 726.2K
 * Testcase Example:  '[2,2,1]'
 *
 * Given a non-empty array of integers, every element appears twice except for
 * one. Find that single one.
 * 
 * Note:
 * 
 * Your algorithm should have a linear runtime complexity. Could you implement
 * it without using extra memory?
 * 
 * Example 1:
 * 
 * 
 * Input: [2,2,1]
 * Output: 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [4,1,2,1,2]
 * Output: 4
 * 
 * 
 */
public class Solution {
    public int SingleNumber(int[] nums) {
        int r = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            r ^= nums[i];
        }
        return r;
    }
}
//异或运算

// √ Accepted
//   √ 16/16 cases passed (100 ms)
//   √ Your runtime beats 89.86 % of csharp submissions
//   √ Your memory usage beats 85.13 % of csharp submissions (24.2 MB)

