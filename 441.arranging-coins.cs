/*
 * @lc app=leetcode id=441 lang=csharp
 *
 * [441] Arranging Coins
 *
 * https://leetcode.com/problems/arranging-coins/description/
 *
 * algorithms
 * Easy (37.61%)
 * Total Accepted:    65.9K
 * Total Submissions: 175K
 * Testcase Example:  '5'
 *
 * You have a total of n coins that you want to form in a staircase shape,
 * where every k-th row must have exactly k coins.
 * ⁠
 * Given n, find the total number of full staircase rows that can be formed.
 * 
 * n is a non-negative integer and fits within the range of a 32-bit signed
 * integer.
 * 
 * Example 1:
 * 
 * n = 5
 * 
 * The coins can form the following rows:
 * ¤
 * ¤ ¤
 * ¤ ¤
 * 
 * Because the 3rd row is incomplete, we return 2.
 * 
 * 
 * 
 * Example 2:
 * 
 * n = 8
 * 
 * The coins can form the following rows:
 * ¤
 * ¤ ¤
 * ¤ ¤ ¤
 * ¤ ¤
 * 
 * Because the 4th row is incomplete, we return 3.
 * 
 * 
 */
public class Solution {
    public int ArrangeCoins(int n) {
        if (n <= 0) return 0;

        int f = 0;
        while (n - f - 1 >= 0)
        {
            f++;
            n -= f;
        }

        return f;
    }
}


//另一种方法，当作等差数列求和，用二分法求最后的值
// √ Accepted
//   √ 1336/1336 cases passed (84 ms)
//   √ Your runtime beats 5.69 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (13 MB)

