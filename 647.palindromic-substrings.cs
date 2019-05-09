/*
 * @lc app=leetcode id=647 lang=csharp
 *
 * [647] Palindromic Substrings

 Given a string, your task is to count how many palindromic substrings in this string.

The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.

Example 1:

Input: "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".
 

Example 2:

Input: "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
 

Note:

The input string length won't exceed 1000.
 */
public class Solution {
    public int CountSubstrings(string s) {
        int res = s.Length;
        if (s.Length <= 1)
            return res;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i+1; j < s.Length; j++)
            {
                if (IsPab(s, i, j))
                    res++;
            }
        }

        return res;
    }

    private bool IsPab(string s, int start, int end)
    {
        for (; start <= end; start++, end--)
        {
            if (s[start] != s[end])
                return false;
        }

        return true;
    }
}

// √ Accepted
//   √ 130/130 cases passed (320 ms)
//   √ Your runtime beats 20.95 % of csharp submissions
//   √ Your memory usage beats 28.57 % of csharp submissions (20.1 MB)

