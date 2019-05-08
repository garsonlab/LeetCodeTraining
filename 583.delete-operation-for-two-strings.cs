/*
 * @lc app=leetcode id=583 lang=csharp
 *
 * [583] Delete Operation for Two Strings
 Given two words word1 and word2, find the minimum number of steps required to make word1 and word2 the same, where in each step you can delete one character in either string.

Example 1:
Input: "sea", "eat"
Output: 2
Explanation: You need one step to make "sea" to "ea" and another step to make "eat" to "ea".
Note:
The length of given words won't exceed 500.
Characters in given words can only be lower-case letters.
 */
public class Solution {
    public int MinDistance(string word1, string word2) {
        int m = word1.Length;
        int n = word2.Length;
        int[,] dp = new int[m+1, n+1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        
        return m + n - 2 * dp[m, n];
    }
}

    //找1和2的最长公共子串，然后用总长-子串长度
// √ Accepted
//   √ 1307/1307 cases passed (88 ms)
//   √ Your runtime beats 88.31 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (25.8 MB)

