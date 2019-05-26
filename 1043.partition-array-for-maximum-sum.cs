/*
 * @lc app=leetcode id=1043 lang=csharp
 *
 * [1043] Partition Array for Maximum Sum

 Given an integer array A, you partition the array into (contiguous) subarrays of length at most K.  After partitioning, each subarray has their values changed to become the maximum value of that subarray.

Return the largest sum of the given array after partitioning.

 

Example 1:

Input: A = [1,15,7,9,2,5,10], K = 3
Output: 84
Explanation: A becomes [15,15,15,9,10,10,10]
 

Note:

1 <= K <= A.length <= 500
0 <= A[i] <= 10^6
 */
public class Solution {
    public int MaxSumAfterPartitioning(int[] A, int K) {
        int[] res = new int[A.Length];
        // for (int i = 0; i < A.Length; i++)
        // {
        //     int s = A[i];
        //     for (int j = 1; j <= K && i-j+1 >= 0; j++)
        //     {
        //         s = Math.Max(s, A[i-j+1]);
        //         res[i] = Math.Max(res[i], ((i-j<0)? 0 : res[i-j]+j*s));
        //     }
        // }

        for (int i = 0; i < A.Length; i++) {
            int domainMax = A[i];
            for (int j = 1; j <= K && i - j + 1 >= 0; j++) {
                domainMax = Math.Max(domainMax, A[i - j + 1]);
                res[i] = Math.Max(res[i], ((i - j < 0)? 0 : res[i - j])  + j * domainMax);
            }
        }
        return res[A.Length-1];
    }
}

// √ Accepted
//   √ 51/51 cases passed (104 ms)
//   √ Your runtime beats 74.58 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.5 MB)

