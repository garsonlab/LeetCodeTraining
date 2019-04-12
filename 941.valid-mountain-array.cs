/*
 * @lc app=leetcode id=941 lang=csharp
 *
 * [941] Valid Mountain Array
 *
 * https://leetcode.com/problems/valid-mountain-array/description/
 *
 * algorithms
 * Easy (34.77%)
 * Total Accepted:    15.8K
 * Total Submissions: 45.2K
 * Testcase Example:  '[2,1]'
 *
 * Given an array A of integers, return true if and only if it is a valid
 * mountain array.
 * 
 * Recall that A is a mountain array if and only if:
 * 
 * 
 * A.length >= 3
 * There exists some i with 0 < i < A.length - 1 such that:
 * 
 * A[0] < A[1] < ... A[i-1] < A[i] 
 * A[i] > A[i+1] > ... > A[B.length - 1]
 * 
 * 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [2,1]
 * Output: false
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [3,5,5]
 * Output: false
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [0,3,2,1]
 * Output: true
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 0 <= A.length <= 10000
 * 0 <= A[i] <= 10000 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool ValidMountainArray(int[] A) {
        if (A.Length <= 2)
            return false;

        int i = 1;
        for (; i < A.Length; i++)
        {
            if(A[i] < A[i-1])
                break;
            else if (A[i] == A[i - 1])
                return false;
        }

        if ( (i == 1 && A[1] < A[0]) || i >= A.Length)
            return false;

        for (; i < A.Length-1; i++)
        {
            if (A[i] <= A[i + 1])
                return false;
        }

        return true;
    }
}

// √ Accepted
//   √ 51/51 cases passed (120 ms)
//   √ Your runtime beats 98.26 % of csharp submissions
//   √ Your memory usage beats 10 % of csharp submissions (30.9 MB)

