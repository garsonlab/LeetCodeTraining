/*
 * @lc app=leetcode id=70 lang=csharp
 *
 * [70] Climbing Stairs
 *
 * https://leetcode.com/problems/climbing-stairs/description/
 *
 * algorithms
 * Easy (43.86%)
 * Total Accepted:    381.5K
 * Total Submissions: 869.9K
 * Testcase Example:  '2'
 *
 * You are climbing a stair case. It takes n steps to reach to the top.
 * 
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can
 * you climb to the top?
 * 
 * Note: Given n will be a positive integer.
 * 
 * Example 1:
 * 
 * 
 * Input: 2
 * Output: 2
 * Explanation: There are two ways to climb to the top.
 * 1. 1 step + 1 step
 * 2. 2 steps
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 3
 * Output: 3
 * Explanation: There are three ways to climb to the top.
 * 1. 1 step + 1 step + 1 step
 * 2. 1 step + 2 steps
 * 3. 2 steps + 1 step
 * 
 * 
 */
public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 1)
            return 1;
        if (n <= 2)
            return 2;
        //return ClimbStairs(n - 1) + ClimbStairs(n - 2); 超时

        int[] c = new[] {2, 1};
        for (int i = 3; i <= n; i++)
        {
            c[i % 2] = c[0] + c[1];
        }

        return c[n % 2];
    }
}

// √ Accepted
//   √ 45/45 cases passed (48 ms)
//   √ Your runtime beats 21.09 % of csharp submissions
//   √ Your memory usage beats 73.53 % of csharp submissions (12.8 MB)

