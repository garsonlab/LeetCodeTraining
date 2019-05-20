/*
 * @lc app=leetcode id=921 lang=csharp
 *
 * [921] Minimum Add to Make Parentheses Valid

 Given a string S of '(' and ')' parentheses, we add the minimum number of parentheses ( '(' or ')', and in any positions ) so that the resulting parentheses string is valid.

Formally, a parentheses string is valid if and only if:

It is the empty string, or
It can be written as AB (A concatenated with B), where A and B are valid strings, or
It can be written as (A), where A is a valid string.
Given a parentheses string, return the minimum number of parentheses we must add to make the resulting string valid.

 

Example 1:

Input: "())"
Output: 1
Example 2:

Input: "((("
Output: 3
Example 3:

Input: "()"
Output: 0
Example 4:

Input: "()))(("
Output: 4
 

Note:

S.length <= 1000
S only consists of '(' and ')' characters.
 */
public class Solution {
    public int MinAddToMakeValid(string S) {
        Stack<int> stack = new Stack<int>();
        int res = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == '(')
            {
                stack.Push(1);
            }
            else
            {
                if (stack.Count > 0)
                    stack.Pop();
                else
                    res++;
            }
        }

        res += stack.Count;

        return res;
    }
}

// √ Accepted
//   √ 116/116 cases passed (72 ms)
//   √ Your runtime beats 95.83 % of csharp submissions
//   √ Your memory usage beats 18.88 % of csharp submissions (20.2 MB)

