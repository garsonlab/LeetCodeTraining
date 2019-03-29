/*
 * @lc app=leetcode id=242 lang=csharp
 *
 * [242] Valid Anagram
 *
 * https://leetcode.com/problems/valid-anagram/description/
 *
 * algorithms
 * Easy (51.24%)
 * Total Accepted:    314.5K
 * Total Submissions: 612.6K
 * Testcase Example:  '"anagram"\n"nagaram"'
 *
 * Given two strings s and t , write a function to determine if t is an anagram
 * of s.
 * 
 * Example 1:
 * 
 * 
 * Input: s = "anagram", t = "nagaram"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: s = "rat", t = "car"
 * Output: false
 * 
 * 
 * Note:
 * You may assume the string contains only lowercase alphabets.
 * 
 * Follow up:
 * What if the inputs contain unicode characters? How would you adapt your
 * solution to such case?
 * 
 */
public class Solution {

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        if (s.Length == 0)
            return true;

        Dictionary<char, int> dic = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            int n;
            if (dic.TryGetValue(s[i], out n))
            {
                dic[s[i]] = n + 1;
            }
            else
            {
                dic[s[i]] = 1;
            }
        }

        for (int i = 0; i < t.Length; i++)
        {
            int n;
            if (dic.TryGetValue(t[i], out n))
            {
                if (n == 1)
                    dic.Remove(t[i]);
                else
                    dic[t[i]] = n - 1;
            }
            else
            {
                return false;
            }
        }

        return dic.Count == 0;
    }



    /* 此处是只有一个字母错位
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;
        if (s.Length == 0)
            return true;
        if (s.Length == 1)
            return s[0] == t[0];

        int idx = s.Length - 1;
        for (; idx >= 0; idx--)
        {
            if (s[idx] != t[idx])
            {
                break;
            }
        }

        if (idx <= 0)
            return false;

        if (s[idx] == t[idx - 1])
            return DislocationEqual(s, t, idx);

        if (s[idx - 1] == t[idx])
            return DislocationEqual(t, s, idx);

        return false;
    }

    bool DislocationEqual(string s, string t, int idx)
    {
        int flag = 0;
        for (int i = idx; i > 0; i--)
        {
            if (s[i] != t[i-1])
            {
                flag = i;
                break;
            }
        }
        
        if (s[flag] != t[idx])
            return false;

        for (int i = flag - 1; i >= 0; i--)
        {
            if (s[i] != t[i])
                return false;
        }

        return true;
    }
    */
}

// √ Accepted
//   √ 34/34 cases passed (100 ms)
//   √ Your runtime beats 49.87 % of csharp submissions
//   √ Your memory usage beats 81.36 % of csharp submissions (21.6 MB)

