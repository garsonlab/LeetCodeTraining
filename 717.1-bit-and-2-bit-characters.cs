/*
 * @lc app=leetcode id=717 lang=csharp
 *
 * [717] 1-bit and 2-bit Characters
 *
 * https://leetcode.com/problems/1-bit-and-2-bit-characters/description/
 *
 * algorithms
 * Easy (48.97%)
 * Total Accepted:    38.1K
 * Total Submissions: 77.6K
 * Testcase Example:  '[1,0,0]'
 *
 * We have two special characters. The first character can be represented by
 * one bit 0. The second character can be represented by two bits (10 or
 * 11).  
 * 
 * Now given a string represented by several bits. Return whether the last
 * character must be a one-bit character or not. The given string will always
 * end with a zero.
 * 
 * Example 1:
 * 
 * Input: 
 * bits = [1, 0, 0]
 * Output: True
 * Explanation: 
 * The only way to decode it is two-bit character and one-bit character. So the
 * last character is one-bit character.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: 
 * bits = [1, 1, 1, 0]
 * Output: False
 * Explanation: 
 * The only way to decode it is two-bit character and two-bit character. So the
 * last character is NOT one-bit character.
 * 
 * 
 * 
 * Note:
 * 1 .
 * bits[i] is always 0 or 1.
 * 
 */
public class Solution {
    public bool IsOneBitCharacter(int[] bits) {
        if (bits[bits.Length - 1] != 0)
            return false;

        if (bits.Length == 1 || bits[bits.Length - 2] == 0)
            return true;

        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] == 1)//遇到1后一个比用考虑
            {
                i++;
                if (i >= bits.Length - 1)
                    return false;
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 93/93 cases passed (88 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (22.7 MB)

