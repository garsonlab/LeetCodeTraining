/*
 * @lc app=leetcode id=905 lang=csharp
 *
 * [905] Sort Array By Parity
 *
 * https://leetcode.com/problems/sort-array-by-parity/description/
 *
 * algorithms
 * Easy (72.23%)
 * Total Accepted:    80.8K
 * Total Submissions: 111.6K
 * Testcase Example:  '[3,1,2,4]'
 *
 * Given an array A of non-negative integers, return an array consisting of all
 * the even elements of A, followed by all the odd elements of A.
 * 
 * You may return any answer array that satisfies this condition.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [3,1,2,4]
 * Output: [2,4,3,1]
 * The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 5000
 * 0 <= A[i] <= 5000
 * 
 * 
 * 
 */
public class Solution {
    public int[] SortArrayByParity(int[] A) {
        for (int i = 0, j = A.Length-1; i < j; i++, j--)
        {
            if (A[i] % 2 == 0)
            {
                j++;
                continue;
            }

            if (A[j] % 2 == 1)
            {
                i--;
                continue;
            }

            int tem = A[i];
            A[i] = A[j];
            A[j] = tem;
        }

        return A;
    }
}

// √ Accepted
//   √ 285/285 cases passed (256 ms)
//   √ Your runtime beats 98.14 % of csharp submissions
//   √ Your memory usage beats 98.68 % of csharp submissions (31.7 MB)

