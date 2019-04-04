/*
 * @lc app=leetcode id=541 lang=csharp
 *
 * [541] Reverse String II
 *
 * https://leetcode.com/problems/reverse-string-ii/description/
 *
 * algorithms
 * Easy (45.10%)
 * Total Accepted:    56.6K
 * Total Submissions: 125.3K
 * Testcase Example:  '"abcdefg"\n2'
 *
 * 
 * Given a string and an integer k, you need to reverse the first k characters
 * for every 2k characters counting from the start of the string. If there are
 * less than k characters left, reverse all of them. If there are less than 2k
 * but greater than or equal to k characters, then reverse the first k
 * characters and left the other as original.
 * 
 * 
 * Example:
 * 
 * Input: s = "abcdefg", k = 2
 * Output: "bacdfeg"
 * 
 * 
 * 
 * Restrictions: 
 * 
 * ⁠The string consists of lower English letters only.
 * ⁠Length of the given string and k will in the range [1, 10000]
 * 
 */
public class Solution {
    public string ReverseStr(string s, int k) {
        List<char> chars = new List<char>(s.Length);
        int flag = 0;
        for (int i = 0; i < s.Length;)
        {
            int m = Math.Min(s.Length - 1, i + k - 1);
            if (flag++ % 2 == 0)
            {
                for (int j = m; j >= i; j--)
                {
                    chars.Add(s[j]);
                }
            }
            else
            {
                for (int j = i; j <= m; j++)
                {
                    chars.Add(s[j]);
                }
            }

            i += k;
        }
        return new string(chars.ToArray());
    }
}


// √ Accepted
//   √ 60/60 cases passed (88 ms)
//   √ Your runtime beats 94.62 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (23.6 MB)

