/*
 * @lc app=leetcode id=39 lang=csharp
 *
 * [39] Combination Sum
 *
 * https://leetcode.com/problems/combination-sum/description/
 *
 * algorithms
 * Medium (47.60%)
 * Total Accepted:    324.6K
 * Total Submissions: 681.3K
 * Testcase Example:  '[2,3,6,7]\n7'
 *
 * Given a set of candidate numbers (candidates) (without duplicates) and a
 * target number (target), find all unique combinations in candidates where the
 * candidate numbers sums to target.
 * 
 * The same repeated number may be chosen from candidates unlimited number of
 * times.
 * 
 * Note:
 * 
 * 
 * All numbers (including target) will be positive integers.
 * The solution set must not contain duplicate combinations.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: candidates = [2,3,6,7], target = 7,
 * A solution set is:
 * [
 * ⁠ [7],
 * ⁠ [2,2,3]
 * ]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: candidates = [2,3,5], target = 8,
 * A solution set is:
 * [
 * [2,2,2,2],
 * [2,3,3],
 * [3,5]
 * ]
 * 
 * 
 */
public class Solution {

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> list = new List<IList<int>>();
        Array.Sort(candidates);
        DepSum(list, ref candidates, "", target, 0);
        return list;
    }

    private void DepSum(IList<IList<int>> list, ref int[] candidates, string p, int target, int idx)
    {
        for (int i = idx; i < candidates.Length; i++)
        {
            if (target - candidates[i] == 0)
            {
                var t = new List<int>();
                for (int j = 0; j < p.Length; j++)
                {
                    t.Add(candidates[p[j] - 1]);
                }
                t.Add(candidates[i]);
                list.Add(t);
            }
            else if (candidates[i] < target)//直接用字符串做拷贝，避免char 0,故+1
            {
                DepSum(list, ref candidates, p + (char)(i+1), target - candidates[i], i);
            }
        }
    }
}

// √ Accepted
//   √ 168/168 cases passed (252 ms)
//   √ Your runtime beats 98.81 % of csharp submissions
//   √ Your memory usage beats 16.98 % of csharp submissions (30.7 MB)

