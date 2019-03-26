/*
 * @lc app=leetcode id=125 lang=csharp
 *
 * [125] Valid Palindrome
 *
 * https://leetcode.com/problems/valid-palindrome/description/
 *
 * algorithms
 * Easy (30.43%)
 * Total Accepted:    331.6K
 * Total Submissions: 1.1M
 * Testcase Example:  '"A man, a plan, a canal: Panama"'
 *
 * Given a string, determine if it is a palindrome, considering only
 * alphanumeric characters and ignoring cases.
 * 
 * Note: For the purpose of this problem, we define empty string as valid
 * palindrome.
 * 
 * Example 1:
 * 
 * 
 * Input: "A man, a plan, a canal: Panama"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "race a car"
 * Output: false
 * 
 * 
 */
public class Solution {
    public bool IsPalindrome(string s) {
        if (s.Length <= 1)
            return true;

        for (int i = 0, j = s.Length-1; i <= j; i++, j--)
        {
            int a = IsValid(s[i]);
            if (a < 0)
            {
                j++;
                continue;
            }

            int b = IsValid(s[j]);
            if (b < 0)
            {
                i--;
                continue;
            }

            if (a != b)
                return false;
        }

        return true;
    }

    
    private int IsValid(char c)
    {
        if (c >= 48 && c <= 57)//0-9
        {
            return c;
        }

        if (c >= 65 && c <= 90)//A-Z
        {
            return c;
        }

        if (c >= 97 && c <= 122)//a-z
        {
            return c - 32;
        }

        return -1;
    }
}

// √ Accepted
//   √ 476/476 cases passed (76 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 50.57 % of csharp submissions (22.2 MB)

