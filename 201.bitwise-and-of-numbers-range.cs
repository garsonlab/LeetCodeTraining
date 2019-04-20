/*
 * @lc app=leetcode id=201 lang=csharp
 *
 * [201] Bitwise AND of Numbers Range
 *
 * https://leetcode.com/problems/bitwise-and-of-numbers-range/description/
 *
 * algorithms
 * Medium (35.69%)
 * Total Accepted:    79.7K
 * Total Submissions: 223K
 * Testcase Example:  '5\n7'
 *
 * Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND
 * of all numbers in this range, inclusive.
 * 
 * Example 1:
 * 
 * 
 * Input: [5,7]
 * Output: 4
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [0,1]
 * Output: 0
 */
public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
        if (m == 0)
            return 0;

        int count = 0;
        while (m != n)
        {
            m >>= 1;
            n >>= 1;
            count++;
        }

        return m << count;

        // long a = (long) m;
        // long b = (long) n;
        // for (int i = m+1; i <= n; i++)
        // {
        //     a &= i;
        // }

        // return (int) a;
    }
}

// √ Accepted
//   √ 8266/8266 cases passed (68 ms)
//   √ Your runtime beats 99.06 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (14.2 MB)

