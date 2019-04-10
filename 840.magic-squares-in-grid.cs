/*
 * @lc app=leetcode id=840 lang=csharp
 *
 * [840] Magic Squares In Grid
 *
 * https://leetcode.com/problems/magic-squares-in-grid/description/
 *
 * algorithms
 * Easy (35.10%)
 * Total Accepted:    11.5K
 * Total Submissions: 32.5K
 * Testcase Example:  '[[4,3,8,4],[9,5,1,9],[2,7,6,2]]'
 *
 * A 3 x 3 magic square is a 3 x 3 grid filled with distinct numbers from 1 to
 * 9 such that each row, column, and both diagonals all have the same sum.
 * 
 * Given an grid of integers, how many 3 x 3 "magic square" subgrids are
 * there?  (Each subgrid is contiguous).
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [[4,3,8,4],
 * ⁠       [9,5,1,9],
 * ⁠       [2,7,6,2]]
 * Output: 1
 * Explanation: 
 * The following subgrid is a 3 x 3 magic square:
 * 438
 * 951
 * 276
 * 
 * while this one is not:
 * 384
 * 519
 * 762
 * 
 * In total, there is only one magic square inside the given grid.
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= grid.length <= 10
 * 1 <= grid[0].length <= 10
 * 0 <= grid[i][j] <= 15
 * 
 * 
 */
public class Solution {
   
    public int NumMagicSquaresInside(int[][] grid)
    {
        int w = grid.Length;
        if (w < 3)
            return 0;
        int h = grid[0].Length;
        if (h < 3)
            return 0;

        int num = 0;

        for (int i = 0; i < w-2; i++)
        {
            for (int j = 0; j < h-2; j++)
            {
                num += IsMagic(ref grid, i, j);
            }
        }

        return num;
    }

    private int IsMagic(ref int[][] grid, int x, int y)
    {
        int sum = 0;
        int a = 1;
        for (int i = x; i < x+3; i++)
        {
            int s = 0;
            for (int j = y; j < y+3; j++)
            {
                s += grid[i][j];

                a *= grid[i][j];
            }

            if (i == x)
                sum = s;
            else if (s != sum)
                return 0;
        }

        if (a != 362880)
            return 0;

        for (int i = y; i < y+3; i++)
        {
            int s = 0;
            for (int j = x; j < x+3; j++)
            {
                s += grid[j][i];
            }

            if (s != sum)
                return 0;
        }

        if (grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2] != sum)
            return 0;
        if (grid[x+2][y] + grid[x + 1][y + 1] + grid[x][y + 2] != sum)
            return 0;

        return 1;
    }

}

// √ Accepted
//   √ 91/91 cases passed (92 ms)
//   √ Your runtime beats 97.56 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (22.1 MB)

