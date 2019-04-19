/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 *
 * https://leetcode.com/problems/reverse-words-in-a-string/description/
 *
 * algorithms
 * Medium (16.33%)
 * Total Accepted:    271.6K
 * Total Submissions: 1.7M
 * Testcase Example:  '"the sky is blue"'
 *
 * Given an input string, reverse the string word by word.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "the sky is blue"
 * Output: "blue is sky the"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "  hello world!  "
 * Output: "world! hello"
 * Explanation: Your reversed string should not contain leading or trailing
 * spaces.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "a good   example"
 * Output: "example good a"
 * Explanation: You need to reduce multiple spaces between two words to a
 * single space in the reversed string.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * A word is defined as a sequence of non-space characters.
 * Input string may contain leading or trailing spaces. However, your reversed
 * string should not contain leading or trailing spaces.
 * You need to reduce multiple spaces between two words to a single space in
 * the reversed string.
 * 
 * 
 * 
 * 
 * Follow up:
 * 
 * For C programmers, try to solve it in-place in O(1) extra space.
 */
public class Solution {
    public string ReverseWords(string s) {
        StringBuilder builder = new StringBuilder();
        string ret = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                if (builder.Length > 0)
                {
                    if (ret.Length > 0)
                        ret = " " + ret;
                    ret = builder.ToString() + ret;

                    builder.Length = 0;
                }
            }
            else
            {
                builder.Append(s[i]);
            }
        }
        if (builder.Length > 0)
        {
            if (ret.Length > 0)
                ret = " " + ret;
            ret = builder.ToString() + ret;
        }


        return ret;
    }
}
// √ Accepted
//   √ 25/25 cases passed (216 ms)
//   √ Your runtime beats 5.45 % of csharp submissions
//   √ Your memory usage beats 6.15 % of csharp submissions (41.4 MB)
