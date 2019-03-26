/*
 * @lc app=leetcode id=169 lang=csharp
 *
 * [169] Majority Element
 *
 * https://leetcode.com/problems/majority-element/description/
 *
 * algorithms
 * Easy (51.77%)
 * Total Accepted:    358.9K
 * Total Submissions: 692.5K
 * Testcase Example:  '[3,2,3]'
 *
 * Given an array of size n, find the majority element. The majority element is
 * the element that appears more than ⌊ n/2 ⌋ times.
 * 
 * You may assume that the array is non-empty and the majority element always
 * exist in the array.
 * 
 * Example 1:
 * 
 * 
 * Input: [3,2,3]
 * Output: 3
 * 
 * Example 2:
 * 
 * 
 * Input: [2,2,1,1,1,2,2]
 * Output: 2
 * 
 * 
 */
public class Solution {
    public int MajorityElement(int[] nums) {
        int major = nums[0];
        int count = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == major)
                count++;
            else if (--count <= 0)
            {
                major = nums[i];
                count = 1;
            }
        }

        return major;
    }
}

//想了一下，众数超多一半，假设最坏的是一个众数抵消一个其他的，最终还剩下一个肯定是众数，该方法叫摩尔投票法
//还可以排序取中间的或者遍历计数
// √ Accepted
//   √ 44/44 cases passed (108 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 79.59 % of csharp submissions (27.5 MB)

