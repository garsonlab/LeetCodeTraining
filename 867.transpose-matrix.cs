/*
 * @lc app=leetcode id=867 lang=csharp
 *
 * [867] Transpose Matrix
 *
 * https://leetcode.com/problems/transpose-matrix/description/
 *
 * algorithms
 * Easy (63.78%)
 * Total Accepted:    41.1K
 * Total Submissions: 64.4K
 * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
 *
 * Given a matrix A, return the transpose of A.
 * 
 * The transpose of a matrix is the matrix flipped over it's main diagonal,
 * switching the row and column indices of the matrix.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [[1,2,3],[4,5,6],[7,8,9]]
 * Output: [[1,4,7],[2,5,8],[3,6,9]]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [[1,2,3],[4,5,6]]
 * Output: [[1,4],[2,5],[3,6]]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 1000
 * 1 <= A[0].length <= 1000
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int[][] Transpose(int[][] A) {
        int w = A.Length;
        int h = A[0].Length;

        int[][] ret = new int[h][];
        for (int i = 0; i < h; i++)
        {
            ret[i] = new int[w];
        }

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                ret[j][i] = A[i][j];
            }
        }

        return ret;
    }
}

// √ Accepted
//   √ 36/36 cases passed (268 ms)
//   √ Your runtime beats 83.23 % of csharp submissions
//   √ Your memory usage beats 46.15 % of csharp submissions (33.5 MB)

