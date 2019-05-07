/*
 * @lc app=leetcode id=516 lang=csharp
 *
 * [516] Longest Palindromic Subsequence

 Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.

Example 1:
Input:

"bbbab"
Output:
4
One possible longest palindromic subsequence is "bbbb".
Example 2:
Input:

"cbbd"
Output:
2
One possible longest palindromic subsequence is "bb".
 */
public class Solution {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;
        if (n <= 1)
            return n;

        int[,] dp = new int[n, n];
        for (int i = n-1; i >= 0; i--)
        {
            dp[i, i] = 1;//初始值是1
            for (int j = i+1; j < n; j++)
            {
                if (s[i] == s[j])//分别向中间靠拢，=dp[i+1,j-1]+2
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[0, n - 1];
    }
}

// √ Accepted
//   √ 83/83 cases passed (140 ms)
//   √ Your runtime beats 51.22 % of csharp submissions
//   √ Your memory usage beats 18.18 % of csharp submissions (43.4 MB)

