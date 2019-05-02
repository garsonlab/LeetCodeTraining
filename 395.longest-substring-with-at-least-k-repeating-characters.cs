/*
 * @lc app=leetcode id=395 lang=csharp
 *
 * [395] Longest Substring with At Least K Repeating Characters


 Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Example 1:

Input:
s = "aaabb", k = 3

Output:
3

The longest substring is "aaa", as 'a' is repeated 3 times.
Example 2:

Input:
s = "ababbc", k = 2

Output:
5

The longest substring is "ababb", as 'a' is repeated 2 times and 'b' is repeated 3 times.
 */
public class Solution {
    public int LongestSubstring(string s, int k) {
        if(k <= 1)
            return s.Length;
        if (s.Length < k)
            return 0;

        int[] count = new int[26];
        foreach (var c in s)
        {
            count[c - 'a']++;
        }

        int idx = 0;
        while (idx<s.Length && count[s[idx] - 'a'] >= k)
        {
            idx++;
        }

        if (idx == s.Length)
            return idx;

        int left = LongestSubstring(s.Substring(0, idx), k);
        while (idx < s.Length && count[s[idx]-'a'] < k)
        {
            idx++;
        }

        int right = LongestSubstring(s.Substring(idx), k);
        return Math.Max(left, right);
    }
}


// √ Accepted
//   √ 28/28 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (19.9 MB)
