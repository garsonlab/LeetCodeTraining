/*
 * @lc app=leetcode id=947 lang=csharp
 *
 * [947] Most Stones Removed with Same Row or Column

 On a 2D plane, we place stones at some integer coordinate points.  Each coordinate point may have at most one stone.

Now, a move consists of removing a stone that shares a column or row with another stone on the grid.

What is the largest possible number of moves we can make?

 

Example 1:

Input: stones = [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]
Output: 5
Example 2:

Input: stones = [[0,0],[0,2],[1,1],[2,0],[2,2]]
Output: 3
Example 3:

Input: stones = [[0,0]]
Output: 0
 

Note:

1 <= stones.length <= 1000
0 <= stones[i][j] < 10000
 */
public class Solution {
    public int RemoveStones(int[][] stones) {
        int n = stones.Length;
        bool[] vis = new bool[n];
        int count = 0;
        for (int i = 0; i < n; ++i)
        {
            if (!vis[i])
            {
                DFSStone(i,stones[i],vis,stones);
                count++;
            }
        }
        return n-count;
    }
    void DFSStone(int idx, int[] p, bool[] vis, int[][] stones)
    {
        vis[idx] = true;
        for (int i = 0; i < stones.Length; ++i)
        {
            int x = stones[i][0], y = stones[i][1];
            if ((p[0] == x || p[1] == y) && !vis[i])
            {
                vis[i] = true;
                DFSStone(i, stones[i],vis,stones);
            }
        }
    }
}

// √ Accepted
//   √ 68/68 cases passed (236 ms)
//   √ Your runtime beats 23.12 % of csharp submissions
//   √ Your memory usage beats 75.74 % of csharp submissions (27.5 MB)

