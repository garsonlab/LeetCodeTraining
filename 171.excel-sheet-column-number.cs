/*
 * @lc app=leetcode id=171 lang=csharp
 *
 * [171] Excel Sheet Column Number
 *
 * https://leetcode.com/problems/excel-sheet-column-number/description/
 *
 * algorithms
 * Easy (51.00%)
 * Total Accepted:    210.8K
 * Total Submissions: 413.1K
 * Testcase Example:  '"A"'
 *
 * Given a column title as appear in an Excel sheet, return its corresponding
 * column number.
 * 
 * For example:
 * 
 * 
 * ⁠   A -> 1
 * ⁠   B -> 2
 * ⁠   C -> 3
 * ⁠   ...
 * ⁠   Z -> 26
 * ⁠   AA -> 27
 * ⁠   AB -> 28 
 * ⁠   ...
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "A"
 * Output: 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "AB"
 * Output: 28
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "ZY"
 * Output: 701
 * 
 */
public class Solution {
    public int TitleToNumber(string s) {
        
        int r = 0;
        int dig = 1;
        for (int i = s.Length-1; i >= 0; i--)
        {
            r += (s[i] - 64) * dig;
            dig *= 26;
        }

        return r;
    }
}
// √ Accepted
//   √ 1000/1000 cases passed (76 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 71.43 % of csharp submissions (22.5 MB)

