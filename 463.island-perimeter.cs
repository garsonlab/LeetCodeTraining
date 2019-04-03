/*
 * @lc app=leetcode id=463 lang=csharp
 *
 * [463] Island Perimeter
 *
 * https://leetcode.com/problems/island-perimeter/description/
 *
 * algorithms
 * Easy (60.44%)
 * Total Accepted:    126.6K
 * Total Submissions: 209.2K
 * Testcase Example:  '[[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]'
 *
 * You are given a map in form of a two-dimensional integer grid where 1
 * represents land and 0 represents water.
 * 
 * Grid cells are connected horizontally/vertically (not diagonally). The grid
 * is completely surrounded by water, and there is exactly one island (i.e.,
 * one or more connected land cells).
 * 
 * The island doesn't have "lakes" (water inside that isn't connected to the
 * water around the island). One cell is a square with side length 1. The grid
 * is rectangular, width and height don't exceed 100. Determine the perimeter
 * of the island.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Input:
 * [[0,1,0,0],
 * ⁠[1,1,1,0],
 * ⁠[0,1,0,0],
 * ⁠[1,1,0,0]]
 * 
 * Output: 16
 * 
 * Explanation: The perimeter is the 16 yellow stripes in the image below:
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int IslandPerimeter(int[][] grid) {
        if (grid.Length == 0)
            return 0;

        int perimeter = 0;
        int width = grid.Length;
        int height = grid[0].Length;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(grid[i][j] == 0)
                    continue;

                if (i == 0 || grid[i - 1][j] == 0)
                    perimeter++;
                if (i == width - 1 || grid[i + 1][j] == 0)
                    perimeter++;

                if (j == 0 || grid[i][j - 1] == 0)
                    perimeter++;
                if (j == height - 1 || grid[i][j + 1] == 0)
                    perimeter++;
            }
        }

        return perimeter;
    }
}

// √ Accepted
//   √ 5833/5833 cases passed (204 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (27 MB)

