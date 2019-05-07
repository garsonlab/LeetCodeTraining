/*
 * @lc app=leetcode id=529 lang=csharp
 *
 * [529] Minesweeper

 Let's play the minesweeper game (Wikipedia, online game)!

You are given a 2D char matrix representing the game board. 'M' represents an unrevealed mine, 'E' represents an unrevealed empty square, 'B' represents a revealed blank square that has no adjacent (above, below, left, right, and all 4 diagonals) mines, digit ('1' to '8') represents how many mines are adjacent to this revealed square, and finally 'X' represents a revealed mine.

Now given the next click position (row and column indices) among all the unrevealed squares ('M' or 'E'), return the board after revealing this position according to the following rules:

If a mine ('M') is revealed, then the game is over - change it to 'X'.
If an empty square ('E') with no adjacent mines is revealed, then change it to revealed blank ('B') and all of its adjacent unrevealed squares should be revealed recursively.
If an empty square ('E') with at least one adjacent mine is revealed, then change it to a digit ('1' to '8') representing the number of adjacent mines.
Return the board when no more squares will be revealed.
 

Example 1:

Input: 

[['E', 'E', 'E', 'E', 'E'],
 ['E', 'E', 'M', 'E', 'E'],
 ['E', 'E', 'E', 'E', 'E'],
 ['E', 'E', 'E', 'E', 'E']]

Click : [3,0]

Output: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'M', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Explanation:

Example 2:

Input: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'M', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Click : [1,2]

Output: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'X', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Explanation:

 

Note:

The range of the input matrix's height and width is [1,50].
The click position will only be an unrevealed square ('M' or 'E'), which also means the input board contains at least one clickable square.
The input board won't be a stage when game is over (some mines have been revealed).
For simplicity, not mentioned rules should be ignored in this problem. For example, you don't need to reveal all the unrevealed mines when the game is over, consider any cases that you will win the game or flag any squares.
 */
public class Solution {

    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        int height = board.Length, width = board[0].Length, row = click[0], col = click[1];
        if (board[row][col] == 'M')
        {
            board[row][col] = 'X';
        }
        else
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    int r = row + i, c = col + j;
                    if (r < 0 || r >= height || c < 0 || c >= width)
                    {
                        continue;
                    }
                    if (board[r][c] == 'M')
                    {
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                board[row][col] = (char)(count + '0');
            }
            else
            {
                board[row][col] = 'B';
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        int r = row + i, c = col + j;
                        if (r < 0 || r >= height || c < 0 || c >= width)
                        {
                            continue;
                        }
                        if (board[r][c] == 'E')
                        {
                            UpdateBoard(board, new[] {r, c});
                        }
                    }
                }
            }
        }
        return board;
    }



    public char[][] UpdateBoard_ERR(char[][] board, int[] click)
    {
        int m = board.Length;
        int n = board[0].Length;

        int x = click[0], y = click[1];

        char c = board[x][y];
        if (c == 'M')
        {
            board[x][y] = 'X';
        }
        else if (c == 'E')
        {
            int mc = GetMCount(board, x, y);

            if (mc > 0)
            {
                board[x][y] = (char) (mc + '0');
            }
            else
            {
                DFSBoard(board, x, y);
            }
        }
        return board;
    }

    private int GetMCount(char[][] board, int x, int y)
    {
        int mc = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            if (i < 0 || i >= board.Length)
                continue;
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (j < 0 || j >= board[0].Length)
                    continue;

                if(i == x && j == y)
                    continue;

                if (board[i][j] == 'M' || board[i][j] == 'X')
                    mc++;
            }
        }

        return mc;
    }

    private void DFSBoard(char[][] board, int x, int y)
    {
        if(x < 0 || x >= board.Length || y < 0 || y >= board[0].Length)
            return;

        if(board[x][y] != 'E')
            return;

        int mc = GetMCount(board, x, y);
        if (mc > 0)
        {
            board[x][y] = (char) (mc + '0');
            return;
        }
        board[x][y] = 'B';
        DFSBoard(board, x - 1, y);
        DFSBoard(board, x + 1, y);
        DFSBoard(board, x, y - 1);
        DFSBoard(board, x, y + 1);
    }


}

// √ Accepted
//   √ 54/54 cases passed (380 ms)
//   √ Your runtime beats 12 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (34.8 MB)

