/*
 * @lc app=leetcode id=371 lang=csharp
 *
 * [371] Sum of Two Integers
 *
 * https://leetcode.com/problems/sum-of-two-integers/description/
 *
 * algorithms
 * Easy (51.13%)
 * Total Accepted:    128.2K
 * Total Submissions: 251K
 * Testcase Example:  '1\n2'
 *
 * Calculate the sum of two integers a and b, but you are not allowed to use
 * the operator + and -.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: a = 1, b = 2
 * Output: 3
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: a = -2, b = 3
 * Output: 1
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int GetSum(int a, int b) {
        int r = a;
        while (b != 0)
        {
            int tmp = a;
            a = a^b;
            b = (tmp&b)<<1;
            r = a;
        }
        return r;
    }
}

//https://blog.csdn.net/harry_128/article/details/80150502
// √ Accepted
//   √ 13/13 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 80.95 % of csharp submissions (12.8 MB)

