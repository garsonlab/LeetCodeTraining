/*
 * @lc app=leetcode id=978 lang=csharp
 *
 * [978] Longest Turbulent Subarray

 A subarray A[i], A[i+1], ..., A[j] of A is said to be turbulent if and only if:

For i <= k < j, A[k] > A[k+1] when k is odd, and A[k] < A[k+1] when k is even;
OR, for i <= k < j, A[k] > A[k+1] when k is even, and A[k] < A[k+1] when k is odd.
That is, the subarray is turbulent if the comparison sign flips between each adjacent pair of elements in the subarray.

Return the length of a maximum size turbulent subarray of A.

 

Example 1:

Input: [9,4,2,10,7,8,8,1,9]
Output: 5
Explanation: (A[1] > A[2] < A[3] > A[4] < A[5])
Example 2:

Input: [4,8,12,16]
Output: 2
Example 3:

Input: [100]
Output: 1
 

Note:

1 <= A.length <= 40000
0 <= A[i] <= 10^9
 */
public class Solution {
    public int MaxTurbulenceSize(int[] A) {
        int max = 0, cur = 1;
        bool up = true;

        for (int i = 1; i < A.Length; i++)
        {
            if (up)
            {
                if (A[i] > A[i - 1])
                {
                    cur++;
                    up = !up;
                }
                else if(A[i] == A[i-1])
                {
                    max = Math.Max(cur, max);
                    cur = 1;
                }
                else
                {
                    max = Math.Max(cur, max);
                    cur = 2;
                }
            }
            else
            {
                if (A[i] < A[i - 1])
                {
                    cur++;
                    up = !up;
                }
                else if (A[i] == A[i - 1])
                {
                    max = Math.Max(cur, max);
                    cur = 1;
                    up = !up;
                }
                else
                {
                    max = Math.Max(cur, max);
                    cur = 2;
                }
            }
        }

        return A.Length > 0 ? Math.Max(max, cur) : 0;
    }
}

// √ Accepted
//   √ 86/86 cases passed (180 ms)
//   √ Your runtime beats 37.5 % of csharp submissions
//   √ Your memory usage beats 25.33 % of csharp submissions (39 MB)

