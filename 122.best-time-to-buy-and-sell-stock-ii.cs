/*
 * @lc app=leetcode id=122 lang=csharp
 *
 * [122] Best Time to Buy and Sell Stock II
 *
 * https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
 *
 * algorithms
 * Easy (51.42%)
 * Total Accepted:    309K
 * Total Submissions: 600.9K
 * Testcase Example:  '[7,1,5,3,6,4]'
 *
 * Say you have an array for which the i^th element is the price of a given
 * stock on day i.
 * 
 * Design an algorithm to find the maximum profit. You may complete as many
 * transactions as you like (i.e., buy one and sell one share of the stock
 * multiple times).
 * 
 * Note: You may not engage in multiple transactions at the same time (i.e.,
 * you must sell the stock before you buy again).
 * 
 * Example 1:
 * 
 * 
 * Input: [7,1,5,3,6,4]
 * Output: 7
 * Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit
 * = 5-1 = 4.
 * Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 =
 * 3.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,2,3,4,5]
 * Output: 4
 * Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit
 * = 5-1 = 4.
 * Note that you cannot buy on day 1, buy on day 2 and sell them later, as you
 * are
 * engaging multiple transactions at the same time. You must sell before buying
 * again.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [7,6,4,3,1]
 * Output: 0
 * Explanation: In this case, no transaction is done, i.e. max profit = 0.
 * 
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length <= 1)
            return 0;

        int ret = 0;
        int s = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < prices[i - 1])
            {
                ret += prices[i - 1] - prices[s];
                s = i;
            }
        }

        if (s != prices.Length - 1)
            ret += prices[prices.Length - 1] - prices[s];

        return ret;
    }
}
//想明白了也就是求单调递增区间值
// √ Accepted
//   √ 201/201 cases passed (96 ms)
//   √ Your runtime beats 67.18 % of csharp submissions
//   √ Your memory usage beats 60.78 % of csharp submissions (23.1 MB)
