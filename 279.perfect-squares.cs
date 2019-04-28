/*
 * @lc app=leetcode id=279 lang=csharp
 *
 * [279] Perfect Squares

 Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

Example 1:

Input: n = 12
Output: 3 
Explanation: 12 = 4 + 4 + 4.
Example 2:

Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
 */
public class Solution {
    public int NumSquares(int n) {
        int[] flag = new int[n+1];
        
        for (int i = 1; i <= n; i++)
        {
            //从f[1]开始计算
            int minVal = int.MaxValue;
            for (int j = 1; j * j <= i; j++)
                minVal = Math.Min(minVal, flag[i - j * j]);
            flag[i] = minVal + 1;
        }

        return flag[n];
    }
}

// √ Accepted
//   √ 588/588 cases passed (92 ms)
//   √ Your runtime beats 81.41 % of csharp submissions
//   √ Your memory usage beats 79.17 % of csharp submissions (14.2 MB)

