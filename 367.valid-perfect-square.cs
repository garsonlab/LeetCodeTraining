/*
 * @lc app=leetcode id=367 lang=csharp
 *
 * [367] Valid Perfect Square
 *
 * https://leetcode.com/problems/valid-perfect-square/description/
 *
 * algorithms
 * Easy (39.47%)
 * Total Accepted:    103.4K
 * Total Submissions: 261.6K
 * Testcase Example:  '16'
 *
 * Given a positive integer num, write a function which returns True if num is
 * a perfect square else False.
 * 
 * Note: Do not use any built-in library function such as sqrt.
 * 
 * Example 1:
 * 
 * 
 * 
 * Input: 16
 * Output: true
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 14
 * Output: false
 * 
 * 
 * 
 */
public class Solution {
    public bool IsPerfectSquare(int num) {
        return MySqrt(num);
    }


    public bool MySqrt(int x) {
        if (x < 100)
        {
            for (int i = 1; i <= 10; i++)
            {

                if (i * i == x)
                {
                    return true;
                }
            }
            return false;
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

        return add == 0;
    }
}


// √ Accepted
//   √ 68/68 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.7 MB)

