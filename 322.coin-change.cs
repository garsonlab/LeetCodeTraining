/*
 * @lc app=leetcode id=322 lang=csharp
 *
 * [322] Coin Change

 You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

Example 1:

Input: coins = [1, 2, 5], amount = 11
Output: 3 
Explanation: 11 = 5 + 5 + 1
Example 2:

Input: coins = [2], amount = 3
Output: -1
Note:
You may assume that you have an infinite number of each kind of coin.
 */
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0)
            return 0;
        int[] dp = new int[amount+1];
        for (int i = 1; i <= amount; i++)
        {
            dp[i] = amount + 1;
        }

        Array.Sort(coins);
        for (int i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                if (i >= coin && dp[i - coin] != amount + 1)
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }

        if (dp[amount] < amount + 1 && dp[amount] > 0)
            return dp[amount];
        return -1;
    }
}

// √ Accepted
//   √ 182/182 cases passed (128 ms)
//   √ Your runtime beats 66.4 % of csharp submissions
//   √ Your memory usage beats 69.77 % of csharp submissions (25.1 MB)

