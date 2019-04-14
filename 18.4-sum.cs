/*
 * @lc app=leetcode id=18 lang=csharp
 *
 * [18] 4Sum
 *
 * https://leetcode.com/problems/4sum/description/
 *
 * algorithms
 * Medium (30.12%)
 * Total Accepted:    223.3K
 * Total Submissions: 741.2K
 * Testcase Example:  '[1,0,-1,0,-2,2]\n0'
 *
 * Given an array nums of n integers and an integer target, are there elements
 * a, b, c, and d in nums such that a + b + c + d = target? Find all unique
 * quadruplets in the array which gives the sum of target.
 * 
 * Note:
 * 
 * The solution set must not contain duplicate quadruplets.
 * 
 * Example:
 * 
 * 
 * Given array nums = [1, 0, -1, 0, -2, 2], and target = 0.
 * 
 * A solution set is:
 * [
 * ⁠ [-1,  0, 0, 1],
 * ⁠ [-2, -1, 1, 2],
 * ⁠ [-2,  0, 0, 2]
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 4)
            return list;
        Array.Sort(nums);

        for (int f = 0; f < nums.Length; f++)
        {
            if (f > 0 && nums[f] == nums[f - 1])
                continue;
            // if(nums[f] > target)
            //     break;

            int tar = target - nums[f];
            for (int i = f+1; i < nums.Length; i++)
            {
                if (i > f+1 && nums[i] == nums[i - 1])
                    continue;
                // if (nums[i] > tar)//第一个数大于0相加肯定大于0
                //     break;
                int j = i + 1, k = nums.Length - 1;
                while (j < k)
                {
                    int v = nums[i] + nums[j] + nums[k];
                    if (v > tar)
                        k--;
                    else if (v < tar)
                        j++;
                    else
                    {
                        list.Add(new List<int>() { nums[f], nums[i], nums[j], nums[k] });

                        while (j < k && nums[j] == nums[j + 1]) j++;
                        while (k > j && nums[k] == nums[k - 1]) k--;
                        j++;
                        k--;
                    }
                }
            }
        }
        

        return list;
    }
}


//根据15题改写，变成3个数相加
// √ Accepted
//   √ 282/282 cases passed (272 ms)
//   √ Your runtime beats 96.65 % of csharp submissions
//   √ Your memory usage beats 88.89 % of csharp submissions (30 MB)
