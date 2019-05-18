/*
 * @lc app=leetcode id=877 lang=csharp
 *
 * [877] Stone Game

 Alex and Lee play a game with piles of stones.  There are an even number of piles arranged in a row, and each pile has a positive integer number of stones piles[i].

The objective of the game is to end with the most stones.  The total number of stones is odd, so there are no ties.

Alex and Lee take turns, with Alex starting first.  Each turn, a player takes the entire pile of stones from either the beginning or the end of the row.  This continues until there are no more piles left, at which point the person with the most stones wins.

Assuming Alex and Lee play optimally, return True if and only if Alex wins the game.

 

Example 1:

Input: [5,3,4,5]
Output: true
Explanation: 
Alex starts first, and can only take the first 5 or the last 5.
Say he takes the first 5, so that the row becomes [3, 4, 5].
If Lee takes 3, then the board is [4, 5], and Alex takes 5 to win with 10 points.
If Lee takes the last 5, then the board is [3, 4], and Alex takes 4 to win with 9 points.
This demonstrated that taking the first 5 was a winning move for Alex, so we return true.
 

Note:

2 <= piles.length <= 500
piles.length is even.
1 <= piles[i] <= 500
sum(piles) is odd.
 */
public class Solution {
    public bool StoneGame(int[] piles) {
        //dp其实就是存储了递归过程中的数值
        //dps[i][j]代表从i到j所能获得的最大的绝对分数
        //（比如为1就说明亚历克斯从i到j可以赢李1分）
        //如何计算dps[i][j]呢:max(piles[i]-dp[i+1][j],piles[j]-dp[i][j-1]);
        //这里减去dps数组是因为李也要找到最大的
        //最后dps=[5 2 4 1]
        //        [0 3 1 4]
        //        [0 0 4 1]
        //        [0 0 0 5]
        int n=piles.Length;
        int [,]dps=new int[n,n];
        //dps[i,i]存储当前i的石子数
        for(int i=0;i<n;i++)
            dps[i,i]=piles[i];
        //d=1,其实代表，先算两个子的时候
        for(int d=1;d<n;d++)
        {
            //有多少组要比较
            for(int j=0;j<n-d;j++)
            {
                //比较j到d+j
                dps[j,d+j]=Math.Max(piles[j]-dps[j+1,d+j],piles[d+j]-dps[j,d+j-1]);
            }
        }
        return dps[0,n-1]>0;
    }
}

// √ Accepted
//   √ 46/46 cases passed (100 ms)
//   √ Your runtime beats 50 % of csharp submissions
//   √ Your memory usage beats 16.25 % of csharp submissions (27.6 MB)

