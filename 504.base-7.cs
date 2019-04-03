/*
 * @lc app=leetcode id=504 lang=csharp
 *
 * [504] Base 7
 *
 * https://leetcode.com/problems/base-7/description/
 *
 * algorithms
 * Easy (44.64%)
 * Total Accepted:    39.5K
 * Total Submissions: 88.3K
 * Testcase Example:  '100'
 *
 * Given an integer, return its base 7 string representation.
 * 
 * Example 1:
 * 
 * Input: 100
 * Output: "202"
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: -7
 * Output: "-10"
 * 
 * 
 * 
 * Note:
 * The input will be in range of [-1e7, 1e7].
 * 
 */
public class Solution {
    public string ConvertToBase7(int num) {
        if (num == 0)
            return "0";

        bool s = num < 0;
        string r = "";
        num = Math.Abs(num);
        while (num > 0)
        {
            r = (num % 7) + r;
            num = num / 7;
        }

        if (s)
            r = "-" + r;
        return r;
    }
}

// √ Accepted
//   √ 241/241 cases passed (104 ms)
//   √ Your runtime beats 15.69 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (20.9 MB)

