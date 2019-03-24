/*
 * @lc app=leetcode id=20 lang=csharp
 *
 * [20] Valid Parentheses
 *
 * https://leetcode.com/problems/valid-parentheses/description/
 *
 * algorithms
 * Easy (36.06%)
 * Total Accepted:    537.9K
 * Total Submissions: 1.5M
 * Testcase Example:  '"()"'
 *
 * Given a string containing just the characters '(', ')', '{', '}', '[' and
 * ']', determine if the input string is valid.
 * 
 * An input string is valid if:
 * 
 * 
 * Open brackets must be closed by the same type of brackets.
 * Open brackets must be closed in the correct order.
 * 
 * 
 * Note that an empty string is also considered valid.
 * 
 * Example 1:
 * 
 * 
 * Input: "()"
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "()[]{}"
 * Output: true
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "(]"
 * Output: false
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: "([)]"
 * Output: false
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: "{[]}"
 * Output: true
 * 
 * 
 */
public class Solution {
    public bool IsValid(string s) {
        int len = s.Length;
        if (len % 2 > 0)
            return false;

        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < len; i++)
        {
            if(stack.Count <= 0)
                stack.Push(s[i]);
            else
            {
                char top  = stack.Peek();
                if (top != s[i] && Math.Abs(s[i] - top) < 3)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
        }

        return stack.Count <= 0;
    }
}

