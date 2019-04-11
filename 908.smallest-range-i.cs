/*
 * @lc app=leetcode id=908 lang=csharp
 *
 * [908] Smallest Range I
 *
 * https://leetcode.com/problems/smallest-range-i/description/
 *
 * algorithms
 * Easy (64.53%)
 * Total Accepted:    20.6K
 * Total Submissions: 31.9K
 * Testcase Example:  '[1]\n0'
 *
 * Given an array A of integers, for each integer A[i] we may choose any x with
 * -K <= x <= K, and add x to A[i].
 * 
 * After this process, we have some array B.
 * 
 * Return the smallest possible difference between the maximum value of B and
 * the minimum value of B.
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
 * Input: A = [1], K = 0
 * Output: 0
 * Explanation: B = [1]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: A = [0,10], K = 2
 * Output: 6
 * Explanation: B = [2,8]
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: A = [1,3,6], K = 3
 * Output: 0
 * Explanation: B = [3,3,3] or B = [4,4,4]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 10000
 * 0 <= A[i] <= 10000
 * 0 <= K <= 10000
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int SmallestRangeI(int[] A, int K) {
        int min = A[0], max = A[0];
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] < min)
                min = A[i];
            if (A[i] > max)
                max = A[i];
        }

        if (max - min <= 2 * K)
            return 0;

        return max - K - (min + K);
    }
}

// √ Accepted
//   √ 68/68 cases passed (104 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 30.77 % of csharp submissions (26.4 MB)

