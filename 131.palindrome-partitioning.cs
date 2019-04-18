/*
 * @lc app=leetcode id=131 lang=csharp
 *
 * [131] Palindrome Partitioning
 *
 * https://leetcode.com/problems/palindrome-partitioning/description/
 *
 * algorithms
 * Medium (40.23%)
 * Total Accepted:    158.6K
 * Total Submissions: 393.4K
 * Testcase Example:  '"aab"'
 *
 * Given a string s, partition s such that every substring of the partition is
 * a palindrome.
 * 
 * Return all possible palindrome partitioning of s.
 * 
 * Example:
 * 
 * 
 * Input: "aab"
 * Output:
 * [
 * ⁠ ["aa","b"],
 * ⁠ ["a","a","b"]
 * ]
 * 
 * 
 */
public class Solution {
    public IList<IList<string>> Partition(string s)
    {
        IList<IList<string>> list = new List<IList<string>>();
        if (s.Length == 0)
            return list;

        GetPartPalindrome(list, new List<string>(), s, 0);
        return list;
    }

    private void GetPartPalindrome(IList<IList<string>> list, List<string> cur, string s, int idx)
    {
        if(idx >= s.Length)
            return;

        string p = "";
        for (int i = idx; i < s.Length; i++)
        {
            p += s[i];

            if (IsPalindome(p))
            {
                var tem = new List<string>(cur);
                tem.Add(p);
                
                if(i == s.Length-1)
                    list.Add(tem);
                else
                    GetPartPalindrome(list, tem, s, i+1);
            }
        }
    }

    private bool IsPalindome(string p)
    {
        if (p.Length <= 1)
            return true;

        for (int i = 0, j = p.Length - 1; i < j; i++, j--)
        {
            if (p[i] != p[j])
                return false;
        }

        return true;
    }
}

// √ Accepted
//   √ 22/22 cases passed (280 ms)
//   √ Your runtime beats 66.46 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (31.6 MB)

