/*
 * @lc app=leetcode id=866 lang=csharp
 *
 * [866] Prime Palindrome

 Find the smallest prime palindrome greater than or equal to N.

Recall that a number is prime if it's only divisors are 1 and itself, and it is greater than 1. 

For example, 2,3,5,7,11 and 13 are primes.

Recall that a number is a palindrome if it reads the same from left to right as it does from right to left. 

For example, 12321 is a palindrome.

 

Example 1:

Input: 6
Output: 7
Example 2:

Input: 8
Output: 11
Example 3:

Input: 13
Output: 101
 

Note:

1 <= N <= 10^8
The answer is guaranteed to exist and be less than 2 * 10^8.
 */
public class Solution {
    public int PrimePalindrome(int N) {
        if(N <= 2)
            return 2;

        for (int i = N; i < int.MaxValue;)
        {
            if(IsPrime(i) && IsPalin(i))
                return i;
            //根据nothing、xxx的 数学规律1：除 11 外的偶数位回文数，都能被 11 整除
            //跳过一些数
            if(i > 11 && i.ToString().Length%2 == 0) {
                i = (int)(Math.Pow(10, i.ToString().Length) + 1);
            } else {
                i++;
            }
        }
        return -1;
    }

    private bool IsPrime(int n) {
        if(n == 2 || n == 3)
            return true;

        if (n % 2 == 0 || n % 3 == 0)
            return false;
        for (int i = 5; i <= (int)Math.Sqrt(n); ++i)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    private bool IsPalin(int n) {
        if(n <= 11)
            return true;

        string s = n.ToString();
        for (int i = 0, j = s.Length-1; i <= j; i++, j--)
        {
            if(s[i] != s[j])
                return false;
        }
        return true;
    }
}

// √ Accepted
//   √ 60/60 cases passed (1444 ms)
//   √ Your runtime beats 6.67 % of csharp submissions
//   √ Your memory usage beats 58.82 % of csharp submissions (16.9 MB)

