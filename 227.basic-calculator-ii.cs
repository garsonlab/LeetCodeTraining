/*
 * @lc app=leetcode id=227 lang=csharp
 *
 * [227] Basic Calculator II

    Implement a basic calculator to evaluate a simple expression string.

    The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.

    Example 1:

    Input: "3+2*2"
    Output: 7
    Example 2:

    Input: " 3/2 "
    Output: 1
    Example 3:

    Input: " 3+5 / 2 "
    Output: 5
    Note:

    You may assume that the given expression is always valid.
    Do not use the eval built-in library function.
 */
public class Solution {
    public int Calculate(string s) {
        int ret = 0;
        int tem = 0;
        int symbol = 0;
        Stack<int> stack = new Stack<int>();

        foreach (var c in s)
        {
            if(c == ' ')
                continue;

            if (c >= '0' && c <= '9')
            {
                tem = tem * 10 + (c - '0');
            }
            else
            { 
                if(symbol == 0)
                    stack.Push(tem);
                else if (symbol == 1)
                    stack.Push(-tem);
                else if (symbol == 2)
                {
                    var t = stack.Pop();
                    stack.Push(t*tem);
                }
                else
                {
                    var t = stack.Pop();
                    stack.Push(t / tem);
                }

                tem = 0;
                
                if (c == '+')
                    symbol = 0;
                else if (c == '-')
                    symbol = 1;
                else if (c == '*')
                    symbol = 2;
                else if (c == '/')
                    symbol = 3;
            }
        }

        if (symbol == 0)
            stack.Push(tem);
        else if (symbol == 1)
            stack.Push(-tem);
        else if (symbol == 2)
        {
            var t = stack.Pop();
            stack.Push(t * tem);
        }
        else
        {
            var t = stack.Pop();
            stack.Push(t / tem);
        }

        while (stack.Count > 0)
        {
            ret += stack.Pop();
        }

        return ret;
    }
}

// √ Accepted
//   √ 109/109 cases passed (80 ms)
//   √ Your runtime beats 86.36 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (23.1 MB)

