/*
 * @lc app=leetcode id=925 lang=csharp
 *
 * [925] Long Pressed Name
 *
 * https://leetcode.com/problems/long-pressed-name/description/
 *
 * algorithms
 * Easy (44.27%)
 * Total Accepted:    14.1K
 * Total Submissions: 31.9K
 * Testcase Example:  '"alex"\n"aaleex"'
 *
 * Your friend is typing his name into a keyboard.  Sometimes, when typing a
 * character c, the key might get long pressed, and the character will be typed
 * 1 or more times.
 * 
 * You examine the typed characters of the keyboard.  Return True if it is
 * possible that it was your friends name, with some characters (possibly none)
 * being long pressed.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: name = "alex", typed = "aaleex"
 * Output: true
 * Explanation: 'a' and 'e' in 'alex' were long pressed.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: name = "saeed", typed = "ssaaedd"
 * Output: false
 * Explanation: 'e' must have been pressed twice, but it wasn't in the typed
 * output.
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: name = "leelee", typed = "lleeelee"
 * Output: true
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: name = "laiden", typed = "laiden"
 * Output: true
 * Explanation: It's not necessary to long press any character.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * name.length <= 1000
 * typed.length <= 1000
 * The characters of name and typed are lowercase letters.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int i = 0, j = 0;
        while (i < name.Length && j < typed.Length)
        {
            if (name[i] != typed[j])
            {
                if (i == 0 || typed[j] != name[i - 1])
                    return false;
                j++;
            }
            else
            {
                i++;
                j++;
            }
        }
        if (i < name.Length)
            return false;

        for (; j < typed.Length; j++)
        {
            if (typed[j] != name[i - 1])
                return false;
        }

        return true;
    }
}

// √ Accepted
//   √ 71/71 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (20.1 MB)

