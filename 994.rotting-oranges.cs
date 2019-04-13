/*
 * @lc app=leetcode id=994 lang=csharp
 *
 * [994] Rotting Oranges
 *
 * https://leetcode.com/problems/rotting-oranges/description/
 *
 * algorithms
 * Easy (46.14%)
 * Total Accepted:    8.4K
 * Total Submissions: 18.1K
 * Testcase Example:  '[[2,1,1],[1,1,0],[0,1,1]]'
 *
 * In a given grid, each cell can have one of three values:
 * 
 * 
 * the value 0 representing an empty cell;
 * the value 1 representing a fresh orange;
 * the value 2 representing a rotten orange.
 * 
 * 
 * Every minute, any fresh orange that is adjacent (4-directionally) to a
 * rotten orange becomes rotten.
 * 
 * Return the minimum number of minutes that must elapse until no cell has a
 * fresh orange.  If this is impossible, return -1 instead.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input: [[2,1,1],[1,1,0],[0,1,1]]
 * Output: 4
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [[2,1,1],[0,1,1],[1,0,1]]
 * Output: -1
 * Explanation:  The orange in the bottom left corner (row 2, column 0) is
 * never rotten, because rotting only happens 4-directionally.
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [[0,2]]
 * Output: 0
 * Explanation:  Since there are already no fresh oranges at minute 0, the
 * answer is just 0.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= grid.length <= 10
 * 1 <= grid[0].length <= 10
 * grid[i][j] is only 0, 1, or 2.
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int OrangesRotting(int[][] grid) {
        int min = 0;
        int h = grid.Length;
        int w = grid[0].Length;
        int good = 0;
        List<int> list = new List<int>();
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if(grid[i][j] == 2)
                    list.Add(i*w+j);
                else if (grid[i][j] == 1)
                    good++;
            }
        }

        if (good == 0)
            return 0;

        while (list.Count > 0 && good > 0)
        {
            bool chg = false;

            for(int i = list.Count-1; i>= 0; i--)
            {
                int x = list[i] % w;
                int y = list[i] / w;

                //bool c = false;
                if (x > 0 && grid[y][x - 1] == 1)
                {
                    grid[y][x - 1] = 2;
                    list.Add(y * w + x - 1);
                    good--;
                    chg = true;
                }
                if (x < w-1 && grid[y][x + 1] == 1)
                {
                    grid[y][x + 1] = 2;
                    list.Add(y * w + x + 1);
                    good--;
                    chg = true;
                }
                if (y > 0 && grid[y - 1][x] == 1)
                {
                    grid[y - 1][x] = 2;
                    list.Add((y-1) * w + x);
                    good--;
                    chg = true;
                }
                if (y < h-1 && grid[y + 1][x] == 1)
                {
                    grid[y + 1][x] = 2;
                    list.Add((y + 1) * w + x);
                    good--;
                    chg = true;
                }
                list.RemoveAt(i);

            }

            if (chg)
                min++;
            else
                return -1;
        }

        if(good > 0)
            return -1;

        return min;
    }
}

// √ Accepted
//   √ 303/303 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 76.39 % of csharp submissions (23.4 MB)

