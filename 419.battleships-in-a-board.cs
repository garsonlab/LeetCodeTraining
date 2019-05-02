/*
 * @lc app=leetcode id=419 lang=csharp
 *
 * [419] Battleships in a Board

 Given an 2D board, count how many battleships are in it. The battleships are represented with 'X's, empty slots are represented with '.'s. You may assume the following rules:
You receive a valid board, made of only battleships or empty slots.
Battleships can only be placed horizontally or vertically. In other words, they can only be made of the shape 1xN (1 row, N columns) or Nx1 (N rows, 1 column), where N can be of any size.
At least one horizontal or vertical cell separates between two battleships - there are no adjacent battleships.
Example:
X..X
...X
...X
In the above board there are 2 battleships.
Invalid Example:
...X
XXXX
...X
This is an invalid board that you will not receive - as battleships will always have a cell separating between them.
Follow up:
Could you do it in one-pass, using only O(1) extra memory and without modifying the value of the board?
 */
public class Solution {
    public int CountBattleships(char[][] board) {
        int m = board.Length;
        if(m <= 0)
            return 0;
        int n = board[0].Length;
        if(n <= 0)
            return 0;

        int res = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(board[i][j] == 'X')
                {
                    int b = 1;
                    if(i > 0 && board[i-1][j] == 'X')
                        b = 0;
                    if(j > 0 && board[i][j-1] == 'X')
                        b = 0;
                    
                    res += b;
                }
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 28/28 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (23.7 MB)

