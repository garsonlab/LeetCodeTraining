/*
 * @lc app=leetcode id=1016 lang=csharp
 *
 * [1016] Binary String With Substrings Representing 1 To N

 Given a binary string S (a string consisting only of '0' and '1's) and a positive integer N, return true if and only if for every integer X from 1 to N, the binary representation of X is a substring of S.

 

Example 1:

Input: S = "0110", N = 3
Output: true
Example 2:

Input: S = "0110", N = 4
Output: false
 

Note:

1 <= S.length <= 1000
1 <= N <= 10^9
 */
public class Solution {
    public bool QueryString(string S, int N) {
        for (int i = 1; i <= N; i++)
        {
            string s = Convert.ToString(i, 2);
            if (!S.Contains(s))
                return false;
        }

        return true;
    }
}


// √ Accepted
//   √ 25/25 cases passed (76 ms)
//   √ Your runtime beats 72.48 % of csharp submissions
//   √ Your memory usage beats 42 % of csharp submissions (19.9 MB)
