/*
 * @lc app=leetcode id=54 lang=csharp
 *
 * [54] Spiral Matrix
 *
 * https://leetcode.com/problems/spiral-matrix/description/
 *
 * algorithms
 * Medium (30.03%)
 * Total Accepted:    222.5K
 * Total Submissions: 740.1K
 * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
 *
 * Given a matrix of m x n elements (m rows, n columns), return all elements of
 * the matrix in spiral order.
 * 
 * Example 1:
 * 
 * 
 * Input:
 * [
 * ⁠[ 1, 2, 3 ],
 * ⁠[ 4, 5, 6 ],
 * ⁠[ 7, 8, 9 ]
 * ]
 * Output: [1,2,3,6,9,8,7,4,5]
 * 
 * 
 * Example 2:
 * 
 * Input:
 * [
 * ⁠ [1, 2, 3, 4],
 * ⁠ [5, 6, 7, 8],
 * ⁠ [9,10,11,12]
 * ]
 * Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 * 
 */
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> list = new List<int>();
        int m = matrix.Length;
        if (m == 0)
            return list;
        if (m == 1)
        {
            list.AddRange(matrix[0]);
            return list;
        }
        int n = matrix[0].Length;

        int l = (Math.Min(m, n) + 1) / 2;
        int row = 0, col = 0;
        for (int i = 0; i < l; i++)
        {
            int len1 = m - i;
            int len2 = n - i;
            for (col = i; row < len1 && col < len2; col++)
            {
                list.Add(matrix[row][col]);
            }
            col--;
            for (row = i + 1; row < len1 && col < len2; row++)
            {
                list.Add(matrix[row][col]);
            }
            row--;
            for (col--; col >= i && row > i; col--)
            {
                list.Add(matrix[row][col]);
            }
            col++;
            for (row--; row > i && col < len2 - 1; row--)
            {
                list.Add(matrix[row][col]);
            }
            row++;
        }

        return list;
    }
}

// √ Accepted
//   √ 22/22 cases passed (244 ms)
//   √ Your runtime beats 95.45 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (27.8 MB)

