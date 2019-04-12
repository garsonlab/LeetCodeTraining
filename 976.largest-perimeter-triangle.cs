/*
 * @lc app=leetcode id=976 lang=csharp
 *
 * [976] Largest Perimeter Triangle
 *
 * https://leetcode.com/problems/largest-perimeter-triangle/description/
 *
 * algorithms
 * Easy (57.07%)
 * Total Accepted:    12.9K
 * Total Submissions: 22.6K
 * Testcase Example:  '[2,1,2]'
 *
 * Given an array A of positive lengths, return the largest perimeter of a
 * triangle with non-zero area, formed from 3 of these lengths.
 * 
 * If it is impossible to form any triangle of non-zero area, return 0.
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
 * Input: [2,1,2]
 * Output: 5
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,2,1]
 * Output: 0
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [3,2,3,4]
 * Output: 10
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: [3,6,2,3]
 * Output: 8
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 3 <= A.length <= 10000
 * 1 <= A[i] <= 10^6
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int LargestPerimeter(int[] A) {
        Array.Sort(A);
        for (int i = A.Length - 1; i >= 2; i--)
        {
            if (A[i - 1] + A[i - 2] > A[i])
            {
                return A[i - 1] + A[i - 2] + A[i];
            }
        }

        return 0;
    }
}

// √ Accepted
//   √ 84/84 cases passed (136 ms)
//   √ Your runtime beats 97.78 % of csharp submissions
//   √ Your memory usage beats 37.5 % of csharp submissions (30.4 MB)

