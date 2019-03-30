/*
 * @lc app=leetcode id=326 lang=csharp
 *
 * [326] Power of Three
 *
 * https://leetcode.com/problems/power-of-three/description/
 *
 * algorithms
 * Easy (41.46%)
 * Total Accepted:    174.7K
 * Total Submissions: 421.2K
 * Testcase Example:  '27'
 *
 * Given an integer, write a function to determine if it is a power of three.
 * 
 * Example 1:
 * 
 * 
 * Input: 27
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 0
 * Output: false
 * 
 * Example 3:
 * 
 * 
 * Input: 9
 * Output: true
 * 
 * Example 4:
 * 
 * 
 * Input: 45
 * Output: false
 * 
 * Follow up:
 * Could you do it without using any loop / recursion?
 */
public class Solution {
    public bool IsPowerOfThree(int n) {
        if(n == 0)
        return false;

        int d = (int)(Math.Log(n) / Math.Log(3));
        return n == (int)Math.Pow(3,d) || n == (int)Math.Pow(3,d+1);
    }
}

// √ Accepted
//   √ 21038/21038 cases passed (124 ms)
//   √ Your runtime beats 59.2 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (16.4 MB)


