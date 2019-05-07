/*
 * @lc app=leetcode id=522 lang=csharp
 *
 * [522] Longest Uncommon Subsequence II

 Given a list of strings, you need to find the longest uncommon subsequence among them. The longest uncommon subsequence is defined as the longest subsequence of one of these strings and this subsequence should not be any subsequence of the other strings.

A subsequence is a sequence that can be derived from one sequence by deleting some characters without changing the order of the remaining elements. Trivially, any string is a subsequence of itself and an empty string is a subsequence of any string.

The input will be a list of strings, and the output needs to be the length of the longest uncommon subsequence. If the longest uncommon subsequence doesn't exist, return -1.

Example 1:
Input: "aba", "cdc", "eae"
Output: 3
Note:

All the given strings' lengths will not exceed 10.
The length of the given list will be in the range of [2, 50].
 */
public class Solution {
    public int FindLUSlength(string[] strs)
    {
        int maxLen = -1;
        for (int i = 0; i < strs.Length; ++i)
        {
            int currentLen = strs[i].Length;
            bool all = true;
            for (int j = 0; j < strs.Length; ++j)
            {
                if (i != j && HasCommon(strs[i], strs[j]))
                {
                    all = false;
                    break;
                }
            }
            if (all)
            {
                maxLen = maxLen < currentLen ? currentLen : maxLen;
            }
        }
        return maxLen;
    }

    bool HasCommon(string a, string b)
    {
        int len1 = a.Length;
        int len2 = b.Length;
        while (len1 > 0 && len2 > 0)
        {
            int i = a.Length - len1;
            int j = b.Length - len2;
            if (a[i] == b[j])
            {
                len1--;
                len2--;
            }
            else
            {
                len2--;
            }
        }

        return len1 == 0;
    }




    public int FindLUSlength_1(string[] strs)
    {
        int n = strs.Length;
        if (n <= 0)
            return -1;
        if (n == 1)
            return strs[0].Length;

        int res = -1;

        int[,] f = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            int len = strs[i].Length;
            bool all = true;
            for (int j = 0; j < n; j++)
            {
                if(i == j)
                    continue;
                int v;
                if (f[i, j] != 0)
                {
                    v = f[i, j];
                }
                else
                {
                    v = hasCommon(strs[i], strs[j]);
                    f[i, j] = v;
                    f[j, i] = v;
                }

                if (v == 1)
                {
                    all = false;
                    break;
                }
            }

            if (all)
                res = Math.Max(res, len);
        }

        return res;
    }

    private int hasCommon(string a, string b)
    {
        int i = 0, j = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i] == b[j])
            {
                i++;
                j++;
            }
            else
            {
                j++;
            }
        }

        return i == a.Length? 1 : -1;
    }
}

// √ Accepted
//   √ 98/98 cases passed (92 ms)
//   √ Your runtime beats 75 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.1 MB)

