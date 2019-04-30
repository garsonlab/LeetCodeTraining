/*
 * @lc app=leetcode id=368 lang=csharp
 *
 * [368] Largest Divisible Subset

 Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj) of elements in this subset satisfies:

Si % Sj = 0 or Sj % Si = 0.

If there are multiple solutions, return any subset is fine.

Example 1:

Input: [1,2,3]
Output: [1,2] (of course, [1,3] will also be ok)
Example 2:

Input: [1,2,4,8]
Output: [1,2,4,8]
 */
public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        List<int> res = new List<int>();
        if (nums.Length == 0)
            return res;

        Array.Sort(nums);
        int[] dp = new int[nums.Length];
        int[] pre = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            pre[i] = i;

            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0)
                {
                    if (dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        pre[i] = j;
                    }
                }
            }
        }

        int max = dp[0], idx = 0;
        for (int i = 1; i < dp.Length; i++)
        {
            if (dp[i] > max)
            {
                max = dp[i];
                idx = i;
            }
        }

        res.Add(nums[idx]);
        while (pre[idx] != idx)
        {
            idx = pre[idx];
            res.Add(nums[idx]);
        }
        res.Reverse();
        return res;
    }
}

// √ Accepted
//   √ 41/41 cases passed (268 ms)
//   √ Your runtime beats 76.92 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (28.7 MB)

