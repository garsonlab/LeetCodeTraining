/*
 * @lc app=leetcode id=973 lang=csharp
 *
 * [973] K Closest Points to Origin

 We have a list of points on the plane.  Find the K closest points to the origin (0, 0).

(Here, the distance between two points on a plane is the Euclidean distance.)

You may return the answer in any order.  The answer is guaranteed to be unique (except for the order that it is in.)

 

Example 1:

Input: points = [[1,3],[-2,2]], K = 1
Output: [[-2,2]]
Explanation: 
The distance between (1, 3) and the origin is sqrt(10).
The distance between (-2, 2) and the origin is sqrt(8).
Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
We only want the closest K = 1 points from the origin, so the answer is just [[-2,2]].
Example 2:

Input: points = [[3,3],[5,-1],[-2,4]], K = 2
Output: [[3,3],[-2,4]]
(The answer [[-2,4],[3,3]] would also be accepted.)
 

Note:

1 <= K <= points.length <= 10000
-10000 < points[i][0] < 10000
-10000 < points[i][1] < 10000
 */
public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        int len = points.Length;
        if (len <= K)
            return points;
        if(K == 0)
            return new int[0][];
        int[][] dis = new int[points.Length][];
        for (int i = 0; i < len; i++)
        {
            int d2 = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            dis[i] = new[] {d2, i};
        }

        Array.Sort(dis, (a, b) => { return a[0] - b[0]; });

        int[][] res = new int[K][];
        for (int i = 0; i < K; i++)
        {
            res[i] = points[dis[i][1]];
        }

        return res;
    }
}

// √ Accepted
//   √ 83/83 cases passed (528 ms)
//   √ Your runtime beats 50.76 % of csharp submissions
//   √ Your memory usage beats 32.79 % of csharp submissions (47 MB)

