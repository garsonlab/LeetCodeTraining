/*
 * @lc app=leetcode id=939 lang=csharp
 *
 * [939] Minimum Area Rectangle

 Given a set of points in the xy-plane, determine the minimum area of a rectangle formed from these points, with sides parallel to the x and y axes.

If there isn't any rectangle, return 0.

 

Example 1:

Input: [[1,1],[1,3],[3,1],[3,3],[2,2]]
Output: 4
Example 2:

Input: [[1,1],[1,3],[3,1],[3,3],[4,1],[4,3]]
Output: 2
 

Note:

1 <= points.length <= 500
0 <= points[i][0] <= 40000
0 <= points[i][1] <= 40000
All points are distinct.
 */
public class Solution {
    public int MinAreaRect(int[][] points)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        Array.Sort(points, (a, b) => { return a[0] - b[0]; });
        int area = int.MaxValue;
        
        for (int i = 0; i < points.Length; i++)
        {
            List<int> yForcurX;
            if (!map.TryGetValue(points[i][0], out yForcurX))
            {
                yForcurX = new List<int>();
                map[points[i][0]] = yForcurX;
            }
            for (int j = 0; j < i; j++)
            {
                if (points[j][0] == points[i][0]) break;
                List<int> yForPreX = map[points[j][0]];
                if (yForPreX.Contains(points[i][1]) && yForcurX.Contains(points[j][1]))
                {
                    area = Math.Min(area, Math.Abs((points[i][0] - points[j][0]) * (points[i][1] - points[j][1])));
                }
            }
            yForcurX.Add(points[i][1]);
        }
        return area == int.MaxValue ? 0 : area;
    }


    public int MinAreaRect_timeout(int[][] points) {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        foreach (int[] p in points)
        {
            List<int> list;
            if (!map.TryGetValue(p[0], out list))
            {
                list = new List<int>();
                map[p[0]] = list;
            }

            list.Add(p[1]);
        }
        int res = int.MaxValue;
        foreach (int[] p1 in points)
        {
            foreach (int[] p2 in points)
            {
                if (p1[0] == p2[0] || p1[1] == p2[1])
                    continue;

                if (map[p1[0]].Contains(p2[1]) && map[p2[0]].Contains(p1[1]))
                {
                    res = Math.Min(res, Math.Abs(p1[0] - p2[0]) * Math.Abs(p1[1] - p2[1]));
                }
            }
        }
        return res == int.MaxValue ? 0 : res;
    }
}


// √ Accepted
//   √ 137/137 cases passed (948 ms)
//   √ Your runtime beats 19.78 % of csharp submissions
//   √ Your memory usage beats 76.39 % of csharp submissions (28 MB)

