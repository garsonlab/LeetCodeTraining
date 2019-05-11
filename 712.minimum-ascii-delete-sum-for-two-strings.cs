/*
 * @lc app=leetcode id=712 lang=csharp
 *
 * [712] Minimum ASCII Delete Sum for Two Strings

 Given two strings s1, s2, find the lowest ASCII sum of deleted characters to make two strings equal.

Example 1:
Input: s1 = "sea", s2 = "eat"
Output: 231
Explanation: Deleting "s" from "sea" adds the ASCII value of "s" (115) to the sum.
Deleting "t" from "eat" adds 116 to the sum.
At the end, both strings are equal, and 115 + 116 = 231 is the minimum sum possible to achieve this.
Example 2:
Input: s1 = "delete", s2 = "leet"
Output: 403
Explanation: Deleting "dee" from "delete" to turn the string into "let",
adds 100[d]+101[e]+101[e] to the sum.  Deleting "e" from "leet" adds 101[e] to the sum.
At the end, both strings are equal to "let", and the answer is 100+101+101+101 = 403.
If instead we turned both strings into "lee" or "eet", we would get answers of 433 or 417, which are higher.
Note:

0 < s1.length, s2.length <= 1000.
All elements of each string will have an ASCII value in [97, 122].
 */
public class Solution {
    public int MinimumDeleteSum(string s1, string s2) {
        int m=s1.Length;
        int n=s2.Length;
        int[,] dp = new int[m+1, n+1];
        
        for(int i=1;i<=m;i++){
            dp[i,0]=dp[i-1,0]+s1[i-1];
        }
        for(int i=1;i<=n;i++)
            dp[0,i]=s2[i-1]+dp[0,i-1];
        
        for(int i=1;i<=m;i++){
            for(int j=1;j<=n;j++){
                dp[i,j]=(s1[i-1]==s2[j-1])? dp[i-1,j-1]:Math.Min(dp[i,j-1]+s2[j-1],  dp[i-1,j]+s1[i-1] );
            }
        }
        return dp[m,n];
    }
}

//我们建立一个二维数组dp，其中dp[i][j]表示字符串s1的前i个字符和字符串s2的前j个字符变相等所要删除的字符的最小ASCII码累加值。
//dp还是多一圈，如果不一样取当前上+s1/左+s2 最小值

// √ Accepted
//   √ 93/93 cases passed (92 ms)
//   √ Your runtime beats 48.39 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (26 MB)

