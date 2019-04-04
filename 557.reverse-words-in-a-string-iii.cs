/*
 * @lc app=leetcode id=557 lang=csharp
 *
 * [557] Reverse Words in a String III
 *
 * https://leetcode.com/problems/reverse-words-in-a-string-iii/description/
 *
 * algorithms
 * Easy (63.31%)
 * Total Accepted:    117.4K
 * Total Submissions: 185.1K
 * Testcase Example:  '"Let\'s take LeetCode contest"'
 *
 * Given a string, you need to reverse the order of characters in each word
 * within a sentence while still preserving whitespace and initial word order.
 * 
 * Example 1:
 * 
 * Input: "Let's take LeetCode contest"
 * Output: "s'teL ekat edoCteeL tsetnoc"
 * 
 * 
 * 
 * Note:
 * In the string, each word is separated by single space and there will not be
 * any extra space in the string.
 * 
 */
public class Solution {
    public string ReverseWords(string s) {
        string r = "";
        string tem = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                if (r.Length > 0)
                    r += " ";
                r += tem;
                tem = "";
            }
            else
            {
                tem = s[i] + tem;
            }
        }

        if (r.Length > 0)
            r += ' ';
        r += tem;

        return r;
    }
}

// √ Accepted
//   √ 30/30 cases passed (620 ms)
//   √ Your runtime beats 5.03 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (42.2 MB)

