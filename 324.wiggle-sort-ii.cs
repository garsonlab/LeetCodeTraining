/*
 * @lc app=leetcode id=324 lang=csharp
 *
 * [324] Wiggle Sort II

 Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....

Example 1:

Input: nums = [1, 5, 1, 1, 6, 4]
Output: One possible answer is [1, 4, 1, 5, 1, 6].
Example 2:

Input: nums = [1, 3, 2, 2, 3, 1]
Output: One possible answer is [2, 3, 1, 3, 1, 2].
Note:
You may assume all input has valid answer.

Follow Up:
Can you do it in O(n) time and/or in-place with O(1) extra space?
 */
public class Solution {
    public void WiggleSort(int[] nums) {
         List<int> list = new List<int>(nums);
        list.Sort();
        int n = nums.Length, l = (n + 1) / 2, r = n;
        for (int i = 0; i < n; i++)
        {
            nums[i] = (i & 1) > 0 ? list[--r] : list[--l];
        }
    }
}

// √ Accepted
//   √ 44/44 cases passed (280 ms)
//   √ Your runtime beats 88.89 % of csharp submissions
//   √ Your memory usage beats 38.46 % of csharp submissions (34.1 MB)

