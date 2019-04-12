/*
 * @lc app=leetcode id=949 lang=csharp
 *
 * [949] Largest Time for Given Digits
 *
 * https://leetcode.com/problems/largest-time-for-given-digits/description/
 *
 * algorithms
 * Easy (33.25%)
 * Total Accepted:    7.5K
 * Total Submissions: 22.5K
 * Testcase Example:  '[1,2,3,4]'
 *
 * Given an array of 4 digits, return the largest 24 hour time that can be
 * made.
 * 
 * The smallest 24 hour time is 00:00, and the largest is 23:59.  Starting from
 * 00:00, a time is larger if more time has elapsed since midnight.
 * 
 * Return the answer as a string of length 5.  If no valid time can be made,
 * return an empty string.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3,4]
 * Output: "23:41"
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [5,5,5,5]
 * Output: ""
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * A.length == 4
 * 0 <= A[i] <= 9
 * 
 * 
 * 
 */
public class Solution {
    public string LargestTimeFromDigits(int[] A) {
        Array.Sort(A);

        for (int i = 3; i >= 0; i--)
        {
            if(A[i] > 2)
                continue;
            for (int j = 3; j >= 0; j--)
            {
                if(i == j)
                    continue;

                if(A[i] == 2 && A[j] >= 4)
                    continue;

                int a = -1, b = -1;
                for (int k = 0; k < 4; k++)
                {
                    if(k != i && k != j)
                        if (a < 0)
                            a = A[k];
                        else
                            b = A[k];
                }

                int m = -1, f = 0;
                if (a * 10 + b < 60)
                {
                    m = a * 10 + b;
                    f = 1;
                }

                if (b * 10 + a < 60 && b * 10 + a > m)
                {
                    m = b * 10 + a;
                    f = 2;
                }

                if (m >= 0)
                {
                    return string.Format("{0}{1}:{2}{3}", A[i], A[j], f == 1 ? a : b, f == 1 ? b : a);
                }
            }
        }

        return "";
    }
}

// √ Accepted
//   √ 172/172 cases passed (104 ms)
//   √ Your runtime beats 85.71 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.3 MB)

