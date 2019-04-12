/*
 * @lc app=leetcode id=970 lang=csharp
 *
 * [970] Powerful Integers
 *
 * https://leetcode.com/problems/powerful-integers/description/
 *
 * algorithms
 * Easy (39.73%)
 * Total Accepted:    9.3K
 * Total Submissions: 23.5K
 * Testcase Example:  '2\n3\n10'
 *
 * Given two positive integers x and y, an integer is powerful if it is equal
 * to x^i + y^j for some integers i >= 0 and j >= 0.
 * 
 * Return a list of all powerful integers that have value less than or equal to
 * bound.
 * 
 * You may return the answer in any order.  In your answer, each value should
 * occur at most once.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: x = 2, y = 3, bound = 10
 * Output: [2,3,4,5,7,9,10]
 * Explanation: 
 * 2 = 2^0 + 3^0
 * 3 = 2^1 + 3^0
 * 4 = 2^0 + 3^1
 * 5 = 2^1 + 3^1
 * 7 = 2^2 + 3^1
 * 9 = 2^3 + 3^0
 * 10 = 2^0 + 3^2
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: x = 3, y = 5, bound = 15
 * Output: [2,4,6,8,10,14]
 * 
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= x <= 100
 * 1 <= y <= 100
 * 0 <= bound <= 10^6
 * 
 */
public class Solution {
    public IList<int> PowerfulIntegers(int x, int y, int bound) {
        int mx = x == 1 ? 0 : (int)Math.Log(bound, x);
        int my = y == 1 ? 0 : (int)Math.Log(bound, y);

        int[] ax = new int[mx+1];
        int[] ay = new int[my+1];
        ax[0] = 1;
        for (int i = 1; i <= mx; i++)
        {
            ax[i] = ax[i - 1] * x;
        }

        ay[0] = 1;
        for (int i = 1; i <= my; i++)
        {
            ay[i] = ay[i - 1] * y;
        }

        List<int> list = new List<int>();
        for (int i = 0; i <= mx; i++)
        {
            for (int j = 0; j <= my; j++)
            {
                int v = ax[i] + ay[j];
                if (v <= bound)
                {
                    if(!list.Contains(v))
                        list.Add(ax[i]+ay[j]);
                }
                else
                    break;
            }
        }
        list.Sort();

        return list;
    }
}

// √ Accepted
//   √ 93/93 cases passed (212 ms)
//   √ Your runtime beats 96.88 % of csharp submissions
//   √ Your memory usage beats 72.73 % of csharp submissions (23.3 MB)

