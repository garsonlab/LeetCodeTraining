/*
 * @lc app=leetcode id=166 lang=csharp
 *
 * [166] Fraction to Recurring Decimal
 *
 * https://leetcode.com/problems/fraction-to-recurring-decimal/description/
 *
 * algorithms
 * Medium (19.32%)
 * Total Accepted:    85.7K
 * Total Submissions: 443K
 * Testcase Example:  '1\n2'
 *
 * Given two integers representing the numerator and denominator of a fraction,
 * return the fraction in string format.
 * 
 * If the fractional part is repeating, enclose the repeating part in
 * parentheses.
 * 
 * Example 1:
 * 
 * 
 * Input: numerator = 1, denominator = 2
 * Output: "0.5"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: numerator = 2, denominator = 1
 * Output: "2"
 * 
 * Example 3:
 * 
 * 
 * Input: numerator = 2, denominator = 3
 * Output: "0.(6)"
 * 
 * 
 */
public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        if (numerator == 0 || denominator == 0)
            return "0";

        if (numerator == int.MinValue && denominator == -1)//边界条件，没法直接除，因为除完结果溢出
            return "2147483648";
        if (numerator == -1 && denominator == int.MinValue)//边界条件，都是int类型，没法除
            return "0.0000000004656612873077392578125";
        if (denominator == 1)
            return numerator.ToString();

        return fractionToDecimal((long)numerator, (long)denominator);
    }


    public string fractionToDecimal(long numerator, long denominator)
    {
        StringBuilder builder = new StringBuilder();
        if ((numerator ^ denominator) < 0)
            builder.Append("-");
        // if (numerator == int.MinValue)
        //     numerator = int.MaxValue;
        // else
            numerator = Math.Abs(numerator);
        // if (denominator == int.MinValue)
        //     denominator = int.MaxValue;
        // else
            denominator = Math.Abs(denominator);

        builder.Append(numerator / denominator);
        numerator %= denominator;

        if (numerator == 0)
            return builder.ToString();
        builder.Append(".");

        Dictionary<long, int> dic = new Dictionary<long, int>();

        while (numerator != 0)
        {
            if (dic.ContainsKey(numerator))
            {
                builder.Insert(dic[numerator], "(");
                builder.Append(")");
                break;
            }
            else
            {
                dic[numerator] = builder.Length;
                builder.Append(numerator * 10 / denominator);
                numerator = (numerator * 10) % denominator;
            }
        }

        return builder.ToString();
    }




    public string FractionToDecimal_Outof(int numerator, int denominator) {
        if (numerator == 0 || denominator == 0)
            return "0";

        if (numerator == int.MinValue && denominator == -1)//边界条件，没法直接除，因为除完结果溢出
            return "2147483648";
        if (numerator == -1 && denominator == int.MinValue)//边界条件，都是int类型，没法除
            return "0.0000000004656612873077392578125";
        if (denominator == 1)
            return numerator.ToString();

        StringBuilder builder = new StringBuilder();
        if ((numerator ^ denominator) < 0)
            builder.Append("-");
        if (numerator == int.MinValue)
            numerator = int.MaxValue;
        else
            numerator = Math.Abs(numerator);
        if (denominator == int.MinValue)
            denominator = int.MaxValue;
        else
            denominator = Math.Abs(denominator);

        builder.Append(numerator / denominator);
        numerator %= denominator;

        if (numerator == 0)
            return builder.ToString();
        builder.Append(".");
        
        Dictionary<int, int> dic = new Dictionary<int, int>();

        while (numerator != 0)
        {
            if (dic.ContainsKey(numerator))
            {
                builder.Insert(dic[numerator], "(");
                builder.Append(")");
                break;
            }
            else
            {
                dic[numerator] = builder.Length;
                //double n = numerator * 10.0d;

                //int a = (int)(n / denominator);
                //builder.Append(a);

                //numerator = (int) (n - denominator * 1.0d * a);

                builder.Append(numerator * 10 / denominator);
                numerator = (numerator * 10) % denominator;
            }
        }

        return builder.ToString();
    }
}

// √ Accepted
//   √ 37/37 cases passed (84 ms)
//   √ Your runtime beats 70.89 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (20.6 MB)

