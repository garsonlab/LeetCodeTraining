/*
 * @lc app=leetcode id=50 lang=csharp
 *
 * [50] Pow(x, n)
 *
 * https://leetcode.com/problems/powx-n/description/
 *
 * algorithms
 * Medium (27.77%)
 * Total Accepted:    306.7K
 * Total Submissions: 1.1M
 * Testcase Example:  '2.00000\n10'
 *
 * Implement pow(x, n), which calculates x raised to the power n (x^n).
 * 
 * Example 1:
 * 
 * 
 * Input: 2.00000, 10
 * Output: 1024.00000
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 2.10000, 3
 * Output: 9.26100
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: 2.00000, -2
 * Output: 0.25000
 * Explanation: 2^-2 = 1/2^2 = 1/4 = 0.25
 * 
 * 
 * Note:
 * 
 * 
 * -100.0 < x < 100.0
 * n is a 32-bit signed integer, within the range [−2^31, 2^31 − 1]
 * 
 * 
 */
public class Solution {
    public double MyPow(double x, int n) {
        if (n == 0)
            return 1;
        double half = MyPow(x, n / 2);

        if (n % 2 == 0)
            return half * half;

        if (n > 0)
            return half * half * x;
        return half * half * 1/x;
    }
}

// √ Accepted
//   √ 304/304 cases passed (40 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 86.57 % of csharp submissions (13.1 MB)

