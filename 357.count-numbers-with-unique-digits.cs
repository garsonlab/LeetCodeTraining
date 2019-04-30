/*
 * @lc app=leetcode id=357 lang=csharp
 *
 * [357] Count Numbers with Unique Digits

 Given a non-negative integer n, count all numbers with unique digits, x, where 0 ≤ x < 10n.

Example:

Input: 2
Output: 91 
Explanation: The answer should be the total numbers in the range of 0 ≤ x < 100, 
             excluding 11,22,33,44,55,66,77,88,99
 */
public class Solution {
    public int CountNumbersWithUniqueDigits(int n) {
        if (n == 0)
            return 1;
        int res = 10, con = 9;
        for (int i = 1; i < n; i++)
        {
            res += con * (10 - i);
            con *= (10 - i);
        }

        return res;
    }
}

// √ Accepted
//   √ 9/9 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (12.9 MB)

