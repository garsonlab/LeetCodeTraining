/*
 * @lc app=leetcode id=482 lang=csharp
 *
 * [482] License Key Formatting
 *
 * https://leetcode.com/problems/license-key-formatting/description/
 *
 * algorithms
 * Easy (40.42%)
 * Total Accepted:    73.4K
 * Total Submissions: 181.2K
 * Testcase Example:  '"5F3Z-2e-9-w"\n4'
 *
 * You are given a license key represented as a string S which consists only
 * alphanumeric character and dashes. The string is separated into N+1 groups
 * by N dashes.
 * 
 * Given a number K, we would want to reformat the strings such that each group
 * contains exactly K characters, except for the first group which could be
 * shorter than K, but still must contain at least one character. Furthermore,
 * there must be a dash inserted between two groups and all lowercase letters
 * should be converted to uppercase.
 * 
 * Given a non-empty string S and a number K, format the string according to
 * the rules described above.
 * 
 * Example 1:
 * 
 * Input: S = "5F3Z-2e-9-w", K = 4
 * 
 * Output: "5F3Z-2E9W"
 * 
 * Explanation: The string S has been split into two parts, each part has 4
 * characters.
 * Note that the two extra dashes are not needed and can be removed.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: S = "2-5g-3-J", K = 2
 * 
 * Output: "2-5G-3J"
 * 
 * Explanation: The string S has been split into three parts, each part has 2
 * characters except the first part as it could be shorter as mentioned
 * above.
 * 
 * 
 * 
 * Note:
 * 
 * The length of string S will not exceed 12,000, and K is a positive integer.
 * String S consists only of alphanumerical characters (a-z and/or A-Z and/or
 * 0-9) and dashes(-).
 * String S is non-empty.
 * 
 * 
 */
public class Solution {
    public string LicenseKeyFormatting(string S, int K)
    {
        Stack<char> stack = new Stack<char>();
        int f = K;
        for (int i = S.Length-1; i >= 0; i--)
        {
            if(S[i] == '-')
                continue;

            if(f == K && stack.Count > 0){
                stack.Push('-');
            }

            if (S[i] >= 'a' && S[i] <= 'z')
            {
                stack.Push((char) (S[i] - 'a' + 'A'));
            }
            else
            {
                stack.Push(S[i]);
            }

            if (--f <= 0)
            {
                f = K;
            }
        }

        return new string(stack.ToArray());
    }

    //超时
    public string LicenseKeyFormatting2(string S, int K) {
        string s = S.Replace("-", "").ToUpper();
        if (s.Length == 0)
            return "";
        
        int idx = s.Length % K;
        idx = idx == 0 ? K : idx;
        string r = s.Substring(0, idx);
        for (int i = idx; i < s.Length;)
        {
            r += "-";
            r += s.Substring(i, K);
            i += K;
        }

        return r;
    }
}


// √ Accepted
//   √ 38/38 cases passed (88 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (25.8 MB)

