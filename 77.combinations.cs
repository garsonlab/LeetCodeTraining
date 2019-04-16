/*
 * @lc app=leetcode id=77 lang=csharp
 *
 * [77] Combinations
 *
 * https://leetcode.com/problems/combinations/description/
 *
 * algorithms
 * Medium (46.83%)
 * Total Accepted:    194.7K
 * Total Submissions: 415.1K
 * Testcase Example:  '4\n2'
 *
 * Given two integers n and k, return all possible combinations of k numbers
 * out of 1 ... n.
 * 
 * Example:
 * 
 * 
 * Input: n = 4, k = 2
 * Output:
 * [
 * ⁠ [2,4],
 * ⁠ [3,4],
 * ⁠ [2,3],
 * ⁠ [1,2],
 * ⁠ [1,3],
 * ⁠ [1,4],
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (n == 0 || k == 0)
            return list;
        CombineK(list, new List<int>(), 1, n, k);

        return list;
    }

    private void CombineK(IList<IList<int>> list, List<int> cur, int idx, int n, int k)
    {
        for (int i = idx; i <= n; i++)
        {
            var tem = new List<int>(cur);
            tem.Add(i);
            if (tem.Count == k)
            {
                list.Add(tem);
            }
            else
                CombineK(list, tem, i+1, n, k);
        }
    }
}

// √ Accepted
//   √ 27/27 cases passed (344 ms)
//   √ Your runtime beats 21.76 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (28 MB)

