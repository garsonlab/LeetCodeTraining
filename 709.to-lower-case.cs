/*
 * @lc app=leetcode id=709 lang=csharp
 *
 * [709] To Lower Case
 *
 * https://leetcode.com/problems/to-lower-case/description/
 *
 * algorithms
 * Easy (76.40%)
 * Total Accepted:    90.8K
 * Total Submissions: 118.7K
 * Testcase Example:  '"Hello"'
 *
 * Implement function ToLowerCase() that has a string parameter str, and
 * returns the same string in lowercase.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "Hello"
 * Output: "hello"
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "here"
 * Output: "here"
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "LOVELY"
 * Output: "lovely"
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public string ToLowerCase(string str) {
        if (str.Length <= 0)
            return "";

        char[] chars = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 'A' && str[i] <= 'Z')
            {
                chars[i] = (char) (str[i] - 'A' + 'a');
            }
            else
            {
                chars[i] = str[i];
            }
        }
        return new string(chars);
    }
}

// √ Accepted
//   √ 8/8 cases passed (80 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 40.62 % of csharp submissions (20.5 MB)

