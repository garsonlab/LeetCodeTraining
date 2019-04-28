/*
 * @lc app=leetcode id=260 lang=csharp
 *
 * [260] Single Number III

 Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.

Example:

Input:  [1,2,1,3,2,5]
Output: [3,5]
Note:

The order of the result is not important. So in the above example, [5, 3] is also correct.
Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?
 */
public class Solution {
    public int[] SingleNumber(int[] nums) {
        List<int> list = new List<int>();
        if (nums.Length == 0)
            return list.ToArray();

        Array.Sort(nums);
        
        for (int i = 1; i < nums.Length;)
        {
            if (nums[i] == nums[i - 1])
            {
                i += 2;
            }
            else
            {
                list.Add(nums[i-1]);
                i++;
            }
        }

        if(list.Count < 2)
            list.Add(nums[nums.Length-1]);
        return list.ToArray();
    }
}

// √ Accepted
//   √ 30/30 cases passed (252 ms)
//   √ Your runtime beats 86.73 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (29.5 MB)

