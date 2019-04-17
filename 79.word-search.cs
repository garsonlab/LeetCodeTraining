/*
 * @lc app=leetcode id=79 lang=csharp
 *
 * [79] Word Search
 *
 * https://leetcode.com/problems/word-search/description/
 *
 * algorithms
 * Medium (30.82%)
 * Total Accepted:    268.3K
 * Total Submissions: 869.4K
 * Testcase Example:  '[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]\n"ABCCED"'
 *
 * Given a 2D board and a word, find if the word exists in the grid.
 * 
 * The word can be constructed from letters of sequentially adjacent cell,
 * where "adjacent" cells are those horizontally or vertically neighboring. The
 * same letter cell may not be used more than once.
 * 
 * Example:
 * 
 * 
 * board =
 * [
 * ⁠ ['A','B','C','E'],
 * ⁠ ['S','F','C','S'],
 * ⁠ ['A','D','E','E']
 * ]
 * 
 * Given word = "ABCCED", return true.
 * Given word = "SEE", return true.
 * Given word = "ABCB", return false.
 * 
 * 
 */
public class Solution {
    public bool Exist(char[][] board, string word)
    {
        int row = board.Length;
        if (row == 0)
            return false;
        int col = board[0].Length;
        if (col == 0)
            return false;
        if (word.Length == 0)
            return false;
        if (row * col < word.Length)
            return false;

        bool[,] used = new bool[row, col];
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (word[0] == board[i][j])
                {
                    for (int h = 0; h < row; h++)
                    for (int k = 0; k < col; k++)
                        used[h, k] = false;
                    stack.Clear();

                    bool r = SearWordPath(ref board, ref used, stack, j, i, word, 1);
                    if (r)
                        return true;
                }
            }
        }


        return false;
    }

    private bool SearWordPath(ref char[][] board, ref bool[,] used, Stack<char> stack, int x, int y, string word, int idx)
    {
        stack.Push(board[y][x]);
        used[y,x] = true;

        if (stack.Count == word.Length)
        {
            return true;
        }

        if (x > 0 && !used[y,x - 1] && board[y][x - 1] == word[idx])
        {
            bool r = SearWordPath(ref board, ref used, stack, x - 1, y, word, idx + 1);
            if (r)
                return true;
        }

        if (x < board[0].Length - 1 && !used[y,x + 1] && board[y][x + 1] == word[idx])
        {
            bool r = SearWordPath(ref board, ref used, stack, x + 1, y, word, idx + 1);
            if (r)
                return true;
        }

        if (y > 0 && !used[y - 1,x] && board[y - 1][x] == word[idx])
        {
            bool r = SearWordPath(ref board, ref used, stack, x, y-1, word, idx + 1);
            if (r)
                return true;
        }

        if (y < board.Length - 1 && !used[y + 1,x] && board[y + 1][x] == word[idx])
        {
            bool r = SearWordPath(ref board, ref used, stack, x, y + 1, word, idx + 1);
            if (r)
                return true;
        }

        stack.Pop();
        used[y,x] = false;
        return false;
    }

}

// √ Accepted
//   √ 87/87 cases passed (220 ms)
//   √ Your runtime beats 43.39 % of csharp submissions
//   √ Your memory usage beats 90.32 % of csharp submissions (27 MB)

