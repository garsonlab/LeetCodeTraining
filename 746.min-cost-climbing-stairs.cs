/*
 * @lc app=leetcode id=746 lang=csharp
 *
 * [746] Min Cost Climbing Stairs
 *
 * https://leetcode.com/problems/min-cost-climbing-stairs/description/
 *
 * algorithms
 * Easy (46.29%)
 * Total Accepted:    72.7K
 * Total Submissions: 156.2K
 * Testcase Example:  '[0,0,0,0]'
 *
 * 
 * On a staircase, the i-th step has some non-negative cost cost[i] assigned (0
 * indexed).
 * 
 * Once you pay the cost, you can either climb one or two steps. You need to
 * find minimum cost to reach the top of the floor, and you can either start
 * from the step with index 0, or the step with index 1.
 * 
 * 
 * Example 1:
 * 
 * Input: cost = [10, 15, 20]
 * Output: 15
 * Explanation: Cheapest is start on cost[1], pay that cost and go to the
 * top.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
 * Output: 6
 * Explanation: Cheapest is start on cost[0], and only step on 1s, skipping
 * cost[3].
 * 
 * 
 * 
 * Note:
 * 
 * cost will have a length in the range [2, 1000].
 * Every cost[i] will be an integer in the range [0, 999].
 * 
 * 
 */
public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.Length];
        dp[0] = cost[0];
        dp[1] = cost[1];
        for (int i = 2; i < cost.Length; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + cost[i], dp[i - 2] + cost[i]);
        }
        return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
    }
}

// √ Accepted
//   √ 276/276 cases passed (92 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 30 % of csharp submissions (23.6 MB)

