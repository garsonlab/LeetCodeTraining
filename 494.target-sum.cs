/*
 * @lc app=leetcode id=494 lang=csharp
 *
 * [494] Target Sum

 You are given a list of non-negative integers, a1, a2, ..., an, and a target, S. Now you have 2 symbols + and -. For each integer, you should choose one from + and - as its new symbol.

Find out how many ways to assign symbols to make sum of integers equal to target S.

Example 1:
Input: nums is [1, 1, 1, 1, 1], S is 3. 
Output: 5
Explanation: 

-1+1+1+1+1 = 3
+1-1+1+1+1 = 3
+1+1-1+1+1 = 3
+1+1+1-1+1 = 3
+1+1+1+1-1 = 3

There are 5 ways to assign symbols to make the sum of nums be target 3.
Note:
The length of the given array is positive and will not exceed 20.
The sum of elements in the given array will not exceed 1000.
Your output answer is guaranteed to be fitted in a 32-bit integer.
 */
public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
        int res = 0;
        DFSSum(nums, S, 0, ref res);
        return res;
    }

    private void DFSSum(int[] nums, int S, int idx, ref int count)
    {
        if (idx >= nums.Length)
        {
            if (S == 0)
                count++;
            return;
        }

        DFSSum(nums, S + nums[idx], idx + 1, ref count);
        DFSSum(nums, S - nums[idx], idx + 1, ref count);
    }
}

// √ Accepted
//   √ 139/139 cases passed (940 ms)
//   √ Your runtime beats 29.95 % of csharp submissions
//   √ Your memory usage beats 92.86 % of csharp submissions (22 MB)

