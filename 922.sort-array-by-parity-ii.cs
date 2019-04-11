/*
 * @lc app=leetcode id=922 lang=csharp
 *
 * [922] Sort Array By Parity II
 *
 * https://leetcode.com/problems/sort-array-by-parity-ii/description/
 *
 * algorithms
 * Easy (66.77%)
 * Total Accepted:    35.2K
 * Total Submissions: 52.8K
 * Testcase Example:  '[4,2,5,7]'
 *
 * Given an array A of non-negative integers, half of the integers in A are
 * odd, and half of the integers are even.
 * 
 * Sort the array so that whenever A[i] is odd, i is odd; and whenever A[i] is
 * even, i is even.
 * 
 * You may return any answer array that satisfies this condition.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [4,2,5,7]
 * Output: [4,5,2,7]
 * Explanation: [4,7,2,5], [2,5,4,7], [2,7,4,5] would also have been
 * accepted.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 2 <= A.length <= 20000
 * A.length % 2 == 0
 * 0 <= A[i] <= 1000
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int[] SortArrayByParityII(int[] A) {
        for (int i = 0; i < A.Length; i++)
        {
            int f = i % 2;
            if (A[i] % 2 != f)
            {
                for (int j = i+1; j < A.Length; j++)
                {
                    if (A[j] % 2 == f)
                    {
                        int tem = A[i];
                        A[i] = A[j];
                        A[j] = tem;
                        break;
                    }
                }
            }
        }

        return A;
    }
}

// √ Accepted
//   √ 61/61 cases passed (288 ms)
//   √ Your runtime beats 62.54 % of csharp submissions
//   √ Your memory usage beats 71.88 % of csharp submissions (34.6 MB)

