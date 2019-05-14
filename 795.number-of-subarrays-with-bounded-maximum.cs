/*
 * @lc app=leetcode id=795 lang=csharp
 *
 * [795] Number of Subarrays with Bounded Maximum

 We are given an array A of positive integers, and two positive integers L and R (L <= R).

Return the number of (contiguous, non-empty) subarrays such that the value of the maximum array element in that subarray is at least L and at most R.

Example :
Input: 
A = [2, 1, 4, 3]
L = 2
R = 3
Output: 3
Explanation: There are three subarrays that meet the requirements: [2], [2, 1], [3].
Note:

L, R  and A[i] will be an integer in the range [0, 10^9].
The length of A will be in the range of [1, 50000].
 */
public class Solution {
    public int NumSubarrayBoundedMax(int[] A, int L, int R) {
        int res = 0, len = A.Length;
        for (int i = 0; i < len; i++)
        {
            if (A[i] > R) continue; //类似于剪枝
            int curMax = int.MinValue;
            for (int j = i; j < len; j++)
            {
                curMax = Math.Max(curMax, A[j]);
                if (curMax > R) break;//当前以i为起点的子数组都不行，剪枝
                if (curMax >= L) res += 1;
            }
        }
        return res;
    }
}

// √ Accepted
//   √ 43/43 cases passed (152 ms)
//   √ Your runtime beats 31.03 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (31.4 MB)

