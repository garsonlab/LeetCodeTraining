/*
 * @lc app=leetcode id=518 lang=csharp
 *
 * [518] Coin Change 2

 You are given coins of different denominations and a total amount of money. Write a function to compute the number of combinations that make up that amount. You may assume that you have infinite number of each kind of coin.

 

Example 1:

Input: amount = 5, coins = [1, 2, 5]
Output: 4
Explanation: there are four ways to make up the amount:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1
Example 2:

Input: amount = 3, coins = [2]
Output: 0
Explanation: the amount of 3 cannot be made up just with coins of 2.
Example 3:

Input: amount = 10, coins = [10] 
Output: 1
 

Note:

You can assume that

0 <= amount <= 5000
1 <= coin <= 5000
the number of coins is less than 500
the answer is guaranteed to fit into signed 32-bit integer
 */
public class Solution {
    public int Change(int amount, int[] coins)
    {
        int[] dp = new int[amount+1];
        dp[0] = 1;
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = 1; j <= amount; j++)
            {
                if (j >= coins[i])
                    dp[j] += dp[j - coins[i]];
            }
        }

        return dp[amount];
    }


    public int Change_timeout(int amount, int[] coins) {
        int res = 0;
        if (amount == 0)
            return 1;

        Array.Sort(coins);
        GetChange(coins, amount, 0, ref res);

        return res;
    }

    private void GetChange(int[] coins, int amount, int idx, ref int count)
    {
        for (int i = idx; i < coins.Length; i++)
        {
            int v = amount - coins[i];
            if (v == 0)
                count++;

            if(v <= 0)
                break;

            GetChange(coins, v, i, ref count);
        }
    }
}

// √ Accepted
//   √ 27/27 cases passed (136 ms)
//   √ Your runtime beats 28.19 % of csharp submissions
//   √ Your memory usage beats 69.23 % of csharp submissions (21.7 MB)

