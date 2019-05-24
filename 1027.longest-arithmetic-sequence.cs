/*
 * @lc app=leetcode id=1027 lang=csharp
 *
 * [1027] Longest Arithmetic Sequence

 Given an array A of integers, return the length of the longest arithmetic subsequence in A.

Recall that a subsequence of A is a list A[i_1], A[i_2], ..., A[i_k] with 0 <= i_1 < i_2 < ... < i_k <= A.length - 1, and that a sequence B is arithmetic if B[i+1] - B[i] are all the same value (for 0 <= i < B.length - 1).

 

Example 1:

Input: [3,6,9,12]
Output: 4
Explanation: 
The whole array is an arithmetic sequence with steps of length = 3.
Example 2:

Input: [9,4,7,2,10]
Output: 3
Explanation: 
The longest arithmetic subsequence is [4,7,10].
Example 3:

Input: [20,1,15,3,10,5,8]
Output: 4
Explanation: 
The longest arithmetic subsequence is [20,15,10,5].
 

Note:

2 <= A.length <= 2000
0 <= A[i] <= 10000
 */
public class Solution {
    public int LongestArithSeqLength(int[] A)
    {
        int n = A.Length, ans = 0;
        Dictionary<int, int>[] dp = new Dictionary<int, int>[n];
        for (int i = 0; i < n; i++)
            dp[i] = new Dictionary<int, int>();
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int s = A[j] - A[i];
                if (dp[j].ContainsKey(s))
                    dp[i][s] = dp[j][s] + 1;
                else
                    dp[i][s] = 1;
                ans = Math.Max(ans, dp[i][s]);
            }
        }

        return ans+1;
    }

    public int LongestArithSeqLength_timeout(int[] A) {
        int[,] dp = new int[A.Length, A.Length];
        int Length = 0;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = i + 1; j < A.Length; j++)
            {
                int len = longestArithSeqLengthDFS(dp, A[j] - A[i], j, A);
                Length = len + 2 > Length ? len + 2 : Length;
            }
        }
        return Length;
    }

    public static int longestArithSeqLengthDFS(int[,] dp, int step, int last, int[] A)
    {
        if (last >= A.Length)
        {
            return 0;
        }

        for (int i = last + 1; i < A.Length; i++)
        {
            if (A[i] - A[last] == step)
            {
                if (dp[last,i] != 0)
                {
                    return dp[last,i];
                }
                else
                {
                    dp[last,i] = longestArithSeqLengthDFS(dp, step, i, A) + 1;
                    return dp[last,i];
                }
            }
        }
        return 0;
    }

}

// √ Accepted
//   √ 35/35 cases passed (500 ms)
//   √ Your runtime beats 67.65 % of csharp submissions
//   √ Your memory usage beats 37.65 % of csharp submissions (85.3 MB)

