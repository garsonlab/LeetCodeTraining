/*
 * @lc app=leetcode id=47 lang=csharp
 *
 * [47] Permutations II
 *
 * https://leetcode.com/problems/permutations-ii/description/
 *
 * algorithms
 * Medium (39.82%)
 * Total Accepted:    232.8K
 * Total Submissions: 584.1K
 * Testcase Example:  '[1,1,2]'
 *
 * Given a collection of numbers that might contain duplicates, return all
 * possible unique permutations.
 * 
 * Example:
 * 
 * 
 * Input: [1,1,2]
 * Output:
 * [
 * ⁠ [1,1,2],
 * ⁠ [1,2,1],
 * ⁠ [2,1,1]
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        bool[] use = new bool[nums.Length];
        IList<IList<int>> list = new List<IList<int>>();
        Array.Sort(nums);
        DepPermute(list, ref nums, ref use, new List<int>());
        return list;
    }

    private void DepPermute(IList<IList<int>> list, ref int[] nums, ref bool[] use, List<int> cur)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (!use[i])
            {

                if (i != 0 && nums[i - 1] == nums[i] && !use[i - 1])
                {
                    continue;
                }
                use[i] = true;
                var tem = new List<int>(cur);
                tem.Add(nums[i]);
                if (tem.Count == nums.Length)
                    list.Add(tem);
                else
                    DepPermute(list, ref nums, ref use, tem);

                use[i] = false;
            }
        }
    }
}

// √ Accepted
//   √ 30/30 cases passed (256 ms)
//   √ Your runtime beats 88.66 % of csharp submissions
//   √ Your memory usage beats 52.94 % of csharp submissions (31.3 MB)

