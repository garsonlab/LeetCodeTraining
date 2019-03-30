/*
 * @lc app=leetcode id=342 lang=csharp
 *
 * [342] Power of Four
 *
 * https://leetcode.com/problems/power-of-four/description/
 *
 * algorithms
 * Easy (40.03%)
 * Total Accepted:    108.4K
 * Total Submissions: 270.6K
 * Testcase Example:  '16'
 *
 * Given an integer (signed 32 bits), write a function to check whether it is a
 * power of 4.
 * 
 * Example 1:
 * 
 * 
 * Input: 16
 * Output: true
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 5
 * Output: false
 * 
 * 
 * Follow up: Could you solve it without loops/recursion?
 */
public class Solution {
    public bool IsPowerOfFour1(int num) {
        if(num == 0)
        return false;
        int d = (int)(Math.Log(num) / Math.Log(4));
        return num == (int)Math.Pow(4,d) || num == (int)Math.Pow(4,d+1);
    }

    public bool IsPowerOfFour(int num) {
        switch(num){
            case 1<<2:
            case 1<<4:
            case 1<<6:
            case 1<<8:
            case 1<<10:
            case 1<<12:
            case 1<<14:
            case 1<<16:
            case 1<<18:
            case 1<<20:
            case 1<<22:
            case 1<<24:
            case 1<<26:
            case 1<<28:
            case 1<<30:
            case 1<<32:
                return true;
            default:
                return false;
        }
    }

    
}

// √ Accepted
//   √ 1060/1060 cases passed (48 ms)
//   √ Your runtime beats 50.69 % of csharp submissions
//   √ Your memory usage beats 8.33 % of csharp submissions (13.3 MB)


// √ Accepted
//   √ 1060/1060 cases passed (40 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 58.33 % of csharp submissions (13 MB)


