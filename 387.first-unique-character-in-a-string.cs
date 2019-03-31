/*
 * @lc app=leetcode id=387 lang=csharp
 *
 * [387] First Unique Character in a String
 *
 * https://leetcode.com/problems/first-unique-character-in-a-string/description/
 *
 * algorithms
 * Easy (49.41%)
 * Total Accepted:    244.3K
 * Total Submissions: 493.5K
 * Testcase Example:  '"leetcode"'
 *
 * 
 * Given a string, find the first non-repeating character in it and return it's
 * index. If it doesn't exist, return -1.
 * 
 * Examples:
 * 
 * s = "leetcode"
 * return 0.
 * 
 * s = "loveleetcode",
 * return 2.
 * 
 * 
 * 
 * 
 * Note: You may assume the string contain only lowercase letters.
 * 
 */
public class Solution {
    public int FirstUniqChar(string s) {
        Dictionary<char, int> one = new Dictionary<char, int>();
        Dictionary<char, int> mul = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if(one.ContainsKey(s[i])){
                one.Remove(s[i]);
                mul[s[i]] = 1;
            } else if(!mul.ContainsKey(s[i])) {
                one[s[i]] = i;
            }
        }

        if (one.Count <= 0)
            return -1;

        int r = s.Length;
        foreach (var pos in one.Values)
        {
            r = pos < r ? pos : r;
        }
        return r;
    }
}

// √ Accepted
//   √ 104/104 cases passed (112 ms)
//   √ Your runtime beats 73.82 % of csharp submissions
//   √ Your memory usage beats 26.51 % of csharp submissions (30 MB)


