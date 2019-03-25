/*
 * @lc app=leetcode id=118 lang=csharp
 *
 * [118] Pascal's Triangle
 *
 * https://leetcode.com/problems/pascals-triangle/description/
 *
 * algorithms
 * Easy (44.90%)
 * Total Accepted:    235.1K
 * Total Submissions: 523K
 * Testcase Example:  '5'
 *
 * Given a non-negative integer numRows, generate the first numRows of Pascal's
 * triangle.
 * 
 * 
 * In Pascal's triangle, each number is the sum of the two numbers directly
 * above it.
 * 
 * Example:
 * 
 * 
 * Input: 5
 * Output:
 * [
 * ⁠    [1],
 * ⁠   [1,1],
 * ⁠  [1,2,1],
 * ⁠ [1,3,3,1],
 * ⁠[1,4,6,4,1]
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        
        List<IList<int>> results = new List<IList<int>>();
        if (numRows <= 0)
            return results;
        results.Add(new List<int>(){1});

        if (numRows >= 2)
        {
            results.Add(new List<int>(){1,1});
        }
        else
        {
            return results;
        }

        numRows -= 2;
        var tem = results[1];
        while (numRows-- > 0)
        {
            List<int> cur = new List<int>(){1};
            for (int i = 1; i < tem.Count; i++)
            {
                cur.Add(tem[i - 1] + tem[i]);
            }
            cur.Add(1);
            results.Add(cur);
            tem = cur;
        }

        return results;
    }
}

// √ Accepted
//   √ 15/15 cases passed (212 ms)
//   √ Your runtime beats 99.81 % of csharp submissions
//   √ Your memory usage beats 84.21 % of csharp submissions (23.3 MB)

