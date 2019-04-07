/*
 * @lc app=leetcode id=693 lang=csharp
 *
 * [693] Binary Number with Alternating Bits
 *
 * https://leetcode.com/problems/binary-number-with-alternating-bits/description/
 *
 * algorithms
 * Easy (57.65%)
 * Total Accepted:    39K
 * Total Submissions: 67.6K
 * Testcase Example:  '5'
 *
 * Given a positive integer, check whether it has alternating bits: namely, if
 * two adjacent bits will always have different values.
 * 
 * Example 1:
 * 
 * Input: 5
 * Output: True
 * Explanation:
 * The binary representation of 5 is: 101
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: 7
 * Output: False
 * Explanation:
 * The binary representation of 7 is: 111.
 * 
 * 
 * 
 * Example 3:
 * 
 * Input: 11
 * Output: False
 * Explanation:
 * The binary representation of 11 is: 1011.
 * 
 * 
 * 
 * Example 4:
 * 
 * Input: 10
 * Output: True
 * Explanation:
 * The binary representation of 10 is: 1010.
 * 
 * 
 */
public class Solution {
    public bool HasAlternatingBits(int n) {
        if (n <= 1)
        {
            return true;
        }

        int p = n%2;
        n = n/2;
        while (n > 0)
        {
            int tem = n%2;
            if(tem == p)
                return false;
            p = tem;
            n /= 2;
        }
        return true;
    }
}

// √ Accepted
//   √ 204/204 cases passed (52 ms)
//   √ Your runtime beats 13.39 % of csharp submissions
//   √ Your memory usage beats 54.55 % of csharp submissions (12.8 MB)

