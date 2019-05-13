/*
 * @lc app=leetcode id=743 lang=csharp
 *
 * [743] Network Delay Time

 There are N network nodes, labelled 1 to N.

Given times, a list of travel times as directed edges times[i] = (u, v, w), where u is the source node, v is the target node, and w is the time it takes for a signal to travel from source to target.

Now, we send a signal from a certain node K. How long will it take for all nodes to receive the signal? If it is impossible, return -1.

Note:

N will be in the range [1, 100].
K will be in the range [1, N].
The length of times will be in the range [1, 6000].
All edges times[i] = (u, v, w) will have 1 <= u, v <= N and 0 <= w <= 100.
 */
public class Solution {
    public int NetworkDelayTime(int[][] times, int N, int K) {
        int[] dist = new int[N + 1];

        for (int i = 0; i < N + 1; ++i)
        {
            //初始化K到每个节点的距离为最大值
            dist[i] = int.MaxValue;
        }

        //到自己的距离为0
        dist[K] = 0;

        int loop = 1;

        while (loop-- > 0)
        {
            //遍历所有边
            for (int i = 0; i < times.Length; i++)
            {
                //寻找变化的节点
                if (dist[times[i][0]] != int.MaxValue)
                {
                    int u = dist[times[i][0]];
                    int v = dist[times[i][1]];
                    int w = times[i][2];
                    //更新较小路径
                    dist[times[i][1]] = Math.Min(u + w, v);
                    //存在更新
                    if (v != dist[times[i][1]])
                        loop = 1;
                }
            }
        }

        int max_num = 0;

        //取得距离K节点最远的值
        for (int i = 1; i <= N; i++)
        {
            if (dist[i] == int.MaxValue)
                return -1;

            max_num = Math.Max(max_num, dist[i]);
        }

        return max_num;
    }
}

// √ Accepted
//   √ 51/51 cases passed (252 ms)
//   √ Your runtime beats 86.6 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (35.1 MB)

