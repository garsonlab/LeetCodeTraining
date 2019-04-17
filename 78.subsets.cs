/*
 * @lc app=leetcode id=78 lang=csharp
 *
 * [78] Subsets
 *
 * https://leetcode.com/problems/subsets/description/
 *
 * algorithms
 * Medium (51.94%)
 * Total Accepted:    349.8K
 * Total Submissions: 672.5K
 * Testcase Example:  '[1,2,3]'
 *
 * Given a set of distinct integers, nums, return all possible subsets (the
 * power set).
 * 
 * Note: The solution set must not contain duplicate subsets.
 * 
 * Example:
 * 
 * 
 * Input: nums = [1,2,3]
 * Output:
 * [
 * ⁠ [3],
 * [1],
 * [2],
 * [1,2,3],
 * [1,3],
 * [2,3],
 * [1,2],
 * []
 * ]
 * 
 */
public class Solution {
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();

        GetSub(list, ref nums, new List<int>(), 0);
        return list;
    }

    private void GetSub(IList<IList<int>> list, ref int[] nums, List<int> cur, int idx)
    {
        list.Add(cur);
        for (int i = idx; i < nums.Length; i++)
        {
            List<int> tem = new List<int>(cur);
            tem.Add(nums[i]);
            GetSub(list, ref nums, tem, i+1);
        }
    }
}

// √ Accepted
//   √ 10/10 cases passed (252 ms)
//   √ Your runtime beats 59.44 % of csharp submissions
//   √ Your memory usage beats 30.61 % of csharp submissions (28.9 MB)

