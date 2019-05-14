/*
 * @lc app=leetcode id=787 lang=csharp
 *
 * [787] Cheapest Flights Within K Stops

 There are n cities connected by m flights. Each fight starts from city u and arrives at v with a price w.

Now given all the cities and flights, together with starting city src and the destination dst, your task is to find the cheapest price from src to dst with up to k stops. If there is no such route, output -1.

Example 1:
Input: 
n = 3, edges = [[0,1,100],[1,2,100],[0,2,500]]
src = 0, dst = 2, k = 1
Output: 200
Explanation: 
The graph looks like this:


The cheapest price from city 0 to city 2 with at most 1 stop costs 200, as marked red in the picture.
Example 2:
Input: 
n = 3, edges = [[0,1,100],[1,2,100],[0,2,500]]
src = 0, dst = 2, k = 0
Output: 500
Explanation: 
The graph looks like this:


The cheapest price from city 0 to city 2 with at most 0 stop costs 500, as marked blue in the picture.
Note:

The number of nodes n will be in range [1, 100], with nodes labeled from 0 to n - 1.
The size of flights will be in range [0, n * (n - 1) / 2].
The format of each flight will be (src, dst, price).
The price of each flight will be in the range [1, 10000].
k is in the range of [0, n - 1].
There will not be any duplicated flights or self cycles.
 */
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
    {
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = int.MaxValue;
        }
        dp[src] = 0;
        for (int z = 0; z <= K; ++z)
        {
            List<int> temp_dp = new List<int>(dp);
            foreach (var e in flights)
            {
                if (dp[e[0]] < int.MaxValue)
                {
                    temp_dp[e[1]] = Math.Min(temp_dp[e[1]], dp[e[0]] + e[2]);
                }
            }
            dp = temp_dp.ToArray();
        }
        return dp[dst] == int.MaxValue ? -1 : dp[dst];
    }


    public int FindCheapestPrice_timeout(int n, int[][] flights, int src, int dst, int K) {
        bool[] visited = new bool[n];
        int min = int.MaxValue;
        DFSCP(flights, visited, src, dst, K, 0, ref min);
        return min > 1000 ? -1 : min;
    }

    private void DFSCP(int[][] flights, bool[] visited, int src, int dst, int K, int pri, ref int min)
    {
        if (dst == src)
        {
            min = Math.Min(pri, min);
            return;
        }

        if (K < 0)
        {
            return;
        }

        visited[src] = true;

        for (int i = 0; i < flights.Length; i++)
        {
            var flight = flights[i];
            if (flight[0] == src && !visited[flight[1]])
            {
                DFSCP(flights, visited, flight[1], dst, K - 1, pri + flight[2], ref min);
            }
        }

        visited[src] = false;
    }

}

// √ Accepted
//   √ 41/41 cases passed (112 ms)
//   √ Your runtime beats 93.27 % of csharp submissions
//   √ Your memory usage beats 30.77 % of csharp submissions (24.5 MB)

