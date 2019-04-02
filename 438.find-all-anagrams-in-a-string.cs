/*
 * @lc app=leetcode id=438 lang=csharp
 *
 * [438] Find All Anagrams in a String
 *
 * https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
 *
 * algorithms
 * Easy (36.70%)
 * Total Accepted:    113.8K
 * Total Submissions: 309.3K
 * Testcase Example:  '"cbaebabacd"\n"abc"'
 *
 * Given a string s and a non-empty string p, find all the start indices of p's
 * anagrams in s.
 * 
 * Strings consists of lowercase English letters only and the length of both
 * strings s and p will not be larger than 20,100.
 * 
 * The order of output does not matter.
 * 
 * Example 1:
 * 
 * Input:
 * s: "cbaebabacd" p: "abc"
 * 
 * Output:
 * [0, 6]
 * 
 * Explanation:
 * The substring with start index = 0 is "cba", which is an anagram of "abc".
 * The substring with start index = 6 is "bac", which is an anagram of
 * "abc".
 * 
 * 
 * 
 * Example 2:
 * 
 * Input:
 * s: "abab" p: "ab"
 * 
 * Output:
 * [0, 1, 2]
 * 
 * Explanation:
 * The substring with start index = 0 is "ab", which is an anagram of "ab".
 * The substring with start index = 1 is "ba", which is an anagram of "ab".
 * The substring with start index = 2 is "ab", which is an anagram of "ab".
 * 
 * 
 */
public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        IList<int> list = new List<int>();

        int[] pflag = new int[26];
        for (int i = 0; i < p.Length; i++)
        {
            pflag[p[i] - 'a']++;
        }

        int[] sflag = new int[26];
        for (int i = 0; i <= s.Length-p.Length; i++)
        {
            for (int j = 0; j < 26; j++) sflag[j] = 0;

            bool isBreak = false;
            for (int j = i; j < i+p.Length; j++)
            {
                int idx = s[j] - 'a';
                sflag[idx]++;

                if (sflag[idx] > pflag[idx])
                {
                    isBreak = true;
                    break;
                }
            }

            if (!isBreak)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (sflag[j] != pflag[j])
                    {
                        isBreak = true;
                        break;
                    }
                }

                if (!isBreak)
                {
                    list.Add(i);
                }
            }
        }

        return list;
    }
}


// √ Accepted
//   √ 36/36 cases passed (1432 ms)
//   √ Your runtime beats 7.94 % of csharp submissions
//   √ Your memory usage beats 94.12 % of csharp submissions (32.6 MB)

