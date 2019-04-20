/*
 * @lc app=leetcode id=208 lang=csharp
 *
 * [208] Implement Trie (Prefix Tree)
 *
 * https://leetcode.com/problems/implement-trie-prefix-tree/description/
 *
 * algorithms
 * Medium (37.63%)
 * Total Accepted:    172K
 * Total Submissions: 455.4K
 * Testcase Example:  '["Trie","insert","search","search","startsWith","insert","search"]\n[[],["apple"],["apple"],["app"],["app"],["app"],["app"]]'
 *
 * Implement a trie with insert, search, and startsWith methods.
 * 
 * Example:
 * 
 * 
 * Trie trie = new Trie();
 * 
 * trie.insert("apple");
 * trie.search("apple");   // returns true
 * trie.search("app");     // returns false
 * trie.startsWith("app"); // returns true
 * trie.insert("app");   
 * trie.search("app");     // returns true
 * 
 * 
 * Note:
 * 
 * 
 * You may assume that all inputs are consist of lowercase letters a-z.
 * All inputs are guaranteed to be non-empty strings.
 * 
 * 
 */
public class Trie
    {
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
        public Trie()
        {
            root = new Node();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
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

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            if(root == null)
                return false;

            Node tmp = root;
            int index;
            foreach (char c in word.ToCharArray())
            {
                index = c - 'a';
                if (tmp.children[index] == null)
                    return false;
                tmp = tmp.children[index];
            }
            return tmp.isEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            if(root == null)
                return false;

            Node tmp = root;
            int index;
            foreach (char c in prefix.ToCharArray())
            {
                index = c - 'a';
                if (tmp.children[index] == null)
                    return false;
                tmp = tmp.children[index];
            }
            return true;
        }
    }

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */


//  √ Accepted
//   √ 15/15 cases passed (204 ms)
//   √ Your runtime beats 97.45 % of csharp submissions
//   √ Your memory usage beats 31.82 % of csharp submissions (47 MB)

