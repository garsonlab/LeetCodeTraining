/*
 * @lc app=leetcode id=459 lang=csharp
 *
 * [459] Repeated Substring Pattern
 *
 * https://leetcode.com/problems/repeated-substring-pattern/description/
 *
 * algorithms
 * Easy (39.52%)
 * Total Accepted:    75.9K
 * Total Submissions: 191.8K
 * Testcase Example:  '"abab"'
 *
 * Given a non-empty string check if it can be constructed by taking a
 * substring of it and appending multiple copies of the substring together. You
 * may assume the given string consists of lowercase English letters only and
 * its length will not exceed 10000.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "abab"
 * Output: True
 * Explanation: It's the substring "ab" twice.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "aba"
 * Output: False
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "abcabcabcabc"
 * Output: True
 * Explanation: It's the substring "abc" four times. (And the substring
 * "abcabc" twice.)
 * 
 * 
 */
public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        if (s.Length <= 1) return false;
        // if (s.Length == 1) return true;

        int len = 1;
        while (len < s.Length)
        {
            if (s[len] != s[0] || s.Length%len != 0)
            {
                len++;
                continue;
            }

            bool equal = true;
            for (int i = len; i < s.Length; i++)
            {
                if (s[i] != s[i % len])
                {
                    equal = false;
                    break;
                }
            }

            if (equal)
            {
                return true;
            }
            len++;
        }

        return false;
    }
}

// √ Accepted
//   √ 120/120 cases passed (108 ms)
//   √ Your runtime beats 75.51 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (28.4 MB)

