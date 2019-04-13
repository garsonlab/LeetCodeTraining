/*
 * @lc app=leetcode id=5 lang=csharp
 *
 * [5] Longest Palindromic Substring
 *
 * https://leetcode.com/problems/longest-palindromic-substring/description/
 *
 * algorithms
 * Medium (26.97%)
 * Total Accepted:    520.7K
 * Total Submissions: 1.9M
 * Testcase Example:  '"babad"'
 *
 * Given a string s, find the longest palindromic substring in s. You may
 * assume that the maximum length of s is 1000.
 * 
 * Example 1:
 * 
 * 
 * Input: "babad"
 * Output: "bab"
 * Note: "aba" is also a valid answer.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "cbbd"
 * Output: "bb"
 * 
 * 
 */
public class Solution {
    public string LongestPalindrome(string s)
    {
        int n = s.Length;
        if (n <= 1) return s;
        int start = 0;
        int end = 0;
        for (int i = 0; i < n; i++)
        {
            int len1 = expandFromCenter(s, i, i);
            int len2 = expandFromCenter(s, i, i + 1);
            int len_tmp;
            len_tmp = Math.Max(len1, len2);
            if (len_tmp > end - start)
            {
                start = i - (len_tmp - 1) / 2;
                end = i + len_tmp / 2;
            }
        }
        return s.Substring(start, end-start+1);
    }

    int expandFromCenter(string s, int left, int right)
    {
        int L = left;
        int R = right;
        while (L >= 0 && R < s.Length && s[L] == s[R])
        {
            L--;
            R++;
        }
        return R - L - 1;
    }
}

// √ Accepted
//   √ 103/103 cases passed (96 ms)
//   √ Your runtime beats 95.02 % of csharp submissions
//   √ Your memory usage beats 85.85 % of csharp submissions (21.2 MB)

