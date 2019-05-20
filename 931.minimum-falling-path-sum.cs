/*
 * @lc app=leetcode id=931 lang=csharp
 *
 * [931] Minimum Falling Path Sum
 Given a square array of integers A, we want the minimum sum of a falling path through A.

A falling path starts at any element in the first row, and chooses one element from each row.  The next row's choice must be in a column that is different from the previous row's column by at most one.

 

Example 1:

Input: [[1,2,3],[4,5,6],[7,8,9]]
Output: 12
Explanation: 
The possible falling paths are:
[1,4,7], [1,4,8], [1,5,7], [1,5,8], [1,5,9]
[2,4,7], [2,4,8], [2,5,7], [2,5,8], [2,5,9], [2,6,8], [2,6,9]
[3,5,7], [3,5,8], [3,5,9], [3,6,8], [3,6,9]
The falling path with the smallest sum is [1,4,7], so the answer is 12.

 

Note:

1 <= A.length == A[0].length <= 100
-100 <= A[i][j] <= 100
 */
public class Solution {
    public int MinFallingPathSum(int[][] A) {
        int m = A.Length;
        if (m == 0)
            return 0;
        int n = A[0].Length;

        int[] dp = new int[n];
        int[] dp2 = new int[n];
        Array.Copy(A[0], dp, n);

        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int pre = j > 0 ? dp[j - 1] + A[i][j] : int.MaxValue;
                int up = dp[j] + A[i][j];
                int next = j < n - 1 ? dp[j + 1] + A[i][j] : int.MaxValue;

                dp2[j] = Math.Min(pre, up);
                dp2[j] = Math.Min(dp2[j], next);
            }
            Array.Copy(dp2, dp, n);
        }

        int res = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            res = Math.Min(res, dp[i]);
        }

        return res;
    }
}

// √ Accepted
//   √ 46/46 cases passed (124 ms)
//   √ Your runtime beats 23.15 % of csharp submissions
//   √ Your memory usage beats 46.59 % of csharp submissions (24.4 MB)

