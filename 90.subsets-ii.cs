/*
 * @lc app=leetcode id=90 lang=csharp
 *
 * [90] Subsets II
 *
 * https://leetcode.com/problems/subsets-ii/description/
 *
 * algorithms
 * Medium (41.92%)
 * Total Accepted:    196.5K
 * Total Submissions: 468.1K
 * Testcase Example:  '[1,2,2]'
 *
 * Given a collection of integers that might contain duplicates, nums, return
 * all possible subsets (the power set).
 * 
 * Note: The solution set must not contain duplicate subsets.
 * 
 * Example:
 * 
 * 
 * Input: [1,2,2]
 * Output:
 * [
 * ⁠ [2],
 * ⁠ [1],
 * ⁠ [1,2,2],
 * ⁠ [2,2],
 * ⁠ [1,2],
 * ⁠ []
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> list = new List<IList<int>>();
        Array.Sort(nums);
        GetSub2(list, ref nums, new List<int>(), 0);
        return list;
    }

    private void GetSub2(IList<IList<int>> list, ref int[] nums, List<int> cur, int idx)
    {
        list.Add(cur);
        for (int i = idx; i < nums.Length; i++)
        {
            if(i > idx && nums[i] == nums[i-1])
                continue;
            List<int> tem = new List<int>(cur);
            tem.Add(nums[i]);
            GetSub2(list, ref nums, tem, i + 1);
        }
    }
}

// √ Accepted
//   √ 19/19 cases passed (272 ms)
//   √ Your runtime beats 50.45 % of csharp submissions
//   √ Your memory usage beats 31.82 % of csharp submissions (29.4 MB)

