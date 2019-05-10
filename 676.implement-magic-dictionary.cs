/*
 * @lc app=leetcode id=676 lang=csharp
 *
 * [676] Implement Magic Dictionary

 Implement a magic directory with buildDict, and search methods.

For the method buildDict, you'll be given a list of non-repetitive words to build a dictionary.

For the method search, you'll be given a word, and judge whether if you modify exactly one character into another character in this word, the modified word is in the dictionary you just built.

Example 1:
Input: buildDict(["hello", "leetcode"]), Output: Null
Input: search("hello"), Output: False
Input: search("hhllo"), Output: True
Input: search("hell"), Output: False
Input: search("leetcoded"), Output: False
Note:
You may assume that all the inputs are consist of lowercase letters a-z.
For contest purpose, the test data is rather small by now. You could think about highly efficient algorithm after the contest.
Please remember to RESET your class variables declared in class MagicDictionary, as static/class variables are persisted across multiple test cases. Please see here for more details.
 */
public class MagicDictionary {

    private List<string> list;
        /** Initialize your data structure here. */
        public MagicDictionary()
        {
            list = new List<string>();
        }

        /** Build a dictionary through a list of words */
        public void BuildDict(string[] dict)
        {
            foreach (var s in dict)
            {
                list.Add(s);
            }
        }

        /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
        public bool Search(string word)
        {
            foreach (var s in list)
            {
                if(s.Length != word.Length)
                    continue;

                int diff = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != word[i])
                    {
                        diff++;
                        if(diff>1)
                            break;
                    }
                }

                if (diff == 1)
                    return true;
            }

            return false;
        }

}

/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dict);
 * bool param_2 = obj.Search(word);
 */

//  √ Accepted
//   √ 32/32 cases passed (112 ms)
//   √ Your runtime beats 42.59 % of csharp submissions
//   √ Your memory usage beats 66.67 % of csharp submissions (23.4 MB)

