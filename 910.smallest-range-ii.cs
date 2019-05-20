/*
 * @lc app=leetcode id=910 lang=csharp
 *
 * [910] Smallest Range II

 Given an array A of integers, for each integer A[i] we need to choose either x = -K or x = K, and add x to A[i] (only once).

After this process, we have some array B.

Return the smallest possible difference between the maximum value of B and the minimum value of B.

 

Example 1:

Input: A = [1], K = 0
Output: 0
Explanation: B = [1]
Example 2:

Input: A = [0,10], K = 2
Output: 6
Explanation: B = [2,8]
Example 3:

Input: A = [1,3,6], K = 3
Output: 3
Explanation: B = [4,6,3]
 

Note:

1 <= A.length <= 10000
0 <= A[i] <= 10000
0 <= K <= 10000
 */
public class Solution {
    public int SmallestRangeII(int[] A, int K) {
        int n = A.Length;
        if (n == 1) return 0;
        
        Array.Sort(A);
        int res = A[n - 1] - A[0];
        for (int i = 0; i < n-1; i++)
        {
            int a = A[i], b = A[i + 1];
            int high = Math.Max(a + K, A[n - 1] - K);
            int low = Math.Min(b - K, A[0] + K);
            res = Math.Min(res, high - low);
        }

        return res;
    }
}

// √ Accepted
//   √ 68/68 cases passed (124 ms)
//   √ Your runtime beats 43.33 % of csharp submissions
//   √ Your memory usage beats 13.04 % of csharp submissions (26.6 MB)

