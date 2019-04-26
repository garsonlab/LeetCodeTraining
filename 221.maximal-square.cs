/*
 * @lc app=leetcode id=221 lang=csharp
 *
 * [221] Maximal Square

    Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

    Example:

    Input: 

    1 0 1 0 0
    1 0 1 1 1
    1 1 1 1 1
    1 0 0 1 0

    Output: 4

 */
public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int w = matrix.Length;
        if (w <= 0)
            return 0;
        int h = matrix[0].Length;
        if (h <= 0)
            return 0;

        int max = 0;
        int[,] flag = new int[w, h];

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (matrix[i][j] == '1')
                {
                    flag[i, j] = 1;

                    if (i > 0 && j > 0 && flag[i-1, j-1] > 0)
                    {
                        int size = flag[i - 1, j - 1];
                        for (int k = 1; k <= size; k++)
                        {
                            if (matrix[i - k][j] == '0' || matrix[i][j - k] == '0')
                            {
                                size = k - 1;
                                break;
                            }
                        }
                        flag[i,j] += size;
                    }

                    max = Math.Max(max, flag[i, j]);
                }
            }
        }
        
        return max*max;
    }
}

// √ Accepted
//   √ 68/68 cases passed (132 ms)
//   √ Your runtime beats 68.97 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (27.2 MB)

