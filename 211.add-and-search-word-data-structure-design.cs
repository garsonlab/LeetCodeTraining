/*
 * @lc app=leetcode id=211 lang=csharp
 *
 * [211] Add and Search Word - Data structure design
 *
 * https://leetcode.com/problems/add-and-search-word-data-structure-design/description/
 *
 * algorithms
 * Medium (29.78%)
 * Total Accepted:    110.7K
 * Total Submissions: 370.6K
 * Testcase Example:  '["WordDictionary","addWord","addWord","addWord","search","search","search","search"]\n[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]'
 *
 * Design a data structure that supports the following two operations:
 * 
 * 
 * void addWord(word)
 * bool search(word)
 * 
 * 
 * search(word) can search a literal word or a regular expression string
 * containing only letters a-z or .. A . means it can represent any one
 * letter.
 * 
 * Example:
 * 
 * 
 * addWord("bad")
 * addWord("dad")
 * addWord("mad")
 * search("pad") -> false
 * search("bad") -> true
 * search(".ad") -> true
 * search("b..") -> true
 * 
 * 
 * Note:
 * You may assume that all words are consist of lowercase letters a-z.
 * 
 */
public class WordDictionary {

    private class Node
    {
        public Node[] children;
        public bool isEnd = false;
        public Node()
        {
            children = new Node[26];
        }
    };
    private Node root = null;


    /** Initialize your data structure here. */
    public WordDictionary() {
        root = new Node();
    }
    
    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        Node tmp = root;
        int index;

        foreach (char c in word.ToCharArray())
        {
            index = c - 'a';
            if (tmp.children[index] == null)
                tmp.children[index] = new Node();
            tmp = tmp.children[index];
        }
        tmp.isEnd = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        if(root == null)
            return false;
        if(word.Length <= 0)
            return false;

        return Searching(root, word, 0);
    }

    private bool Searching(Node node, string word, int idx) {
        if(word[idx] == '.') {
            foreach (var item in node.children)
            {
                if(item == null)
                    continue;
                if(idx == word.Length-1)
                {
                    if(item.isEnd)
                        return true;
                    else
                        continue;
                }

                bool ret = Searching(item, word, idx+1);
                if(ret)
                    return true;
            }
            return false;
        } else {
            int index = word[idx] - 'a';
            if(node.children[index] == null)
                return false;
            if(idx == word.Length-1)
                return node.children[index].isEnd;
            return Searching(node.children[index], word, idx+1);
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

//  √ Accepted
//   √ 13/13 cases passed (220 ms)
//   √ Your runtime beats 97.08 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (45.1 MB)

