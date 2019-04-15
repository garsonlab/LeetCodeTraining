/*
 * @lc app=leetcode id=46 lang=csharp
 *
 * [46] Permutations
 *
 * https://leetcode.com/problems/permutations/description/
 *
 * algorithms
 * Medium (54.33%)
 * Total Accepted:    360.7K
 * Total Submissions: 663.4K
 * Testcase Example:  '[1,2,3]'
 *
 * Given a collection of distinct integers, return all possible permutations.
 * 
 * Example:
 * 
 * 
 * Input: [1,2,3]
 * Output:
 * [
 * ⁠ [1,2,3],
 * ⁠ [1,3,2],
 * ⁠ [2,1,3],
 * ⁠ [2,3,1],
 * ⁠ [3,1,2],
 * ⁠ [3,2,1]
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> Permute(int[] nums)
    {
        bool[] use = new bool[nums.Length];
        IList<IList<int>> list = new List<IList<int>>();
        DepPermute(list, ref nums, ref use, new List<int>());
        return list;
    }

    private void DepPermute(IList<IList<int>> list, ref int[] nums, ref bool[] use, List<int> cur)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (!use[i])
            {
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
//   √ 25/25 cases passed (252 ms)
//   √ Your runtime beats 79.55 % of csharp submissions
//   √ Your memory usage beats 27.27 % of csharp submissions (30.4 MB)

