/*
 * @lc app=leetcode id=231 lang=csharp
 *
 * [231] Power of Two
 *
 * https://leetcode.com/problems/power-of-two/description/
 *
 * algorithms
 * Easy (41.70%)
 * Total Accepted:    217.8K
 * Total Submissions: 522K
 * Testcase Example:  '1'
 *
 * Given an integer, write a function to determine if it is a power of two.
 * 
 * Example 1:
 * 
 * 
 * Input: 1
 * Output: true 
 * Explanation: 2^0 = 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 16
 * Output: true
 * Explanation: 2^4 = 16
 * 
 * Example 3:
 * 
 * 
 * Input: 218
 * Output: false
 * 
 */
public class Solution {
    public bool IsPowerOfTwo(int n) {
        if (n <= 0)
        {
            return false;
        }

        while (n > 1)
        {
            if (n % 2 != 0)
                return false;
            n = n >> 1;
        }

        return true;
    }
}


// √ Accepted
//   √ 1108/1108 cases passed (40 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 21.74 % of csharp submissions (13 MB)


