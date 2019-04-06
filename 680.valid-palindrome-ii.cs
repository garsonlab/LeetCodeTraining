/*
 * @lc app=leetcode id=680 lang=csharp
 *
 * [680] Valid Palindrome II
 *
 * https://leetcode.com/problems/valid-palindrome-ii/description/
 *
 * algorithms
 * Easy (33.88%)
 * Total Accepted:    67.6K
 * Total Submissions: 199.2K
 * Testcase Example:  '"aba"'
 *
 * 
 * Given a non-empty string s, you may delete at most one character.  Judge
 * whether you can make it a palindrome.
 * 
 * 
 * Example 1:
 * 
 * Input: "aba"
 * Output: True
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: "abca"
 * Output: True
 * Explanation: You could delete the character 'c'.
 * 
 * 
 * 
 * Note:
 * 
 * The string will only contain lowercase characters a-z.
 * The maximum length of the string is 50000.
 * 
 * 
 */
public class Solution {
    public bool ValidPalindrome(string s)
    {

        for (int i = 0, j = s.Length -1; i <= j; i++, j--)
        {
            if (s[i] != s[j])
            {
                bool p1 = IsPalindrome(ref s, i+1, j);
                if (p1)
                    return true;
                return IsPalindrome(ref s, i, j - 1);
            }
        }

        return true;
    }

    bool IsPalindrome(ref string s, int start, int end)
    {
        for (int i = start, j = end; i <= j; i++, j--)
        {
            if (s[i] != s[j])
                return false;
        }

        return true;
    }



    public bool ValidPalindrome2(string s) {
        bool changed = false;
        for (int i = 0, j = s.Length -1; i <= j; i++, j--)
        {
            if (s[i] != s[j])
            {
                if (changed)
                    return false;
                if (s[i + 1] == s[j])
                {
                    j++;
                    changed = true;
                }
                else if (s[i] == s[j - 1])
                {
                    i--;
                    changed = true;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 460/460 cases passed (108 ms)
//   √ Your runtime beats 97.18 % of csharp submissions
//   √ Your memory usage beats 22.22 % of csharp submissions (40.6 MB)

