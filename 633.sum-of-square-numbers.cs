/*
 * @lc app=leetcode id=633 lang=csharp
 *
 * [633] Sum of Square Numbers
 *
 * https://leetcode.com/problems/sum-of-square-numbers/description/
 *
 * algorithms
 * Easy (32.81%)
 * Total Accepted:    41K
 * Total Submissions: 125K
 * Testcase Example:  '5'
 *
 * Given a non-negative integer c, your task is to decide whether there're two
 * integers a and b such that a^2 + b^2 = c.
 * 
 * Example 1:
 * 
 * 
 * Input: 5
 * Output: True
 * Explanation: 1 * 1 + 2 * 2 = 5
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 3
 * Output: False
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool JudgeSquareSum(int c) {
        int m = (int) Math.Sqrt(c);
        for (int i = m; i >= m/2; i--)
        {
            int l = c - i * i;
            double s = Math.Sqrt(l);

            if (Math.Abs(Math.Round(s) - s) < 1e-10)
                return true;
        }

        return false;
    }
}

// √ Accepted
//   √ 124/124 cases passed (44 ms)
//   √ Your runtime beats 64.42 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (13 MB)

