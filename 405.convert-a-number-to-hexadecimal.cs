/*
 * @lc app=leetcode id=405 lang=csharp
 *
 * [405] Convert a Number to Hexadecimal
 *
 * https://leetcode.com/problems/convert-a-number-to-hexadecimal/description/
 *
 * algorithms
 * Easy (41.71%)
 * Total Accepted:    45K
 * Total Submissions: 107.9K
 * Testcase Example:  '26'
 *
 * 
 * Given an integer, write an algorithm to convert it to hexadecimal. For
 * negative integer, two’s complement method is used.
 * 
 * 
 * Note:
 * 
 * All letters in hexadecimal (a-f) must be in lowercase.
 * The hexadecimal string must not contain extra leading 0s. If the number is
 * zero, it is represented by a single zero character '0'; otherwise, the first
 * character in the hexadecimal string will not be the zero character.
 * The given number is guaranteed to fit within the range of a 32-bit signed
 * integer.
 * You must not use any method provided by the library which converts/formats
 * the number to hex directly.
 * 
 * 
 * 
 * Example 1:
 * 
 * Input:
 * 26
 * 
 * Output:
 * "1a"
 * 
 * 
 * 
 * Example 2:
 * 
 * Input:
 * -1
 * 
 * Output:
 * "ffffffff"
 * 
 * 
 */
public class Solution {
    public string ToHex(int num) {
        if (num == 0)
            return "0";

        char[] chars = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

        string r = "";
        if (num > 0)
        {
            while (num > 0)
            {
                int x = num % 16;
                r = chars[x] + r;
                num = num / 16;
            }
        }
        else
        {
            num = -num - 1;
            for (int i = 0; i < 8; i++)
            {
                int x = num % 16;
                num = num / 16;

                x = x ^ 0xf;
                r = chars[x] + r;
            }
        }

        return r;
    }
}


// √ Accepted
//   √ 100/100 cases passed (96 ms)
//   √ Your runtime beats 26.42 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (20.5 MB)

