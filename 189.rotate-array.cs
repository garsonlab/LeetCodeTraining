/*
 * @lc app=leetcode id=189 lang=csharp
 *
 * [189] Rotate Array
 *
 * https://leetcode.com/problems/rotate-array/description/
 *
 * algorithms
 * Easy (29.23%)
 * Total Accepted:    276.6K
 * Total Submissions: 943.9K
 * Testcase Example:  '[1,2,3,4,5,6,7]\n3'
 *
 * Given an array, rotate the array to the right by k steps, where k is
 * non-negative.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3,4,5,6,7] and k = 3
 * Output: [5,6,7,1,2,3,4]
 * Explanation:
 * rotate 1 steps to the right: [7,1,2,3,4,5,6]
 * rotate 2 steps to the right: [6,7,1,2,3,4,5]
 * rotate 3 steps to the right: [5,6,7,1,2,3,4]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [-1,-100,3,99] and k = 2
 * Output: [3,99,-1,-100]
 * Explanation: 
 * rotate 1 steps to the right: [99,-1,-100,3]
 * rotate 2 steps to the right: [3,99,-1,-100]
 * 
 * 
 * Note:
 * 
 * 
 * Try to come up as many solutions as you can, there are at least 3 different
 * ways to solve this problem.
 * Could you do it in-place with O(1) extra space?
 * 
 */
public class Solution {
    public void Rotate(int[] nums, int k) {
        if (nums.Length <= 1 || k <= 0)
            return;
            
        k = k % nums.Length;
        if(k == 0)
            return;
        Reverse(ref nums, 0, nums.Length-1);
        Reverse(ref nums, 0, k-1);
        Reverse(ref nums, k, nums.Length-1);
    }

    private void Reverse(ref int[] nums, int start, int end)
    {
        for (int i = start, j = end; i < j; i++, j--)
        {
            int tem = nums[i];
            nums[i] = nums[j];
            nums[j] = tem;
        }
    }
}

// √ Accepted
//   √ 34/34 cases passed (252 ms)
//   √ Your runtime beats 90.06 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (30.5 MB)


