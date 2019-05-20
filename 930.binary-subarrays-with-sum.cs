/*
 * @lc app=leetcode id=930 lang=csharp
 *
 * [930] Binary Subarrays With Sum

 In an array A of 0s and 1s, how many non-empty subarrays have sum S?

 

Example 1:

Input: A = [1,0,1,0,1], S = 2
Output: 4
Explanation: 
The 4 subarrays are bolded below:
[1,0,1,0,1]
[1,0,1,0,1]
[1,0,1,0,1]
[1,0,1,0,1]
 

Note:

A.length <= 30000
0 <= S <= A.length
A[i] is either 0 or 1.
 */
public class Solution {
    public int NumSubarraysWithSum(int[] A, int S)
    {
        int res = 0;
        int i = 0, j = i + 1;
        int sum = A[0];
        while (i < A.Length)
        {
            if (j == i)
            {
                j = i + 1;
                sum = A[i];
            }
            while (sum < S && j < A.Length)
            {
                sum += A[j];
                j++;
            }

            if (sum == S)
            {
                res++;
                // 附近有没有0
                int tmp = j;
                while (tmp < A.Length && A[tmp] == 0)
                {
                    res++; tmp++;
                }
            }
            sum -= A[i];
            i++;
        }

        return res;
    }


    public int NumSubarraysWithSum_Timeout(int[] A, int S) {
        int res = 0;
        for (int i = 0; i < A.Length; i++)
        {
            int sum = 0;
            for (int j = i; j < A.Length; j++)
            {
                sum += A[j];

                if (sum == S)
                    res++;

                if(sum > S)
                    break;
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 59/59 cases passed (136 ms)
//   √ Your runtime beats 83.33 % of csharp submissions
//   √ Your memory usage beats 77.78 % of csharp submissions (29.2 MB)

