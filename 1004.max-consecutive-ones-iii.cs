/*
 * @lc app=leetcode id=1004 lang=csharp
 *
 * [1004] Max Consecutive Ones III

 Given an array A of 0s and 1s, we may change up to K values from 0 to 1.

Return the length of the longest (contiguous) subarray that contains only 1s. 

 

Example 1:

Input: A = [1,1,1,0,0,0,1,1,1,1,0], K = 2
Output: 6
Explanation: 
[1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1.  The longest subarray is underlined.
Example 2:

Input: A = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], K = 3
Output: 10
Explanation: 
[0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1.  The longest subarray is underlined.
 

Note:

1 <= A.length <= 20000
0 <= K <= A.length
A[i] is 0 or 1 
 */
public class Solution {
    public int LongestOnes(int[] A, int K) {
        int res = 0;
        int i = 0, j = 0;
        while (i < A.Length && j < A.Length)
        {
            // 以i为起点，最长可以有多长
            while (j < A.Length && (A[j] == 1 || (A[j] == 0 && K > 0)))
            {
                if (A[j] == 0) K--;
                j++;
            }
            res = Math.Max(res, j - i);

            if (A[i] == 0) K++;
            i++;
        }

        return res;
    }
}

// √ Accepted
//   √ 48/48 cases passed (180 ms)
//   √ Your runtime beats 34.07 % of csharp submissions
//   √ Your memory usage beats 27.47 % of csharp submissions (37.3 MB)

