/*
 * @lc app=leetcode id=673 lang=csharp
 *
 * [673] Number of Longest Increasing Subsequence

 Given an unsorted array of integers, find the number of longest increasing subsequence.

Example 1:
Input: [1,3,5,4,7]
Output: 2
Explanation: The two longest increasing subsequence are [1, 3, 4, 7] and [1, 3, 5, 7].
Example 2:
Input: [2,2,2,2,2]
Output: 5
Explanation: The length of longest continuous increasing subsequence is 1, and there are 5 subsequences' length is 1, so output 5.
Note: Length of the given array will be not exceed 2000 and the answer is guaranteed to be fit in 32-bit signed int.
 */
public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }

        int[] dp = new int[nums.Length];
        int[] combination = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            combination[i] = 1;
        }

        int max = 1, res = 0;

        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    if (dp[j] + 1 > dp[i])
                    { //如果+1长于当前LIS 则组合数不变
                        dp[i] = dp[j] + 1;
                        combination[i] = combination[j];
                    }
                    else if (dp[j] + 1 == dp[i])
                    { //如果+1等于当前LIS 则说明找到了新组合
                        combination[i] += combination[j];
                    }
                }
            }
            max = Math.Max(max, dp[i]);
        }

        for (int i = 0; i < nums.Length; i++)
            if (dp[i] == max)
                res += combination[i];

        return res;
    }
}

// √ Accepted
//   √ 223/223 cases passed (128 ms)
//   √ Your runtime beats 48.24 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (23.5 MB)

