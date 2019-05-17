/*
 * @lc app=leetcode id=845 lang=csharp
 *
 * [845] Longest Mountain in Array

 Let's call any (contiguous) subarray B (of A) a mountain if the following properties hold:

B.length >= 3
There exists some 0 < i < B.length - 1 such that B[0] < B[1] < ... B[i-1] < B[i] > B[i+1] > ... > B[B.length - 1]
(Note that B could be any subarray of A, including the entire array A.)

Given an array A of integers, return the length of the longest mountain. 

Return 0 if there is no mountain.

Example 1:

Input: [2,1,4,7,3,2,5]
Output: 5
Explanation: The largest mountain is [1,4,7,3,2] which has length 5.
Example 2:

Input: [2,2,2]
Output: 0
Explanation: There is no mountain.
Note:

0 <= A.length <= 10000
0 <= A[i] <= 10000
Follow up:

Can you solve it using only one pass?
Can you solve it in O(1) space?
 */
public class Solution {
    public int LongestMountain(int[] A) {
        int res = 0;
        int count = 1;
        bool increace = true;

        for (int i = 1; i < A.Length; i++)
        {
            if (increace && A[i] > A[i - 1])
                count++;
            else if (increace && count > 1 && A[i] < A[i - 1])
            {
                increace = false;
                count++;
            }
            else if (!increace && A[i] < A[i - 1])
                count++;
            else
            {
                if (!increace && count >= 3)
                    res = Math.Max(res, count);

                count = 1;
                if (A[i - 1] < A[i])
                    count++;
                increace = true;
            }
        }
        if (!increace && count >= 3)
            res = Math.Max(res, count);

        return res;
    }
}

// √ Accepted
//   √ 72/72 cases passed (124 ms)
//   √ Your runtime beats 44.83 % of csharp submissions
//   √ Your memory usage beats 30.61 % of csharp submissions (27.8 MB)

