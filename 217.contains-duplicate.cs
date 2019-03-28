/*
 * @lc app=leetcode id=217 lang=csharp
 *
 * [217] Contains Duplicate
 *
 * https://leetcode.com/problems/contains-duplicate/description/
 *
 * algorithms
 * Easy (51.07%)
 * Total Accepted:    313K
 * Total Submissions: 611.7K
 * Testcase Example:  '[1,2,3,1]'
 *
 * Given an array of integers, find if the array contains any duplicates.
 * 
 * Your function should return true if any value appears at least twice in the
 * array, and it should return false if every element is distinct.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3,1]
 * Output: true
 * 
 * Example 2:
 * 
 * 
 * Input: [1,2,3,4]
 * Output: false
 * 
 * Example 3:
 * 
 * 
 * Input: [1,1,1,3,3,4,3,2,4,2]
 * Output: true
 * 
 */
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(nums[i]))
                return true;
            else
                dic.Add(nums[i], 1);
        }

        return false;
    }
}

// √ Accepted
//   √ 18/18 cases passed (108 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 10.17 % of csharp submissions (30 MB)


