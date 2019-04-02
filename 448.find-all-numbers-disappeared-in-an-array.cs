/*
 * @lc app=leetcode id=448 lang=csharp
 *
 * [448] Find All Numbers Disappeared in an Array
 *
 * https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/description/
 *
 * algorithms
 * Easy (52.87%)
 * Total Accepted:    142.1K
 * Total Submissions: 268.5K
 * Testcase Example:  '[4,3,2,7,8,2,3,1]'
 *
 * Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some
 * elements appear twice and others appear once.
 * 
 * Find all the elements of [1, n] inclusive that do not appear in this array.
 * 
 * Could you do it without extra space and in O(n) runtime? You may assume the
 * returned list does not count as extra space.
 * 
 * Example:
 * 
 * Input:
 * [4,3,2,7,8,2,3,1]
 * 
 * Output:
 * [5,6]
 * 
 * 
 */
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        IList<int> list = new List<int>();
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            if (nums[i] != i+1)
            {
                int idx = nums[i];
                while (nums[idx-1] != idx)
                {
                    int n = nums[idx-1];
                    nums[idx-1] = idx;
                    idx = n;
                }
            }
        }

        for (int i = 0; i < len; i++)
        {
            if (nums[i] != i+1)
                list.Add(i+1);
        }

        return list;
    }
}

// √ Accepted
//   √ 34/34 cases passed (312 ms)
//   √ Your runtime beats 93.9 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (42.2 MB)

