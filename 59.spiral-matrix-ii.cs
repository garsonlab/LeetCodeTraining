/*
 * @lc app=leetcode id=59 lang=csharp
 *
 * [59] Spiral Matrix II
 *
 * https://leetcode.com/problems/spiral-matrix-ii/description/
 *
 * algorithms
 * Medium (45.95%)
 * Total Accepted:    132.2K
 * Total Submissions: 287.4K
 * Testcase Example:  '3'
 *
 * Given a positive integer n, generate a square matrix filled with elements
 * from 1 to n^2 in spiral order.
 * 
 * Example:
 * 
 * 
 * Input: 3
 * Output:
 * [
 * ⁠[ 1, 2, 3 ],
 * ⁠[ 8, 9, 4 ],
 * ⁠[ 7, 6, 5 ]
 * ]
 * 
 * 
 */
public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] matrix = new int[n][];
        if (n <= 0)
            return matrix;
        if (n == 1)
        {
            matrix[0] = new[] {1};
            return matrix;
        }

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        int val = 0;

        int l = (n + 1) / 2;
        int row = 0, col = 0;
        for (int i = 0; i < l; i++)
        {
            int len = n - i;
            for (col = i; row < len && col < len; col++)
            {
                matrix[row][col] = ++val;
            }
            col--;
            for (row = i + 1; row < len && col < len; row++)
            {
                matrix[row][col] = ++val;
            }
            row--;
            for (col--; col >= i && row > i; col--)
            {
                matrix[row][col] = ++val;
            }
            col++;
            for (row--; row > i && col < len - 1; row--)
            {
                matrix[row][col] = ++val;
            }
            row++;
        }

        return matrix;
    }
}

// √ Accepted
//   √ 20/20 cases passed (216 ms)
//   √ Your runtime beats 24.1 % of csharp submissions
//   √ Your memory usage beats 7.69 % of csharp submissions (23.4 MB)

