/*
 * @lc app=leetcode id=447 lang=csharp
 *
 * [447] Number of Boomerangs
 *
 * https://leetcode.com/problems/number-of-boomerangs/description/
 *
 * algorithms
 * Easy (49.44%)
 * Total Accepted:    52.2K
 * Total Submissions: 105.4K
 * Testcase Example:  '[[0,0],[1,0],[2,0]]'
 *
 * Given n points in the plane that are all pairwise distinct, a "boomerang" is
 * a tuple of points (i, j, k) such that the distance between i and j equals
 * the distance between i and k (the order of the tuple matters).
 * 
 * Find the number of boomerangs. You may assume that n will be at most 500 and
 * coordinates of points are all in the range [-10000, 10000] (inclusive).
 * 
 * Example:
 * 
 * Input:
 * [[0,0],[1,0],[2,0]]
 * 
 * Output:
 * 2
 * 
 * Explanation:
 * The two boomerangs are [[1,0],[0,0],[2,0]] and [[1,0],[2,0],[0,0]]
 * 
 * 
 */
public class Solution {
    public int NumberOfBoomerangs(int[][] points) {
        int n = 0;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int len = points.Length;
        for (int i = 0; i < len; i++)
        {
            dic.Clear();
            for (int j = 0; j < len; j++)
            {
                if(i == j) continue;

                int x = points[i][0] - points[j][0];
                int y = points[i][1] - points[j][1];
                int dis = (x * x) + (y * y);
                int c;
                if (!dic.TryGetValue(dis, out c))
                    c = 0;
                dic[dis] = c + 1;
            }

            foreach (var v in dic.Values)
            {
                if (v > 1)
                {
                    n += v * (v - 1);
                }
            }
        }

        return n;
    }
}

// √ Accepted
//   √ 31/31 cases passed (204 ms)
//   √ Your runtime beats 95.52 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (22.8 MB)

