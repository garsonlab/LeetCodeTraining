/*
 * @lc app=leetcode id=172 lang=csharp
 *
 * [172] Factorial Trailing Zeroes
 *
 * https://leetcode.com/problems/factorial-trailing-zeroes/description/
 *
 * algorithms
 * Easy (37.27%)
 * Total Accepted:    150.1K
 * Total Submissions: 402.5K
 * Testcase Example:  '3'
 *
 * Given an integer n, return the number of trailing zeroes in n!.
 * 
 * Example 1:
 * 
 * 
 * Input: 3
 * Output: 0
 * Explanation: 3! = 6, no trailing zero.
 * 
 * Example 2:
 * 
 * 
 * Input: 5
 * Output: 1
 * Explanation: 5! = 120, one trailing zero.
 * 
 * Note: Your solution should be in logarithmic time complexity.
 * 
 */
public class Solution {
    public int TrailingZeroes(int n) {
        int r = 0;
        while (n >= 5)
        {
            n /= 5;
            r += n;
        }

        return r;
    }
}

//2*5=10，所以5的个数就是0的个数
// √ Accepted
//   √ 502/502 cases passed (56 ms)
//   √ Your runtime beats 10.74 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.8 MB)

