/*
 * @lc app=leetcode id=665 lang=csharp
 *
 * [665] Non-decreasing Array
 *
 * https://leetcode.com/problems/non-decreasing-array/description/
 *
 * algorithms
 * Easy (19.46%)
 * Total Accepted:    47.3K
 * Total Submissions: 243.3K
 * Testcase Example:  '[4,2,3]'
 *
 * 
 * Given an array with n integers, your task is to check if it could become
 * non-decreasing by modifying at most 1 element.
 * 
 * 
 * 
 * We define an array is non-decreasing if array[i]  holds for every i (1 
 * 
 * Example 1:
 * 
 * Input: [4,2,3]
 * Output: True
 * Explanation: You could modify the first 4 to 1 to get a non-decreasing
 * array.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: [4,2,1]
 * Output: False
 * Explanation: You can't get a non-decreasing array by modify at most one
 * element.
 * 
 * 
 * 
 * Note:
 * The n belongs to [1, 10,000].
 * 12512
 */
public class Solution {
    public bool CheckPossibility(int[] nums) {
        if (nums.Length < 3)
            return true;

        int cnt = 0;
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] < nums[i - 1]){
                cnt++;
                if(i - 2 >= 0 && nums[i - 2] > nums[i]) nums[i] = nums[i-1];
                else nums[i - 1] = nums[i];
            }
        }
        return cnt <= 1;
    }
}

//如果后一个小于前一个，尝试把这个两个位置设置成相同的
// √ Accepted
//   √ 325/325 cases passed (120 ms)
//   √ Your runtime beats 90.86 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (29.8 MB)

