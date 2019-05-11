/*
 * @lc app=leetcode id=695 lang=csharp
 *
 * [695] Max Area of Island

 Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)

Example 1:

[[0,0,1,0,0,0,0,1,0,0,0,0,0],
 [0,0,0,0,0,0,0,1,1,1,0,0,0],
 [0,1,1,0,1,0,0,0,0,0,0,0,0],
 [0,1,0,0,1,1,0,0,1,0,1,0,0],
 [0,1,0,0,1,1,0,0,1,1,1,0,0],
 [0,0,0,0,0,0,0,0,0,0,1,0,0],
 [0,0,0,0,0,0,0,1,1,1,0,0,0],
 [0,0,0,0,0,0,0,1,1,0,0,0,0]]
Given the above grid, return 6. Note the answer is not 11, because the island must be connected 4-directionally.
Example 2:

[[0,0,0,0,0,0,0,0]]
Given the above grid, return 0.
Note: The length of each dimension in the given grid does not exceed 50.
 */
public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length;
        if (m == 0)
            return 0;
        int n = grid[0].Length;
        if (n == 0)
            return 0;

        int res = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] != 0)
                    res = Math.Max(res, GetArea(grid, m, n, i, j));
            }
        }

        return res;
    }

    private int GetArea(int[][] grid, int m, int n, int i, int j)
    {
        if (i < 0 || i >= m || j < 0 || j >= n)
            return 0;
        if (grid[i][j] == 0)
            return 0;
        
        grid[i][j] = 0;
        int up = GetArea(grid, m, n, i - 1, j);
        int down = GetArea(grid, m, n, i + 1, j);
        int left = GetArea(grid, m, n, i, j - 1);
        int right = GetArea(grid, m, n, i, j + 1);

        return 1 + up + down + left + right;
    }
}

// √ Accepted
//   √ 726/726 cases passed (112 ms)
//   √ Your runtime beats 83.91 % of csharp submissions
//   √ Your memory usage beats 30.77 % of csharp submissions (26.1 MB)

