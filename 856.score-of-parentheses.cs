/*
 * @lc app=leetcode id=856 lang=csharp
 *
 * [856] Score of Parentheses

 Given a balanced parentheses string S, compute the score of the string based on the following rule:

() has score 1
AB has score A + B, where A and B are balanced parentheses strings.
(A) has score 2 * A, where A is a balanced parentheses string.
 

Example 1:

Input: "()"
Output: 1
Example 2:

Input: "(())"
Output: 2
Example 3:

Input: "()()"
Output: 2
Example 4:

Input: "(()(()))"
Output: 6
 

Note:

S is a balanced parentheses string, containing only ( and ).
2 <= S.length <= 50
 */
public class Solution {
    public int ScoreOfParentheses(string S) {
        int sum = 0, n = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == '(')
            {
                n = n == 0 ? 1 : n * 2;
            }
            else
            {
                if (S[i - 1] == '(')
                    sum += n;
                n /= 2;
            }
        }

        return sum;
    }
}

// √ Accepted
//   √ 85/85 cases passed (92 ms)
//   √ Your runtime beats 12.2 % of csharp submissions
//   √ Your memory usage beats 30.43 % of csharp submissions (20 MB)

