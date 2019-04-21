/*
 * @lc app=leetcode id=213 lang=csharp
 *
 * [213] House Robber II
 *
 * https://leetcode.com/problems/house-robber-ii/description/
 *
 * algorithms
 * Medium (35.17%)
 * Total Accepted:    111.8K
 * Total Submissions: 317.6K
 * Testcase Example:  '[2,3,2]'
 *
 * You are a professional robber planning to rob houses along a street. Each
 * house has a certain amount of money stashed. All houses at this place are
 * arranged in a circle. That means the first house is the neighbor of the last
 * one. Meanwhile, adjacent houses have security system connected and it will
 * automatically contact the police if two adjacent houses were broken into on
 * the same night.
 * 
 * Given a list of non-negative integers representing the amount of money of
 * each house, determine the maximum amount of money you can rob tonight
 * without alerting the police.
 * 
 * Example 1:
 * 
 * 
 * Input: [2,3,2]
 * Output: 3
 * Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money
 * = 2),
 * because they are adjacent houses.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,2,3,1]
 * Output: 4
 * Explanation: Rob house 1 (money = 1) and then rob house 3 (money =
 * 3).
 * Total amount you can rob = 1 + 3 = 4.
 * 
 */
public class Solution {
    public int Rob(int[] nums) {
        int len = nums.Length;
        if(len == 0)
            return 0;
         if(len == 1)
            return nums[0];
        if(len == 2)
            return Math.Max(nums[0], nums[1]);


        int[] dp1 = new int[len];
        int[] dp2 = new int[len-1];
        dp1[0] = nums[0];
        dp1[1] = Math.Max(nums[0], nums[1]);

        dp2[0] = nums[1];
        dp2[1] = Math.Max(nums[1], nums[2]);

        for(int i = 2; i < len-1; i++) {
        	dp1[i] = Math.Max(dp1[i-1], dp1[i-2] + nums[i]);
        	dp2[i] = Math.Max(dp2[i-1], dp2[i-2] + nums[i+1]);
        }
 
        return Math.Max(dp1[len-2], dp2[len-2]);
    }
}

// √ Accepted
//   √ 74/74 cases passed (88 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (21.8 MB)

