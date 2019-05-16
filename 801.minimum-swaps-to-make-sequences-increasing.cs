/*
 * @lc app=leetcode id=801 lang=csharp
 *
 * [801] Minimum Swaps To Make Sequences Increasing

 We have two integer sequences A and B of the same non-zero length.

We are allowed to swap elements A[i] and B[i].  Note that both elements are in the same index position in their respective sequences.

At the end of some number of swaps, A and B are both strictly increasing.  (A sequence is strictly increasing if and only if A[0] < A[1] < A[2] < ... < A[A.length - 1].)

Given A and B, return the minimum number of swaps to make both sequences strictly increasing.  It is guaranteed that the given input always makes it possible.

Example:
Input: A = [1,3,5,4], B = [1,2,3,7]
Output: 1
Explanation: 
Swap A[3] and B[3].  Then the sequences are:
A = [1, 3, 5, 7] and B = [1, 2, 3, 4]
which are both strictly increasing.
Note:

A, B are arrays with the same length, and that length will be in the range [1, 1000].
A[i], B[i] are integer values in the range [0, 2000].
 */
public class Solution {
    public int MinSwap(int[] A, int[] B) {
        int[] cost = new[] {0, 1};
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[i - 1] && B[i] > B[i - 1])
            {
                if (A[i] > B[i - 1] && B[i] > A[i - 1])
                {
                    cost[0] = Math.Min(cost[0], cost[1]);
                    cost[1] = cost[0] + 1;
                }
                else
                {
                    cost[1]++;
                }
            }
            else
            {
                int tem = cost[0];
                cost[0] = cost[1];
                cost[1] = tem + 1;
            }
        }

        return Math.Min(cost[0], cost[1]);
    }
// dp[i][0], dp[i][1]第i个位置不交换/交换，从0-i序列的最小交换次数。 dp[i][0] = min(dp[i-1][0], dp[i-1][1]) dp[i][1] = min(dp[i-1][0], dp[i-1][1]) + 1
            /*
        int[,] dp = new int[A.Length, 2];
        dp[A.Length - 1,0] = 0;
        dp[A.Length - 1,1] = 1;
        //避免后效性,从尾部开始计算
        for (int i = A.Length - 2; i >= 0; i--)
        {
            //只有4种情况
            //-----------------
            //A[i]  A[i + 1]
            //B[i]  B[i + 1]
            //-----------------
            //A[i]  B[i + 1]
            //B[i]  A[i + 1]
            //-----------------
            //B[i]  A[i + 1]
            //A[i]  B[i + 1]
            //-----------------
            //B[i]  B[i + 1]
            //A[i]  A[i + 1] 
            int min = int.MaxValue;
            if (A[i] < A[i + 1] && B[i] < B[i + 1])
            {
                min = dp[i + 1,0];
            }
            if (A[i] < B[i + 1] && B[i] < A[i + 1])
            {
                min = Math.Min(min, dp[i + 1,1]);
            }
            dp[i,0] = min;
            min = int.MaxValue;
            if (B[i] < A[i + 1] && A[i] < B[i + 1])
            {
                min = dp[i + 1,0] + 1;
            }

            if (B[i] < B[i + 1] && A[i] < A[i + 1])
            {
                min = Math.Min(min, dp[i + 1,1] + 1);
            }
            dp[i,1] = min;
        }
        return Math.Min(dp[0,0], dp[0,1]);*/
}

// √ Accepted
//   √ 102/102 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 18.18 % of csharp submissions (24.6 MB)

