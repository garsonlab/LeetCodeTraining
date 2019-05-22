/*
 * @lc app=leetcode id=963 lang=csharp
 *
 * [963] Minimum Area Rectangle II

 Given a set of points in the xy-plane, determine the minimum area of any rectangle formed from these points, with sides not necessarily parallel to the x and y axes.

If there isn't any rectangle, return 0.

 

Example 1:



Input: [[1,2],[2,1],[1,0],[0,1]]
Output: 2.00000
Explanation: The minimum area rectangle occurs at [1,2],[2,1],[1,0],[0,1], with an area of 2.
Example 2:



Input: [[0,1],[2,1],[1,1],[1,0],[2,0]]
Output: 1.00000
Explanation: The minimum area rectangle occurs at [1,0],[1,1],[2,1],[2,0], with an area of 1.
Example 3:



Input: [[0,3],[1,2],[3,1],[1,3],[2,1]]
Output: 0
Explanation: There is no possible rectangle to form from these points.
Example 4:



Input: [[3,1],[1,1],[0,1],[2,1],[3,3],[3,2],[0,2],[2,3]]
Output: 2.00000
Explanation: The minimum area rectangle occurs at [2,1],[2,3],[3,3],[3,1], with an area of 2.
 

Note:

1 <= points.length <= 50
0 <= points[i][0] <= 40000
0 <= points[i][1] <= 40000
All points are distinct.
Answers within 10^-5 of the actual value will be accepted as correct.
 */
public class Solution {
    public double MinAreaFreeRect(int[][] points) {
        double s = double.MaxValue;
        int n = points.Length;
        List<string> list = new List<string>();
        foreach (var point in points)
        {
            list.Add(point[0] + "," + point[1]);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                for (int k = j+1; k < n; k++)
                {
                    s = Math.Min(s, GetArea(list, points[i], points[j], points[k]));
                }
            }
        }

        return s == double.MaxValue ? 0 : s;
    }

    private double GetArea(List<string> list, int[] a, int[] b, int[] c)
    {
        int ab_x = a[0] - b[0];
        int ab_y = a[1] - b[1];

        int ac_x = a[0] - c[0];
        int ac_y = a[1] - c[1];

        int bc_x = b[0] - c[0];
        int bc_y = b[1] - c[1];


        if (ab_x * ac_x + ab_y * ac_y == 0)
        {
            int tx = b[0] + c[0] - a[0];
            int ty = b[1] + c[1] - a[1];
            string tem = tx + "," + ty;
            if (list.Contains(tem))
                return Math.Sqrt(ab_x * ab_x + ab_y * ab_y) * Math.Sqrt(ac_x * ac_x + ac_y * ac_y);
        }

        if (ab_x * bc_x + ab_y * bc_y == 0)
        {
            int tx = a[0] + c[0] - b[0];
            int ty = a[1] + c[1] - b[1];
            string tem = tx + "," + ty;
            if (list.Contains(tem))
                return Math.Sqrt(ab_x * ab_x + ab_y * ab_y) * Math.Sqrt(bc_x * bc_x + bc_y * bc_y);
        }

        if (ac_x * bc_x + ac_y * bc_y == 0)
        {
            int tx = a[0] + b[0] - c[0];
            int ty = a[1] + b[1] - c[1];
            string tem = tx + "," + ty;
            if (list.Contains(tem))
                return Math.Sqrt(ac_x * ac_x + ac_y * ac_y) * Math.Sqrt(bc_x * bc_x + bc_y * bc_y);
        }

        return double.MaxValue;
    }


}

// √ Accepted
//   √ 109/109 cases passed (136 ms)
//   √ Your runtime beats 92.31 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (24.7 MB)

