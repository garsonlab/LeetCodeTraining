/*
 * @lc app=leetcode id=966 lang=csharp
 *
 * [966] Vowel Spellchecker

 Given a wordlist, we want to implement a spellchecker that converts a query word into a correct word.

For a given query word, the spell checker handles two categories of spelling mistakes:

Capitalization: If the query matches a word in the wordlist (case-insensitive), then the query word is returned with the same case as the case in the wordlist.
Example: wordlist = ["yellow"], query = "YellOw": correct = "yellow"
Example: wordlist = ["Yellow"], query = "yellow": correct = "Yellow"
Example: wordlist = ["yellow"], query = "yellow": correct = "yellow"
Vowel Errors: If after replacing the vowels ('a', 'e', 'i', 'o', 'u') of the query word with any vowel individually, it matches a word in the wordlist (case-insensitive), then the query word is returned with the same case as the match in the wordlist.
Example: wordlist = ["YellOw"], query = "yollow": correct = "YellOw"
Example: wordlist = ["YellOw"], query = "yeellow": correct = "" (no match)
Example: wordlist = ["YellOw"], query = "yllw": correct = "" (no match)
In addition, the spell checker operates under the following precedence rules:

When the query exactly matches a word in the wordlist (case-sensitive), you should return the same word back.
When the query matches a word up to capitlization, you should return the first such match in the wordlist.
When the query matches a word up to vowel errors, you should return the first such match in the wordlist.
If the query has no matches in the wordlist, you should return the empty string.
Given some queries, return a list of words answer, where answer[i] is the correct word for query = queries[i].

 

Example 1:

Input: wordlist = ["KiTe","kite","hare","Hare"], queries = ["kite","Kite","KiTe","Hare","HARE","Hear","hear","keti","keet","keto"]
Output: ["kite","KiTe","KiTe","Hare","hare","","","KiTe","","KiTe"]
 

Note:

1 <= wordlist.length <= 5000
1 <= queries.length <= 5000
1 <= wordlist[i].length <= 7
1 <= queries[i].length <= 7
All strings in wordlist and queries consist only of english letters.
 */
public class Solution {
    public string[] Spellchecker(string[] wordlist, string[] queries) {
        Dictionary<string, List<string[]>> mm = new Dictionary<string, List<string[]>>();
        
        foreach (var s in wordlist)
        {
            string lower = s.ToLower();
            string rp = ReplaceA_U(lower);
            List<string[]> list;
            if (!mm.TryGetValue(rp, out list))
            {
                list = new List<string[]>();
                mm[rp] = list;
            }
            list.Add(new []{s, lower});
        }

        string[] result = new string[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            string s = queries[i];
            string lower = s.ToLower();
            string rp = ReplaceA_U(lower);
            if (!mm.ContainsKey(rp))
            {
                result[i] = "";
                continue;
            }

            List<string[]> list = mm[rp];
            bool same = false;
            string ls = "";

            foreach (var l in list)
            {
                if (l[0] == s)
                    same = true;

                if (ls.Length == 0 && l[1] == lower)
                    ls = l[0];
            }

            if (same)
                result[i] = s;
            else if (ls.Length > 0)
                result[i] = ls;
            else
                result[i] = list[0][0];
        }
        return result;
    }

    string ReplaceA_U(string s)
    {
        char[] cs = s.ToCharArray();
        for (int i = 0; i < cs.Length; i++)
        {
            char c = cs[i];
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                cs[i] = '.';
        }
        return new string(cs);
    }

}

// √ Accepted
//   √ 53/53 cases passed (348 ms)
//   √ Your runtime beats 72 % of csharp submissions
//   √ Your memory usage beats 42.1 % of csharp submissions (45.3 MB)

