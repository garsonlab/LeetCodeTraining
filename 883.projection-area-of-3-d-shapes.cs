/*
 * @lc app=leetcode id=883 lang=csharp
 *
 * [883] Projection Area of 3D Shapes
 *
 * https://leetcode.com/problems/projection-area-of-3d-shapes/description/
 *
 * algorithms
 * Easy (65.40%)
 * Total Accepted:    16.2K
 * Total Submissions: 24.8K
 * Testcase Example:  '[[2]]'
 *
 * On a N * N grid, we place some 1 * 1 * 1 cubes that are axis-aligned with
 * the x, y, and z axes.
 * 
 * Each value v = grid[i][j] represents a tower of v cubes placed on top of
 * grid cell (i, j).
 * 
 * Now we view the projection of these cubes onto the xy, yz, and zx planes.
 * 
 * A projection is like a shadow, that maps our 3 dimensional figure to a 2
 * dimensional plane. 
 * 
 * Here, we are viewing the "shadow" when looking at the cubes from the top,
 * the front, and the side.
 * 
 * Return the total area of all three
 * projections.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [[2]]
 * Output: 5
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [[1,2],[3,4]]
 * Output: 17
 * Explanation: 
 * Here are the three projections ("shadows") of the shape made with each
 * axis-aligned plane.
 * 
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [[1,0],[0,2]]
 * Output: 8
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: [[1,1,1],[1,0,1],[1,1,1]]
 * Output: 14
 * 
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: [[2,2,2],[2,1,2],[2,2,2]]
 * Output: 21
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= grid.length = grid[0].length <= 50
 * 0 <= grid[i][j] <= 50
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int ProjectionArea(int[][] grid) {
        int area = 0;
        int w = grid.Length;
        int h = grid[0].Length;

        for (int i = 0; i < w; i++)
        {
            int max = grid[i][0];
            for (int j = 0; j < h; j++)
            {
                if (grid[i][j] > 0)
                    area++;

                max = Math.Max(max, grid[i][j]);

                if (i > 0)
                {
                    grid[0][j] = Math.Max(grid[0][j], grid[i][j]);
                }
            }

            area += max;
        }

        for (int j = 0; j < h; j++)
        {
            area += grid[0][j];
        }

        return area;
    }
}

// √ Accepted
//   √ 90/90 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 37.5 % of csharp submissions (23.6 MB)

