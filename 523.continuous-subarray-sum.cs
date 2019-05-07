/*
 * @lc app=leetcode id=523 lang=csharp
 *
 * [523] Continuous Subarray Sum

 Given a list of non-negative numbers and a target integer k, write a function to check if the array has a continuous subarray of size at least 2 that sums up to the multiple of k, that is, sums up to n*k where n is also an integer.

 

Example 1:

Input: [23, 2, 4, 6, 7],  k=6
Output: True
Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.
Example 2:

Input: [23, 2, 6, 4, 7],  k=6
Output: True
Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.
 

Note:

The length of the array won't exceed 10,000.
You may assume the sum of all the numbers is in the range of a signed 32-bit integer.
 */
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k)
    {
        int temp = 0;
        foreach (var num in nums)
        {
            temp += num;
        }
        if (temp == 0 && nums.Length > 1)
            return true;
        if(k == 0)
        {
            bool n0 = false;
            for (int i = 1; i < nums.Length; i++)
            {
                if(nums[i-1] == 0 && nums[i] == 0)
                {
                    n0 = true;
                    break;
                }
            }
            return n0;
        }
        for (int i = 1; i < nums.Length; i++)
        {
            int sum = nums[i];
            for (int j = i - 1; j >= 0; j--)
            {
                sum += nums[j];
                if (sum % k == 0)
                    return true;
            }
        }
        return false;
    }

    public bool CheckSubarraySum_1(int[] nums, int k) {
        
        int n = nums.Length;
        if (n <= 1)
            return false;

        if(k == 0)
        {
            bool n0 = false;
            for (int i = 1; i < n; i++)
            {
                if(nums[i-1] == 0 && nums[i] == 0)
                {
                    n0 = true;
                    break;
                }
            }
            return n0;
        }

        int[,] dp = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            if (i > 0)
            {
                dp[0, i] = nums[i] + dp[0, i - 1];
                if (dp[0, i] % k == 0)
                    return true;
            }
            else
            {
                dp[0, 0] = nums[i];
            }
        }

        if(dp[0, n-1] < k)
            return false;

        for (int i = 1; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                dp[i, j] = (dp[i - 1, j] - dp[i - i, i]);
                if (dp[i, j] == 0)
                    return true;
            }
        }

        return false;
    }
}

// √ Accepted
//   √ 86/86 cases passed (148 ms)
//   √ Your runtime beats 33.67 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (29.5 MB)

