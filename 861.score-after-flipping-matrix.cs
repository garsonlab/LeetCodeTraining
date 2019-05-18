/*
 * @lc app=leetcode id=861 lang=csharp
 *
 * [861] Score After Flipping Matrix

 We have a two dimensional matrix A where each value is 0 or 1.

A move consists of choosing any row or column, and toggling each value in that row or column: changing all 0s to 1s, and all 1s to 0s.

After making any number of moves, every row of this matrix is interpreted as a binary number, and the score of the matrix is the sum of these numbers.

Return the highest possible score.

 

Example 1:

Input: [[0,0,1,1],[1,0,1,0],[1,1,0,0]]
Output: 39
Explanation:
Toggled to [[1,1,1,1],[1,0,0,1],[1,1,1,1]].
0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39
 

Note:

1 <= A.length <= 20
1 <= A[0].length <= 20
A[i][j] is 0 or 1.
 */
public class Solution {
    public int MatrixScore(int[][] A) {
        foreach (var i in A)
        {
            if(i[0] != 1)
                FlipRow(i);
        }

        int len = A[0].Length;
        for (int i = 0; i < len; i++)
        {
            int num = 0;
            foreach (var row in A)
            {
                if (row[i] == 1)
                    num++;
            }
            if(num < A.Length-num)
                FlipCol(A, i);
        }

        int sum = 0;
        foreach (var row in A)
        {
            int n = 1;
            for (int i = 1; i < len; i++)
            {
                n = n * 2 + row[i];
            }

            sum += n;
        }

        return sum;
    }

    private void FlipRow(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 1 - nums[i];
        }
    }

    private void FlipCol(int[][] nums, int col)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i][col] = 1 - nums[i][col];
        }
    }
}

// √ Accepted
//   √ 80/80 cases passed (144 ms)
//   √ Your runtime beats 7.55 % of csharp submissions
//   √ Your memory usage beats 30.23 % of csharp submissions (22.3 MB)

