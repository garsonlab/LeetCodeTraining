/*
 * @lc app=leetcode id=397 lang=csharp
 *
 * [397] Integer Replacement

 Given a positive integer n and you can do operations as follow:

If n is even, replace n with n/2.
If n is odd, you can replace n with either n + 1 or n - 1.
What is the minimum number of replacements needed for n to become 1?

Example 1:

Input:
8

Output:
3

Explanation:
8 -> 4 -> 2 -> 1
Example 2:

Input:
7

Output:
4

Explanation:
7 -> 8 -> 4 -> 2 -> 1
or
7 -> 6 -> 3 -> 2 -> 1
 */
public class Solution {

    public int IntegerReplacement(int n) {
        if(n == 1)
            return 0;
        
        if((n&1) == 0) {
            return 1+IntegerReplacement(n>>1);
        }

        if(n == int.MaxValue)
            return 1+IntegerReplacement((n-1) >> 1);
        
        return 2 + Math.Min(IntegerReplacement((n+1) >> 1), IntegerReplacement((n-1) >> 1));
    }
}

// √ Accepted
//   √ 47/47 cases passed (52 ms)
//   √ Your runtime beats 34.62 % of csharp submissions
//   √ Your memory usage beats 83.33 % of csharp submissions (12.8 MB)

