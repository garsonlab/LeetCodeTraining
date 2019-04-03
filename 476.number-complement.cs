/*
 * @lc app=leetcode id=476 lang=csharp
 *
 * [476] Number Complement
 *
 * https://leetcode.com/problems/number-complement/description/
 *
 * algorithms
 * Easy (62.10%)
 * Total Accepted:    102.9K
 * Total Submissions: 165.5K
 * Testcase Example:  '5'
 *
 * Given a positive integer, output its complement number. The complement
 * strategy is to flip the bits of its binary representation.
 * 
 * Note:
 * 
 * The given integer is guaranteed to fit within the range of a 32-bit signed
 * integer.
 * You could assume no leading zero bit in the integer’s binary
 * representation.
 * 
 * 
 * 
 * Example 1:
 * 
 * Input: 5
 * Output: 2
 * Explanation: The binary representation of 5 is 101 (no leading zero bits),
 * and its complement is 010. So you need to output 2.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: 1
 * Output: 0
 * Explanation: The binary representation of 1 is 1 (no leading zero bits), and
 * its complement is 0. So you need to output 0.
 * 
 * 
 */
public class Solution {
    public int FindComplement(int num) {
        int r = 0;
        int dig = 1;

        while (num > 0)
        {
            r += ((num % 2 + 1) % 2) * dig;
            num = num >> 1;
            dig = dig << 1;
        }

        return r;
    }
}

// √ Accepted
//   √ 149/149 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 64.29 % of csharp submissions (12.9 MB)

