/*
 * @lc app=leetcode id=219 lang=csharp
 *
 * [219] Contains Duplicate II
 *
 * https://leetcode.com/problems/contains-duplicate-ii/description/
 *
 * algorithms
 * Easy (34.83%)
 * Total Accepted:    187.9K
 * Total Submissions: 538.8K
 * Testcase Example:  '[1,2,3,1]\n3'
 *
 * Given an array of integers and an integer k, find out whether there are two
 * distinct indices i and j in the array such that nums[i] = nums[j] and the
 * absolute difference between i and j is at most k.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,3,1], k = 3
 * Output: true
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [1,0,1,1], k = 1
 * Output: true
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [1,2,3,1,2,3], k = 2
 * Output: false
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            List<int> list;
            if (!dic.TryGetValue(nums[i], out list))
            {
                list = new List<int>();
                dic.Add(nums[i], list);
            }

            for (int j = 0; j < list.Count; j++)
            {
                if (Math.Abs(list[j] - i) <= k)
                    return true;
            }
            list.Add(i);
        }

        return false;
    }
}

// √ Accepted
//   √ 23/23 cases passed (112 ms)
//   √ Your runtime beats 71.01 % of csharp submissions
//   √ Your memory usage beats 6.25 % of csharp submissions (33.8 MB)

