/*
 * @lc app=leetcode id=704 lang=csharp
 *
 * [704] Binary Search
 *
 * https://leetcode.com/problems/binary-search/description/
 *
 * algorithms
 * Easy (45.87%)
 * Total Accepted:    40.6K
 * Total Submissions: 87.4K
 * Testcase Example:  '[-1,0,3,5,9,12]\n9'
 *
 * Given a sorted (in ascending order) integer array nums of n elements and a
 * target value, write a function to search target in nums. If target exists,
 * then return its index, otherwise return -1.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [-1,0,3,5,9,12], target = 9
 * Output: 4
 * Explanation: 9 exists in nums and its index is 4
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [-1,0,3,5,9,12], target = 2
 * Output: -1
 * Explanation: 2 does not exist in nums so return -1
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * You may assume that all elements in nums are unique.
 * n will be in the range [1, 10000].
 * The value of each element in nums will be in the range [-9999, 9999].
 * 
 * 
 */
public class Solution {
    public int Search(int[] nums, int target)
    {
        return BinarySerch(ref nums, 0, nums.Length - 1, target);
    }

    private int BinarySerch(ref int[] nums, int start, int end, int target)
    {
        if (start > end)
            return -1;
        if (start == end)
        {
            if (nums[start] != target)
                return -1;

            return start;
        }

        int mid = (start + 1) / 2 + end / 2;
        if (nums[mid] < target)
            return BinarySerch(ref nums, mid + 1, end, target);
        else if (nums[mid] == target)
            return mid;
        else
            return BinarySerch(ref nums, start, mid - 1, target);
    }
}

// √ Accepted
//   √ 46/46 cases passed (132 ms)
//   √ Your runtime beats 97.08 % of csharp submissions
//   √ Your memory usage beats 72.41 % of csharp submissions (33.2 MB)

