/*
 * @lc app=leetcode id=873 lang=csharp
 *
 * [873] Length of Longest Fibonacci Subsequence

 A sequence X_1, X_2, ..., X_n is fibonacci-like if:

n >= 3
X_i + X_{i+1} = X_{i+2} for all i + 2 <= n
Given a strictly increasing array A of positive integers forming a sequence, find the length of the longest fibonacci-like subsequence of A.  If one does not exist, return 0.

(Recall that a subsequence is derived from another sequence A by deleting any number of elements (including none) from A, without changing the order of the remaining elements.  For example, [3, 5, 8] is a subsequence of [3, 4, 5, 6, 7, 8].)

 

Example 1:

Input: [1,2,3,4,5,6,7,8]
Output: 5
Explanation:
The longest subsequence that is fibonacci-like: [1,2,3,5,8].
Example 2:

Input: [1,3,7,11,12,14,18]
Output: 3
Explanation:
The longest subsequence that is fibonacci-like:
[1,11,12], [3,11,14] or [7,11,18].
 

Note:

3 <= A.length <= 1000
1 <= A[0] < A[1] < ... < A[A.length - 1] <= 10^9
(The time limit has been reduced by 50% for submissions in Java, C, and C++.)
 */
public class Solution {
    public int LenLongestFibSubseq(int[] A) {
        int len = A.Length;
        int[,] dp = new int[len, len];
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < len; i++)
        {
            dic[A[i]] = i;
        }

        int max = 0;
        for (int i = 2; i < len; i++)
        {
            for (int j = i-1; j >= 0; j--)
            {
                int diff = A[i] - A[j];
                int index;
                if(dic.TryGetValue(diff, out index) && index < j) {
                    dp[i, j] = dp[j, index] + 1;
                    max = Math.Max(dp[i, j], max);
                }
            }
        }
        return max == 0? max : max+2;
    }
}


// √ Accepted
//   √ 33/33 cases passed (208 ms)
//   √ Your runtime beats 54.55 % of csharp submissions
//   √ Your memory usage beats 13.33 % of csharp submissions (26.1 MB)
