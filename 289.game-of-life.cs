/*
 * @lc app=leetcode id=289 lang=csharp
 *
 * [289] Game of Life

 According to the Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

Given a board with m by n cells, each cell has an initial state live (1) or dead (0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

Any live cell with fewer than two live neighbors dies, as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by over-population..
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
Write a function to compute the next state (after one update) of the board given its current state. The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously.

Example:

Input: 
[
  [0,1,0],
  [0,0,1],
  [1,1,1],
  [0,0,0]
]
Output: 
[
  [0,0,0],
  [1,0,1],
  [0,1,1],
  [0,1,0]
]
Follow up:

Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
In this question, we represent the board using a 2D array. In principle, the board is infinite, which would cause problems when the active area encroaches the border of the array. How would you address these problems?
 */
public class Solution {
    public void GameOfLife(int[][] board) {
        int m = board.Length;
        if(m <= 0)
            return;
        int n = board[0].Length;
        if(n <= 0)
            return;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int live = 0;
                for (int k = i-1; k <= i+1; k++)
                {
                    if(k < 0 || k >= m)
                        continue;
                    for (int l = j-1; l <= j+1; l++)
                    {
                        if(l < 0 || l >= n)
                            continue;
                        if(k == i && l == j)
                            continue;
                        if (board[k][l]%10 == 1)
                            live++;
                    }
                }

                if(live < 2) { }
                else if (live == 2)
                    board[i][j] = board[i][j] * 11;
                else if (live == 3)
                    board[i][j] += 10;
                else { }
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board[i][j] /= 10;
            }
        }
    }
}

// √ Accepted
//   √ 23/23 cases passed (248 ms)
//   √ Your runtime beats 93.79 % of csharp submissions
//   √ Your memory usage beats 95.45 % of csharp submissions (27.9 MB)

