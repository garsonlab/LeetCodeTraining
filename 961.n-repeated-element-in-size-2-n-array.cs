/*
 * @lc app=leetcode id=961 lang=csharp
 *
 * [961] N-Repeated Element in Size 2N Array
 *
 * https://leetcode.com/problems/n-repeated-element-in-size-2n-array/description/
 *
 * algorithms
 * Easy (73.15%)
 * Total Accepted:    43.9K
 * Total Submissions: 60.2K
 * Testcase Example:  '[1,2,3,3]'
 *
 * In a array A of size 2N, there are N+1 unique elements, and exactly one of
 * these elements is repeated N times.
 * 
 * Return the element repeated N times.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3,3]
 * Output: 3
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [2,1,2,5,3,2]
 * Output: 2
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [5,1,5,2,5,3,5,4]
 * Output: 5
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 4 <= A.length <= 10000
 * 0 <= A[i] < 10000
 * A.length is even
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int RepeatedNTimes(int[] A) {
        Array.Sort(A);
        return A[A.Length / 2] == A[A.Length - 1] ? A[A.Length / 2] : A[A.Length / 2 - 1];
    }
    //因为有N+1个不同的，排序后必在中间
}

// √ Accepted
//   √ 102/102 cases passed (140 ms)
//   √ Your runtime beats 66.87 % of csharp submissions
//   √ Your memory usage beats 68.18 % of csharp submissions (30.9 MB)

