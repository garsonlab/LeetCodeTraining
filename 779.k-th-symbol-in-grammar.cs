/*
 * @lc app=leetcode id=779 lang=csharp
 *
 * [779] K-th Symbol in Grammar

 On the first row, we write a 0. Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.

Given row N and index K, return the K-th indexed symbol in row N. (The values of K are 1-indexed.) (1 indexed).

Examples:
Input: N = 1, K = 1
Output: 0

Input: N = 2, K = 1
Output: 0

Input: N = 2, K = 2
Output: 1

Input: N = 4, K = 5
Output: 1

Explanation:
row 1: 0
row 2: 01
row 3: 0110
row 4: 01101001
Note:

N will be an integer in the range [1, 30].
K will be an integer in the range [1, 2^(N-1)].
 */
public class Solution {
    public int KthGrammar(int N, int K) {
        if (N == 1)
            return 0;
        return K % 2 == 0 ? 1 - KthGrammar(N - 1, (K + 1) / 2) : KthGrammar(N - 1, (K + 1) / 2);
    }
}

//该行第K个数由前一行对应位置的数字决定

// √ Accepted
//   √ 55/55 cases passed (40 ms)
//   √ Your runtime beats 44.86 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.6 MB)

