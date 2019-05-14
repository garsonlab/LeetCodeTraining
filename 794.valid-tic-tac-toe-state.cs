/*
 * @lc app=leetcode id=794 lang=csharp
 *
 * [794] Valid Tic-Tac-Toe State

 A Tic-Tac-Toe board is given as a string array board. Return True if and only if it is possible to reach this board position during the course of a valid tic-tac-toe game.

The board is a 3 x 3 array, and consists of characters " ", "X", and "O".  The " " character represents an empty square.

Here are the rules of Tic-Tac-Toe:

Players take turns placing characters into empty squares (" ").
The first player always places "X" characters, while the second player always places "O" characters.
"X" and "O" characters are always placed into empty squares, never filled ones.
The game ends when there are 3 of the same (non-empty) character filling any row, column, or diagonal.
The game also ends if all squares are non-empty.
No more moves can be played if the game is over.
Example 1:
Input: board = ["O  ", "   ", "   "]
Output: false
Explanation: The first player always plays "X".

Example 2:
Input: board = ["XOX", " X ", "   "]
Output: false
Explanation: Players take turns making moves.

Example 3:
Input: board = ["XXX", "   ", "OOO"]
Output: false

Example 4:
Input: board = ["XOX", "O O", "XOX"]
Output: true
Note:

board is a length-3 array of strings, where each string board[i] has length 3.
Each board[i][j] is a character in the set {" ", "X", "O"}.
 */
public class Solution {
    public bool ValidTicTacToe(string[] board) {
        int count_X = 0;
        int count_O = 0;
        for (int i = 0; i < board.Length; ++i)
        {
            for (int j = 0; j < board[0].Length; ++j)
            {
                if (board[i][j] == 'X') ++count_X;
                if (board[i][j] == 'O') ++count_O;
            }
        }

        if (count_X<count_O || count_X> count_O+1) return false;
        
        if (win(board, 'X') && count_X!=count_O+1) return false;
        if (win(board, 'O') && count_X!=count_O) return false;
        
        return true;
    }

    bool win(string[] board, char ch)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (board[i][0] == ch && board[i][1] == ch && board[i][2] == ch) return true;
            if (board[0][i] == ch && board[1][i] == ch && board[2][i] == ch) return true;
        }
        if (board[0][0] == ch && board[1][1] == ch && board[2][2] == ch) return true;
        if (board[0][2] == ch && board[1][1] == ch && board[2][0] == ch) return true;
        return false;
    }
}


// √ Accepted
//   √ 108/108 cases passed (84 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (22 MB)

