/*
 * @lc app=leetcode id=7 lang=csharp
 *
 * [7] Reverse Integer
 *
 * https://leetcode.com/problems/reverse-integer/description/
 *
 * algorithms
 * Easy (25.21%)
 * Total Accepted:    635.1K
 * Total Submissions: 2.5M
 * Testcase Example:  '123'
 *
 * Given a 32-bit signed integer, reverse digits of an integer.
 * 
 * Example 1:
 * 
 * 
 * Input: 123
 * Output: 321
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: -123
 * Output: -321
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: 120
 * Output: 21
 * 
 * 
 * Note:
 * Assume we are dealing with an environment which could only store integers
 * within the 32-bit signed integer range: [−2^31,  2^31 − 1]. For the purpose
 * of this problem, assume that your function returns 0 when the reversed
 * integer overflows.
 * 
 */
public class Solution {
    public int Reverse(int x) {
        int result = 0, tem = 0;
        
        while (x != 0)
        {
            result = result*10 + x%10;
            x = x/10;
            if (result/10 != tem)
            {
                return 0;
            }
            tem = result;
        }
        return result;
    }
}

