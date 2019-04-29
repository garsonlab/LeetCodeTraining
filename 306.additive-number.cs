/*
 * @lc app=leetcode id=306 lang=csharp
 *
 * [306] Additive Number

 Additive number is a string whose digits can form additive sequence.

A valid additive sequence should contain at least three numbers. Except for the first two numbers, each subsequent number in the sequence must be the sum of the preceding two.

Given a string containing only digits '0'-'9', write a function to determine if it's an additive number.

Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.

Example 1:

Input: "112358"
Output: true 
Explanation: The digits can form an additive sequence: 1, 1, 2, 3, 5, 8. 
             1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
Example 2:

Input: "199100199"
Output: true 
Explanation: The additive sequence is: 1, 99, 100, 199. 
             1 + 99 = 100, 99 + 100 = 199
Follow up:
How would you handle overflow for very large input integers?
 */
public class Solution {
    public bool IsAdditiveNumber(string num)
    {
        if (num.Length < 3)
            return false;

        for (int i = 1; i <= num.Length/2; i++)
        {
            if(num[0] == '0' && i > 1)
                break;

            long a = long.Parse(num.Substring(0, i));
            for (int j = i+1; j < num.Length; j++)
            {
                if(num[i] == '0' && j > i+1)
                    break;
                long b = long.Parse(num.Substring(i, j-i));

                if (IsAdditive(num.Substring(j), a + b, b))
                    return true;
            }
        }

        return false;
    }

    private bool IsAdditive(string num, long val, long pre)
    {
        string v = val.ToString();

        if (!num.StartsWith(v))
            return false;
        num = num.Substring(v.Length);
        if (num.Length == 0)
            return true;
        return IsAdditive(num, val + pre, val);
    }
}

// √ Accepted
//   √ 40/40 cases passed (116 ms)
//   √ Your runtime beats 6.67 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (20.8 MB)

