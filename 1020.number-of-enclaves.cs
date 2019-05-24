/*
 * @lc app=leetcode id=1020 lang=csharp
 *
 * [1020] Number of Enclaves

 Given a 2D array A, each cell is 0 (representing sea) or 1 (representing land)

A move consists of walking from one land square 4-directionally to another land square, or off the boundary of the grid.

Return the number of land squares in the grid for which we cannot walk off the boundary of the grid in any number of moves.

 

Example 1:

Input: [[0,0,0,0],[1,0,1,0],[0,1,1,0],[0,0,0,0]]
Output: 3
Explanation: 
There are three 1s that are enclosed by 0s, and one 1 that isn't enclosed because its on the boundary.
Example 2:

Input: [[0,1,1,0],[0,0,1,0],[0,0,1,0],[0,0,0,0]]
Output: 0
Explanation: 
All 1s are either on the boundary or can reach the boundary.
 

Note:

1 <= A.length <= 500
1 <= A[i].length <= 500
0 <= A[i][j] <= 1
All rows have the same size.
 */
public class Solution {
    public int NumEnclaves(int[][] A) {
        int res = 0;
        bool border = false;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A[0].Length; j++)
            {
                if (A[i][j] == 1)
                {
                    border = false;
                    int v = DFSNE(A, i, j, ref border);
                    // Console.WriteLine(v);

                    if (!border)
                        res += v;
                }
            }
        }

        return res;
    }

    private int DFSNE(int[][] A, int x, int y, ref bool border)
    {
        if(x < 0 || x >= A.Length || y < 0 || y >= A[0].Length)
            return 0;

        if(A[x][y] != 1)
            return 0;

        if (x == 0 || x == A.Length - 1 || y == 0 || y >= A[0].Length - 1)
            border = true;
        A[x][y] = 0;

        int res = 1;
        res += DFSNE(A, x - 1, y, ref border);
        res += DFSNE(A, x + 1, y, ref border);
        res += DFSNE(A, x, y - 1, ref border);
        res += DFSNE(A, x, y + 1, ref border);
        // Console.WriteLine(x+", " + y + "," + res);
        return res;
    }

}

// √ Accepted
//   √ 56/56 cases passed (180 ms)
//   √ Your runtime beats 21.3 % of csharp submissions
//   √ Your memory usage beats 42.31 % of csharp submissions (29.6 MB)

