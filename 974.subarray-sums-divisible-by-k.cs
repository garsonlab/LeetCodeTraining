/*
 * @lc app=leetcode id=974 lang=csharp
 *
 * [974] Subarray Sums Divisible by K

 Given an array A of integers, return the number of (contiguous, non-empty) subarrays that have a sum divisible by K.

 

Example 1:

Input: A = [4,5,0,-2,-3,1], K = 5
Output: 7
Explanation: There are 7 subarrays with a sum divisible by K = 5:
[4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]
 

Note:

1 <= A.length <= 30000
-10000 <= A[i] <= 10000
2 <= K <= 10000
 */
public class Solution {
    
    public int SubarraysDivByK(int[] A, int K)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int res = 0, sum = 0;
        dic[0] = 1;
        foreach (var i in A)
        {
            sum += i;
            while (sum < 0)
            {
                sum += K;
            }

            int m = sum % K;

            if (dic.ContainsKey(m))
                dic[m]++;
            else
                dic[m] = 1;
        }

        foreach (var i in dic.Values)
        {
            res += i * (i - 1) / 2;
        }

        return res;
    }


    public int SubarraysDivByK_timeout(int[] A, int K) {
        int res = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % K == 0)
                res++;

            if (i > 0)
            {
                A[i] += A[i - 1];
                if (A[i] % K == 0)
                    res++;
            }
        }

        for (int i = 0; i < A.Length; i++)
        {
            for (int j = i+2; j < A.Length; j++)
            {
                if ((A[j] - A[i]) % K == 0)
                    res++;
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 73/73 cases passed (156 ms)
//   √ Your runtime beats 57.97 % of csharp submissions
//   √ Your memory usage beats 29.09 % of csharp submissions (33.5 MB)

