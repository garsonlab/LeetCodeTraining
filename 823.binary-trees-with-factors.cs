/*
 * @lc app=leetcode id=823 lang=csharp
 *
 * [823] Binary Trees With Factors

 Given an array of unique integers, each integer is strictly greater than 1.

We make a binary tree using these integers and each number may be used for any number of times.

Each non-leaf node's value should be equal to the product of the values of it's children.

How many binary trees can we make?  Return the answer modulo 10 ** 9 + 7.

Example 1:

Input: A = [2, 4]
Output: 3
Explanation: We can make these trees: [2], [4], [4, 2, 2]
Example 2:

Input: A = [2, 4, 5, 10]
Output: 7
Explanation: We can make these trees: [2], [4], [5], [10], [4, 2, 2], [10, 2, 5], [10, 5, 2].
 

Note:

1 <= A.length <= 1000.
2 <= A[i] <= 10 ^ 9.
 */
public class Solution {
    public int NumFactoredBinaryTrees(int[] A) {
        Dictionary<int, long> dp = new Dictionary<int, long>();
        foreach (var i in A)
        {
            dp[i] = 1;
        }

        Array.Sort(A);
        long mod = 1000000007;
        long sum = 0;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (A[i]%A[j] == 0 && dp.ContainsKey(A[i]/A[j]))
                {
                    dp[A[i]] = (dp[A[i]] + dp[A[j]]*dp[A[i]/A[j]])%mod;
                }
            }
            sum = (sum+dp[A[i]])%mod;
        }
        return (int)sum;
    }
}

// 动态规划。假设dp[i]为以数字i为根结点的所有树的总量。

// 当i=a*b，a,b都出现在数组中时，dp[i]+=2*dp[a]*dp[b]。因为子树可以交换位置
// 当i=a*a时，a出现在数组中时，dp[i]+=dp[a]*dp[b]。
// 其余条件dp[i]=1,因此可以将dp的所有元素初始化为1。
// 最终的返回结果是dp中所有元素的和。

// √ Accepted
//   √ 47/47 cases passed (144 ms)
//   √ Your runtime beats 60 % of csharp submissions
//   √ Your memory usage beats 46.15 % of csharp submissions (23.5 MB)

