/*
 * @lc app=leetcode id=567 lang=csharp
 *
 * [567] Permutation in String

 Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1. In other words, one of the first string's permutations is the substring of the second string.

 

Example 1:

Input: s1 = "ab" s2 = "eidbaooo"
Output: True
Explanation: s2 contains one permutation of s1 ("ba").
Example 2:

Input:s1= "ab" s2 = "eidboaoo"
Output: False
 

Note:

The input strings only contain lower case letters.
The length of both given strings is in range [1, 10,000].
 */
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length == 0)
            return true;
        if (s2.Length == 0 || s2.Length < s1.Length)
            return false;

        int[] s1n = new int[26], tem = new int[26];
        int len = s1.Length;

        for (int i = 0; i < len; i++)
        {
            s1n[s1[i] - 'a']++;
            tem[s2[i] - 'a']++;
        }

        if (isSame(s1n, tem))
            return true;

        for (int i = len; i < s2.Length; i++)
        {
            char a = s2[i - len];
            char b = s2[i];
            if(a == b)
                continue;

            tem[a - 'a']--;
            tem[b - 'a']++;
            if (isSame(s1n, tem))
                return true;
        }

        return false;
    }

    private bool isSame(int[] a1, int[] a2)
    {
        for (int i = 0; i < a1.Length; i++)
        {
            if (a1[i] != a2[i])
                return false;
        }

        return true;
    }

}

// √ Accepted
//   √ 103/103 cases passed (76 ms)
//   √ Your runtime beats 98.6 % of csharp submissions
//   √ Your memory usage beats 26.09 % of csharp submissions (22.1 MB)

