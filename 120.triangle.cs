/*
 * @lc app=leetcode id=120 lang=csharp
 *
 * [120] Triangle
 *
 * https://leetcode.com/problems/triangle/description/
 *
 * algorithms
 * Medium (38.83%)
 * Total Accepted:    176.2K
 * Total Submissions: 452.9K
 * Testcase Example:  '[[2],[3,4],[6,5,7],[4,1,8,3]]'
 *
 * Given a triangle, find the minimum path sum from top to bottom. Each step
 * you may move to adjacent numbers on the row below.
 * 
 * For example, given the following triangle
 * 
 * 
 * [
 * ⁠    [2],
 * ⁠   [3,4],
 * ⁠  [6,5,7],
 * ⁠ [4,1,8,3]
 * ]
 * 
 * 
 * The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
 * 
 * Note:
 * 
 * Bonus point if you are able to do this using only O(n) extra space, where n
 * is the total number of rows in the triangle.
 * 
 */
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        if (triangle.Count == 0)
            return 0;
        for (int i = 1; i < triangle.Count; i++)
        {
            IList<int> row = triangle[i];
            row[0] += triangle[i - 1][0];
            row[i] += triangle[i - 1][i - 1];
            for (int j = 1; j < i; j++)
            {
                row[j] += Math.Min(triangle[i - 1][j-1], triangle[i - 1][j]);
            }
        }

        int total = triangle[triangle.Count-1][0];
        foreach (var i in triangle[triangle.Count-1])
        {
            if (i < total)
                total = i;
        }
        return total;
    }
}

// √ Accepted
//   √ 43/43 cases passed (100 ms)
//   √ Your runtime beats 67.98 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (22.3 MB)

