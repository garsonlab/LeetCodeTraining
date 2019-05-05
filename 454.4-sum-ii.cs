/*
 * @lc app=leetcode id=454 lang=csharp
 *
 * [454] 4Sum II

 Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that A[i] + B[j] + C[k] + D[l] is zero.

To make problem a bit easier, all A, B, C, D have same length of N where 0 ≤ N ≤ 500. All integers are in the range of -228 to 228 - 1 and the result is guaranteed to be at most 231 - 1.

Example:

Input:
A = [ 1, 2]
B = [-2,-1]
C = [-1, 2]
D = [ 0, 2]

Output:
2

Explanation:
The two tuples are:
1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0
 */
public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int res = 0;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < B.Length; j++)
            {
                int v = A[i]+B[j];
                if (dic.ContainsKey(v))
                    dic[v]++;
                else
                    dic[v] = 1;
            }
        }

        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < B.Length; j++)
            {
                int v = C[i]+D[j];
                if (dic.ContainsKey(-v))
                    res += dic[-v];
            }
        }
        
        return res;
    }

    public int FourSumCount_timeout(int[] A, int[] B, int[] C, int[] D) {
        int res = 0;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < B.Length; j++)
            {
                for (int k = 0; k < C.Length; k++)
                {
                    for (int l = 0; l < D.Length; l++)
                    {
                        if(A[i] + B[j] + C[k] + D[l] == 0)
                            res++;
                    }
                }
            }
        }
        return res;
    }
}

// √ Accepted
//   √ 48/48 cases passed (168 ms)
//   √ Your runtime beats 88.82 % of csharp submissions
//   √ Your memory usage beats 55.56 % of csharp submissions (34.2 MB)

