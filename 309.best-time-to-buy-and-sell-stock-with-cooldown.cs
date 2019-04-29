/*
 * @lc app=leetcode id=309 lang=csharp
 *
 * [309] Best Time to Buy and Sell Stock with Cooldown

 Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
Example:

Input: [1,2,3,0,2]
Output: 3 
Explanation: transactions = [buy, sell, cooldown, buy, sell]
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 0)
        {
            return 0;
        }
        //dp1[i]表示第i天手上有股票的最大收益（前i天的最后一个状态是买入）
        int[] dp1 = new int[prices.Length];
        //dp2[i]表示第i天卖出股票的最大收益
        int[] dp2 = new int[prices.Length];
        //dp3[i]表示前i天最后一个状态为冷冻期的最大收益（第i天要么无状态即冷冻期后没有再买入，要么为冻结状态）
        int[] dp3 = new int[prices.Length];

        dp1[0] = - prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            //第i天买入股票：dp3[i - 1] - prices[i]（dp3[i - 1]表明今天可以买）
            //第i天不买入股票：dp1[i - 1]
            dp1[i] = Math.Max(dp3[i - 1] - prices[i], dp1[i - 1]);
            //第i天卖出股票
            dp2[i] = dp1[i - 1] + prices[i];
            //第i天为冷冻期：代表第i-1天卖出股票->dp2[i - 1]
            //第i天为无状态：dp3[i- 1]
            dp3[i] = Math.Max(dp2[i - 1], dp3[i - 1]);
        }
        //1.最后一天卖出
        //2.最后一天为冷冻期
        //3.最后一天无状态（冷冻期后没有再买入）
        return Math.Max(dp2[prices.Length - 1], dp3[prices.Length - 1]);
    }
}

// √ Accepted
//   √ 211/211 cases passed (92 ms)
//   √ Your runtime beats 79.1 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (22.3 MB)

