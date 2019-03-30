/*
 * @lc app=leetcode id=344 lang=csharp
 *
 * [344] Reverse String
 *
 * https://leetcode.com/problems/reverse-string/description/
 *
 * algorithms
 * Easy (62.90%)
 * Total Accepted:    393.8K
 * Total Submissions: 625.4K
 * Testcase Example:  '["h","e","l","l","o"]'
 *
 * Write a function that reverses a string. The input string is given as an
 * array of characters char[].
 * 
 * Do not allocate extra space for another array, you must do this by modifying
 * the input array in-place with O(1) extra memory.
 * 
 * You may assume all the characters consist of printable ascii
 * characters.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: ["h","e","l","l","o"]
 * Output: ["o","l","l","e","h"]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ["H","a","n","n","a","h"]
 * Output: ["h","a","n","n","a","H"]
 * 
 * 
 * 
 * 
 */
public class Solution {
    public void ReverseString(char[] s) {
        for (int i = 0, j = s.Length-1; i < j; i++, j--)
        {
            char tem = s[i];
            s[i] = s[j];
            s[j] = tem;
        }
    }
}

// √ Accepted
//   √ 478/478 cases passed (396 ms)
//   √ Your runtime beats 57.06 % of csharp submissions
//   √ Your memory usage beats 92.93 % of csharp submissions (33.1 MB)

