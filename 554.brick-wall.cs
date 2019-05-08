/*
 * @lc app=leetcode id=554 lang=csharp
 *
 * [554] Brick Wall

 There is a brick wall in front of you. The wall is rectangular and has several rows of bricks. The bricks have the same height but different width. You want to draw a vertical line from the top to the bottom and cross the least bricks.

The brick wall is represented by a list of rows. Each row is a list of integers representing the width of each brick in this row from left to right.

If your line go through the edge of a brick, then the brick is not considered as crossed. You need to find out how to draw the line to cross the least bricks and return the number of crossed bricks.

You cannot draw a line just along one of the two vertical edges of the wall, in which case the line will obviously cross no bricks.

 

Example:

Input: [[1,2,2,1],
        [3,1,2],
        [1,3,2],
        [2,4],
        [3,1,2],
        [1,3,1,1]]

Output: 2

Explanation: 

 

Note:

The width sum of bricks in different rows are the same and won't exceed INT_MAX.
The number of bricks in each row is in range [1,10,000]. The height of wall is in range [1,10,000]. Total number of bricks of the wall won't exceed 20,000.
 */
public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        
        if (wall.Count <= 0)
            return 0;
        if (wall.Count == 1)
            return wall[0].Count == 1 ? 1 : 0;

        Dictionary<int, int> dic= new Dictionary<int, int>();
        int f = -1, count = 0, h = 0;
        foreach (var w in wall)
        {
            int s = 0;
            for (int i = 0; i < w.Count; i++)
            {
                s += w[i];
                int n;
                if (!dic.TryGetValue(s, out n))
                    n = 0;
                dic[s] = n + 1;
                if (i != w.Count - 1 && n + 1 > count)
                {
                    f = s;
                    count = n + 1;
                }
            }
        }

        return wall.Count - count;
    }
}

// √ Accepted
//   √ 85/85 cases passed (144 ms)
//   √ Your runtime beats 46.38 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (33.2 MB)

