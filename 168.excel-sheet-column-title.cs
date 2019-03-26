/*
 * @lc app=leetcode id=168 lang=csharp
 *
 * [168] Excel Sheet Column Title
 *
 * https://leetcode.com/problems/excel-sheet-column-title/description/
 *
 * algorithms
 * Easy (28.60%)
 * Total Accepted:    165.9K
 * Total Submissions: 579.3K
 * Testcase Example:  '1'
 *
 * Given a positive integer, return its corresponding column title as appear in
 * an Excel sheet.
 * 
 * For example:
 * 
 * 
 * ⁠   1 -> A
 * ⁠   2 -> B
 * ⁠   3 -> C
 * ⁠   ...
 * ⁠   26 -> Z
 * ⁠   27 -> AA
 * ⁠   28 -> AB 
 * ⁠   ...
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: 1
 * Output: "A"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 28
 * Output: "AB"
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: 701
 * Output: "ZY"
 * 
 */
public class Solution {
    public string ConvertToTitle(int n) {
        string result = "";
        while (n > 0)
        {
            result = (char) ((n - 1) % 26 + 65) + result;
            n = (n - 1) / 26;
        }

        return result;
    }
}

// √ Accepted
//   √ 18/18 cases passed (76 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 21.05 % of csharp submissions (20.3 MB)

