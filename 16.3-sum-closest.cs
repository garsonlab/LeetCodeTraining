/*
 * @lc app=leetcode id=16 lang=csharp
 *
 * [16] 3Sum Closest
 *
 * https://leetcode.com/problems/3sum-closest/description/
 *
 * algorithms
 * Medium (43.18%)
 * Total Accepted:    316.8K
 * Total Submissions: 731.7K
 * Testcase Example:  '[-1,2,1,-4]\n1'
 *
 * Given an array nums of n integers and an integer target, find three integers
 * in nums such that the sum is closest to target. Return the sum of the three
 * integers. You may assume that each input would have exactly one solution.
 * 
 * Example:
 * 
 * 
 * Given array nums = [-1, 2, 1, -4], and target = 1.
 * 
 * The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
 * 
 * 
 */
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        int closest = nums[0]+nums[1]+nums[2];

        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)//后半部分相加肯定大于0
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            int j = i + 1, k = nums.Length - 1;
            while (j < k)
            {
                int v = nums[i] + nums[j] + nums[k];
                if (Math.Abs(v - target) < Math.Abs(closest - target))
                    closest = v;

                if (v > target)
                    k--;
                else if (v < target)
                    j++;
                else
                {
                    return target;
                }
            }

            if (nums[i] > target)//如果最小的都超过目标则只执行上面一次
                break;
        }

        return closest;
    }
}

// √ Accepted
//   √ 125/125 cases passed (112 ms)
//   √ Your runtime beats 65.67 % of csharp submissions
//   √ Your memory usage beats 22.73 % of csharp submissions (22.8 MB)

