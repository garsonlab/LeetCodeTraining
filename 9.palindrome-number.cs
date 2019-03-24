/*
 * @lc app=leetcode id=9 lang=csharp
 *
 * [9] Palindrome Number
 *
 * https://leetcode.com/problems/palindrome-number/description/
 *
 * algorithms
 * Easy (42.37%)
 * Total Accepted:    531.9K
 * Total Submissions: 1.3M
 * Testcase Example:  '121'
 *
 * Determine whether an integer is a palindrome. An integer is a palindrome
 * when it reads the same backward as forward.
 * 
 * Example 1:
 * 
 * 
 * Input: 121
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: -121
 * Output: false
 * Explanation: From left to right, it reads -121. From right to left, it
 * becomes 121-. Therefore it is not a palindrome.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: 10
 * Output: false
 * Explanation: Reads 01 from right to left. Therefore it is not a
 * palindrome.
 * 
 * 
 * Follow up:
 * 
 * Coud you solve it without converting the integer to a string?
 * 
 */
public class Solution {
    public bool IsPalindrome(int x)
     {
        if (x < 0)
        {
            return false;
        }

        int dig = 1;
        int tem = x;
        while (tem >= 10)
        {
            tem /= 10;
            dig *= 10;
        }

        if (dig == 1)
            return true;

        int per = 10;

        while (dig >= per)
        {
            if ((x / dig)%10 != (x % per)/(per/10))
                return false;
            dig /= 10;
            per *= 10;
        }
        return true;
    }
}

