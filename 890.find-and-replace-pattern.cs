/*
 * @lc app=leetcode id=890 lang=csharp
 *
 * [890] Find and Replace Pattern

 You have a list of words and a pattern, and you want to know which words in words matches the pattern.

A word matches the pattern if there exists a permutation of letters p so that after replacing every letter x in the pattern with p(x), we get the desired word.

(Recall that a permutation of letters is a bijection from letters to letters: every letter maps to another letter, and no two letters map to the same letter.)

Return a list of the words in words that match the given pattern. 

You may return the answer in any order.

 

Example 1:

Input: words = ["abc","deq","mee","aqq","dkd","ccc"], pattern = "abb"
Output: ["mee","aqq"]
Explanation: "mee" matches the pattern because there is a permutation {a -> m, b -> e, ...}. 
"ccc" does not match the pattern because {a -> c, b -> c, ...} is not a permutation,
since a and b map to the same letter.
 

Note:

1 <= words.length <= 50
1 <= pattern.length = words[i].length <= 20
 */
public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        List<string> res = new List<string>();
        Dictionary<char, char> dic = new Dictionary<char, char>();
        List<char> cont = new List<char>();

        foreach (var word in words)
        {
            if(word.Length != pattern.Length)
                continue;

            dic.Clear();
            cont.Clear();
            bool match = true;
            for (int i = 0; i < word.Length; i++)
            {
                if(!dic.ContainsKey(pattern[i]))
                {
                    // Console.WriteLine("Add " + word[i] + " " + pattern[i]);
                    if(cont.Contains(word[i]))
                    {
                        match = false;
                        break;
                    }
                    cont.Add(word[i]);
                    dic[pattern[i]] = word[i];
                }
                else if(dic[pattern[i]] != word[i])
                {
                    match = false;
                    break;
                }
            }
            if(match)
                res.Add(word);
        }
        return res;
    }
}

// √ Accepted
//   √ 46/46 cases passed (284 ms)
//   √ Your runtime beats 26.14 % of csharp submissions
//   √ Your memory usage beats 92.04 % of csharp submissions (29.5 MB)

