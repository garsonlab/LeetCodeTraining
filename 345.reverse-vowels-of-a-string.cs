/*
 * @lc app=leetcode id=345 lang=csharp
 *
 * [345] Reverse Vowels of a String
 *
 * https://leetcode.com/problems/reverse-vowels-of-a-string/description/
 *
 * algorithms
 * Easy (40.98%)
 * Total Accepted:    146.9K
 * Total Submissions: 358.1K
 * Testcase Example:  '"hello"'
 *
 * Write a function that takes a string as input and reverse only the vowels of
 * a string.
 * 
 * Example 1:
 * 
 * 
 * Input: "hello"
 * Output: "holle"
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "leetcode"
 * Output: "leotcede"
 * 
 * 
 * Note:
 * The vowels does not include the letter "y".
 * 
 * 
 * 
 */
public class Solution {
    public string ReverseVowels(string s) {
        char[] str = new char[s.Length];
        for (int i = 0, j = s.Length-1; i <= j; i++, j--)
        {
            if(!IsVowel(s[i])) {
                str[i] = s[i];
                j++;
                continue;
            }
            if(!IsVowel(s[j])) {
                str[j] = s[j];
                i--;
                continue;
            }

            str[i] = s[j];
            str[j] = s[i];
        }
        return new string(str);
    }

    private bool IsVowel(char c) {
        switch (c)
        {
            case 'a':
            case 'A':
            case 'e':
            case 'E':
            case 'i':
            case 'I':
            case 'o':
            case 'O':
            case 'u':
            case 'U':
                return true;
            default:
                return false;
        }
    }
}

// √ Accepted
//   √ 481/481 cases passed (88 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 53.85 % of csharp submissions (25.1 MB)


