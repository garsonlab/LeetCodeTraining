/*
 * @lc app=leetcode id=935 lang=csharp
 *
 * [935] Knight Dialer
 A chess knight can move as indicated in the chess diagram below:

 .           

 

This time, we place our chess knight on any numbered key of a phone pad (indicated above), and the knight makes N-1 hops.  Each hop must be from one key to another numbered key.

Each time it lands on a key (including the initial placement of the knight), it presses the number of that key, pressing N digits total.

How many distinct numbers can you dial in this manner?

Since the answer may be large, output the answer modulo 10^9 + 7.

 

Example 1:

Input: 1
Output: 10
Example 2:

Input: 2
Output: 20
Example 3:

Input: 3
Output: 46
 

Note:

1 <= N <= 5000
 */
public class Solution {
    public int KnightDialer(int N) {
        int[,] solv = new int[10, N];
        int mod = 1000000007;

        for (int i = 0; i <= 9; i++)
        {
            solv[i, 0] = 1;
        }

        if (N > 1)
        {
            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != 5)
                        solv[j, i] = getSum(solv, j, i, mod) % mod;
                }
            }
        }
        int result = 0;
        for (int i = 0; i <= 9; i++)
        {
            result += solv[i, N - 1];
            result = result % mod;
        }
        return result;
    }
    private int getSum(int[,] solv, int i, int j, int mod)
    {
        if (i == 0) return solv[4, j - 1] + solv[6, j - 1];
        if (i == 1) return solv[6, j - 1] + solv[8, j - 1];
        if (i == 2) return solv[7, j - 1] + solv[9, j - 1];
        if (i == 3) return solv[4, j - 1] + solv[8, j - 1];
        if (i == 4) return ((solv[3, j - 1] + solv[9, j - 1]) % mod + solv[0, j - 1]) % mod;
        if (i == 6) return ((solv[1, j - 1] + solv[7, j - 1]) % mod + solv[0, j - 1]) % mod;
        if (i == 7) return solv[2, j - 1] + solv[6, j - 1];
        if (i == 8) return solv[1, j - 1] + solv[3, j - 1];
        return solv[2, j - 1] + solv[4, j - 1];
    }
}

// √ Accepted
//   √ 120/120 cases passed (84 ms)
//   √ Your runtime beats 88.89 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (23.2 MB)

