/*
 * @lc app=leetcode id=775 lang=csharp
 *
 * [775] Global and Local Inversions

 We have some permutation A of [0, 1, ..., N - 1], where N is the length of A.

The number of (global) inversions is the number of i < j with 0 <= i < j < N and A[i] > A[j].

The number of local inversions is the number of i with 0 <= i < N and A[i] > A[i+1].

Return true if and only if the number of global inversions is equal to the number of local inversions.

Example 1:

Input: A = [1,0,2]
Output: true
Explanation: There is 1 global inversion, and 1 local inversion.
Example 2:

Input: A = [1,2,0]
Output: false
Explanation: There are 2 global inversions, and 1 local inversion.
Note:

A will be a permutation of [0, 1, ..., A.length - 1].
A will have length in range [1, 5000].
The time limit for this problem has been reduced.
 */
public class Solution {
    public bool IsIdealPermutation(int[] A) {
        if (A.Length <= 1) return true;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] == A[i - 1] - 1)
            {
                int tem = A[i];
                A[i] = A[i - 1];
                A[i - 1] = tem;
            }
            else if ((A[i] == A[i - 1] + 1) || (A[i] == A[i - 1] + 2))
            {
                continue;
            }
            else
            {
                return false;
            }

        }
        return true;
    }
}

// √ Accepted
//   √ 208/208 cases passed (156 ms)
//   √ Your runtime beats 44 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (35.4 MB)

