/*
 * @lc app=leetcode id=130 lang=csharp
 *
 * [130] Surrounded Regions
 *
 * https://leetcode.com/problems/surrounded-regions/description/
 *
 * algorithms
 * Medium (22.46%)
 * Total Accepted:    139.7K
 * Total Submissions: 621K
 * Testcase Example:  '[["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]'
 *
 * Given a 2D board containing 'X' and 'O' (the letter O), capture all regions
 * surrounded by 'X'.
 * 
 * A region is captured by flipping all 'O's into 'X's in that surrounded
 * region.
 * 
 * Example:
 * 
 * 
 * X X X X
 * X O O X
 * X X O X
 * X O X X
 * 
 * 
 * After running your function, the board should be:
 * 
 * 
 * X X X X
 * X X X X
 * X X X X
 * X O X X
 * 
 * 
 * Explanation:
 * 
 * Surrounded regions shouldn’t be on the border, which means that any 'O' on
 * the border of the board are not flipped to 'X'. Any 'O' that is not on the
 * border and it is not connected to an 'O' on the border will be flipped to
 * 'X'. Two cells are connected if they are adjacent cells connected
 * horizontally or vertically.
 * 
 */
public class Solution {
    public void Solve(char[][] board)
    {
        int m = board.Length;
        if (m <= 2)
            return;
        int n = board[0].Length;
        if(n <= 2)
            return;

        for (int i = 0; i < m; i++)
        {
            if (board[i][0] == 'O')
            {
                DFSSolve(ref board, 0, i);
            }

            if (board[i][n - 1] == 'O')
            {
                DFSSolve(ref board, n - 1, i);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (board[0][i] == 'O')
            {
                DFSSolve(ref board, i, 0);
            }

            if (board[m - 1][i] == 'O')
            {
                DFSSolve(ref board, i, m - 1);
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == '*')
                    board[i][j] = 'O';
                else if (board[i][j] == 'O')
                    board[i][j] = 'X';
            }
        }
    }

    private void DFSSolve(ref char[][] board, int x, int y)
    {
        if (x < 0 || x >= board[0].Length)
            return;
        if(y < 0 || y >= board.Length)
            return;
        
        if(board[y][x] != 'O')
            return;

        board[y][x] = '*';

        DFSSolve(ref board, x - 1, y);
        DFSSolve(ref board, x + 1, y);
        DFSSolve(ref board, x, y + 1);
        DFSSolve(ref board, x, y - 1);
    }

}

// √ Accepted
//   √ 59/59 cases passed (324 ms)
//   √ Your runtime beats 43.71 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (32.5 MB)

