/*
 * @lc app=leetcode id=121 lang=csharp
 *
 * [121] Best Time to Buy and Sell Stock
 *
 * https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
 *
 * algorithms
 * Easy (46.47%)
 * Total Accepted:    455K
 * Total Submissions: 978.1K
 * Testcase Example:  '[7,1,5,3,6,4]'
 *
 * Say you have an array for which the i^th element is the price of a given
 * stock on day i.
 * 
 * If you were only permitted to complete at most one transaction (i.e., buy
 * one and sell one share of the stock), design an algorithm to find the
 * maximum profit.
 * 
 * Note that you cannot sell a stock before you buy one.
 * 
 * Example 1:
 * 
 * 
 * Input: [7,1,5,3,6,4]
 * Output: 5
 * Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit
 * = 6-1 = 5.
 * Not 7-1 = 6, as selling price needs to be larger than buying price.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [7,6,4,3,1]
 * Output: 0
 * Explanation: In this case, no transaction is done, i.e. max profit = 0.
 * 
 * 
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length <= 1)
                return 0;

        int min = int.MaxValue;
        int max = int.MinValue;

        int temMin = prices[0];
        int temMax = prices[0];
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] >= temMax)
            {
                temMax = prices[i];
            }
            else
            {
                if (temMin < min)
                    min = temMin;

                if (temMax > max)
                    max = temMax;

                temMin = prices[i];
                temMax = prices[i];
            }
        }

        return max - min;
    }
}

