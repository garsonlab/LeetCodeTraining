/*
 * @lc app=leetcode id=1 lang=csharp
 *
 * [1] Two Sum
 *
 * https://leetcode.com/problems/two-sum/description/
 *
 * algorithms
 * Easy (42.57%)
 * Total Accepted:    1.6M
 * Total Submissions: 3.7M
 * Testcase Example:  '[2,7,11,15]\n9'
 *
 * Given an array of integers, return indices of the two numbers such that they
 * add up to a specific target.
 * 
 * You may assume that each input would have exactly one solution, and you may
 * not use the same element twice.
 * 
 * Example:
 * 
 * 
 * Given nums = [2, 7, 11, 15], target = 9,
 * 
 * Because nums[0] + nums[1] = 2 + 7 = 9,
 * return [0, 1].
 * 
 * 
 * 
 * 
 */
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> marks = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int left = target-nums[i];
            if (marks.ContainsKey(left))
            {
                return new int[]{marks[left], i};
            }
            else
            {
                marks[nums[i]] = i;
            }
        }
        return null;
    }
}

