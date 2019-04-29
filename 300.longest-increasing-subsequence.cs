/*
 * @lc app=leetcode id=300 lang=csharp
 *
 * [300] Longest Increasing Subsequence

 Given an unsorted array of integers, find the length of longest increasing subsequence.

Example:

Input: [10,9,2,5,3,7,101,18]
Output: 4 
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
Note:

There may be more than one LIS combination, it is only necessary for you to return the length.
Your algorithm should run in O(n2) complexity.
Follow up: Could you improve it to O(n log n) time complexity?
 */
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int count = 0;
        int[] dp = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int n = 0;
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    n = Math.Max(n, dp[j]);
                }
            }

            dp[i] = n + 1;
            count = Math.Max(count, dp[i]);
        }

        return count;
    }
}


// √ Accepted
//   √ 24/24 cases passed (108 ms)
//   √ Your runtime beats 75.92 % of csharp submissions
//   √ Your memory usage beats 15 % of csharp submissions (21.8 MB)
