/*
 * @lc app=leetcode id=119 lang=csharp
 *
 * [119] Pascal's Triangle II
 *
 * https://leetcode.com/problems/pascals-triangle-ii/description/
 *
 * algorithms
 * Easy (42.41%)
 * Total Accepted:    190.3K
 * Total Submissions: 448.1K
 * Testcase Example:  '3'
 *
 * Given a non-negative index k where k ≤ 33, return the k^th index row of the
 * Pascal's triangle.
 * 
 * Note that the row index starts from 0.
 * 
 * 
 * In Pascal's triangle, each number is the sum of the two numbers directly
 * above it.
 * 
 * Example:
 * 
 * 
 * Input: 3
 * Output: [1,3,3,1]
 * 
 * 
 * Follow up:
 * 
 * Could you optimize your algorithm to use only O(k) extra space?
 * 
 */
public class Solution {
    public IList<int> GetRow(int rowIndex) {
        
        rowIndex += 1;
        List<int> result = new List<int>(rowIndex);
        if (rowIndex <= 0)
            return result;
        result.Add(1);
        if (rowIndex <= 1)
            return result;
        result.Add(1);
        for (int i = 3; i <= rowIndex; i++)
        {
            result.Add(1);
            for (int j = i-2; j > 0; j--)
            {
                result[j] = result[j] + result[j-1];
            }

            result[0] = 1;
        }

        return result;
    }
}

// √ Accepted
//   √ 34/34 cases passed (232 ms)
//   √ Your runtime beats 64.58 % of csharp submissions
//   √ Your memory usage beats 97.56 % of csharp submissions (22.9 MB)


