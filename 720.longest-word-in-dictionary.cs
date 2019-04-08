/*
 * @lc app=leetcode id=720 lang=csharp
 *
 * [720] Longest Word in Dictionary
 *
 * https://leetcode.com/problems/longest-word-in-dictionary/description/
 *
 * algorithms
 * Easy (43.93%)
 * Total Accepted:    32.5K
 * Total Submissions: 73.7K
 * Testcase Example:  '["w","wo","wor","worl","world"]'
 *
 * Given a list of strings words representing an English Dictionary, find the
 * longest word in words that can be built one character at a time by other
 * words in words.  If there is more than one possible answer, return the
 * longest word with the smallest lexicographical order.  If there is no
 * answer, return the empty string.
 * 
 * Example 1:
 * 
 * Input: 
 * words = ["w","wo","wor","worl", "world"]
 * Output: "world"
 * Explanation: 
 * The word "world" can be built one character at a time by "w", "wo", "wor",
 * and "worl".
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: 
 * words = ["a", "banana", "app", "appl", "ap", "apply", "apple"]
 * Output: "apple"
 * Explanation: 
 * Both "apply" and "apple" can be built from other words in the dictionary.
 * However, "apple" is lexicographically smaller than "apply".
 * 
 * 
 * 
 * Note:
 * All the strings in the input will only contain lowercase letters.
 * The length of words will be in the range [1, 1000].
 * The length of words[i] will be in the range [1, 30].
 * 
 */
public class Solution {
    public string LongestWord(string[] words) {
        string ret = "";
        Array.Sort(words);
        Dictionary<string, int> dic = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if(word.Length == 1)
            {
                dic[word] = 1;
                if (word.Length > ret.Length)
                    ret = word;
            }
            else
            {
                string tem = word.Substring(0, word.Length - 1);
                if (dic.ContainsKey(tem))
                {
                    dic[word] = 1;
                    if (word.Length > ret.Length)
                        ret = word;
                }
            }
        }
        
        return ret;
    }
}


// √ Accepted
//   √ 57/57 cases passed (284 ms)
//   √ Your runtime beats 64.84 % of csharp submissions
//   √ Your memory usage beats 61.54 % of csharp submissions (31 MB)
