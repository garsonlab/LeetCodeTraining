/*
 * @lc app=leetcode id=64 lang=csharp
 *
 * [64] Minimum Path Sum
 *
 * https://leetcode.com/problems/minimum-path-sum/description/
 *
 * algorithms
 * Medium (46.24%)
 * Total Accepted:    221.1K
 * Total Submissions: 477.6K
 * Testcase Example:  '[[1,3,1],[1,5,1],[4,2,1]]'
 *
 * Given a m x n grid filled with non-negative numbers, find a path from top
 * left to bottom right which minimizes the sum of all numbers along its path.
 * 
 * Note: You can only move either down or right at any point in time.
 * 
 * Example:
 * 
 * 
 * Input:
 * [
 * [1,3,1],
 * ⁠ [1,5,1],
 * ⁠ [4,2,1]
 * ]
 * Output: 7
 * Explanation: Because the path 1→3→1→1→1 minimizes the sum.
 * 
 * 
 */
public class Solution {
    public int MinPathSum(int[][] grid) {
        int n = grid.Length;
        if (n == 0)
            return 0;
        int m = grid[0].Length;
        if (m == 0)
            return 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if(i == 0 && j == 0)
                    continue;

                int u = i > 0 ? grid[i - 1][j] : int.MaxValue;
                int l = j > 0 ? grid[i][j - 1] : int.MaxValue;
                
                grid[i][j] += Math.Min(u, l);
            }
        }

        return grid[n - 1][m - 1];
    }
}

// √ Accepted
//   √ 61/61 cases passed (124 ms)
//   √ Your runtime beats 74.93 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (23.6 MB)

