/*
 * @lc app=leetcode id=63 lang=csharp
 *
 * [63] Unique Paths II
 *
 * https://leetcode.com/problems/unique-paths-ii/description/
 *
 * algorithms
 * Medium (33.32%)
 * Total Accepted:    192.8K
 * Total Submissions: 578.5K
 * Testcase Example:  '[[0,0,0],[0,1,0],[0,0,0]]'
 *
 * A robot is located at the top-left corner of a m x n grid (marked 'Start' in
 * the diagram below).
 * 
 * The robot can only move either down or right at any point in time. The robot
 * is trying to reach the bottom-right corner of the grid (marked 'Finish' in
 * the diagram below).
 * 
 * Now consider if some obstacles are added to the grids. How many unique paths
 * would there be?
 * 
 * 
 * 
 * An obstacle and empty space is marked as 1 and 0 respectively in the grid.
 * 
 * Note: m and n will be at most 100.
 * 
 * Example 1:
 * 
 * 
 * Input:
 * [
 * [0,0,0],
 * [0,1,0],
 * [0,0,0]
 * ]
 * Output: 2
 * Explanation:
 * There is one obstacle in the middle of the 3x3 grid above.
 * There are two ways to reach the bottom-right corner:
 * 1. Right -> Right -> Down -> Down
 * 2. Down -> Down -> Right -> Right
 * 
 * 
 */
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int n = obstacleGrid.Length;
        if (n == 0)
            return 0;
        int m = obstacleGrid[0].Length;
        if (m == 0)
            return 0;
        if (obstacleGrid[0][0] == 1 || obstacleGrid[n-1][m-1] == 1)
            return 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (obstacleGrid[i][j] == 1)
                    obstacleGrid[i][j] = -1;
            }
        }

        obstacleGrid[0][0] = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if(obstacleGrid[i][j] == -1)
                    continue;
                if (i > 0 && obstacleGrid[i - 1][j] != -1)
                    obstacleGrid[i][j] += obstacleGrid[i - 1][j];
                if (j > 0 && obstacleGrid[i][j - 1] != -1)
                    obstacleGrid[i][j] += obstacleGrid[i][j - 1];
            }
        }

        return obstacleGrid[n - 1][m - 1];
    }
}

// √ Accepted
//   √ 43/43 cases passed (92 ms)
//   √ Your runtime beats 99.29 % of csharp submissions
//   √ Your memory usage beats 83.72 % of csharp submissions (22.4 MB)

