/*
 * @lc app=leetcode id=372 lang=csharp
 *
 * [372] Super Pow

 Your task is to calculate ab mod 1337 where a is a positive integer and b is an extremely large positive integer given in the form of an array.

Example 1:

Input: a = 2, b = [3]
Output: 8
Example 2:

Input: a = 2, b = [1,0]
Output: 1024
 */
public class Solution {
    public int SuperPow(int a, int[] b)
    {
        int res = 1;
        foreach (var i in b)
        {
            res = Pow(res, 10) * Pow(a, i) % 1337;
        }

        return res;
    }

    int Pow(int x, int n)
    {
        if (n == 0) return 1;
        if (n == 1) return x % 1337;
        return Pow(x % 1337, n / 2) * Pow(x % 1337, n - n / 2) % 1337;
    }
}

// 因为k^abcde = (k^abcd)^10 * k^e 
// 后者可以直接算出，所以原问题就缩小成了求解k^abcd
// √ Accepted
//   √ 54/54 cases passed (108 ms)
//   √ Your runtime beats 57.14 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (24.1 MB)

