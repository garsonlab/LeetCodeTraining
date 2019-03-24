/*
 * @lc app=leetcode id=35 lang=csharp
 *
 * [35] Search Insert Position
 *
 * https://leetcode.com/problems/search-insert-position/description/
 *
 * algorithms
 * Easy (40.55%)
 * Total Accepted:    372.5K
 * Total Submissions: 918.5K
 * Testcase Example:  '[1,3,5,6]\n5'
 *
 * Given a sorted array and a target value, return the index if the target is
 * found. If not, return the index where it would be if it were inserted in
 * order.
 * 
 * You may assume no duplicates in the array.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,3,5,6], 5
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,3,5,6], 2
 * Output: 1
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [1,3,5,6], 7
 * Output: 4
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: [1,3,5,6], 0
 * Output: 0
 * 
 * 
 */
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == target || nums[i] > target)
                return i;
        }
        return nums.Length;
    }
}
// √ Accepted
//   √ 62/62 cases passed (92 ms)
//   √ Your runtime beats 99.87 % of csharp submissions
//   √ Your memory usage beats 30 % of csharp submissions (22.6 MB)

