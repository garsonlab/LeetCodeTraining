/*
 * @lc app=leetcode id=688 lang=csharp
 *
 * [688] Knight Probability in Chessboard

 On an NxN chessboard, a knight starts at the r-th row and c-th column and attempts to make exactly K moves. The rows and columns are 0 indexed, so the top-left square is (0, 0), and the bottom-right square is (N-1, N-1).

A chess knight has 8 possible moves it can make, as illustrated below. Each move is two squares in a cardinal direction, then one square in an orthogonal direction.

 



 

Each time the knight is to move, it chooses one of eight possible moves uniformly at random (even if the piece would go off the chessboard) and moves there.

The knight continues moving until it has made exactly K moves or has moved off the chessboard. Return the probability that the knight remains on the board after it has stopped moving.

 

Example:

Input: 3, 2, 0, 0
Output: 0.0625
Explanation: There are two moves (to (1,2), (2,1)) that will keep the knight on the board.
From each of those positions, there are also two moves that will keep the knight on the board.
The total probability the knight stays on the board is 0.0625.
 

Note:

N will be between 1 and 25.
K will be between 0 and 100.
The knight always initially starts on the board.
 */
public class Solution {
    public double KnightProbability(int N, int K, int r, int c) {
        int[][] directions = new[]
        {
            new[] {1, 2}, new[] {-1, 2}, new[] {1, -2}, new[] {-1, -2}, new[] {2, 1}, new[] {-2, 1}, new[] {2, -1},
            new[] {-2, -1}
        };

        //board[row][col][j]用于存储在row行，col列走j步不出界的概率
        double[,,] board = new double[N, N, K+1];
        
        return nextStep(board, directions, N, K, r, c, K);
    }
    //step代表的是还需要走的步数，[nowRow][nowCol]是现在的位置
    double nextStep(double[,,] board, int[][] directions, int N, int K, int nowRow, int nowCol, int step)
    {
        if (nowRow < 0 || nowCol < 0 || nowRow >= N || nowCol >= N)
        {//出界
            return 0;
        }
        //如果此时step == 0，代表它已经不能移动，所以没有出界的概率就是1.0
        if (step == 0)
        {
            return 1.0;
        }
        //如果这个点之前搜索过，（注意double类型不能直接判断board[nowRow][nowCol][step] == 0，需要判断它是否小于一个很小的值，比如1e-6）
        if (Math.Abs(board[nowRow,nowCol,step]) > 1e-6)
        {
            return board[nowRow,nowCol,step];
        }
        //穷举八个方向
        foreach (var direction in directions)
        {
            board[nowRow,nowCol,step] += nextStep(board, directions, N, K, nowRow + direction[0], nowCol + direction[1], step - 1) / 8;
        }
        return board[nowRow,nowCol,step];
    }


    public double KnightProbability_Err(int N, int K, int r, int c) {
        if (K == 0)
            return 1;
        double[,] record = new double[N, N];
        double[,] temp = new double[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                record[i, j] = 1;
                temp[i, j] = 1;
            }
        }

        while (K-- > 0)
        {
            for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                UpdateRatio(record, temp, N, i, j);
            temp = record;
        }

        return record[r, c];
    }

    private void UpdateRatio(double[,] record, double[,] temp, int N, int r, int c)
    {
        double res = 0;

        if (r - 1 > -1 && c - 2 > -1 && r - 1 < N && c - 2 < N)
            res += temp[r - 1,c - 2] * 0.125;
        if (r + 1 > -1 && c - 2 > -1 && r + 1 < N && c - 2 < N)
            res += temp[r + 1,c - 2] * 0.125;
        if (r - 2 > -1 && c - 1 > -1 && r - 2 < N && c - 1 < N)
            res += temp[r - 2,c - 1] * 0.125;
        if (r + 2 > -1 && c - 1 > -1 && r + 2 < N && c - 1 < N)
            res += temp[r + 2,c - 1] * 0.125;
        if (r - 2 > -1 && c + 1 > -1 && r - 2 < N && c + 1 < N)
            res += temp[r - 2,c + 1] * 0.125;
        if (r + 2 > -1 && c + 1 > -1 && r + 2 < N && c + 1 < N)
            res += temp[r + 2,c + 1] * 0.125;
        if (r - 1 > -1 && c + 2 > -1 && r - 1 < N && c + 2 < N)
            res += temp[r - 1,c + 2] * 0.125;
        if (r + 1 > -1 && c + 2 > -1 && r + 1 < N && c + 2 < N)
            res += temp[r + 1,c + 2] * 0.125;

        record[r,c] = res;
    }

}

// √ Accepted
//   √ 21/21 cases passed (56 ms)
//   √ Your runtime beats 64.29 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (13.4 MB)

