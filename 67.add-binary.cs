/*
 * @lc app=leetcode id=67 lang=csharp
 *
 * [67] Add Binary
 *
 * https://leetcode.com/problems/add-binary/description/
 *
 * algorithms
 * Easy (38.22%)
 * Total Accepted:    283.2K
 * Total Submissions: 740.6K
 * Testcase Example:  '"11"\n"1"'
 *
 * Given two binary strings, return their sum (also a binary string).
 * 
 * The input strings are both non-empty and contains only characters 1 or 0.
 * 
 * Example 1:
 * 
 * 
 * Input: a = "11", b = "1"
 * Output: "100"
 * 
 * Example 2:
 * 
 * 
 * Input: a = "1010", b = "1011"
 * Output: "10101"
 * 
 */
public class Solution {
    public string AddBinary(string a, string b) {
        int length = a.Length >= b.Length ? b.Length : a.Length;
        int maxLen = a.Length >= b.Length ? a.Length : b.Length;
        int la = a.Length - length, lb = b.Length - length;
        int off = la >= lb ? la : lb;
        int add = 0;
        char[] chars = new char[maxLen];
        for (int i = length - 1; i >= 0; i--)
        {
            int val = a[la + i] - 48 + b[lb + i] - 48 + add;
            chars[i + off] = (char) (48 + val % 2);
            add = val / 2;
        }
        if (la > 0)
        {
            for (int i = la-1; i >= 0; i--)
            {
                int c = a[i] - 48 + add;
                chars[i] = (char) (48 + c % 2);
                add = c / 2;
            }
        }
        else if (lb > 0)
        {
            for (int i = lb-1; i >= 0; i--)
            {
                int c = b[i] - 48 + add;
                chars[i] = (char)(48 + c % 2);
                add = c / 2;
            }
        }

        if (add > 0)
        {
            return add + new String(chars);
        }
        else
            return new String(chars);
    }
}

// √ Accepted
//   √ 294/294 cases passed (84 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 95.45 % of csharp submissions (22.4 MB)


