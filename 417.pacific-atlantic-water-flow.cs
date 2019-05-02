/*
 * @lc app=leetcode id=417 lang=csharp
 *
 * [417] Pacific Atlantic Water Flow


 Given an m x n matrix of non-negative integers representing the height of each unit cell in a continent, the "Pacific ocean" touches the left and top edges of the matrix and the "Atlantic ocean" touches the right and bottom edges.

Water can only flow in four directions (up, down, left, or right) from a cell to another one with height equal or lower.

Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.

Note:
The order of returned grid coordinates does not matter.
Both m and n are less than 150.
Example:

Given the following 5x5 matrix:

  Pacific ~   ~   ~   ~   ~ 
       ~  1   2   2   3  (5) *
       ~  3   2   3  (4) (4) *
       ~  2   4  (5)  3   1  *
       ~ (6) (7)  1   4   5  *
       ~ (5)  1   1   2   4  *
          *   *   *   *   * Atlantic

Return:

[[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (positions with parentheses in above matrix).
 */
public class Solution {
    public IList<int[]> PacificAtlantic(int[][] matrix) {
        IList<int[]> res = new List<int[]>();
        if(matrix.Length == 0 || matrix[0].Length == 0)
            return res;

        bool toP, toA;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                toP = false;
                toA = false;

                DFS(matrix, i, j, ref toP, ref toA, int.MaxValue);

                if(toP && toA)
                    res.Add(new []{i, j});
            }
        }
        return res;
    }

    private void DFS(int[][] matrix, int x, int y, ref bool toP, ref bool toA, int preHeight)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        if(x < 0 || y < 0 || x >= m || y >= n || matrix[x][y] == -1)
            return;
        
        if(matrix[x][y] > preHeight)
            return;
        
        if(x == 0 || y == 0)
            toP = true;
        if(x == m-1 || y == n-1)
            toA = true;

        if(toP && toA)
            return;
        
        int curHeight = matrix[x][y];
        matrix[x][y] = -1;//mark visited
        DFS(matrix, x-1, y, ref toP, ref toA, curHeight);
        DFS(matrix, x+1, y, ref toP, ref toA, curHeight);
        DFS(matrix, x, y-1, ref toP, ref toA, curHeight);
        DFS(matrix, x, y+1, ref toP, ref toA, curHeight);
        matrix[x][y] = curHeight;
    }
}

// √ Accepted
//   √ 113/113 cases passed (540 ms)
//   √ Your runtime beats 10.26 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (32.2 MB)

