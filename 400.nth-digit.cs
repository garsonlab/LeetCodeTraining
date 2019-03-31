/*
 * @lc app=leetcode id=400 lang=csharp
 *
 * [400] Nth Digit
 *
 * https://leetcode.com/problems/nth-digit/description/
 *
 * algorithms
 * Easy (30.17%)
 * Total Accepted:    45.6K
 * Total Submissions: 151K
 * Testcase Example:  '3'
 *
 * Find the n^th digit of the infinite integer sequence 1, 2, 3, 4, 5, 6, 7, 8,
 * 9, 10, 11, ... 
 * 
 * Note:
 * n is positive and will fit within the range of a 32-bit signed integer (n <
 * 2^31).
 * 
 * 
 * Example 1:
 * 
 * Input:
 * 3
 * 
 * Output:
 * 3
 * 
 * 
 * 
 * Example 2:
 * 
 * Input:
 * 11
 * 
 * Output:
 * 0
 * 
 * Explanation:
 * The 11th digit of the sequence 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12... is a
 * 0, which is part of the number 10.
 * 
 * 
 */
public class Solution {
    public int FindNthDigit(int n) {
        if (n < 10)
            return n;
        double length = 0, cnt = 9, i = 1;
        for (; length + cnt * i < n; ++i) {
            length += cnt * i;
            cnt *= 10;
        }
        
        double num = Math.Pow(10, i - 1) - 1 + (n - length + 1) / i;
        int index = (int)((n - length - 1) % i);
        return num.ToString()[index] - '0';
    }


    public int FindNthDigit2(int n) {
        int min = 0;
        int r = 9;
        int d = 1;

        while (n > r)
        {
            min = r;
            r += 9*((int)Math.Pow(10, d++))*d;
        }

        int left = n-min;
        int num = (int)Math.Pow(10, d-1) + left/d;

        // return num;

        return num.ToString()[left%(d+1)] - '0';
        // int idx = left%(d);
        // int bit = 0;
        // for (int i = 0; i <= d-idx-1; i++)
        // {
        //     bit = num%10;
        //     num /= 10;
        // }
        // return bit;

        // int idx = left%(d+1);
        // int bit = 0;
        // for (int j = d; j >= idx; j--) {
        //     bit = num % 10;
        //     num /= 10;
        // }
        // return bit;
    }
}

//1-9有 9*pow(10, 0)*1个数字
//10-99有 9*pow(10, 1)*2
//100-999唷 900

// √ Accepted
//   √ 70/70 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (13.1 MB)


