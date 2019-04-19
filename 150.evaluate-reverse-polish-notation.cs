/*
 * @lc app=leetcode id=150 lang=csharp
 *
 * [150] Evaluate Reverse Polish Notation
 *
 * https://leetcode.com/problems/evaluate-reverse-polish-notation/description/
 *
 * algorithms
 * Medium (31.76%)
 * Total Accepted:    156.7K
 * Total Submissions: 492.7K
 * Testcase Example:  '["2","1","+","3","*"]'
 *
 * Evaluate the value of an arithmetic expression in Reverse Polish Notation.
 * 
 * Valid operators are +, -, *, /. Each operand may be an integer or another
 * expression.
 * 
 * Note:
 * 
 * 
 * Division between two integers should truncate toward zero.
 * The given RPN expression is always valid. That means the expression would
 * always evaluate to a result and there won't be any divide by zero
 * operation.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: ["2", "1", "+", "3", "*"]
 * Output: 9
 * Explanation: ((2 + 1) * 3) = 9
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ["4", "13", "5", "/", "+"]
 * Output: 6
 * Explanation: (4 + (13 / 5)) = 6
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]
 * Output: 22
 * Explanation: 
 * ⁠ ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
 * = ((10 * (6 / (12 * -11))) + 17) + 5
 * = ((10 * (6 / -132)) + 17) + 5
 * = ((10 * 0) + 17) + 5
 * = (0 + 17) + 5
 * = 17 + 5
 * = 22
 * 
 * 
 */
public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        int tem;
        foreach (string token in tokens)
        {
            if (int.TryParse(token, out tem))
            {
                stack.Push(tem);
            }
            else
            {
                int fir = stack.Pop();
                int sec = stack.Pop();

                if(token == "+")
                    stack.Push(fir+sec);
                else if(token == "-")
                    stack.Push(sec-fir);
                else if(token == "*")
                    stack.Push(fir*sec);
                else
                    stack.Push(sec/fir);
            }
        }

        return stack.Pop();
    }
}

// √ Accepted
//   √ 20/20 cases passed (100 ms)
//   √ Your runtime beats 96.14 % of csharp submissions
//   √ Your memory usage beats 47.37 % of csharp submissions (23.5 MB)

