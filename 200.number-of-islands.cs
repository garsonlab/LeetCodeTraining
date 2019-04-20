/*
 * @lc app=leetcode id=200 lang=csharp
 *
 * [200] Number of Islands
 *
 * https://leetcode.com/problems/number-of-islands/description/
 *
 * algorithms
 * Medium (40.91%)
 * Total Accepted:    333.6K
 * Total Submissions: 813.2K
 * Testcase Example:  '[["1","1","1","1","0"],["1","1","0","1","0"],["1","1","0","0","0"],["0","0","0","0","0"]]'
 *
 * Given a 2d grid map of '1's (land) and '0's (water), count the number of
 * islands. An island is surrounded by water and is formed by connecting
 * adjacent lands horizontally or vertically. You may assume all four edges of
 * the grid are all surrounded by water.
 * 
 * Example 1:
 * 
 * 
 * Input:
 * 11110
 * 11010
 * 11000
 * 00000
 * 
 * Output: 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input:
 * 11000
 * 11000
 * 00100
 * 00011
 * 
 * Output: 3
 * 
 */
public class Solution {
    public int NumIslands(char[][] grid)
    {
        int m = grid.Length;
        if (m == 0)
            return 0;
        int n = grid[0].Length;
        if (n == 0)
            return 0;

        int count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '1')
                {
                    count++;
                    DFSIsland(ref grid, j, i);
                }
            }
        }

        return count;
    }
    
    private void DFSIsland(ref char[][] grid, int x, int y)
    {
        if (x < 0 || x >= grid[0].Length)
            return;
        if (y < 0 || y >= grid.Length)
            return;

        if (grid[y][x] != '1')
            return;

        grid[y][x] = '*';

        DFSIsland(ref grid, x - 1, y);
        DFSIsland(ref grid, x + 1, y);
        DFSIsland(ref grid, x, y + 1);
        DFSIsland(ref grid, x, y - 1);
    }

}

// √ Accepted
//   √ 47/47 cases passed (104 ms)
//   √ Your runtime beats 99.92 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (25.7 MB)

