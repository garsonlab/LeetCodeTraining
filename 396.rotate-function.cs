/*
 * @lc app=leetcode id=396 lang=csharp
 *
 * [396] Rotate Function

 Given an array of integers A and let n to be its length.

Assume Bk to be an array obtained by rotating the array A k positions clock-wise, we define a "rotation function" F on A as follow:

F(k) = 0 * Bk[0] + 1 * Bk[1] + ... + (n-1) * Bk[n-1].

Calculate the maximum value of F(0), F(1), ..., F(n-1).

Note:
n is guaranteed to be less than 105.

Example:

A = [4, 3, 2, 6]

F(0) = (0 * 4) + (1 * 3) + (2 * 2) + (3 * 6) = 0 + 3 + 4 + 18 = 25
F(1) = (0 * 6) + (1 * 4) + (2 * 3) + (3 * 2) = 0 + 4 + 6 + 6 = 16
F(2) = (0 * 2) + (1 * 6) + (2 * 4) + (3 * 3) = 0 + 6 + 8 + 9 = 23
F(3) = (0 * 3) + (1 * 2) + (2 * 6) + (3 * 4) = 0 + 2 + 12 + 12 = 26

So the maximum value of F(0), F(1), F(2), F(3) is F(3) = 26.
 */
public class Solution {
    public int MaxRotateFunction(int[] A) {
        int n = A.Length;
        long fk = 0;
        long fk1 = 0;
        long sum = 0;

        foreach (var val in A)
        {
            sum += val;
        }
        for (int i = 0; i < n; i++)
        {
            fk += i * A[i];
        }
        long max = fk;
        for (int k = 0; k < n - 1; k++)
        {

            fk1 = fk - n * (A[n - k - 1]) + sum;
            fk = fk1;
            if (fk > max) max = fk;
        }

        return (int)max;
    }
}

//F(k+1)=F(k) + sum(A) - n * A[-k-1]
// √ Accepted
//   √ 17/17 cases passed (112 ms)
//   √ Your runtime beats 43.24 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (23.5 MB)

