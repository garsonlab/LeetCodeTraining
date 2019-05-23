/*
 * @lc app=leetcode id=1017 lang=csharp
 *
 * [1017] Convert to Base -2

 Given a number N, return a string consisting of "0"s and "1"s that represents its value in base -2 (negative two).

The returned string must have no leading zeroes, unless the string is "0".

 

Example 1:

Input: 2
Output: "110"
Explantion: (-2) ^ 2 + (-2) ^ 1 = 2
Example 2:

Input: 3
Output: "111"
Explantion: (-2) ^ 2 + (-2) ^ 1 + (-2) ^ 0 = 3
Example 3:

Input: 4
Output: "100"
Explantion: (-2) ^ 2 = 4
 

Note:

0 <= N <= 10^9
 */
public class Solution {
    public string BaseNeg2(int N) {
        string res = "";
        while (true)
        {
            res = Math.Abs(N % 2) + res;
            N = (int)Math.Ceiling(N / -2.0);
            if (N == 0)
            {
                break;
            }
        }
        return res;
    }
}

// √ Accepted
//   √ 170/170 cases passed (84 ms)
//   √ Your runtime beats 29.57 % of csharp submissions
//   √ Your memory usage beats 80.39 % of csharp submissions (20.6 MB)

