/*
 * @lc app=leetcode id=240 lang=csharp
 *
 * [240] Search a 2D Matrix II

 Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
Example:

Consider the following matrix:

[
  [1,   4,  7, 11, 15],
  [2,   5,  8, 12, 19],
  [3,   6,  9, 16, 22],
  [10, 13, 14, 17, 24],
  [18, 21, 23, 26, 30]
]
Given target = 5, return true.

Given target = 20, return false.
 */
public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        int x = 0, y = m-1;

        while(x < n && y >= 0) {
            if(matrix[y, x] == target)
                return true;
            
            if(matrix[y, x] < target)
                x++;
            else
                y--;
        }

        return false;
    }
}

// √ Accepted
//   √ 129/129 cases passed (284 ms)
//   √ Your runtime beats 89.98 % of csharp submissions
//   √ Your memory usage beats 7.41 % of csharp submissions (29.6 MB)

