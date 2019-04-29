/*
 * @lc app=leetcode id=318 lang=csharp
 *
 * [318] Maximum Product of Word Lengths


 Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. You may assume that each word will contain only lower case letters. If no such two words exist, return 0.

Example 1:

Input: ["abcw","baz","foo","bar","xtfn","abcdef"]
Output: 16 
Explanation: The two words can be "abcw", "xtfn".
Example 2:

Input: ["a","ab","abc","d","cd","bcd","abcd"]
Output: 4 
Explanation: The two words can be "ab", "cd".
Example 3:

Input: ["a","aa","aaa","aaaa"]
Output: 0 
Explanation: No such pair of words.
 */
public class Solution {
    public int MaxProduct(string[] words) {
        int[] flag = new int[words.Length];
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < words.Length; i++)
        {
            dic.Clear();
            string s = words[i];
            int r = 0;
            for (int j = 0; j < s.Length; j++)
            {
                dic[s[j] - 'a'] = 1;
                //r += 1 << (s[j] - 'a');
            }

            foreach (var key in dic.Keys)
            {
                r += 1 << key;
            }

            flag[i] = r;

        }

        int ret = 0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i+1; j < words.Length; j++)
            {
                if ((flag[i] & flag[j]) > 0)
                    continue;
                ret = Math.Max(ret, words[i].Length * words[j].Length);
            }
        }

        return ret;
    }
}

// √ Accepted
//   √ 174/174 cases passed (148 ms)
//   √ Your runtime beats 54.35 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (26.3 MB)

