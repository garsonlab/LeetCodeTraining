/*
 * @lc app=leetcode id=198 lang=csharp
 *
 * [198] House Robber
 *
 * https://leetcode.com/problems/house-robber/description/
 *
 * algorithms
 * Easy (40.88%)
 * Total Accepted:    306.1K
 * Total Submissions: 748.6K
 * Testcase Example:  '[1,2,3,1]'
 *
 * You are a professional robber planning to rob houses along a street. Each
 * house has a certain amount of money stashed, the only constraint stopping
 * you from robbing each of them is that adjacent houses have security system
 * connected and it will automatically contact the police if two adjacent
 * houses were broken into on the same night.
 * 
 * Given a list of non-negative integers representing the amount of money of
 * each house, determine the maximum amount of money you can rob tonight
 * without alerting the police.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3,1]
 * Output: 4
 * Explanation: Rob house 1 (money = 1) and then rob house 3 (money =
 * 3).
 * Total amount you can rob = 1 + 3 = 4.
 * 
 * Example 2:
 * 
 * 
 * Input: [2,7,9,3,1]
 * Output: 12
 * Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house
 * 5 (money = 1).
 * Total amount you can rob = 2 + 9 + 1 = 12.
 * 
 * 
 */
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0)
            return 0;
        if (nums.Length == 1)
            return nums[0];
        if (nums.Length == 2)
            return Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            int v = Math.Max(nums[i - 2] + nums[i], nums[i - 1]);//2,1,1,2
            if (i >= 3)
            {
                v = Math.Max(v, nums[i - 3] + nums[i]);
            }

            nums[i] = v;//Math.Max(nums[i - 2] + nums[i], nums[i-1]);
        }

        return nums[nums.Length - 1];
    }
}

// √ Accepted
//   √ 69/69 cases passed (88 ms)
//   √ Your runtime beats 98.3 % of csharp submissions
//   √ Your memory usage beats 60.78 % of csharp submissions (21.7 MB)

