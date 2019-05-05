/*
 * @lc app=leetcode id=467 lang=csharp
 *
 * [467] Unique Substrings in Wraparound String

 Consider the string s to be the infinite wraparound string of "abcdefghijklmnopqrstuvwxyz", so s will look like this: "...zabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcd....".

Now we have another string p. Your job is to find out how many unique non-empty substrings of p are present in s. In particular, your input is the string p and you need to output the number of different non-empty substrings of p in the string s.

Note: p consists of only lowercase English letters and the size of p might be over 10000.

Example 1:
Input: "a"
Output: 1

Explanation: Only the substring "a" of string "a" is in the string s.
Example 2:
Input: "cac"
Output: 2
Explanation: There are two substrings "a", "c" of string "cac" in the string s.
Example 3:
Input: "zab"
Output: 6
Explanation: There are six substrings "z", "a", "b", "za", "ab", "zab" of string "zab" in the string s.
 */
public class Solution {
    public int FindSubstringInWraproundString(string p) {
        int len = p.Length;
            if (len <= 1)
                return len;

            int[] dp = new int[26];
            dp[p[0] - 'a'] = 1;
            int count = 1;
            for (int i = 1; i < len; i++)
            {
                if (p[i] - p[i - 1] == 1 || (p[i] == 'a' && p[i - 1] == 'z'))
                    count++;
                else
                    count = 1;

                int tem = p[i] - 'a';
                dp[tem] = Math.Max(dp[tem], count);
            }

            int res = 0;
            foreach (var d in dp)
            {
                res += d;
            }

            return res;
    }
}

// √ Accepted
//   √ 81/81 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (21.4 MB)

