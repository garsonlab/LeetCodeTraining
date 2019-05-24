/*
 * @lc app=leetcode id=1034 lang=csharp
 *
 * [1034] Coloring A Border

 Given a 2-dimensional grid of integers, each value in the grid represents the color of the grid square at that location.

Two squares belong to the same connected component if and only if they have the same color and are next to each other in any of the 4 directions.

The border of a connected component is all the squares in the connected component that are either 4-directionally adjacent to a square not in the component, or on the boundary of the grid (the first or last row or column).

Given a square at location (r0, c0) in the grid and a color, color the border of the connected component of that square with the given color, and return the final grid.

 

Example 1:

Input: grid = [[1,1],[1,2]], r0 = 0, c0 = 0, color = 3
Output: [[3, 3], [3, 2]]
Example 2:

Input: grid = [[1,2,2],[2,3,2]], r0 = 0, c0 = 1, color = 3
Output: [[1, 3, 3], [2, 3, 3]]
Example 3:

Input: grid = [[1,1,1],[1,1,1],[1,1,1]], r0 = 1, c0 = 1, color = 2
Output: [[2, 2, 2], [2, 1, 2], [2, 2, 2]]
 

Note:

1 <= grid.length <= 50
1 <= grid[0].length <= 50
1 <= grid[i][j] <= 1000
0 <= r0 < grid.length
0 <= c0 < grid[0].length
1 <= color <= 1000
 */
public class Solution {
    public int[][] ColorBorder(int[][] grid, int r0, int c0, int color) {
        Queue<int[]> queue = new Queue<int[]>();
        bool[,] visit = new bool[grid.Length,grid[0].Length];
        int initColor = grid[r0][c0];
        visit[r0,c0] = true;
        queue.Enqueue(new int[] { r0, c0 });
        int[][] dirs = new int[][] { new []{ 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };
        while (queue.Count > 0)
        {
            int[] point = queue.Dequeue();
            int x = point[0], y = point[1];
            if (inBorder(grid, x, y))
                grid[x][y] = color;
            foreach (int[] dir in dirs)
            {
                int nx = x + dir[0], ny = y + dir[1];
                if (nx < 0 || nx >= grid.Length || ny < 0 || ny >= grid[0].Length || visit[nx, ny])
                    continue;
                if (grid[nx][ny] == initColor)
                {
                    queue.Enqueue(new int[] { nx, ny });
                    visit[nx, ny] = true;
                }
                else
                    grid[x][y] = color;
            }
        }
        return grid;
    }

    public bool inBorder(int[][] grid, int r, int c)
    {
        return r == 0 || c == 0 || r == grid.Length - 1 || c == grid[0].Length - 1;
    }

}

// √ Accepted
//   √ 154/154 cases passed (292 ms)
//   √ Your runtime beats 34.21 % of csharp submissions
//   √ Your memory usage beats 51.06 % of csharp submissions (31.4 MB)

