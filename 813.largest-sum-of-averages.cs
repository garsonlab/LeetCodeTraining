/*
 * @lc app=leetcode id=813 lang=csharp
 *
 * [813] Largest Sum of Averages

 We partition a row of numbers A into at most K adjacent (non-empty) groups, then our score is the sum of the average of each group. What is the largest score we can achieve?

Note that our partition must use every number in A, and that scores are not necessarily integers.

Example:
Input: 
A = [9,1,2,3,9]
K = 3
Output: 20
Explanation: 
The best choice is to partition A into [9], [1, 2, 3], [9]. The answer is 9 + (1 + 2 + 3) / 3 + 9 = 20.
We could have also partitioned A into [9, 1], [2], [3, 9], for example.
That partition would lead to a score of 5 + 2 + 6 = 13, which is worse.
 

Note:

1 <= A.length <= 100.
1 <= A[i] <= 10000.
1 <= K <= A.length.
Answers within 10^-6 of the correct answer will be accepted as correct.
 */
public class Solution {
    public double LargestSumOfAverages(int[] A, int K) {
        int len = A.Length;
        double[] pre = new double[len + 1]; //区间和预处理 sum[i, j] = pre[j + 1] - pre[i]
        for (int i = 1; i <= len; ++i)
        {
            pre[i] = pre[i - 1] + A[i - 1];
        }
        double[,] dp = new double[K,len];
        for (int k = 0; k < K; ++k)
        {
            for (int i = 0; i < len; ++i)
            {
                dp[k,i] = k == 0 ? pre[i + 1] / (i + 1) : dp[k - 1,i];
                if (k > 0)
                {
                    for (int j = i - 1; j >= 0; --j)
                    {
                        dp[k,i] = Math.Max(dp[k,i], dp[k - 1,j] + (pre[i + 1] - pre[j + 1]) / (i - j));
                    }
                }
            }
        }
        return dp[K - 1,len - 1];
    }
    //dp[k][i] = Math.max(dp[k - 1][i], dp[k - 1][j] + (sum[j + 1, i] / (i - j)); (k > = 1, sum[j + 1, i] 表示区间j+1到i中间所有数的和)
    //用dp[k][i] 表示前i+1个元素(0~i)最多分k个组是平均数和最大
}

// √ Accepted
//   √ 51/51 cases passed (116 ms)
//   √ Your runtime beats 16.67 % of csharp submissions
//   √ Your memory usage beats 31.25 % of csharp submissions (21.9 MB)

