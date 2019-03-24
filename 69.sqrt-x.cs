/*
 * @lc app=leetcode id=69 lang=csharp
 *
 * [69] Sqrt(x)
 *
 * https://leetcode.com/problems/sqrtx/description/
 *
 * algorithms
 * Easy (30.86%)
 * Total Accepted:    340.5K
 * Total Submissions: 1.1M
 * Testcase Example:  '4'
 *
 * Implement int sqrt(int x).
 * 
 * Compute and return the square root of x, where x is guaranteed to be a
 * non-negative integer.
 * 
 * Since the return type is an integer, the decimal digits are truncated and
 * only the integer part of the result is returned.
 * 
 * Example 1:
 * 
 * 
 * Input: 4
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 8
 * Output: 2
 * Explanation: The square root of 8 is 2.82842..., and since 
 * the decimal part is truncated, 2 is returned.
 * 
 * 
 */
public class Solution {
    public int MySqrt(int x) {
        if (x < 100)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i * i > x)
                {
                    return i - 1;
                }
            }
        }

        int len = 1;
        int dig = 10;
        while (x/dig >= 10)
        {
            dig *= 10;
            len++;
        }

        if (x >= 10)
            len++;

        int result = 0;
        int add = 0;
        if (len%2 > 0)
        {
            int s = x / dig;
            for (int i = 1; i <= 4; i++)
            {
                if (i * i > s)
                {
                    result = i - 1;
                    add = s - result * result;
                    break;
                }
            }

            dig = dig / 100;
        }
        else
        {
            int s = x / (dig/10);
            for (int i = 1; i <= 10; i++)
            {
                if (i*i > s)
                {
                    result = i - 1;
                    add = s - result * result;
                    break;
                }
            }

            dig = dig / 1000;
        }

        while (dig > 0)
        {
            int s = (x / dig) % 100;
            s = add * 100 + s;

            int tem = 20 * result;
            for (int i = 1; i <= 10; i++)
            {
                if ((tem + i) * i > s)
                {
                    result = result * 10 + i - 1;
                    add = s - (tem + i - 1) * (i - 1);
                    break;
                }
            }

            dig = dig / 100;
        }

        return result;
    }
}

// √ Accepted
//   √ 1017/1017 cases passed (40 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 47.54 % of csharp submissions (13.1 MB)

