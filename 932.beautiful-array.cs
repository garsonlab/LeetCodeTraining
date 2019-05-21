/*
 * @lc app=leetcode id=932 lang=csharp
 *
 * [932] Beautiful Array

 For some fixed N, an array A is beautiful if it is a permutation of the integers 1, 2, ..., N, such that:

For every i < j, there is no k with i < k < j such that A[k] * 2 = A[i] + A[j].

Given N, return any beautiful array A.  (It is guaranteed that one exists.)

 

Example 1:

Input: 4
Output: [2,1,4,3]
Example 2:

Input: 5
Output: [3,1,2,5,4]
 

Note:

1 <= N <= 1000
 */
public class Solution {
    public int[] BeautifulArray(int N) {
        int[] res = new int[N];
        int m = N - 1;
        int k = 1;
        while (m > 1)
        {
            m /= 2;
            k *= 2;
        }
        res[0] = 1;
        int i = 1, t = 1;
        while (i < N)
        {
            for (int j = 0; j < t; j++)
            {
                if (res[j] + k <= N)
                {
                    res[i] = res[j] + k;
                    i++;
                }
            }
            t = i;
            k /= 2;
        }
        return res;
    }
}


// √ Accepted
//   √ 38/38 cases passed (228 ms)
//   √ Your runtime beats 28.57 % of csharp submissions
//   √ Your memory usage beats 7.69 % of csharp submissions (24.8 MB)
