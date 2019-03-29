/*
 * @lc app=leetcode id=258 lang=csharp
 *
 * [258] Add Digits
 *
 * https://leetcode.com/problems/add-digits/description/
 *
 * algorithms
 * Easy (53.65%)
 * Total Accepted:    231K
 * Total Submissions: 430.1K
 * Testcase Example:  '38'
 *
 * Given a non-negative integer num, repeatedly add all its digits until the
 * result has only one digit.
 * 
 * Example:
 * 
 * 
 * Input: 38
 * Output: 2 
 * Explanation: The process is like: 3 + 8 = 11, 1 + 1 = 2. 
 * Since 2 has only one digit, return it.
 * 
 * 
 * Follow up:
 * Could you do it without any loop/recursion in O(1) runtime?
 */
public class Solution {
    public int AddDigits(int num) {
        if (num == 0)
            return 0;

        int r = num % 9;
        return r == 0 ? 9 : r;
    }
}

//规律就是所有的都是1-9
// √ Accepted
//   √ 1101/1101 cases passed (40 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 38.46 % of csharp submissions (12.9 MB)

