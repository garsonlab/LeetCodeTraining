/*
 * @lc app=leetcode id=1007 lang=csharp
 *
 * [1007] Minimum Domino Rotations For Equal Row
 In a row of dominoes, A[i] and B[i] represent the top and bottom halves of the i-th domino.  (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)

We may rotate the i-th domino, so that A[i] and B[i] swap values.

Return the minimum number of rotations so that all the values in A are the same, or all the values in B are the same.

If it cannot be done, return -1.

 

Example 1:



Input: A = [2,1,2,4,2,2], B = [5,2,6,2,3,2]
Output: 2
Explanation: 
The first figure represents the dominoes as given by A and B: before we do any rotations.
If we rotate the second and fourth dominoes, we can make every value in the top row equal to 2, as indicated by the second figure.
Example 2:

Input: A = [3,5,1,2,3], B = [3,6,3,3,4]
Output: -1
Explanation: 
In this case, it is not possible to rotate the dominoes to make one row of values equal.
 

Note:

1 <= A[i], B[i] <= 6
2 <= A.length == B.length <= 20000
 */
public class Solution {
    public int MinDominoRotations(int[] A, int[] B) {
        int a = A[0], b = B[0];
        int n = A.Length;
        for (int i = 1; i < n; i++)
        {
            if (a > 0 && a != A[i] && a != B[i])
                a = 0;
            if (b > 0 && b != A[i] && b != B[i])
                b = 0;
        }
        int res = -1;
        if (a > 0 || b > 0)
        {
            int suv = a > 0 ? a : b;
            int num1 = 0, num2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (A[i] != suv) num1++;
                if (B[i] != suv) num2++;
            }
            res = Math.Min(num1, num2);
        }
        return res;
    }
}

// √ Accepted
//   √ 84/84 cases passed (268 ms)
//   √ Your runtime beats 29.73 % of csharp submissions
//   √ Your memory usage beats 11.33 % of csharp submissions (42.7 MB)

