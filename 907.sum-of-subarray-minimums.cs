/*
 * @lc app=leetcode id=907 lang=csharp
 *
 * [907] Sum of Subarray Minimums
 Given an array of integers A, find the sum of min(B), where B ranges over every (contiguous) subarray of A.

Since the answer may be large, return the answer modulo 10^9 + 7.

 

Example 1:

Input: [3,1,2,4]
Output: 17
Explanation: Subarrays are [3], [1], [2], [4], [3,1], [1,2], [2,4], [3,1,2], [1,2,4], [3,1,2,4]. 
Minimums are 3, 1, 2, 4, 1, 1, 2, 1, 1, 1.  Sum is 17.
 

Note:

1 <= A.length <= 30000
1 <= A[i] <= 30000
 */
public class Solution {
    public int SumSubarrayMins(int[] A) {
        
        int res = 0, n = A.Length, mod = (int)Math.Pow(10, 9) + 7, k, j;
        Stack<int> s = new Stack<int>();
        for (int i = 0; i <= n; ++i)
        {
            while (s.Count > 0 && A[s.Peek()] > (i == n ? 0 : A[i]))
            {
                j = s.Pop();
                k = s.Count == 0 ? -1 : s.Peek();
                res = (res + A[j] * (i - j) * (j - k)) % mod;
            }
            s.Push(i);
        }
        return res;
    }
}


// √ Accepted
//   √ 100/100 cases passed (168 ms)
//   √ Your runtime beats 91.43 % of csharp submissions
//   √ Your memory usage beats 95.65 % of csharp submissions (36 MB)
