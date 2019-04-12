/*
 * @lc app=leetcode id=977 lang=csharp
 *
 * [977] Squares of a Sorted Array
 *
 * https://leetcode.com/problems/squares-of-a-sorted-array/description/
 *
 * algorithms
 * Easy (72.68%)
 * Total Accepted:    51.2K
 * Total Submissions: 70.7K
 * Testcase Example:  '[-4,-1,0,3,10]'
 *
 * Given an array of integers A sorted in non-decreasing order, return an array
 * of the squares of each number, also in sorted non-decreasing order.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [-4,-1,0,3,10]
 * Output: [0,1,9,16,100]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [-7,-3,2,3,11]
 * Output: [4,9,9,49,121]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 10000
 * -10000 <= A[i] <= 10000
 * A is sorted in non-decreasing order.
 * 
 * 
 * 
 */
public class Solution {
    public int[] SortedSquares(int[] A) {
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = A[i] * A[i];
        }

        Array.Sort(A);
        return A;
    }
}

// √ Accepted
//   √ 132/132 cases passed (312 ms)
//   √ Your runtime beats 80.7 % of csharp submissions
//   √ Your memory usage beats 94.29 % of csharp submissions (39.8 MB)

