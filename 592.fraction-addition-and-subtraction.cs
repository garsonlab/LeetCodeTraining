/*
 * @lc app=leetcode id=592 lang=csharp
 *
 * [592] Fraction Addition and Subtraction
 Given a string representing an expression of fraction addition and subtraction, you need to return the calculation result in string format. The final result should be irreducible fraction. If your final result is an integer, say 2, you need to change it to the format of fraction that has denominator 1. So in this case, 2 should be converted to 2/1.

Example 1:
Input:"-1/2+1/2"
Output: "0/1"
Example 2:
Input:"-1/2+1/2+1/3"
Output: "1/3"
Example 3:
Input:"1/3-1/2"
Output: "-1/6"
Example 4:
Input:"5/3+1/3"
Output: "2/1"
Note:
The input string only contains '0' to '9', '/', '+' and '-'. So does the output.
Each fraction (input and output) has format ±numerator/denominator. If the first input fraction or the output is positive, then '+' will be omitted.
The input only contains valid irreducible fractions, where the numerator and denominator of each fraction will always be in the range [1,10]. If the denominator is 1, it means this fraction is actually an integer in a fraction format defined above.
The number of given fractions will be in the range [1,10].
The numerator and denominator of the final result are guaranteed to be valid and in the range of 32-bit int.
 */
public class Solution {
    public string FractionAddition(string expression)
    {
        expression = expression.Replace("-", "+-");
        string[] ex = expression.Split('+');
        List<int[]> list = new List<int[]>();
        int b = 0;
        foreach (var s in ex)
        {
            if(s.Length == 0)
                continue;

            string[] ns = s.Split('/');
            int[] t = new[] {int.Parse(ns[0]), int.Parse(ns[1])};
            list.Add(t);

            if (b == 0)
                b = t[1];
            else
                b = minGongBeiShu(b, t[1]);
        }

        int a = 0;
        foreach (var l in list)
        {
            a += l[0] * (b / l[1]);
        }

        if (a == 0)
            return "0/1";

        int c = maxGongYue(Math.Abs(a), Math.Abs(b));
        a /= c;
        b /= c;

        string res = "";
        if (a * b < 0)
            res = "-";
        return res + Math.Abs(a) + "/" + Math.Abs(b);
    }

    private int minGongBeiShu(int n1, int n2)
    {
        int temp = Math.Max(n1, n2);
        n2 = Math.Min(n1, n2);//n2中存放两个数中最小的
        n1 = temp;//n1中存放两个数中最大的
        int product = n1 * n2;//求两个数的乘积
        while (n2 != 0)
        {
            n1 = n1 > n2 ? n1 : n2;//使n1中的数大于n2中的数
            int m = n1 % n2;
            n1 = n2;
            n2 = m;
        }
        
        return (product / n1);//最小公倍数
    }

    private int maxGongYue(int a, int b)
    {
        if (a <= 0 || b <= 0)
            return 1;
        else if (a > b)
            return maxGongYue(a - b, b);
        else if
            (a < b)
            return maxGongYue(a, b - a);
        else
            return a;
    }

}

// √ Accepted
//   √ 105/105 cases passed (104 ms)
//   √ Your runtime beats 56.25 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (21.1 MB)

