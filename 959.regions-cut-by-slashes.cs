/*
 * @lc app=leetcode id=959 lang=csharp
 *
 * [959] Regions Cut By Slashes

 In a N x N grid composed of 1 x 1 squares, each 1 x 1 square consists of a /, \, or blank space.  These characters divide the square into contiguous regions.

(Note that backslash characters are escaped, so a \ is represented as "\\".)

Return the number of regions.

 

Example 1:

Input:
[
  " /",
  "/ "
]
Output: 2
Explanation: The 2x2 grid is as follows:

Example 2:

Input:
[
  " /",
  "  "
]
Output: 1
Explanation: The 2x2 grid is as follows:

Example 3:

Input:
[
  "\\/",
  "/\\"
]
Output: 4
Explanation: (Recall that because \ characters are escaped, "\\/" refers to \/, and "/\\" refers to /\.)
The 2x2 grid is as follows:

Example 4:

Input:
[
  "/\\",
  "\\/"
]
Output: 5
Explanation: (Recall that because \ characters are escaped, "/\\" refers to /\, and "\\/" refers to \/.)
The 2x2 grid is as follows:

Example 5:

Input:
[
  "//",
  "/ "
]
Output: 3
Explanation: The 2x2 grid is as follows:

 

Note:

1 <= grid.length == grid[0].length <= 30
grid[i][j] is either '/', '\', or ' '.
 */
public class Solution {
    
    public int RegionsBySlashes(string[] grid)
    {
        int N = grid.Length;
        if (N == 0)
            return 0;

        int[,] grids = new int[N * 3, N * 3];
        for (int i = 0; i < grid.Length; i++)
        {
            string s = grid[i];
            for (int j = 0; j < N; j++)
            {
                if (s[j] == '\\')
                {
                    grids[i * 3, j * 3] = -1;
                    grids[i * 3 + 1, j * 3 + 1] = -1;
                    grids[i * 3 + 2, j * 3 + 2] = -1;
                }
                else if (s[j] == '/')
                {
                    grids[i * 3, j * 3 + 2] = -1;
                    grids[i * 3 + 1, j * 3 + 1] = -1;
                    grids[i * 3 + 2, j * 3] = -1;
                }
            }
        }

        int res = 0;
        for (int i = 0; i < N*3; i++)
        {
            for (int j = 0; j < N*3; j++)
            {
                if (grids[i, j] == 0)
                {
                    DFSSlash(grids, N*3, i, j, ++res);
                }
            }
        }

        return res;
    }

    private void DFSSlash(int[,] grids, int len, int x, int y, int idx)
    {
        if(x < 0 || x >= len || y < 0 || y >= len)
            return;
        if (grids[x, y] != 0)
            return;

        grids[x, y] = idx;

        DFSSlash(grids, len, x - 1, y, idx);
        DFSSlash(grids, len, x + 1, y, idx);
        DFSSlash(grids, len, x, y - 1, idx);
        DFSSlash(grids, len, x, y + 1, idx);
    }
    
}
// 简化成岛屿问题
// √ Accepted
//   √ 137/137 cases passed (120 ms)
//   √ Your runtime beats 58.62 % of csharp submissions
//   √ Your memory usage beats 53.33 % of csharp submissions (23.7 MB)

