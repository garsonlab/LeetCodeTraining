/*
 * @lc app=leetcode id=909 lang=csharp
 *
 * [909] Snakes and Ladders

 On an N x N board, the numbers from 1 to N*N are written boustrophedonically starting from the bottom left of the board, and alternating direction each row.  For example, for a 6 x 6 board, the numbers are written as follows:


You start on square 1 of the board (which is always in the last row and first column).  Each move, starting from square x, consists of the following:

You choose a destination square S with number x+1, x+2, x+3, x+4, x+5, or x+6, provided this number is <= N*N.
(This choice simulates the result of a standard 6-sided die roll: ie., there are always at most 6 destinations, regardless of the size of the board.)
If S has a snake or ladder, you move to the destination of that snake or ladder.  Otherwise, you move to S.
A board square on row r and column c has a "snake or ladder" if board[r][c] != -1.  The destination of that snake or ladder is board[r][c].

Note that you only take a snake or ladder at most once per move: if the destination to a snake or ladder is the start of another snake or ladder, you do not continue moving.  (For example, if the board is `[[4,-1],[-1,3]]`, and on the first move your destination square is `2`, then you finish your first move at `3`, because you do not continue moving to `4`.)

Return the least number of moves required to reach square N*N.  If it is not possible, return -1.

Example 1:

Input: [
[-1,-1,-1,-1,-1,-1],
[-1,-1,-1,-1,-1,-1],
[-1,-1,-1,-1,-1,-1],
[-1,35,-1,-1,13,-1],
[-1,-1,-1,-1,-1,-1],
[-1,15,-1,-1,-1,-1]]
Output: 4
Explanation: 
At the beginning, you start at square 1 [at row 5, column 0].
You decide to move to square 2, and must take the ladder to square 15.
You then decide to move to square 17 (row 3, column 5), and must take the snake to square 13.
You then decide to move to square 14, and must take the ladder to square 35.
You then decide to move to square 36, ending the game.
It can be shown that you need at least 4 moves to reach the N*N-th square, so the answer is 4.
Note:

2 <= board.length = board[0].length <= 20
board[i][j] is between 1 and N*N or is equal to -1.
The board square with number 1 has no snake or ladder.
The board square with number N*N has no snake or ladder.
 */
public class Solution {
    
    public int SnakesAndLadders(int[][] board)
    {
        int N = board.Length;
        if (N <= 1)
            return 0;

        int tx = 0, ty = 0;
        Queue<int> q = new Queue<int>();
        List<int> visited = new List<int>();
        int step = 0;
        q.Enqueue(0);
        visited.Add(0);
        while (q.Count > 0)
        {
            int s = q.Count;
            for (int i = 0; i < s; ++i)
            {
                int idx = q.Dequeue();
                if (idx == N * N - 1) return step;
                for (int j = 1; idx + j < N * N && j <= 6; ++j)
                {
                    computeIndex(idx + j, N, ref tx, ref ty);
                    if (board[tx][ty] != -1)
                    {
                        if (!visited.Contains(board[tx][ty] - 1))
                        {
                            q.Enqueue(board[tx][ty] - 1);
                            visited.Add(board[tx][ty] - 1);
                        }
                    }
                    else
                    {
                        if (!visited.Contains(idx + j))
                        {
                            q.Enqueue(idx + j);
                            visited.Add(idx + j);
                        }
                    }
                }
            }
            step += 1;
        }
        return -1;
    }

    void computeIndex(int i, int N, ref int x, ref int y)
    {
        x = i / N;
        y = 0;
        if (x % 2 == 0) y = i % N;
        else y = N - (i % N) - 1;
        x = N - 1 - x;
    }



    public int SnakesAndLadders_ERR(int[][] board) {
        int N = board.Length;
        if (N <= 1)
            return 0;

        for (int i = 0, j=N-1; i < j; i++,j--)
        {
            var tem = board[i];
            board[i] = board[j];
            board[j] = tem;
        }

        for (int c = 1; c < N; c+=2)
        {
            for (int i = 0, j = N-1; i < j; i++, j--)
            {
                var tem = board[c][i];
                board[c][i] = board[c][j];
                board[c][j] = tem;
            }
        }


        Dictionary<int, int> visited = new Dictionary<int, int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        visited[0] = 0;

        while (queue.Count > 0)
        {
            var i = queue.Dequeue();
            if (i == N * N - 1)
                return visited[i];

            int row = i / N;
            int col = i % N;

            if (board[row][col] > 0)
            {
                int sl = board[row][col] - 1;
                if (!visited.ContainsKey(sl))
                {
                    visited[sl] = visited[i] + 1;
                    queue.Enqueue(sl);
                }
            }


            for (int j = 1; j <= 6; j++)
            {
                if(i+j >= N*N)
                    break;

                int t = i + j;
                if(visited.ContainsKey(t))
                    continue;

                int t_r = t / N;
                int t_c = t % N;

                visited[t] = visited[i] + 1;
                //queue.Enqueue(t);

                if (board[t_r][t_c] > 0)
                {
                    int sl = board[t_r][t_c] - 1;
                    if (!visited.ContainsKey(sl))
                    {
                        visited[sl] = visited[i] + 1;
                        queue.Enqueue(sl);
                    }
                }
                else
                {
                    queue.Enqueue(t);
                }
            }
        }

        return -1;
    }
}


// √ Accepted
//   √ 211/211 cases passed (148 ms)
//   √ Your runtime beats 9.46 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (25.7 MB)
