/*
 * @lc app=leetcode id=542 lang=csharp
 *
 * [542] 01 Matrix

 Given a matrix consists of 0 and 1, find the distance of the nearest 0 for each cell.

The distance between two adjacent cells is 1.

 

Example 1:

Input:
[[0,0,0],
 [0,1,0],
 [0,0,0]]

Output:
[[0,0,0],
 [0,1,0],
 [0,0,0]]
Example 2:

Input:
[[0,0,0],
 [0,1,0],
 [1,1,1]]

Output:
[[0,0,0],
 [0,1,0],
 [1,2,1]]
 

Note:

The number of elements of the given matrix will not exceed 10,000.
There are at least one 0 in the given matrix.
The cells are adjacent in only four directions: up, down, left and right.
 */
public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        int row = matrix.Length;
        int col = matrix[0].Length;
        // 第一次遍历，正向遍历，根据相邻左元素和上元素得出当前元素的对应结果
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i][j] == 1)
                {
                    matrix[i][j] = row + col;
                }
                if (i > 0)
                {
                    matrix[i][j] = Math.Min(matrix[i][j], matrix[i - 1][j] + 1);
                }
                if (j > 0)
                {
                    matrix[i][j] = Math.Min(matrix[i][j], matrix[i][j - 1] + 1);
                }
            }
        }
        // 第二次遍历，反向遍历，根据相邻右元素和下元素及当前元素的结果得出最终结果
        for (int i = row - 1; i >= 0; i--)
        {
            for (int j = col - 1; j >= 0; j--)
            {
                if (i < row - 1)
                {
                    matrix[i][j] = Math.Min(matrix[i][j], matrix[i + 1][j] + 1);
                }
                if (j < col - 1)
                {
                    matrix[i][j] = Math.Min(matrix[i][j], matrix[i][j + 1] + 1);
                }
            }
        }
        return matrix;
    }
}


// √ Accepted
//   √ 48/48 cases passed (372 ms)
//   √ Your runtime beats 59.71 % of csharp submissions
//   √ Your memory usage beats 89.47 % of csharp submissions (37.5 MB)
