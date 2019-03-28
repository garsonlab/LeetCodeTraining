/*
 * @lc app=leetcode id=205 lang=csharp
 *
 * [205] Isomorphic Strings
 *
 * https://leetcode.com/problems/isomorphic-strings/description/
 *
 * algorithms
 * Easy (36.85%)
 * Total Accepted:    192.2K
 * Total Submissions: 520.7K
 * Testcase Example:  '"egg"\n"add"'
 *
 * Given two strings s and t, determine if they are isomorphic.
 * 
 * Two strings are isomorphic if the characters in s can be replaced to get t.
 * 
 * All occurrences of a character must be replaced with another character while
 * preserving the order of characters. No two characters may map to the same
 * character but a character may map to itself.
 * 
 * Example 1:
 * 
 * 
 * Input: s = "egg", t = "add"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "foo", t = "bar"
 * Output: false
 * 
 * Example 3:
 * 
 * 
 * Input: s = "paper", t = "title"
 * Output: true
 * 
 * Note:
 * You may assume both s and t have the same length.
 * 
 */
public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }

        int len = s.Length;
        if (len == 0)
        {
            return true;
        }

        Dictionary<char, char> dic = new Dictionary<char, char>();
        List<char> flag = new List<char>();
        char tem;
        for (int i = 0; i < len; i++)
        {
            if (dic.TryGetValue(s[i], out tem))
            {
                if (t[i] != tem)
                    return false;
            }
            else
            {
                if (flag.Contains(t[i]))
                    return false;
                flag.Add(t[i]);
                dic[s[i]] = t[i];
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 30/30 cases passed (76 ms)
//   √ Your runtime beats 94.04 % of csharp submissions
//   √ Your memory usage beats 45 % of csharp submissions (21.3 MB)

