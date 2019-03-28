/*
 * @lc app=leetcode id=202 lang=csharp
 *
 * [202] Happy Number
 *
 * https://leetcode.com/problems/happy-number/description/
 *
 * algorithms
 * Easy (44.47%)
 * Total Accepted:    219.4K
 * Total Submissions: 492.6K
 * Testcase Example:  '19'
 *
 * Write an algorithm to determine if a number is "happy".
 * 
 * A happy number is a number defined by the following process: Starting with
 * any positive integer, replace the number by the sum of the squares of its
 * digits, and repeat the process until the number equals 1 (where it will
 * stay), or it loops endlessly in a cycle which does not include 1. Those
 * numbers for which this process ends in 1 are happy numbers.
 * 
 * Example: 
 * 
 * 
 * Input: 19
 * Output: true
 * Explanation: 
 * 1^2 + 9^2 = 82
 * 8^2 + 2^2 = 68
 * 6^2 + 8^2 = 100
 * 1^2 + 0^2 + 0^2 = 1
 * 
 */
public class Solution {
    public bool IsHappy(int n) {
        if (n <= 0)
        {
            return false;
        }

        if (n == 1)
        {
            return true;
        }

        while (n != 1)
        {
            int x = 0;
            while (n > 0)
            {
                x += (n % 10) * (n % 10);
                n /= 10;
            }

            n = x;

            if (n == 89)
                return false;
        }

        return true;
    }
}

//非快乐数在89处循环
// √ Accepted
//   √ 401/401 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 70.97 % of csharp submissions (12.9 MB)


