/*
 * @lc app=leetcode id=304 lang=csharp
 *
 * [304] Range Sum Query 2D - Immutable

 Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

Range Sum Query 2D
The above rectangle (with the red border) is defined by (row1, col1) = (2, 1) and (row2, col2) = (4, 3), which contains sum = 8.

Example:
Given matrix = [
  [3, 0, 1, 4, 2],
  [5, 6, 3, 2, 1],
  [1, 2, 0, 1, 5],
  [4, 1, 0, 1, 7],
  [1, 0, 3, 0, 5]
]

sumRegion(2, 1, 4, 3) -> 8
sumRegion(1, 1, 2, 2) -> 11
sumRegion(1, 2, 2, 4) -> 12
Note:
You may assume that the matrix does not change.
There are many calls to sumRegion function.
You may assume that row1 ≤ row2 and col1 ≤ col2.
 */
public class NumMatrix {

    private int[,] dp;
        public NumMatrix(int[][] matrix)
        {
            int m = matrix.Length, n = 0;
            if(m == 0)
                dp = new int[0, 0];
            else
            {
                n = matrix[0].Length;
                dp = new int[m, n];
            }
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0) dp[i,j] = matrix[i][j];
                    else if (i == 0) dp[i, j] = dp[i, j - 1] + matrix[i][j];
                    else if (j == 0) dp[i, j] = dp[i - 1, j] + matrix[i][j];
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1] - dp[i - 1, j - 1] + matrix[i][j];
                    }
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (row1 > row2) return SumRegion(row2, col1, row1, col2);
            if (col1 > col2) return SumRegion(row1, col2, row2, col1);

            return dp[row2, col2] + (row1 > 0 && col1 > 0 ? dp[row1 - 1, col1 - 1] : 0) -
                   (row1 > 0 ? dp[row1 - 1, col2] : 0) - (col1 > 0 ? dp[row2, col1 - 1] : 0);
        }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */

//  √ Accepted
//   √ 12/12 cases passed (152 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 91.67 % of csharp submissions (33.6 MB)

