/*
 * @lc app=leetcode id=29 lang=csharp
 *
 * [29] Divide Two Integers
 *
 * https://leetcode.com/problems/divide-two-integers/description/
 *
 * algorithms
 * Medium (16.15%)
 * Total Accepted:    188.9K
 * Total Submissions: 1.2M
 * Testcase Example:  '10\n3'
 *
 * Given two integers dividend and divisor, divide two integers without using
 * multiplication, division and mod operator.
 * 
 * Return the quotient after dividing dividend by divisor.
 * 
 * The integer division should truncate toward zero.
 * 
 * Example 1:
 * 
 * 
 * Input: dividend = 10, divisor = 3
 * Output: 3
 * 
 * Example 2:
 * 
 * 
 * Input: dividend = 7, divisor = -3
 * Output: -2
 * 
 * Note:
 * 
 * 
 * Both dividend and divisor will be 32-bit signed integers.
 * The divisor will never be 0.
 * Assume we are dealing with an environment which could only store integers
 * within the 32-bit signed integer range: [−2^31,  2^31 − 1]. For the purpose
 * of this problem, assume that your function returns 2^31 − 1 when the
 * division result overflows.
 * 
 * 
 */
public class Solution {
    public int Divide(int dividend, int divisor) {
        if (dividend == 0)
            return 0;
        if (dividend == int.MinValue && divisor == -1)//最小值处理
            return int.MaxValue;

        bool negative = (dividend ^ divisor) < 0;//异或运算求符号相反

        long t = Math.Abs((long) dividend);
        long d = Math.Abs((long) divisor);

        int result = 0;
        for (int i = 31; i >= 0; i--)
        {
            if ((t >> i) >= d)//找2^n*d的最大值
            {
                result += 1 << i;//将结果加上2^n
                t -= d << i;//将被除数减去2^n*divisor
            }
        }

        return negative ? -result : result;
    }
}

// √ Accepted
//   √ 989/989 cases passed (40 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 90.91 % of csharp submissions (13 MB)

