/*
 * @lc app=leetcode id=507 lang=csharp
 *
 * [507] Perfect Number
 *
 * https://leetcode.com/problems/perfect-number/description/
 *
 * algorithms
 * Easy (33.89%)
 * Total Accepted:    37.8K
 * Total Submissions: 111.3K
 * Testcase Example:  '28'
 *
 * We define the Perfect Number is a positive integer that is equal to the sum
 * of all its positive divisors except itself. 
 * 
 * Now, given an integer n, write a function that returns true when it is a
 * perfect number and false when it is not.
 * 
 * 
 * Example:
 * 
 * Input: 28
 * Output: True
 * Explanation: 28 = 1 + 2 + 4 + 7 + 14
 * 
 * 
 * 
 * Note:
 * The input number n will not exceed 100,000,000. (1e8)
 * 
 */
public class Solution {
    public bool CheckPerfectNumber(int num) {
        if(num <= 1)
            return false;
        int tem = num - 1;
        int end = (int) Math.Sqrt(num);

        for (int i = 2; i <= end; i++)
        {
            if (num % i == 0)
            {
                tem -= i;
                tem -= num / i;
            }
        }

        return tem == 0;
    }
}


// √ Accepted
//   √ 156/156 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 71.43 % of csharp submissions (12.8 MB)

