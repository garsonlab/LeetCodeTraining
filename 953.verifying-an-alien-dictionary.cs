/*
 * @lc app=leetcode id=953 lang=csharp
 *
 * [953] Verifying an Alien Dictionary
 *
 * https://leetcode.com/problems/verifying-an-alien-dictionary/description/
 *
 * algorithms
 * Easy (55.97%)
 * Total Accepted:    15K
 * Total Submissions: 26.9K
 * Testcase Example:  '["hello","leetcode"]\n"hlabcdefgijkmnopqrstuvwxyz"'
 *
 * In an alien language, surprisingly they also use english lowercase letters,
 * but possibly in a different order. The order of the alphabet is some
 * permutation of lowercase letters.
 * 
 * Given a sequence of words written in the alien language, and the order of
 * the alphabet, return true if and only if the given words are sorted
 * lexicographicaly in this alien language.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
 * Output: true
 * Explanation: As 'h' comes before 'l' in this language, then the sequence is
 * sorted.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
 * Output: false
 * Explanation: As 'd' comes after 'l' in this language, then words[0] >
 * words[1], hence the sequence is unsorted.
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
 * Output: false
 * Explanation: The first three characters "app" match, and the second string
 * is shorter (in size.) According to lexicographical rules "apple" > "app",
 * because 'l' > '∅', where '∅' is defined as the blank character which is less
 * than any other character (More info).
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= words.length <= 100
 * 1 <= words[i].length <= 20
 * order.length == 26
 * All characters in words[i] and order are english lowercase letters.
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
   public bool IsAlienSorted(string[] words, string order)
    {
        if (words.Length <= 1)
            return true;
        int[] w = new int[26];
        for (int i = 0; i < order.Length; i++)
        {
            w[order[i] - 'a'] = i;
        }

        for (int i = 1; i < words.Length; i++)
        {
            if (Compare(words[i - 1], words[i], ref w) > 0)
                return false;
        }

        return true;
    }

    private int Compare(string a, string b, ref int[] w)
    {
        int l = Math.Min(a.Length, b.Length);
        for (int i = 0; i < l; i++)
        {
            if (a[i] != b[i])
            {
                int r = w[a[i] - 'a'] - w[b[i] - 'a'];
                return r < 0 ? -1 : 1;
            }
        }

        if (a.Length > l)
        {
            return 1;
        }

        if (b.Length > l)
            return -1;

        return 0;
    }
}

// √ Accepted
//   √ 115/115 cases passed (92 ms)
//   √ Your runtime beats 78.92 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (23 MB)

