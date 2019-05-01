/*
 * @lc app=leetcode id=377 lang=csharp
 *
 * [377] Combination Sum IV

 Given an integer array with all positive numbers and no duplicates, find the number of possible combinations that add up to a positive integer target.

Example:

nums = [1, 2, 3]
target = 4

The possible combination ways are:
(1, 1, 1, 1)
(1, 1, 2)
(1, 2, 1)
(1, 3)
(2, 1, 1)
(2, 2)
(3, 1)

Note that different sequences are counted as different combinations.

Therefore the output is 7.
 

Follow up:
What if negative numbers are allowed in the given array?
How does it change the problem?
What limitation we need to add to the question to allow negative numbers?

Credits:
Special thanks to @pbrother for adding this problem and creating all test cases.
 */
public class Solution {
    public int CombinationSum4(int[] nums, int target)
    {
        int[] memo = new int[target + 1];
        memo[0] = 1;
        for (int i = 0; i < target; i++) {
            foreach (int num in nums)
            {
                if (i + num <= target) {
                    memo[i + num] += memo[i];
                }
            }
        }
        return memo[target];
    }


    public int CombinationSum4_out(int[] nums, int target)//1,2,3\n32
    {
        Array.Sort(nums);
        int res = 0;
        CS(nums, target, ref res);
        return res;
    }

    private void CS(int[] nums, int target, ref int res)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int v = target - nums[i];
            if (v == 0)
                res++;
            if(v <= 0)
                break;
            CS(nums, v, ref res);
        }
    }
}
// √ Accepted
//   √ 17/17 cases passed (104 ms)
//   √ Your runtime beats 49.5 % of csharp submissions
//   √ Your memory usage beats 62.5 % of csharp submissions (21.6 MB)

