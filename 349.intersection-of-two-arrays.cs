/*
 * @lc app=leetcode id=349 lang=csharp
 *
 * [349] Intersection of Two Arrays
 *
 * https://leetcode.com/problems/intersection-of-two-arrays/description/
 *
 * algorithms
 * Easy (53.35%)
 * Total Accepted:    204.8K
 * Total Submissions: 382.6K
 * Testcase Example:  '[1,2,2,1]\n[2,2]'
 *
 * Given two arrays, write a function to compute their intersection.
 * 
 * Example 1:
 * 
 * 
 * Input: nums1 = [1,2,2,1], nums2 = [2,2]
 * Output: [2]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * Output: [9,4]
 * 
 * 
 * Note:
 * 
 * 
 * Each element in the result must be unique.
 * The result can be in any order.
 * 
 * 
 * 
 * 
 */
using System.Collections.Generic;

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        Dictionary<int, int> marks = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            marks[nums1[i]] = 1;
        }

        List<int> inters = new List<int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            if(marks.ContainsKey(nums2[i]))
            {
                inters.Add(nums2[i]);
                marks.Remove(nums2[i]);
            }
        }
        return inters.ToArray();
    }
}

// √ Accepted
//   √ 60/60 cases passed (248 ms)
//   √ Your runtime beats 93.95 % of csharp submissions
//   √ Your memory usage beats 32.65 % of csharp submissions (29.3 MB)

