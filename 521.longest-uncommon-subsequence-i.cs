/*
 * @lc app=leetcode id=521 lang=csharp
 *
 * [521] Longest Uncommon Subsequence I 
 *
 * https://leetcode.com/problems/longest-uncommon-subsequence-i/description/
 *
 * algorithms
 * Easy (56.16%)
 * Total Accepted:    44.8K
 * Total Submissions: 79.7K
 * Testcase Example:  '"aba"\n"cdc"'
 *
 * 
 * Given a group of two strings, you need to find the longest uncommon
 * subsequence of this group of two strings.
 * The longest uncommon subsequence is defined as the longest subsequence of
 * one of these strings and this subsequence should not be any subsequence of
 * the other strings.
 * 
 * 
 * 
 * A subsequence is a sequence that can be derived from one sequence by
 * deleting some characters without changing the order of the remaining
 * elements. Trivially, any string is a subsequence of itself and an empty
 * string is a subsequence of any string.
 * 
 * 
 * 
 * The input will be two strings, and the output needs to be the length of the
 * longest uncommon subsequence. If the longest uncommon subsequence doesn't
 * exist, return -1.
 * 
 * 
 * Example 1:
 * 
 * Input: "aba", "cdc"
 * Output: 3
 * Explanation: The longest uncommon subsequence is "aba" (or "cdc"), because
 * "aba" is a subsequence of "aba", but not a subsequence of any other strings
 * in the group of two strings. 
 * 
 * 
 * 
 * Note:
 * 
 * Both strings' lengths will not exceed 100.
 * Only letters from a ~ z will appear in input strings. 
 * 
 * 
 */
public class Solution {
    public int FindLUSlength(string a, string b)
    {
        if (a == b) return -1;
        return a.Length >= b.Length ? a.Length : b.Length;
    }

    //看了一堆没懂题目
    public int FindLUSlength2(string a, string b)
    {
        List<char> ca = new List<char>(a);
        List<char> cb = new List<char>();
        List<char> db = new List<char>();
        for (int i = 0; i < b.Length; i++)
        {
            char c = b[i];
            if (ca.Contains(c))
            {
                ca.Remove(c);
                db.Add(c);
            }
            else if(!db.Contains(c))
            {
                cb.Add(c);
            }
        }

        if (ca.Count == 0 || cb.Count == 0)
            return -1;

        return ca.Count > cb.Count ? ca.Count : cb.Count;
    }
}

// √ Accepted
//   √ 41/41 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 12.5 % of csharp submissions (19.9 MB)

