/*
 * @lc app=leetcode id=91 lang=csharp
 *
 * [91] Decode Ways
 *
 * https://leetcode.com/problems/decode-ways/description/
 *
 * algorithms
 * Medium (22.11%)
 * Total Accepted:    250.7K
 * Total Submissions: 1.1M
 * Testcase Example:  '"12"'
 *
 * A message containing letters from A-Z is being encoded to numbers using the
 * following mapping:
 * 
 * 
 * 'A' -> 1
 * 'B' -> 2
 * ...
 * 'Z' -> 26
 * 
 * 
 * Given a non-empty string containing only digits, determine the total number
 * of ways to decode it.
 * 
 * Example 1:
 * 
 * 
 * Input: "12"
 * Output: 2
 * Explanation: It could be decoded as "AB" (1 2) or "L" (12).
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "226"
 * Output: 3
 * Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2
 * 6).
 * 
 */
public class Solution {
    public int NumDecodings(string s) {
        if (s.Length < 1 || s[0] == '0')
            return 0;
        if (s.Length == 1)
            return 1;

        int pre = 1;
        int cur = 1;
        for (int i = 1; i < s.Length; i++)
        {
            int tem = s[i] == '0' ? 0 : cur;

            if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] >= '0' && s[i] <= '6'))
            {
                tem += pre;
            }

            pre = cur;
            cur = tem;
        }

        return cur;
    }
}

// √ Accepted
//   √ 258/258 cases passed (72 ms)
//   √ Your runtime beats 99.61 % of csharp submissions
//   √ Your memory usage beats 79.31 % of csharp submissions (20.4 MB)

