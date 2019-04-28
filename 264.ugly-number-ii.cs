/*
 * @lc app=leetcode id=264 lang=csharp
 *
 * [264] Ugly Number II

 Write a program to find the n-th ugly number.

Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 

Example:

Input: n = 10
Output: 12
Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
Note:  

1 is typically treated as an ugly number.
n does not exceed 1690.
 */
public class Solution {
    public int NthUglyNumber(int n) {
        List<int> ugly = new List<int>(){1};
        int[] idx = new int[3];
        int res = 1;
        for (int i = 1; i < n; i++)
        {
            int a2 = ugly[idx[0]] * 2;
            int a3 = ugly[idx[1]] * 3;
            int a5 = ugly[idx[2]] * 5;
            res = Math.Min(a2, Math.Min(a3, a5));

            if (res == a2)
                idx[0]++;
            if (res == a3)
                idx[1]++;
            if (res == a5)
                idx[2]++;
            ugly.Add(res);
        }

        return res;
    }
}

// √ Accepted
//   √ 596/596 cases passed (60 ms)
//   √ Your runtime beats 24.21 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (15.3 MB)

