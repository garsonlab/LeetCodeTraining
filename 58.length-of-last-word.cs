/*
 * @lc app=leetcode id=58 lang=csharp
 *
 * [58] Length of Last Word
 *
 * https://leetcode.com/problems/length-of-last-word/description/
 *
 * algorithms
 * Easy (32.18%)
 * Total Accepted:    252K
 * Total Submissions: 782.9K
 * Testcase Example:  '"Hello World"'
 *
 * Given a string s consists of upper/lower-case alphabets and empty space
 * characters ' ', return the length of last word in the string.
 * 
 * If the last word does not exist, return 0.
 * 
 * Note: A word is defined as a character sequence consists of non-space
 * characters only.
 * 
 * Example:
 * 
 * Input: "Hello World"
 * Output: 5
 * 
 * 
 */
public class Solution {
    public int LengthOfLastWord(string s) {
        if (s.Length <= 0)
        {
            return 0;
        }

        int last = 0;
        bool hasWord = false;
        for (int i = s.Length-1; i >= 0; i--)
        {
            if (s[i] != ' ')
            {
                if (last == 0)
                {
                    last = i;
                }
                hasWord = true;
            }
            else
            {
                if(last > 0)
                {
                    return last-i;
                }
            }
        }
        if (hasWord)
        {
            last+=1;
        }
        return last;
    }
}

// √ Accepted
//   √ 59/59 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 87.23 % of csharp submissions (20 MB)


