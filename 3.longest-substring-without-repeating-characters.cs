/*
 * @lc app=leetcode id=3 lang=csharp
 *
 * [3] Longest Substring Without Repeating Characters
 *
 * https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
 *
 * algorithms
 * Medium (28.17%)
 * Total Accepted:    871.7K
 * Total Submissions: 3.1M
 * Testcase Example:  '"abcabcbb"'
 *
 * Given a string, find the length of the longest substring without repeating
 * characters.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "abcabcbb"
 * Output: 3 
 * Explanation: The answer is "abc", with the length of 3. 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "bbbbb"
 * Output: 1
 * Explanation: The answer is "b", with the length of 1.
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "pwwkew"
 * Output: 3
 * Explanation: The answer is "wke", with the length of 3. 
 * ⁠            Note that the answer must be a substring, "pwke" is a
 * subsequence and not a substring.
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length <= 1)
            return s.Length;

        int max = 0;
        
        Dictionary<char, int> dic = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dic.ContainsKey(s[i]))
            {
                if (dic.Count > max)
                    max = dic.Count;

                int idx = dic[s[i]];
                int start = i - dic.Count;
                for (int j = start; j <= idx; j++)
                {
                    dic.Remove(s[j]);
                }

            }
            dic.Add(s[i], i);
        }

        max = Math.Max(dic.Count, max);

        return max;
    }
}

// √ Accepted
//   √ 987/987 cases passed (88 ms)
//   √ Your runtime beats 81.07 % of csharp submissions
//   √ Your memory usage beats 86.61 % of csharp submissions (23.5 MB)

