/*
 * @lc app=leetcode id=962 lang=csharp
 *
 * [962] Maximum Width Ramp

 Given an array A of integers, a ramp is a tuple (i, j) for which i < j and A[i] <= A[j].  The width of such a ramp is j - i.

Find the maximum width of a ramp in A.  If one doesn't exist, return 0.

 

Example 1:

Input: [6,0,8,2,1,5]
Output: 4
Explanation: 
The maximum width ramp is achieved at (i, j) = (1, 5): A[1] = 0 and A[5] = 5.
Example 2:

Input: [9,8,1,0,1,9,4,0,4,1]
Output: 7
Explanation: 
The maximum width ramp is achieved at (i, j) = (2, 9): A[2] = 1 and A[9] = 1.
 

Note:

2 <= A.length <= 50000
0 <= A[i] <= 50000
 */
public class Solution {
    public int MaxWidthRamp(int[] A)
    {
        int n = A.Length;
        int[] B = new int[50005];
        int t = 0;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (t == 0 || A[B[t]] > A[i]) B[++t] = i;
        }
        for (int i = n - 1; i > 0; i--)
        {
            while (t > 0 && A[B[t]] <= A[i])
            {
                ans = Math.Max(ans, i - B[t]);
                t--;
            }
        }
        return ans;
    }

    public int MaxWidthRamp_timeout2(int[] A)
    {
        bool d = false;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] >= A[i - 1])
            {
                d = true;
                break;
            }
        }

        if (!d)
            return 0;

        int result = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if(i > 0 && A[i] == A[i-1])
                continue;

            for (int j = A.Length - 1; j > i; j--)
            {
                if (A[j] >= A[i])
                {
                    result = Math.Max(j - i, result);
                    break;
                }
            }
        }
        return result;
    }

    public int MaxWidthRamp_timeout(int[] A) {
        int left = 0;
        int length = A.Length;
        if (length < 2) return 0;
        int max = 0;
        int right = length - 1;
        while (left < right && right - left > max)
        {
            while (right > left)
            {
                if (A[left] <= A[right])
                {
                    max = (right - left) > max ? (right - left) : max;
                    break;
                }
                else
                {
                    right--;
                }
            }
            right = length - 1;
            left++;
            while (left < right && A[left] > A[left - 1])
            {
                left++;
            }
        }
        return max;
    }
}

// √ Accepted
//   √ 98/98 cases passed (140 ms)
//   √ Your runtime beats 84.51 % of csharp submissions
//   √ Your memory usage beats 6.52 % of csharp submissions (38.5 MB)

