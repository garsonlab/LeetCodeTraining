/*
 * @lc app=leetcode id=1015 lang=csharp
 *
 * [1015] Smallest Integer Divisible by K

 Given a positive integer K, you need find the smallest positive integer N such that N is divisible by K, and N only contains the digit 1.

Return the length of N.  If there is no such N, return -1.

 

Example 1:

Input: 1
Output: 1
Explanation: The smallest answer is N = 1, which has length 1.
Example 2:

Input: 2
Output: -1
Explanation: There is no such positive integer N divisible by 2.
Example 3:

Input: 3
Output: 3
Explanation: The smallest answer is N = 111, which has length 3.
 

Note:

1 <= K <= 10^5
 */
public class Solution {
    public int SmallestRepunitDivByK(int K) {
        if (K % 2 == 0 || K % 5 == 0)
            return -1;
        int i = 1;
        for (int n = 1; n % K != 0; i++)
        {
            n %= K;
            n = n * 10 + 1;
        }
        return i;
    }
}

// √ Accepted
//   √ 70/70 cases passed (40 ms)
//   √ Your runtime beats 67.46 % of csharp submissions
//   √ Your memory usage beats 96.67 % of csharp submissions (12.7 MB)

