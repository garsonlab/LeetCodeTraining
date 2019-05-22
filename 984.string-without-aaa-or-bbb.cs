/*
 * @lc app=leetcode id=984 lang=csharp
 *
 * [984] String Without AAA or BBB

 Given two integers A and B, return any string S such that:

S has length A + B and contains exactly A 'a' letters, and exactly B 'b' letters;
The substring 'aaa' does not occur in S;
The substring 'bbb' does not occur in S.
 

Example 1:

Input: A = 1, B = 2
Output: "abb"
Explanation: "abb", "bab" and "bba" are all correct answers.
Example 2:

Input: A = 4, B = 1
Output: "aabaa"
 

Note:

0 <= A <= 100
0 <= B <= 100
It is guaranteed such an S exists for the given A and B.
 */
public class Solution {
    public string StrWithout3a3b(int A, int B) {
        char a = 'a', b = 'b';
        if (A < B)
        {
            int tem = A;
            A = B;
            B = tem;
            a = 'b';
            b = 'a';
        }

        StringBuilder builder = new StringBuilder();
        while (A > 0 || B > 0)
        {
            if (A > 0)
            {
                builder.Append(a);
                A--;
            }

            if (A > B)
            {
                builder.Append(a);
                A--;
            }

            if (B > 0)
            {
                builder.Append(b);
                B--;
            }
        }

        return builder.ToString();
    }
}
// √ Accepted
//   √ 103/103 cases passed (80 ms)
//   √ Your runtime beats 98.81 % of csharp submissions
//   √ Your memory usage beats 81.54 % of csharp submissions (20.5 MB)
