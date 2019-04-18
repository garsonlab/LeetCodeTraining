/*
 * @lc app=leetcode id=127 lang=csharp
 *
 * [127] Word Ladder
 *
 * https://leetcode.com/problems/word-ladder/description/
 *
 * algorithms
 * Medium (23.50%)
 * Total Accepted:    246K
 * Total Submissions: 1M
 * Testcase Example:  '"hit"\n"cog"\n["hot","dot","dog","lot","log","cog"]'
 *
 * Given two words (beginWord and endWord), and a dictionary's word list, find
 * the length of shortest transformation sequence from beginWord to endWord,
 * such that:
 * 
 * 
 * Only one letter can be changed at a time.
 * Each transformed word must exist in the word list. Note that beginWord is
 * not a transformed word.
 * 
 * 
 * Note:
 * 
 * 
 * Return 0 if there is no such transformation sequence.
 * All words have the same length.
 * All words contain only lowercase alphabetic characters.
 * You may assume no duplicates in the word list.
 * You may assume beginWord and endWord are non-empty and are not the same.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input:
 * beginWord = "hit",
 * endWord = "cog",
 * wordList = ["hot","dot","dog","lot","log","cog"]
 * 
 * Output: 5
 * 
 * Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" ->
 * "dog" -> "cog",
 * return its length 5.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input:
 * beginWord = "hit"
 * endWord = "cog"
 * wordList = ["hot","dot","dog","lot","log"]
 * 
 * Output: 0
 * 
 * Explanation: The endWord "cog" is not in wordList, therefore no possible
 * transformation.
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord) || beginWord == endWord)
            return 0;

        Dictionary<string, int> dic = new Dictionary<string, int>(){{beginWord, 1}};
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);

        while (queue.Count > 0)
        {
            string s = queue.Dequeue();

            for (int w = wordList.Count-1; w >= 0; w--)
            {
                string word = wordList[w];

                int n = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != word[i])
                    {
                        n++;
                        if(n > 1)
                            break;
                    }
                }

                if (n == 1)
                {
                    wordList.RemoveAt(w);
                    queue.Enqueue(word);
                    dic[word] = dic[s] + 1;

                    if (word == endWord)
                        return dic[word];
                }
            }
        }

        return 0;
    }
}

// √ Accepted
//   √ 40/40 cases passed (332 ms)
//   √ Your runtime beats 83.37 % of csharp submissions
//   √ Your memory usage beats 96.08 % of csharp submissions (24.6 MB)

