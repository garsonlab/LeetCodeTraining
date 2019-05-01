/*
 * @lc app=leetcode id=378 lang=csharp
 *
 * [378] Kth Smallest Element in a Sorted Matrix
 Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Note that it is the kth smallest element in the sorted order, not the kth distinct element.

Example:

matrix = [
   [ 1,  5,  9],
   [10, 11, 13],
   [12, 13, 15]
],
k = 8,

return 13.
Note: 
You may assume k is always valid, 1 ≤ k ≤ n2.
 */
public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int[] idx = new int[m];
        while (k > 0)
        {
            int min = 0;
            for (int i = 1; i < m; i++)
            {
                if (idx[min] >= n || ( idx[i] < n && matrix[i][idx[i]] < matrix[min][idx[min]]))
                {
                    min = i;
                }
            }

            if (--k == 0)
                return matrix[min][idx[min]];
            idx[min]++;
        }

        return 0;
    }
}

// √ Accepted
//   √ 85/85 cases passed (208 ms)
//   √ Your runtime beats 68.42 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (28.7 MB)

