/*
 * @lc app=leetcode id=1021 lang=csharp
 *
 * [1021] Remove Outermost Parentheses
 *
 * https://leetcode.com/problems/remove-outermost-parentheses/description/
 *
 * algorithms
 * Easy (82.62%)
 * Total Accepted:    8.6K
 * Total Submissions: 10.5K
 * Testcase Example:  '"(()())(())"'
 *
 * A valid parentheses string is either empty (""), "(" + A + ")", or A + B,
 * where A and B are valid parentheses strings, and + represents string
 * concatenation.  For example, "", "()", "(())()", and "(()(()))" are all
 * valid parentheses strings.
 * 
 * A valid parentheses string S is primitive if it is nonempty, and there does
 * not exist a way to split it into S = A+B, with A and B nonempty valid
 * parentheses strings.
 * 
 * Given a valid parentheses string S, consider its primitive decomposition: S
 * = P_1 + P_2 + ... + P_k, where P_i are primitive valid parentheses strings.
 * 
 * Return S after removing the outermost parentheses of every primitive string
 * in the primitive decomposition of S.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "(()())(())"
 * Output: "()()()"
 * Explanation: 
 * The input string is "(()())(())", with primitive decomposition "(()())" +
 * "(())".
 * After removing outer parentheses of each part, this is "()()" + "()" =
 * "()()()".
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "(()())(())(()(()))"
 * Output: "()()()()(())"
 * Explanation: 
 * The input string is "(()())(())(()(()))", with primitive decomposition
 * "(()())" + "(())" + "(()(()))".
 * After removing outer parentheses of each part, this is "()()" + "()" +
 * "()(())" = "()()()()(())".
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "()()"
 * Output: ""
 * Explanation: 
 * The input string is "()()", with primitive decomposition "()" + "()".
 * After removing outer parentheses of each part, this is "" + "" = "".
 * 
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * S.length <= 10000
 * S[i] is "(" or ")"
 * S is a valid parentheses string
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public string RemoveOuterParentheses(string S) {
        string str = "";
        int s = -1;
        int n = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == '(')
            {
                n++;
                if (s == -1)
                    s = i;
            }
            else
            {
                n--;
                if (n == 0)
                {
                    str += S.Substring(s + 1, i - 1 - s);
                    s = -1;
                }
            }
        }

        return str;
    }
}

// √ Accepted
//   √ 59/59 cases passed (92 ms)
//   √ Your runtime beats 54.33 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (27 MB)

