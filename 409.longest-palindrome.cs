/*
 * @lc app=leetcode id=409 lang=csharp
 *
 * [409] Longest Palindrome
 *
 * https://leetcode.com/problems/longest-palindrome/description/
 *
 * algorithms
 * Easy (47.57%)
 * Total Accepted:    91.8K
 * Total Submissions: 192.6K
 * Testcase Example:  '"abccccdd"'
 *
 * Given a string which consists of lowercase or uppercase letters, find the
 * length of the longest palindromes that can be built with those letters.
 * 
 * This is case sensitive, for example "Aa" is not considered a palindrome
 * here.
 * 
 * Note:
 * Assume the length of given string will not exceed 1,010.
 * 
 * 
 * Example: 
 * 
 * Input:
 * "abccccdd"
 * 
 * Output:
 * 7
 * 
 * Explanation:
 * One longest palindrome that can be built is "dccaccd", whose length is 7.
 * 
 * 
 */
public class Solution {

    public int LongestPalindrome(string s)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            int n = 0;
            if (dic.TryGetValue(s[i], out n))
            {
            }

            dic[s[i]] = n + 1;
        }

        int num = 0;
        bool single = false;

        foreach (int value in dic.Values)
        {
            num += value / 2 * 2;
            if (!single && value % 2 > 0)
            {
                num++;
                single = true;
            }
        }

        return num;
    }

    //此处求得是最长串，不是组合的
    public int LongestPalindrome2(string s) {
        int length = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            int len = 1;
            int p = i - 1, n = i + 1;
            while (p >= 0 && n < s.Length && s[p] == s[n])
            {
                p--;
                n++;
            }

            if (p != i - 1)
            {
                len = (i - p - 1) * 2 + 1;
            }


            p = i; n = i + 1;
            while (p >= 0 && n < s.Length && s[p] == s[n])
            {
                p--;
                n++;
            }

            if (p != i)
            {
                int l = (i - p) * 2;
                len = l > len ? l : len;
            }

            if (len > length)
                length = len;
        }

        return length;
    }
}


// √ Accepted
//   √ 95/95 cases passed (76 ms)
//   √ Your runtime beats 86.59 % of csharp submissions
//   √ Your memory usage beats 62.16 % of csharp submissions (20.1 MB)

