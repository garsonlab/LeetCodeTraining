/*
 * @lc app=leetcode id=43 lang=csharp
 *
 * [43] Multiply Strings
 *
 * https://leetcode.com/problems/multiply-strings/description/
 *
 * algorithms
 * Medium (30.30%)
 * Total Accepted:    192.9K
 * Total Submissions: 636.3K
 * Testcase Example:  '"2"\n"3"'
 *
 * Given two non-negative integers num1 and num2 represented as strings, return
 * the product of num1 and num2, also represented as a string.
 * 
 * Example 1:
 * 
 * 
 * Input: num1 = "2", num2 = "3"
 * Output: "6"
 * 
 * Example 2:
 * 
 * 
 * Input: num1 = "123", num2 = "456"
 * Output: "56088"
 * 
 * 
 * Note:
 * 
 * 
 * The length of both num1 and num2 is < 110.
 * Both num1 and num2 contain only digits 0-9.
 * Both num1 and num2 do not contain any leading zero, except the number 0
 * itself.
 * You must not use any built-in BigInteger library or convert the inputs to
 * integer directly.
 * 
 * 
 */
public class Solution {
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
            return "0";

        int idx = 0;
        StringBuilder builder = new StringBuilder();
        for (int i = num2.Length-1; i >= 0; i--)
        {
            MulSingle(builder, num1, num2[i]-'0', idx++);
        }

        string re = builder.ToString();
        builder.Length = 0;
        for (int i = re.Length-1; i >= 0; i--)
        {
            builder.Append(re[i]);
        }
        
        return builder.ToString();
    }

    private void MulSingle(StringBuilder builder, string num, int n, int s)
    {
        if (n == 0)
            return;

        for (int i = builder.Length; i <= s; i++)
        {
            builder.Append("0");
        }

        int add = 0;
        for (int i = num.Length-1; i >= 0; i--)
        {
            int v = (num[i] - '0') * n + add;

            if (s >= builder.Length)
                builder.Append(v % 10);
            else
            {
                v += (builder[s] - '0');
                builder[s] = (char) (v % 10 + '0');
            }

            s++;
            add = v / 10;
        }

        while (add > 0)
        {
            if (s >= builder.Length)
                builder.Append(add % 10);
            else
                builder[s] = (char)(add % 10 + '0');

            s++;
            add = add / 10;
        }
    }

}

// √ Accepted
//   √ 311/311 cases passed (92 ms)
//   √ Your runtime beats 81.03 % of csharp submissions
//   √ Your memory usage beats 94.74 % of csharp submissions (23 MB)

