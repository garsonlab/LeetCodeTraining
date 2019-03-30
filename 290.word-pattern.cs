/*
 * @lc app=leetcode id=290 lang=csharp
 *
 * [290] Word Pattern
 *
 * https://leetcode.com/problems/word-pattern/description/
 *
 * algorithms
 * Easy (34.62%)
 * Total Accepted:    133.7K
 * Total Submissions: 385.9K
 * Testcase Example:  '"abba"\n"dog cat cat dog"'
 *
 * Given a pattern and a string str, find if str follows the same pattern.
 * 
 * Here follow means a full match, such that there is a bijection between a
 * letter in pattern and a non-empty word in str.
 * 
 * Example 1:
 * 
 * 
 * Input: pattern = "abba", str = "dog cat cat dog"
 * Output: true
 * 
 * Example 2:
 * 
 * 
 * Input:pattern = "abba", str = "dog cat cat fish"
 * Output: false
 * 
 * Example 3:
 * 
 * 
 * Input: pattern = "aaaa", str = "dog cat cat dog"
 * Output: false
 * 
 * Example 4:
 * 
 * 
 * Input: pattern = "abba", str = "dog dog dog dog"
 * Output: false
 * 
 * Notes:
 * You may assume pattern contains only lowercase letters, and str contains
 * lowercase letters that may be separated by a single space.
 * 
 */
public class Solution {
    public bool WordPattern(string pattern, string str) {
        string[] words = str.Split(' ');
        if (pattern.Length != words.Length)
            return false;

        Dictionary<char, int> dic = new Dictionary<char, int>();
        Dictionary<string, char> pat = new Dictionary<string, char>();
        for (int i = 0; i < pattern.Length; i++)
        {
            if (!dic.ContainsKey(pattern[i]))
            {
                dic[pattern[i]] = i;
                if (pat.ContainsKey(words[i]))
                    return false;
                pat.Add(words[i], pattern[i]);
            }
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            int n = dic[pattern[i]];
            if(n == i) continue;

            if (words[n] != words[i])
                return false;
        }

        return true;
    }
}

// √ Accepted
//   √ 33/33 cases passed (76 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (19.9 MB)


