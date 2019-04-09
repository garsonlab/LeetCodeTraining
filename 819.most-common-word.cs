/*
 * @lc app=leetcode id=819 lang=csharp
 *
 * [819] Most Common Word
 *
 * https://leetcode.com/problems/most-common-word/description/
 *
 * algorithms
 * Easy (41.88%)
 * Total Accepted:    45.9K
 * Total Submissions: 109.4K
 * Testcase Example:  '"Bob hit a ball, the hit BALL flew far after it was hit."\n["hit"]'
 *
 * Given a paragraph and a list of banned words, return the most frequent word
 * that is not in the list of banned words.  It is guaranteed there is at least
 * one word that isn't banned, and that the answer is unique.
 * 
 * Words in the list of banned words are given in lowercase, and free of
 * punctuation.  Words in the paragraph are not case sensitive.  The answer is
 * in lowercase.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Input: 
 * paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
 * banned = ["hit"]
 * Output: "ball"
 * Explanation: 
 * "hit" occurs 3 times, but it is a banned word.
 * "ball" occurs twice (and no other word does), so it is the most frequent
 * non-banned word in the paragraph. 
 * Note that words in the paragraph are not case sensitive,
 * that punctuation is ignored (even if adjacent to words, such as "ball,"), 
 * and that "hit" isn't the answer even though it occurs more because it is
 * banned.
 * 
 * 
 * 
 * 
 * Note: 
 * 
 * 
 * 1 <= paragraph.length <= 1000.
 * 0 <= banned.length <= 100.
 * 1 <= banned[i].length <= 10.
 * The answer is unique, and written in lowercase (even if its occurrences in
 * paragraph may have uppercase symbols, and even if it is a proper noun.)
 * paragraph only consists of letters, spaces, or the punctuation symbols
 * !?',;.
 * There are no hyphens or hyphenated words.
 * Words only consist of letters, never apostrophes or other punctuation
 * symbols.
 * 
 * 
 */
public class Solution {
    public string MostCommonWord(string paragraph, string[] banned)
    {
        Dictionary<string, int> b = new Dictionary<string, int>();
        foreach (var s in banned)
        {
            b[s] = 1;
        }

        Dictionary<string, int> dic = new Dictionary<string, int>();
        int max = 0;
        string ret = "";

        int start = -1;
        int len = 0;
        for (int i = 0; i <= paragraph.Length; i++)
        {
            if (i<paragraph.Length && IsLetter(paragraph[i]))
            {
                if (len == 0)
                {
                    start = i;
                    len = 1;
                }
                else
                {
                    len++;
                }
            }
            else
            {
                if (len > 0)
                {
                    string s = paragraph.Substring(start, len).ToLower();
                    if (!b.ContainsKey(s))
                    {
                        int n;
                        if (!dic.TryGetValue(s, out n))
                            n = 0;
                        dic[s] = n + 1;

                        if (n + 1 > max)
                        {
                            max = n + 1;
                            ret = s;
                        }
                    }
                }

                start = -1;
                len = 0;
            }
        }

        return ret;
    }


    private bool IsLetter(char c)
    {
        return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';
    }
}

// √ Accepted
//   √ 47/47 cases passed (104 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 89.47 % of csharp submissions (23.1 MB)

