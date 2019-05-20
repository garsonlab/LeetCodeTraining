/*
 * @lc app=leetcode id=926 lang=csharp
 *
 * [926] Flip String to Monotone Increasing

 A string of '0's and '1's is monotone increasing if it consists of some number of '0's (possibly 0), followed by some number of '1's (also possibly 0.)

We are given a string S of '0's and '1's, and we may flip any '0' to a '1' or a '1' to a '0'.

Return the minimum number of flips to make S monotone increasing.

 

Example 1:

Input: "00110"
Output: 1
Explanation: We flip the last digit to get 00111.
Example 2:

Input: "010110"
Output: 2
Explanation: We flip to get 011111, or alternatively 000111.
Example 3:

Input: "00011000"
Output: 2
Explanation: We flip to get 00000000.
 

Note:

1 <= S.length <= 20000
S only consists of '0' and '1' characters.
 */
public class Solution {
    public int MinFlipsMonoIncr(string S) {
        int n = S.Length;
        int[] left = new int[n], right = new int[n];

        int sum = 0;
        int res = n;

        for (int i = 0; i < n; i++)
        {
            left[i] = sum;
            if (S[i] == '1')
                sum++;
        }

        sum = 0;
        for (int i = n-1; i >= 0; i--)
        {
            right[i] = sum;
            if (S[i] == '0')
                sum++;
        }

        for (int i = 0; i < n; i++)
        {
            res = Math.Min(res, left[i] + right[i]);
        }

        return res;
    }
}

// √ Accepted
//   √ 81/81 cases passed (76 ms)
//   √ Your runtime beats 71.11 % of csharp submissions
//   √ Your memory usage beats 8.11 % of csharp submissions (22.7 MB)

