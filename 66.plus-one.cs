/*
 * @lc app=leetcode id=66 lang=csharp
 *
 * [66] Plus One
 *
 * https://leetcode.com/problems/plus-one/description/
 *
 * algorithms
 * Easy (40.81%)
 * Total Accepted:    363.8K
 * Total Submissions: 891.4K
 * Testcase Example:  '[1,2,3]'
 *
 * Given a non-empty array of digits representing a non-negative integer, plus
 * one to the integer.
 * 
 * The digits are stored such that the most significant digit is at the head of
 * the list, and each element in the array contain a single digit.
 * 
 * You may assume the integer does not contain any leading zero, except the
 * number 0 itself.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3]
 * Output: [1,2,4]
 * Explanation: The array represents the integer 123.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [4,3,2,1]
 * Output: [4,3,2,2]
 * Explanation: The array represents the integer 4321.
 * 
 */
public class Solution {
    public int[] PlusOne(int[] digits) {
        int add = 1;
        for (int i = digits.Length-1; i >= 0; i--)
        {
            int val = digits[i] + add;
            digits[i] = val%10;
            add = val/10;

            if (add <= 0)
            {
                break;
            }
        }

        if (add <= 0)
        {
            return digits;
        }
        else
        {
            int[] newDig = new int[digits.Length+1];
            newDig[0] = add;
            for (int i = 0; i < digits.Length; i++)
            {
                newDig[i+1] = digits[i];
            }
            return newDig;
        }
    }
}

// √ Accepted
//   √ 109/109 cases passed (244 ms)
//   √ Your runtime beats 91.56 % of csharp submissions
//   √ Your memory usage beats 64.38 % of csharp submissions (28.1 MB)


