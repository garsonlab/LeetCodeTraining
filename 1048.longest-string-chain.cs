/*
 * @lc app=leetcode id=1048 lang=csharp
 *
 * [1048] Longest String Chain

 Given a list of words, each word consists of English lowercase letters.

Let's say word1 is a predecessor of word2 if and only if we can add exactly one letter anywhere in word1 to make it equal to word2.  For example, "abc" is a predecessor of "abac".

A word chain is a sequence of words [word_1, word_2, ..., word_k] with k >= 1, where word_1 is a predecessor of word_2, word_2 is a predecessor of word_3, and so on.

Return the longest possible length of a word chain with words chosen from the given list of words.

 

Example 1:

Input: ["a","b","ba","bca","bda","bdca"]
Output: 4
Explanation: one of the longest word chain is "a","ba","bda","bdca".
 

Note:

1 <= words.length <= 1000
1 <= words[i].length <= 16
words[i] only consists of English lowercase letters.
 */
public class Solution {
    public int LongestStrChain(string[] words) {
        
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            List<int> list;
            if(!dic.TryGetValue(word.Length, out list)) {
                list = new List<int>();
                dic[word.Length] = list;
            }
            list.Add(i);

        }

        int max = 0;
        int[] dp = new int[words.Length];
        List<int> keys = new List<int>(dic.Keys);
        keys.Sort();

        int res = 0;
        foreach (var key in keys)
        {
            if(dic.ContainsKey(key-1)) {
                for (int i = 0; i < dic[key].Count; i++)
                {
                    res = Math.Max(res, HasPre(words, dp, dic[key-1], dic[key][i]) +1);
                }
            }
        }

        if(res > 0)
            return res;

        return words.Length > 0? 1 : 0;
    }

    private int HasPre(string[] words, int[] dp, List<int> list, int k) {
        int max = -1;
        string p = words[k];
        foreach (var w in list)
        {
            string word = words[w];
            int diff = 0;
            for (int i = 0, j = 0; i < word.Length && j < p.Length;)
            {
                if(word[i] == p[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                    diff++;
                }
            }
            if(diff <= 1) {
                dp[k] = Math.Max(dp[k], dp[w]+1);

                max = Math.Max(max, dp[k]);
            }
            // Console.WriteLine(p + "  pre: " + word + "   " + diff + " dp " + dp[k]);
        }
        return max;
    }
}

// √ Accepted
//   √ 71/71 cases passed (124 ms)
//   √ Your runtime beats 88.31 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (25.3 MB)

