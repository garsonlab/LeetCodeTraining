/*
 * @lc app=leetcode id=784 lang=csharp
 *
 * [784] Letter Case Permutation
 *
 * https://leetcode.com/problems/letter-case-permutation/description/
 *
 * algorithms
 * Easy (55.54%)
 * Total Accepted:    41.6K
 * Total Submissions: 74.6K
 * Testcase Example:  '"a1b2"'
 *
 * Given a string S, we can transform every letter individually to be lowercase
 * or uppercase to create another string.  Return a list of all possible
 * strings we could create.
 * 
 * 
 * Examples:
 * Input: S = "a1b2"
 * Output: ["a1b2", "a1B2", "A1b2", "A1B2"]
 * 
 * Input: S = "3z4"
 * Output: ["3z4", "3Z4"]
 * 
 * Input: S = "12345"
 * Output: ["12345"]
 * 
 * 
 * Note:
 * 
 * 
 * S will be a string with length between 1 and 12.
 * S will consist only of letters or digits.
 * 
 * 
 */
public class Solution {
        public IList<string> LetterCasePermutation(string S)
    {
        IList<string> ret = new List<string>();

        List<List<char>> chars = new List<List<char>>();
        for (int i = 0; i < S.Length; i++)
        {
            List<char> list = new List<char>();
            list.Add(S[i]);
            if (S[i] >= 'A' && S[i] <= 'Z')
            {
                list.Add((char) (S[i] - 'A' + 'a'));
            }
            else if (S[i] >= 'a' && S[i] <= 'z')
            {
                list.Add((char)(S[i] - 'a' + 'A'));
            }
            chars.Add(list);
        }

        GetStr(chars, ret, 0, "");
        return ret;
    }

    private void GetStr(List<List<char>> chars, IList<string> ret, int c, string r)
    {
        List<char> list = chars[c];
        for (int i = 0; i < list.Count; i++)
        {
            if (c == chars.Count - 1)
            {
                ret.Add(r+list[i]);
            }
            else
            {
                GetStr(chars, ret, c+1, r+list[i]);
            }
        }
    }

     private void GetStr(string S, IList<string> ret, int c, string r)
    {
        if (c == S.Length - 1)
        {
            ret.Add(r + S[c]);
            if (S[c] >= 'A' && S[c] <= 'Z')
            {
                ret.Add(r + (char)(S[c] - 'A' + 'a'));
            }
            else if (S[c] >= 'a' && S[c] <= 'z')
            {
                ret.Add(r + (char)(S[c] - 'a' + 'A'));
            }
        }
        else
        {
            GetStr(S, ret, c+1, r + S[c]);
            if (S[c] >= 'A' && S[c] <= 'Z')
            {
                GetStr(S, ret, c + 1, r + (char)(S[c] - 'A' + 'a'));
            }
            else if (S[c] >= 'a' && S[c] <= 'z')
            {
                GetStr(S, ret, c + 1, r + (char)(S[c] - 'a' + 'A'));
            }
        }
    }
}

// √ Accepted
//   √ 63/63 cases passed (264 ms)
//   √ Your runtime beats 87.26 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (32.5 MB)

