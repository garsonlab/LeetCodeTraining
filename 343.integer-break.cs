/*
 * @lc app=leetcode id=343 lang=csharp
 *
 * [343] Integer Break

 Given a positive integer n, break it into the sum of at least two positive integers and maximize the product of those integers. Return the maximum product you can get.

Example 1:

Input: 2
Output: 1
Explanation: 2 = 1 + 1, 1 × 1 = 1.
Example 2:

Input: 10
Output: 36
Explanation: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36.
Note: You may assume that n is not less than 2 and not larger than 58.
 */
public class Solution {
    public int IntegerBreak(int n) {
        if (n <= 3)
            return n - 1;
        int[] dp = new int[n+1];
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 3;

        for (int i = 4; i <= n; i++)
        {
            int max = i - 1;
            for (int j = 2; j < i; j++)
            {
                max = Math.Max(max, dp[j] * dp[i - j]);
            }

            dp[i] = max;
        }

        return dp[n];
    }
}

// √ Accepted
//   √ 50/50 cases passed (48 ms)
//   √ Your runtime beats 16.67 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (12.9 MB)

