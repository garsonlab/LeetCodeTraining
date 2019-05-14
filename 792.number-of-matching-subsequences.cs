/*
 * @lc app=leetcode id=792 lang=csharp
 *
 * [792] Number of Matching Subsequences

 Given string S and a dictionary of words words, find the number of words[i] that is a subsequence of S.

Example :
Input: 
S = "abcde"
words = ["a", "bb", "acd", "ace"]
Output: 3
Explanation: There are three words in words that are a subsequence of S: "a", "acd", "ace".
Note:

All words in words and S will only consists of lowercase letters.
The length of S will be in the range of [1, 50000].
The length of words will be in the range of [1, 5000].
The length of words[i] will be in the range of [1, 50].
 */
public class Solution {
    public int NumMatchingSubseq(string S, string[] words) {
        List<int>[] pos = new List<int>[26];
        for (int i = 0; i < 26; i++)
        {
            pos[i] = new List<int>();
        }
        
        for (int i = 0; i < S.Length; i++)
        {
            pos[S[i] - 'a'].Add(i);
        }

        int count = 0;
        for (int i = 0; i < words.Length; i++)
        {
            int j = 0, cur = -1;
            // iterate each letter in the word
            while (j != words[i].Length)
            {
                int k = 0;
                while (k != pos[words[i][j] - 'a'].Count)
                {
                    // keep the relative positions by greedy
                    if (pos[words[i][j] - 'a'][k] > cur)
                    {
                        cur = pos[words[i][j] - 'a'][k];
                        break;
                    }
                    k++;
                }
                // when there is no match, break to prune
                if (k == pos[words[i][j] - 'a'].Count)
                {
                    break;
                }
                j++;
            }
            // the case every letter could be matched
            if (j == words[i].Length) count++;
        }
        return count;
    }
}

// √ Accepted
//   √ 49/49 cases passed (316 ms)
//   √ Your runtime beats 63.94 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (44.3 MB)
