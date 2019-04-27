/*
 * @lc app=leetcode id=238 lang=csharp
 *
 * [238] Product of Array Except Self

 Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Example:

Input:  [1,2,3,4]
Output: [24,12,8,6]
Note: Please solve it without division and in O(n).

Follow up:
Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)
 */
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] ret = new int[nums.Length];
        int a = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            ret[i] = a;
            a*=nums[i];
        }

        a = 1;
        for (int i = nums.Length-1; i >= 0; i--)
        {
            ret[i]*=a;
            a*=nums[i];
        }
        return ret;
    }
}

// √ Accepted
//   √ 17/17 cases passed (260 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 70.73 % of csharp submissions (35 MB)

