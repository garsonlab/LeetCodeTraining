/*
 * @lc app=leetcode id=812 lang=csharp
 *
 * [812] Largest Triangle Area
 *
 * https://leetcode.com/problems/largest-triangle-area/description/
 *
 * algorithms
 * Easy (55.23%)
 * Total Accepted:    13.3K
 * Total Submissions: 23.9K
 * Testcase Example:  '[[0,0],[0,1],[1,0],[0,2],[2,0]]'
 *
 * You have a list of points in the plane. Return the area of the largest
 * triangle that can be formed by any 3 of the points.
 * 
 * 
 * Example:
 * Input: points = [[0,0],[0,1],[1,0],[0,2],[2,0]]
 * Output: 2
 * Explanation: 
 * The five points are show in the figure below. The red triangle is the
 * largest.
 * 
 * 
 * 
 * 
 * Notes: 
 * 
 * 
 * 3 <= points.length <= 50.
 * No points will be duplicated.
 * -50 <= points[i][j] <= 50.
 * Answers within 10^-6 of the true value will be accepted as correct.
 * 
 * 
 * 
 * 
 */
public class Solution {
   public double LargestTriangleArea(int[][] points)
    {
        double area = 0;
        for (int i = 0; i < points.Length; i++)
        {
            for (int j = i+1; j < points.Length; j++)
            {
                for (int k = j+1; k < points.Length; k++)
                {
                    double s = GetArea(points[i], points[j], points[k]);
                    if (s > area)
                        area = s;
                }
            }
        }

        return Math.Sqrt(area);
    }

    //海伦公式 vp(p-x)(p-y)(p-z)
    private double GetArea(int[] a, int[] b, int[] c)
    {
        double x = Math.Sqrt((a[0] - b[0]) * (a[0] - b[0]) + (a[1] - b[1]) * (a[1] - b[1]));
        double y = Math.Sqrt((a[0] - c[0]) * (a[0] - c[0]) + (a[1] - c[1]) * (a[1] - c[1]));
        double z = Math.Sqrt((c[0] - b[0]) * (c[0] - b[0]) + (c[1] - b[1]) * (c[1] - b[1]));
        double m = (x + y + z) / 2;

        return m * (m - x) * (m - y) * (m - z);
    }
}

// √ Accepted
//   √ 57/57 cases passed (116 ms)
//   √ Your runtime beats 64.29 % of csharp submissions
//   √ Your memory usage beats 66.67 % of csharp submissions (22 MB)

