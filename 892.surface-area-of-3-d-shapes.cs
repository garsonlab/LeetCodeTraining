/*
 * @lc app=leetcode id=892 lang=csharp
 *
 * [892] Surface Area of 3D Shapes
 *
 * https://leetcode.com/problems/surface-area-of-3d-shapes/description/
 *
 * algorithms
 * Easy (55.69%)
 * Total Accepted:    9.8K
 * Total Submissions: 17.7K
 * Testcase Example:  '[[2]]'
 *
 * On a N * N grid, we place some 1 * 1 * 1 cubes.
 * 
 * Each value v = grid[i][j] represents a tower of v cubes placed on top of
 * grid cell (i, j).
 * 
 * Return the total surface area of the resulting shapes.
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
 * Output: 10
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [[1,2],[3,4]]
 * Output: 34
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [[1,0],[0,2]]
 * Output: 16
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: [[1,1,1],[1,0,1],[1,1,1]]
 * Output: 32
 * 
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: [[2,2,2],[2,1,2],[2,2,2]]
 * Output: 46
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= N <= 50
 * 0 <= grid[i][j] <= 50
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int SurfaceArea(int[][] grid) {
        int area = 0;
        int w = grid.Length;
        int h = grid[0].Length;

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                int c = grid[i][j];
                if (c > 0)
                {
                    int u = i > 0 ? grid[i - 1][j] : 0;
                    int d = i < w - 1 ? grid[i + 1][j] : 0;
                    int l = j > 0 ? grid[i][j - 1] : 0;
                    int r = j < h - 1 ? grid[i][j + 1] : 0;

                    area += 2;//ud
                    area += c > u ? c - u : 0;
                    area += c > d ? c - d : 0;
                    area += c > l ? c - l : 0;
                    area += c > r ? c - r : 0;
                }
            }
        }

        return area;
    }
}


// √ Accepted
//   √ 90/90 cases passed (116 ms)
//   √ Your runtime beats 41.67 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (23.6 MB)
