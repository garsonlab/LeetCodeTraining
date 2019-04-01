/*
 * @lc app=leetcode id=415 lang=csharp
 *
 * [415] Add Strings
 *
 * https://leetcode.com/problems/add-strings/description/
 *
 * algorithms
 * Easy (43.21%)
 * Total Accepted:    88.5K
 * Total Submissions: 204.1K
 * Testcase Example:  '"0"\n"0"'
 *
 * Given two non-negative integers num1 and num2 represented as string, return
 * the sum of num1 and num2.
 * 
 * Note:
 * 
 * The length of both num1 and num2 is < 5100.
 * Both num1 and num2 contains only digits 0-9.
 * Both num1 and num2 does not contain any leading zero.
 * You must not use any built-in BigInteger library or convert the inputs to
 * integer directly.
 * 
 * 
 */
public class Solution {
    public string AddStrings(string num1, string num2) {
        string val = "";
        int add = 0;
        int i = num1.Length - 1;
        int j = num2.Length - 1;
        for (; i >= 0 && j >= 0; i--, j--)
        {
            int v = num1[i] - '0' + num2[j] - '0' + add;
            add = v / 10;
            val = (char) (v % 10 + '0') + val;
        }

        if (i >= 0)
        {
            for (; i>= 0; i--)
            {
                int v = num1[i] - '0' + add;
                add = v / 10;
                val = (char)(v % 10 + '0') + val;
            }
        }
        else if (j >= 0)
        {
            for (; j >= 0; j--)
            {
                int v = num2[j] - '0' + add;
                add = v / 10;
                val = (char)(v % 10 + '0') + val;
            }
        }

        if (add > 0)
        {
            val = (char)(add + '0') + val;
        }

        return val;
    }
}


// √ Accepted
//   √ 315/315 cases passed (136 ms)
//   √ Your runtime beats 30 % of csharp submissions
//   √ Your memory usage beats 6.25 % of csharp submissions (45.2 MB)

