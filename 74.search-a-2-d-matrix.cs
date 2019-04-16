/*
 * @lc app=leetcode id=74 lang=csharp
 *
 * [74] Search a 2D Matrix
 *
 * https://leetcode.com/problems/search-a-2d-matrix/description/
 *
 * algorithms
 * Medium (34.76%)
 * Total Accepted:    216K
 * Total Submissions: 621.3K
 * Testcase Example:  '[[1,3,5,7],[10,11,16,20],[23,30,34,50]]\n3'
 *
 * Write an efficient algorithm that searches for a value in an m x n matrix.
 * This matrix has the following properties:
 * 
 * 
 * Integers in each row are sorted from left to right.
 * The first integer of each row is greater than the last integer of the
 * previous row.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input:
 * matrix = [
 * ⁠ [1,   3,  5,  7],
 * ⁠ [10, 11, 16, 20],
 * ⁠ [23, 30, 34, 50]
 * ]
 * target = 3
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input:
 * matrix = [
 * ⁠ [1,   3,  5,  7],
 * ⁠ [10, 11, 16, 20],
 * ⁠ [23, 30, 34, 50]
 * ]
 * target = 13
 * Output: false
 * 
 */
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int row = matrix.Length;
        if (row == 0)
            return false;
        int col = matrix[0].Length;
        if (col == 0)
            return false;
        
        for (int i = 0; i < row; i++)
        {
            if (target >= matrix[i][0] && target <= matrix[i][col - 1])
            {
                return MidSearch2(matrix[i], 0, col - 1, target);
            }

            if(target < matrix[i][0])
                break;
        }

        return false;
    }

    private bool MidSearch2(int[] nums, int s, int e, int target)
    {
        if (s > e)
            return false;
        if (s == e)
            return nums[s] == target;
        int mid = (s + e) / 2;

        if (nums[mid] == target)
            return true;
        if (nums[mid] > target)
            return MidSearch2(nums, s, mid - 1, target);
        return MidSearch2(nums, mid + 1, e, target);
    }
}

// √ Accepted
//   √ 136/136 cases passed (100 ms)
//   √ Your runtime beats 99.39 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (23.6 MB)

