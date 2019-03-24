/*
 * @lc app=leetcode id=28 lang=csharp
 *
 * [28] Implement strStr()
 *
 * https://leetcode.com/problems/implement-strstr/description/
 *
 * algorithms
 * Easy (31.43%)
 * Total Accepted:    394.9K
 * Total Submissions: 1.3M
 * Testcase Example:  '"hello"\n"ll"'
 *
 * Implement strStr().
 * 
 * Return the index of the first occurrence of needle in haystack, or -1 if
 * needle is not part of haystack.
 * 
 * Example 1:
 * 
 * 
 * Input: haystack = "hello", needle = "ll"
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: haystack = "aaaaa", needle = "bba"
 * Output: -1
 * 
 * 
 * Clarification:
 * 
 * What should we return when needle is an empty string? This is a great
 * question to ask during an interview.
 * 
 * For the purpose of this problem, we will return 0 when needle is an empty
 * string. This is consistent to C's strstr() and Java's indexOf().
 * 
 */
public class Solution {
    public int StrStr(string haystack, string needle) {
        int hayLen = haystack.Length;
        int needLen = needle.Length;
        if (needLen <= 0)
        {
            return 0;
        }
        if (hayLen < needLen)
        {
            return -1;
        }

        for (int i = 0; i < hayLen; i++)
        {
            if (hayLen-i < needLen)
            {
                return -1;
            }

            for (int j = 0; j < needLen; j++)
            {
                if (haystack[i+j] != needle[j])
                {
                    break;
                }

                if (j == needLen-1)
                {
                    return i;
                }
            }
        }

        return -1;
    }
}
// √ Accepted
//   √ 74/74 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 68.12 % of csharp submissions (20.3 MB)
