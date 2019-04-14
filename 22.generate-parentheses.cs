/*
 * @lc app=leetcode id=22 lang=csharp
 *
 * [22] Generate Parentheses
 *
 * https://leetcode.com/problems/generate-parentheses/description/
 *
 * algorithms
 * Medium (54.07%)
 * Total Accepted:    320.7K
 * Total Submissions: 592.8K
 * Testcase Example:  '3'
 *
 * 
 * Given n pairs of parentheses, write a function to generate all combinations
 * of well-formed parentheses.
 * 
 * 
 * 
 * For example, given n = 3, a solution set is:
 * 
 * 
 * [
 * ⁠ "((()))",
 * ⁠ "(()())",
 * ⁠ "(())()",
 * ⁠ "()(())",
 * ⁠ "()()()"
 * ]
 * 
 */
public class Solution {
    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> list = new List<string>();
        if (n <= 0)
            return list;
        GP(list, "", n, n);
        return list;
    }

    private void GP(IList<string> list, string ret, int l, int r)
    {
        if (l > 0)
            GP(list, ret + "(", l - 1, r);
        if (r > l)
            GP(list, ret + ")", l, r - 1);

        if (l == 0 && r == 0)
            list.Add(ret);
    }
}

// √ Accepted
//   √ 8/8 cases passed (240 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 36.07 % of csharp submissions (31.1 MB)

