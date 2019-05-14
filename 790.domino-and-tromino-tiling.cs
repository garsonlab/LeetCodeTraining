/*
 * @lc app=leetcode id=790 lang=csharp
 *
 * [790] Domino and Tromino Tiling

 We have two types of tiles: a 2x1 domino shape, and an "L" tromino shape. These shapes may be rotated.

XX  <- domino

XX  <- "L" tromino
X
Given N, how many ways are there to tile a 2 x N board? Return your answer modulo 10^9 + 7.

(In a tiling, every square must be covered by a tile. Two tilings are different if and only if there are two 4-directionally adjacent cells on the board such that exactly one of the tilings has both squares occupied by a tile.)

Example:
Input: 3
Output: 5
Explanation: 
The five different ways are listed below, different letters indicates different tiles:
XYZ XXZ XYY XXY XYY
XYZ YYZ XZZ XYY XXY
Note:

N  will be in range [1, 1000].
 */
public class Solution {
    public int NumTilings(int N)
    {
        if (N <= 2)
            return N;
        if (N == 3)
            return 5;

        int[] res = new int[N+1];//递推式: dp[i] = 2*dp[i-1] + dp[i-3];
        res[1] = 1;
        res[2] = 2;
        res[3] = 5;
        for (int i = 4; i <= N; i++)
        {
            res[i] = (2 * res[i - 1] % (1000000007) + res[i - 3] % (1000000007)) % 1000000007;
        }

        return res[N];
    }


    public int NumTilings_ERR(int N) {
        int a = N, b = N;
        int res = 0;
        DFST(a, b, ref res);
        return res;
    }

    private void DFST(int a, int b, ref int res)
    {
        if (a == 0 && b == 0)
            res++;
        if(a<0 || b < 0)
            return;

        if (a > b)
        {
            DFST(a - 2, b, ref res);
            DFST(a - 2, b - 1, ref res);
        }
        else if(a == b)
        {
            DFST(a - 2, b - 1, ref res);
            DFST(a - 1, b - 2, ref res);
            DFST(a - 1, b - 1, ref res);
        }
        else
        {
            DFST(a, b - 2, ref res);
            DFST(a - 1, b - 2, ref res);
        }
    }

}

// √ Accepted
//   √ 39/39 cases passed (40 ms)
//   √ Your runtime beats 44.44 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.7 MB)

