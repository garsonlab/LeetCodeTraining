/*
 * @lc app=leetcode id=999 lang=csharp
 *
 * [999] Available Captures for Rook
 *
 * https://leetcode.com/problems/available-captures-for-rook/description/
 *
 * algorithms
 * Easy (67.34%)
 * Total Accepted:    9.6K
 * Total Submissions: 14.3K
 * Testcase Example:  '[[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]'
 *
 * On an 8 x 8 chessboard, there is one white rook.  There also may be empty
 * squares, white bishops, and black pawns.  These are given as characters 'R',
 * '.', 'B', and 'p' respectively. Uppercase characters represent white pieces,
 * and lowercase characters represent black pieces.
 * 
 * The rook moves as in the rules of Chess: it chooses one of four cardinal
 * directions (north, east, west, and south), then moves in that direction
 * until it chooses to stop, reaches the edge of the board, or captures an
 * opposite colored pawn by moving to the same square it occupies.  Also, rooks
 * cannot move into the same square as other friendly bishops.
 * 
 * Return the number of pawns the rook can capture in one move.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input:
 * [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]
 * Output: 3
 * Explanation: 
 * In this example the rook is able to capture all the pawns.
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input:
 * [[".",".",".",".",".",".",".","."],[".","p","p","p","p","p",".","."],[".","p","p","B","p","p",".","."],[".","p","B","R","B","p",".","."],[".","p","p","B","p","p",".","."],[".","p","p","p","p","p",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]
 * Output: 0
 * Explanation: 
 * Bishops are blocking the rook to capture any pawn.
 * 
 * 
 * Example 3:
 * 
 * 
 * 
 * 
 * Input:
 * [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","p",".",".",".","."],["p","p",".","R",".","p","B","."],[".",".",".",".",".",".",".","."],[".",".",".","B",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."]]
 * Output: 3
 * Explanation: 
 * The rook can capture the pawns at positions b5, d6 and f5.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * board.length == board[i].length == 8
 * board[i][j] is either 'R', '.', 'B', or 'p'
 * There is exactly one cell with board[i][j] == 'R'
 * 
 * 
 */
public class Solution {
    public int NumRookCaptures(char[][] board) {
        int x = 0, y = 0;
        int h = board.Length;
        int w = board[0].Length;

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (board[i][j] == 'R')
                {
                    x = j;
                    y = i;
                    break;
                }
            }
        }

        int count = 0;
        if (x > 0)
        {
            for (int i = x-1; i >= 0; i--)
            {
                if(board[y][i] == 'B')
                    break;
                if (board[y][i] == 'p')
                {
                    count++;
                    break;
                }
            }
        }
        if (x < w)
        {
            for (int i = x + 1; i < w; i++)
            {
                if (board[y][i] == 'B')
                    break;
                if (board[y][i] == 'p')
                {
                    count++;
                    break;
                }
            }
        }

        if (y > 0)
        {
            for (int i = y-1; i >= 0; i--)
            {
                if (board[i][x] == 'B')
                    break;
                if (board[i][x] == 'p')
                {
                    count++;
                    break;
                }
            }
        }
        if (y < h)
        {
            for (int i = y + 1; i < h; i++)
            {
                if (board[i][x] == 'B')
                    break;
                if (board[i][x] == 'p')
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }
}

// √ Accepted
//   √ 22/22 cases passed (108 ms)
//   √ Your runtime beats 10.36 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (21.8 MB)

