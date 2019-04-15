/*
 * @lc app=leetcode id=40 lang=csharp
 *
 * [40] Combination Sum II
 *
 * https://leetcode.com/problems/combination-sum-ii/description/
 *
 * algorithms
 * Medium (40.88%)
 * Total Accepted:    211.5K
 * Total Submissions: 516.9K
 * Testcase Example:  '[10,1,2,7,6,1,5]\n8'
 *
 * Given a collection of candidate numbers (candidates) and a target number
 * (target), find all unique combinations in candidates where the candidate
 * numbers sums to target.
 * 
 * Each number in candidates may only be used once in the combination.
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
 * Input: candidates = [10,1,2,7,6,1,5], target = 8,
 * A solution set is:
 * [
 * ⁠ [1, 7],
 * ⁠ [1, 2, 5],
 * ⁠ [2, 6],
 * ⁠ [1, 1, 6]
 * ]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: candidates = [2,5,2,1,2], target = 5,
 * A solution set is:
 * [
 * [1,2,2],
 * [5]
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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
            if(i > idx && candidates[i] == candidates[i-1])
                continue;

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
                DepSum(list, ref candidates, p + (char)(i+1), target - candidates[i], i+1);
            }
        }
    }
}

// √ Accepted
//   √ 172/172 cases passed (252 ms)
//   √ Your runtime beats 98.14 % of csharp submissions
//   √ Your memory usage beats 45.83 % of csharp submissions (29.5 MB)

