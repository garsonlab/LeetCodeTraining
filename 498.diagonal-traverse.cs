/*
 * @lc app=leetcode id=498 lang=csharp
 *
 * [498] Diagonal Traverse

 Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.

 

Example:

Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]

Output:  [1,2,4,7,5,3,6,8,9]

Explanation:

 

Note:

The total number of elements of the given matrix will not exceed 10,000.
 */
public class Solution {

    public int[] FindDiagonalOrder(int[][] matrix)
    {
        int row = matrix.Length;
        if(row <= 0)
            return new int[0];
        int col = matrix[0].Length;
        if(col <= 0)
            return new int[0];
        
        int r = 0, c = 0;
        int[] res = new int[row * col];
        for (int i = 0; i < res.Length; i++)
        {
            res[i] = matrix[r][c];
            // r + c 即为遍历的层数，偶数向上遍历，奇数向下遍历
            if ((r + c) % 2 == 0)
            {
                if (c == col - 1)
                {
                    // 往右移动一格准备向下遍历
                    r++;
                }
                else if (r == 0)
                {
                    // 往下移动一格准备向下遍历
                    c++;
                }
                else
                {
                    // 往上移动
                    r--;
                    c++;
                }
            }
            else
            {
                if (r == row - 1)
                {
                    // 往右移动一格准备向上遍历
                    c++;
                }
                else if (c == 0)
                {
                    // 往上移动一格准备向上遍历
                    r++;
                }
                else
                {
                    // 往下移动
                    r++;
                    c--;
                }
            }
        }
        return res;
    }


    public int[] FindDiagonalOrder_err(int[][] matrix) {
        int m = matrix.Length;
        if(m <= 0)
            return new int[0];
        int n = matrix[0].Length;
        if(n <= 0)
            return new int[0];
        
        List<int> list = new List<int>(m*n);
        int i = 0, j = 0;
        bool up = true;

        while (true)
        {
            list.Add(matrix[j][i]);

            if(i == n - 1 && j == m - 1)
                break;

            if (up)
            {
                if (i + 1 >= n)
                {
                    up = false;
                    j++;
                }
                else if (j - 1 < 0)
                {
                    up = false;
                    i++;
                }
                else
                {
                    i++;
                    j--;
                }
            }
            else
            {
                if (i - 1 < 0)
                {
                    up = true;
                    j++;
                }
                else if (j + 1 >= m)
                {
                    up = true;
                    i++;
                }
                else
                {
                    i--;
                    j++;
                }
            }
        }

        return list.ToArray();
    }
}


// √ Accepted
//   √ 32/32 cases passed (296 ms)
//   √ Your runtime beats 93.06 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (35.9 MB)
