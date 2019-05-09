/*
 * @lc app=leetcode id=650 lang=csharp
 *
 * [650] 2 Keys Keyboard

 Initially on a notepad only one character 'A' is present. You can perform two operations on this notepad for each step:

Copy All: You can copy all the characters present on the notepad (partial copy is not allowed).
Paste: You can paste the characters which are copied last time.
 

Given a number n. You have to get exactly n 'A' on the notepad by performing the minimum number of steps permitted. Output the minimum number of steps to get n 'A'.

Example 1:

Input: 3
Output: 3
Explanation:
Intitally, we have one character 'A'.
In step 1, we use Copy All operation.
In step 2, we use Paste operation to get 'AA'.
In step 3, we use Paste operation to get 'AAA'.
 

Note:

The n will be in the range [1, 1000].
 */
public class Solution {
    public int MinSteps(int n) {
        //S[1] = 0
        //S[2] = 2
        //S[3] = 3
        //S[4] = 4
        //S[5] = 5
        //S[n] = min(i, S[n/i]+n/i) 

        if (n <= 1)
            return 0;
        int[] dp = new int[n+1];
        for (int i = 2; i <= n; i++)
        {
            dp[i] = i;
        }

        for (int i = 4; i <= n; ++i)
        {
            for (int j = 2; j < i; ++j)
            {
                if (i % j == 0)
                {
                    dp[i] = Math.Min(dp[i], dp[j] + i / j);
                }
            }
        }

        return dp[n];
    }
}

// 设计状态 f(i)f(i)，表示构成 ii 个 A 所需要的最少步数，注意这里只需要计算是 n 的约数的状态，即状态 ii，满足 n%i==0n%i==0。
// 初始时，f(1)=0f(1)=0，其余为正无穷；每次转移时，枚举 ii 非自身的约数 jj，即 i%j==0i%j==0 并且 j≠ij≠i，则有 f(i)=min(f(i),f(j)+ij)f(i)=min(f(i),f(j)+ij)。
// 最终答案为 f(n)f(n)。

// √ Accepted
//   √ 126/126 cases passed (104 ms)
//   √ Your runtime beats 14.49 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (12.8 MB)

