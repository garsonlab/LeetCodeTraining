/*
 * @lc app=leetcode id=1039 lang=csharp
 *
 * [1039] Minimum Score Triangulation of Polygon
 Given N, consider a convex N-sided polygon with vertices labelled A[0], A[i], ..., A[N-1] in clockwise order.

Suppose you triangulate the polygon into N-2 triangles.  For each triangle, the value of that triangle is the product of the labels of the vertices, and the total score of the triangulation is the sum of these values over all N-2 triangles in the triangulation.

Return the smallest possible total score that you can achieve with some triangulation of the polygon.

 

Example 1:

Input: [1,2,3]
Output: 6
Explanation: The polygon is already triangulated, and the score of the only triangle is 6.
Example 2:



Input: [3,7,4,5]
Output: 144
Explanation: There are two triangulations, with possible scores: 3*7*5 + 4*5*7 = 245, or 3*4*5 + 3*4*7 = 144.  The minimum score is 144.
Example 3:

Input: [1,3,1,4,1,5]
Output: 13
Explanation: The minimum score triangulation has score 1*1*3 + 1*1*4 + 1*1*5 + 1*1*1 = 13.
 

Note:

3 <= A.length <= 50
1 <= A[i] <= 100
 */
public class Solution {
    public int MinScoreTriangulation(int[] A) {
        int n = A.Length;
        int[,] dp = new int[n, n];

        for (int length = 0; length < n; length++)
        {
            for (int i = 0; i < n-length; i++)
            {
                int j = i+length;
                for (int k = i+1; k < j; k++)
                {
                    int s = A[i]*A[j]*A[k] + dp[i, k] + dp[k, j];
                    // if(dp[i, j] == 0)

                    dp[i, j] = dp[i,j]==0? s : Math.Min(s, dp[i, j]);
                }
            }
        }
        return dp[0, n-1];
    }
}

// 对于点 0，1，...，n-1构成的多边形三角剖分，考虑点0和n-1，因为总有某个点 j 与点0和n-1构成三角形，

// 使得原多边形被分成一个三角形和至多两个凸多边形，求解原问题退化成求解两个规模更小的子问题，

// 即有若 f(0,n-1)表示原问题的解，则存在 j使

// f(0,n-1) = f(0,j) + f(j,n-1) + A[0]*A[k]*A[n-1]
// √ Accepted
//   √ 93/93 cases passed (96 ms)
//   √ Your runtime beats 59.62 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.1 MB)
