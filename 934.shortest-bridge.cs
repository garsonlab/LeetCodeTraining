/*
 * @lc app=leetcode id=934 lang=csharp
 *
 * [934] Shortest Bridge

 In a given 2D binary array A, there are two islands.  (An island is a 4-directionally connected group of 1s not connected to any other 1s.)

Now, we may change 0s to 1s so as to connect the two islands together to form 1 island.

Return the smallest number of 0s that must be flipped.  (It is guaranteed that the answer is at least 1.)

 

Example 1:

Input: [[0,1],[1,0]]
Output: 1
Example 2:

Input: [[0,1,0],[0,0,0],[0,0,1]]
Output: 2
Example 3:

Input: [[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
Output: 1
 

Note:

1 <= A.length = A[0].length <= 100
A[i][j] == 0 or A[i][j] == 1
 
 */
public class Solution {
   
    public int ShortestBridge(int[][] A)
    {
        int N = A.Length;
        bool flag = false;
        Queue<int[]> q = new Queue<int[]>();
        int[][] dirs = new[] {new[] {1, 0}, new[] {0, 1}, new[] {-1, 0}, new[] {0, -1}};
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (!flag && A[i][j] == 1)
                {
                    PaintOne(A, i, j);
                    flag = true;
                }
                else if (A[i][j] == 1)
                {
                    q.Enqueue(new []{i, j});
                }
            }
        }
        int res = 0;
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size-- > 0)
            {
                int[] t = q.Dequeue();
                foreach (var direct in dirs)
                {
                    int x = t[0] + direct[0];
                    int y = t[1] + direct[1];
                    if (x < 0 || y < 0 || x >= N || y >= N) continue;
                    if (A[x][y] == 0)
                    {
                        A[x][y] = 1;
                        q.Enqueue(new []{x, y});
                    }
                    else if (A[x][y] == 1) continue;
                    else return res;
                }
            }
            ++res;
        }
        return 1;
    }


   public int ShortestBridge_timeout(int[][] A)
    {
        int N = A.Length;
        int[][] dir = new int[4][]
        {
            new []{-1,0},
            new []{1,0},
            new []{0,-1},
            new []{0,1},
        };
        bool first = false;
        int ori = -1, target = -1;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (A[i][j] == 1)
                {
                    if (!first)
                    {
                        ori = i * N + j; 
                        PaintOne(A, i, j);
                        first = true;
                    }
                    else
                    {
                        target = i * N + j;
                        break;
                    }
                }
            }

            if(target >= 0)
                break;
        }

        Dictionary<int, int> cost = new Dictionary<int, int>();
        Dictionary<int, int> fr = new Dictionary<int, int>();

        List<int> list = new List<int>();
        list.Add(ori);
        cost[ori] = 0;

        while (list.Count > 0)
        {
            var index = list[0];
            list.RemoveAt(0);

            if(index == target)
                break;

            int c = cost[index];

            int row = index / N;
            int col = index % N;

            foreach (var i in dir)
            {
                int tr = i[0] + row;
                int tc = i[1] + col;

                if(tr < 0 || tr >= N || tc < 0 || tc >= N)
                    continue;

                var idx = tr * N + tc;
                int nc = c + (A[tr][tc] == 0 ? 100000 : 1);
                int old = cost.ContainsKey(idx) ? cost[idx] : int.MaxValue;

                if (nc < old)
                {
                    cost[idx] = nc;
                    fr[idx] = index;
                    list.Add(idx);

                    list.Sort((a, b) => { return cost[a] - cost[b]; });
                }
            }
        }

        int res = 0, tem = target;
        while (tem != ori)
        {
            tem = fr[tem];
            int r = tem / N;
            int c = tem % N;

            if (A[r][c] == 0)
                res++;
        }

        return res;
    }

    private void PaintOne(int[][] A, int x, int y)
    {
        if (x < 0 || x >= A.Length || y < 0 || y >= A.Length)
            return;

        if (A[x][y] != 1)
            return;

        A[x][y] = 2;

        PaintOne(A, x - 1, y);
        PaintOne(A, x + 1, y);
        PaintOne(A, x, y - 1);
        PaintOne(A, x, y + 1);
    }
}

// √ Accepted
//   √ 96/96 cases passed (152 ms)
//   √ Your runtime beats 57.45 % of csharp submissions
//   √ Your memory usage beats 71.79 % of csharp submissions (28.5 MB)

