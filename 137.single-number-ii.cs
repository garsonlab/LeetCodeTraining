/*
 * @lc app=leetcode id=137 lang=csharp
 *
 * [137] Single Number II
 *
 * https://leetcode.com/problems/single-number-ii/description/
 *
 * algorithms
 * Medium (45.55%)
 * Total Accepted:    162.7K
 * Total Submissions: 356.9K
 * Testcase Example:  '[2,2,3,2]'
 *
 * Given a non-empty array of integers, every element appears three times
 * except for one, which appears exactly once. Find that single one.
 * 
 * Note:
 * 
 * Your algorithm should have a linear runtime complexity. Could you implement
 * it without using extra memory?
 * 
 * Example 1:
 * 
 * 
 * Input: [2,2,3,2]
 * Output: 3
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [0,1,0,1,0,1,99]
 * Output: 99
 * 
 */
public class Solution {
    public int SingleNumber(int[] nums) {
        int a = 0, b = 0;
        foreach (var n in nums)
        {
            b = (b ^ n) & ~a;
            a = (a ^ n) & ~b;
        }

        return b;
    }
}

//^异或 相同为0，不同为1
//&同位与，同1为1
//~取反

// √ Accepted
//   √ 11/11 cases passed (92 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.8 MB)

