/*
 * @lc app=leetcode id=747 lang=csharp
 *
 * [747] Largest Number At Least Twice of Others
 *
 * https://leetcode.com/problems/largest-number-at-least-twice-of-others/description/
 *
 * algorithms
 * Easy (40.27%)
 * Total Accepted:    46.2K
 * Total Submissions: 114.7K
 * Testcase Example:  '[0,0,0,1]'
 *
 * In a given integer array nums, there is always exactly one largest element.
 * 
 * Find whether the largest element in the array is at least twice as much as
 * every other number in the array.
 * 
 * If it is, return the index of the largest element, otherwise return -1.
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [3, 6, 1, 0]
 * Output: 1
 * Explanation: 6 is the largest integer, and for every other number in the
 * array x,
 * 6 is more than twice as big as x.  The index of value 6 is 1, so we return
 * 1.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1, 2, 3, 4]
 * Output: -1
 * Explanation: 4 isn't at least as big as twice the value of 3, so we return
 * -1.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * nums will have a length in the range [1, 50].
 * Every nums[i] will be an integer in the range [0, 99].
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int DominantIndex(int[] nums) {
        if (nums.Length < 0)
            return -1;
        if (nums.Length == 1)
            return 0;

        int idx = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[idx])
                idx = i;
        }


        for (int i = 0; i < nums.Length; i++)
        {
            if (i != idx)
            {
                if (nums[idx] < nums[i] * 2)
                    return -1;
            }
        }

        return idx;
    }
}

// √ Accepted
//   √ 250/250 cases passed (92 ms)
//   √ Your runtime beats 91.01 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (22.6 MB)

