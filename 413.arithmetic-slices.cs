/*
 * @lc app=leetcode id=413 lang=csharp
 *
 * [413] Arithmetic Slices

 A sequence of number is called arithmetic if it consists of at least three elements and if the difference between any two consecutive elements is the same.

For example, these are arithmetic sequence:

1, 3, 5, 7, 9
7, 7, 7, 7
3, -1, -5, -9
The following sequence is not arithmetic.

1, 1, 2, 5, 7

A zero-indexed array A consisting of N numbers is given. A slice of that array is any pair of integers (P, Q) such that 0 <= P < Q < N.

A slice (P, Q) of array A is called arithmetic if the sequence:
A[P], A[p + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.

The function should return the number of arithmetic slices in the array A.


Example:

A = [1, 2, 3, 4]

return: 3, for 3 arithmetic slices in A: [1, 2, 3], [2, 3, 4] and [1, 2, 3, 4] itself.
 */
public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        if(A.Length < 3)
            return 0;
        
        int res = 0;
        
        int num = 2;
        int offset = A[1] - A[0];
        for (int i = 2; i < A.Length; i++)
        {
            if(A[i] - A[i-1] == offset)
                num++;
            else
            {
                if(num == 3)
                    res += 1;
                else if(num > 3)
                    res += (num-2)*(num-1)/2;

                offset = A[i] - A[i-1];
                num = 2;
            }
        }

        if(num == 3)
            res += 1;
        else if(num > 3)
            res += (num-2)*(num-1)/2;
        
        return res;
    }
}

// √ Accepted
//   √ 15/15 cases passed (88 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 55.56 % of csharp submissions (21.7 MB)

