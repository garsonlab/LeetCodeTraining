/*
 * @lc app=leetcode id=537 lang=csharp
 *
 * [537] Complex Number Multiplication
 Given two strings representing two complex numbers.

You need to return a string representing their multiplication. Note i2 = -1 according to the definition.

Example 1:
Input: "1+1i", "1+1i"
Output: "0+2i"
Explanation: (1 + i) * (1 + i) = 1 + i2 + 2 * i = 2i, and you need convert it to the form of 0+2i.
Example 2:
Input: "1+-1i", "1+-1i"
Output: "0+-2i"
Explanation: (1 - i) * (1 - i) = 1 + i2 - 2 * i = -2i, and you need convert it to the form of 0+-2i.
Note:

The input strings will not have extra blank.
The input strings will be given in the form of a+bi, where the integer a and b will both belong to the range of [-100, 100]. And the output should be also in this form.
 */
public class Solution {
    public string ComplexNumberMultiply(string a, string b) {
        int a1 = 0, a2 = 0, b1 = 0, b2 = 0;
        ParseCN(a, ref a1, ref a2);
        ParseCN(b, ref b1, ref b2);

        int r1 = a1*b1 - a2*b2;
        int r2 = a2*b1 + a1*b2;
        return r1 + "+" + r2 + "i";
    }

    private void ParseCN(string a, ref int x, ref int y) {
        string[] ps = a.Split('+');
        x = int.Parse(ps[0]);

        string s = ps[1].Substring(0, ps[1].Length-1);
        if(s.Length == 1 && s[0] == '-')
            y = -1;
        else if(s.Length == 0)
            y = 1;
        else
            y = int.Parse(s);
    }
}

// √ Accepted
//   √ 55/55 cases passed (84 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (21 MB)

