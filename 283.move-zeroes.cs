/*
 * @lc app=leetcode id=283 lang=csharp
 *
 * [283] Move Zeroes
 *
 * https://leetcode.com/problems/move-zeroes/description/
 *
 * algorithms
 * Easy (53.79%)
 * Total Accepted:    437.8K
 * Total Submissions: 812.6K
 * Testcase Example:  '[0,1,0,3,12]'
 *
 * Given an array nums, write a function to move all 0's to the end of it while
 * maintaining the relative order of the non-zero elements.
 * 
 * Example:
 * 
 * 
 * Input: [0,1,0,3,12]
 * Output: [1,3,12,0,0]
 * 
 * Note:
 * 
 * 
 * You must do this in-place without making a copy of the array.
 * Minimize the total number of operations.
 * 
 */
public class Solution {
    public void MoveZeroes(int[] nums) {
        for (int i = 0, j = 0; i < nums.Length && j < nums.Length; i++, j++)
        {
            if (nums[i] != 0)
            {
                continue;
            }

            if (nums[j] == 0)
            {
                i--;
                continue;
            }

            nums[i] = nums[j];
            nums[j] = 0;
        }
    }
}

// √ Accepted
//   √ 21/21 cases passed (260 ms)
//   √ Your runtime beats 71.55 % of csharp submissions
//   √ Your memory usage beats 84.35 % of csharp submissions (29.9 MB)


