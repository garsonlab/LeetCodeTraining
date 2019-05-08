/*
 * @lc app=leetcode id=560 lang=csharp
 *
 * [560] Subarray Sum Equals K

 Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

Example 1:
Input:nums = [1,1,1], k = 2
Output: 2
Note:
The length of the array is in range [1, 20,000].
The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
 */
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int len = nums.Length;
        if (len == 0)
            return 0;

        int res = 0;

        for (int i = 0; i < len; i++)
        {
            if (nums[i] == k)
                res++;

            if (i > 0)
            {
                nums[i] += nums[i - 1];

                if (nums[i] == k)
                    res++;
            }
        }

        for (int i = 1; i < len; i++)
        {
            for (int j = i+1; j < len; j++)
            {
                int s = nums[j] - nums[i - 1];
                if (s == k)
                    res++;
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 80/80 cases passed (748 ms)
//   √ Your runtime beats 12.9 % of csharp submissions
//   √ Your memory usage beats 79.17 % of csharp submissions (25.3 MB)

