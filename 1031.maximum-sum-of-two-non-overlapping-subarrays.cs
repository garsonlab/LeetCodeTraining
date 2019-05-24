/*
 * @lc app=leetcode id=1031 lang=csharp
 *
 * [1031] Maximum Sum of Two Non-Overlapping Subarrays

 Given an array A of non-negative integers, return the maximum sum of elements in two non-overlapping (contiguous) subarrays, which have lengths L and M.  (For clarification, the L-length subarray could occur before or after the M-length subarray.)

Formally, return the largest V for which V = (A[i] + A[i+1] + ... + A[i+L-1]) + (A[j] + A[j+1] + ... + A[j+M-1]) and either:

0 <= i < i + L - 1 < j < j + M - 1 < A.length, or
0 <= j < j + M - 1 < i < i + L - 1 < A.length.
 

Example 1:

Input: A = [0,6,5,2,2,5,1,9,4], L = 1, M = 2
Output: 20
Explanation: One choice of subarrays is [9] with length 1, and [6,5] with length 2.
Example 2:

Input: A = [3,8,1,3,2,1,8,9,0], L = 3, M = 2
Output: 29
Explanation: One choice of subarrays is [3,8,1] with length 3, and [8,9] with length 2.
Example 3:

Input: A = [2,1,5,6,0,9,5,0,3,8], L = 4, M = 3
Output: 31
Explanation: One choice of subarrays is [5,6,0,9] with length 4, and [3,8] with length 3.
 

Note:

L >= 1
M >= 1
L + M <= A.length <= 1000
0 <= A[i] <= 1000
 */
public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        int max = 0;
        int maxL = 0; // L数组的最大值
        int maxM = 0; // M数组的最大值
        /*分类讨论L在M前面和L在M后面的情况*/
        /*L在M前面*/
        for (int i = L; i < A.Length - M + 1; i++)
        {
            maxL = Math.Max(maxL, sumOfSub(A, i - L, i - 1));
            max = Math.Max(max, sumOfSub(A, i, i + M - 1) + maxL);
        }
        /*L在M后面*/
        for (int i = M; i < A.Length - L + 1; i++)
        {
            maxM = Math.Max(maxM, sumOfSub(A, i - M, i - 1));
            max = Math.Max(max, sumOfSub(A, i, i + L - 1) + maxM);
        }
        return max;
    }
    /*计算数组L到R上的和*/
    private int sumOfSub(int[] A, int L, int R)
    {
        int sum = 0;
        for (int i = L; i <= R; ++i)
        {
            sum += A[i];
        }
        return sum;
    }
}

// √ Accepted
//   √ 51/51 cases passed (96 ms)
//   √ Your runtime beats 67.06 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (22.5 MB)

