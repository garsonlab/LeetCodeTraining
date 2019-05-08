/*
 * @lc app=leetcode id=576 lang=csharp
 *
 * [576] Out of Boundary Paths

 There is an m by n grid with a ball. Given the start coordinate (i,j) of the ball, you can move the ball to adjacent cell or cross the grid boundary in four directions (up, down, left, right). However, you can at most move N times. Find out the number of paths to move the ball out of grid boundary. The answer may be very large, return it after mod 109 + 7.

 

Example 1:

Input: m = 2, n = 2, N = 2, i = 0, j = 0
Output: 6
Explanation:

Example 2:

Input: m = 1, n = 3, N = 3, i = 0, j = 1
Output: 12
Explanation:

 

Note:

Once you move the ball out of boundary, you cannot move it back.
The length and height of the grid is in range [1,50].
N is in range [0,50].
 */
public class Solution {

    public int FindPaths(int m, int n, int N, int i, int j)
    {
        int mod = 1000000007;
        int[,] dp = new int[m,n];
        dp[i,j] = 1;
        int res = 0;
        int[][] dirs = new []
        {
            new []{ -1, 0 }, new []{ 1, 0 }, new []{ 0, -1 }, new []{ 0, 1 }
        };

        for (int move = 0; move < N; move++)
        {
            int[,] temp = new int[m,n];
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    foreach (var dir in dirs)
                    {
                        int dx = x + dir[0];
                        int dy = y + dir[1];
                        if (dx < 0 || dx == m || dy < 0 || dy == n)
                        {
                            res = (res + dp[x,y]) % mod;
                        }
                        else
                        {
                            temp[dx,dy] = (temp[dx,dy] + dp[x,y]) % mod;
                        }
                    }
                }
            }
            dp = temp;
        }
        return res;
    }

    public int FindPaths_ERR2(int m, int n, int N, int i, int j)
    {
        int[, ,] dp = new int[N+1, m, n];
        for (int k = 1; k <= N; k++)
        {
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    int v1 = (x == 0) ? 1 : dp[k - 1,x - 1,y];
                    int v2 = (x == m - 1) ? 1 : dp[k - 1,x + 1,y];
                    int v3 = (y == 0) ? 1 : dp[k - 1,x,y - 1];
                    int v4 = (y == n - 1) ? 1 : dp[k - 1,x,y + 1];
                    dp[k,x,y] = (v1 + v2 + v3 + v4) % 1000000007;
                }
            }
        }

        return dp[N, i, j];
    }

    public int FindPaths_ERR(int m, int n, int N, int i, int j) {
        int mod = 1000000007;
        int[,] dp = new int[m, n];
        dp[i, j] = 1;
        int res = 0;

        int[][] dir = new[]
        {
            new[] {-1, 0},
            new[] {1, 0},
            new[] {0, -1},
            new[] {0, 1},
        };

        for (int move = 0; move < N; move++)
        {
            int[,] temp = new int[m, n];
            for (int k = 0; k < m; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    foreach (var d in dir)
                    {
                        int x = k + d[0];
                        int y = l + d[1];

                        if (x < 0 || x >= m || y < 0 || y >= n)
                            res = (res + dp[k, l]) % mod;
                        else
                            temp[x, y] = (temp[x, y] + temp[k, l]) % mod;
                    }
                }
            }

            dp = temp;
        }

        return res;
    }
}

// 初始化dp[x][y]表示到x,y这个位置上有多少种走法. 刚开始给的 i, j 位置上是1, 其他位置全是0. 

// 状态转移 (x,y) 从上下左右四个方向 往外走，走到dx, dy. dp[x][y] 就加到dp[dx][dy]上.

// 如果(dx, dy)已经出界了, 那说明这就是提出boundary了. 可以把dp[x][y] 加到res中.

// 答案是在每一种状态时边界点能从不同方向走出来的和.

// Note: 角上只有一个点, 但可以从不同方向走出来，每个方向都要算一次.
// √ Accepted
//   √ 94/94 cases passed (68 ms)
//   √ Your runtime beats 48.39 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (13.5 MB)
