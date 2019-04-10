/*
 * @lc app=leetcode id=832 lang=csharp
 *
 * [832] Flipping an Image
 *
 * https://leetcode.com/problems/flipping-an-image/description/
 *
 * algorithms
 * Easy (71.77%)
 * Total Accepted:    84.5K
 * Total Submissions: 117.4K
 * Testcase Example:  '[[1,1,0],[1,0,1],[0,0,0]]'
 *
 * Given a binary matrix A, we want to flip the image horizontally, then invert
 * it, and return the resulting image.
 * 
 * To flip an image horizontally means that each row of the image is reversed.
 * For example, flipping [1, 1, 0] horizontally results in [0, 1, 1].
 * 
 * To invert an image means that each 0 is replaced by 1, and each 1 is
 * replaced by 0. For example, inverting [0, 1, 1] results in [1, 0, 0].
 * 
 * Example 1:
 * 
 * 
 * Input: [[1,1,0],[1,0,1],[0,0,0]]
 * Output: [[1,0,0],[0,1,0],[1,1,1]]
 * Explanation: First reverse each row: [[0,1,1],[1,0,1],[0,0,0]].
 * Then, invert the image: [[1,0,0],[0,1,0],[1,1,1]]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
 * Output: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
 * Explanation: First reverse each row:
 * [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]].
 * Then invert the image: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
 * 
 * 
 * Notes:
 * 
 * 
 * 1 <= A.length = A[0].length <= 20
 * 0 <= A[i][j] <= 1
 * 
 * 
 */
public class Solution {
    public int[][] FlipAndInvertImage(int[][] A) {
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0, k = A[i].Length-1; j <= k; j++, k--)
            {
                int tem = A[i][j];
                A[i][j] = (A[i][k] + 1) % 2;
                A[i][k] = (tem + 1) % 2;
            }
        }

        return A;
    }
}

// √ Accepted
//   √ 82/82 cases passed (256 ms)
//   √ Your runtime beats 77.54 % of csharp submissions
//   √ Your memory usage beats 71.43 % of csharp submissions (30.2 MB)

