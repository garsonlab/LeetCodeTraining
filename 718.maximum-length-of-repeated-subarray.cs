/*
 * @lc app=leetcode id=718 lang=csharp
 *
 * [718] Maximum Length of Repeated Subarray

 Given two integer arrays A and B, return the maximum length of an subarray that appears in both arrays.

Example 1:

Input:
A: [1,2,3,2,1]
B: [3,2,1,4,7]
Output: 3
Explanation: 
The repeated subarray with maximum length is [3, 2, 1].
 

Note:

1 <= len(A), len(B) <= 1000
0 <= A[i], B[i] < 100
 */
public class Solution {
    public int FindLength(int[] A, int[] B) {
        int res = 0;
        int[,] dp = new int[A.Length+1, B.Length+1];
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < B.Length; j++)
            {
                if (A[i] == B[j])
                    dp[i + 1, j + 1] = dp[i, j] + 1;
                res = Math.Max(res, dp[i + 1, j + 1]);
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 54/54 cases passed (224 ms)
//   √ Your runtime beats 66.94 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (45.9 MB)

