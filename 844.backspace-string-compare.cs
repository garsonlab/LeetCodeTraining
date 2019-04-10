/*
 * @lc app=leetcode id=844 lang=csharp
 *
 * [844] Backspace String Compare
 *
 * https://leetcode.com/problems/backspace-string-compare/description/
 *
 * algorithms
 * Easy (45.42%)
 * Total Accepted:    50.2K
 * Total Submissions: 110.2K
 * Testcase Example:  '"ab#c"\n"ad#c"'
 *
 * Given two strings S and T, return if they are equal when both are typed into
 * empty text editors. # means a backspace character.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: S = "ab#c", T = "ad#c"
 * Output: true
 * Explanation: Both S and T become "ac".
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: S = "ab##", T = "c#d#"
 * Output: true
 * Explanation: Both S and T become "".
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: S = "a##c", T = "#a#c"
 * Output: true
 * Explanation: Both S and T become "c".
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: S = "a#c", T = "b"
 * Output: false
 * Explanation: S becomes "c" while T becomes "b".
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= S.length <= 200
 * 1 <= T.length <= 200
 * S and T only contain lowercase letters and '#' characters.
 * 
 * 
 * Follow up:
 * 
 * 
 * Can you solve it in O(N) time and O(1) space?
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool BackspaceCompare(string S, string T) {
        Stack<char> stack = new Stack<char>();
        foreach (var c in S)
        {
            if (c == '#')
            {
                if(stack.Count > 0)
                    stack.Pop();
            }
            else
                stack.Push(c);
        }

        string s = new string(stack.ToArray());
        stack.Clear();
        foreach (var c in T)
        {
            if (c == '#')
            {
                if(stack.Count > 0)
                    stack.Pop();
            }
            else
                stack.Push(c);
        }

        return s == new string(stack.ToArray());
    }
}

// √ Accepted
//   √ 104/104 cases passed (88 ms)
//   √ Your runtime beats 48.96 % of csharp submissions
//   √ Your memory usage beats 5.88 % of csharp submissions (20.5 MB)

