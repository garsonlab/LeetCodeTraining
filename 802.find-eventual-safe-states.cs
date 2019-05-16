/*
 * @lc app=leetcode id=802 lang=csharp
 *
 * [802] Find Eventual Safe States

 In a directed graph, we start at some node and every turn, walk along a directed edge of the graph.  If we reach a node that is terminal (that is, it has no outgoing directed edges), we stop.

Now, say our starting node is eventually safe if and only if we must eventually walk to a terminal node.  More specifically, there exists a natural number K so that for any choice of where to walk, we must have stopped at a terminal node in less than K steps.

Which nodes are eventually safe?  Return them as an array in sorted order.

The directed graph has N nodes with labels 0, 1, ..., N-1, where N is the length of graph.  The graph is given in the following form: graph[i] is a list of labels j such that (i, j) is a directed edge of the graph.

Example:
Input: graph = [[1,2],[2,3],[5],[0],[5],[],[]]
Output: [2,4,5,6]
Here is a diagram of the above graph.
Illustration of graph

Note:

graph will have length at most 10000.
The number of edges in the graph will not exceed 32000.
Each graph[i] will be a sorted list of different integers, chosen within the range [0, graph.length - 1].
 */
public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        List<int> res = new List<int>();
        if (graph == null || graph.Length == 0) return res;

        int nodeCount = graph.Length;
        int[] color = new int[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            if (EvInCycle(graph, i, color)) res.Add(i);
        }

        return res;
    }
    public bool EvInCycle(int[][] graph, int start, int[] color)
    {
        if (color[start] != 0) return color[start] == 1;

        color[start] = 2;
        foreach (int newNode in graph[start])
        {
            if (!EvInCycle(graph, newNode, color)) return false;
        }
        color[start] = 1;

        return true;
    }


    public IList<int> EventualSafeNodes_outtime(int[][] graph) {
        List<int> res = new List<int>();

        bool[] visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            bool incycle = false;
            foreach (var j in graph[i])
            {
                if (EInCycle(graph, visited, j, i))
                {
                    incycle = true;
                    break;
                }
            }
            if(!incycle)
                res.Add(i);
            else
                visited[i] = true;
        }

        return res;
    }

    private bool EInCycle(int[][] graph, bool[] visited, int c, int t)
    {
        if (visited[c])
            return true;
        if (c == t)
            return true;
        visited[c] = true;
        foreach (var i in graph[c])
        {
            // if(visited[i])
            //     continue;
            bool ic = EInCycle(graph, visited, i, t);
            
            if (ic)
            {
                visited[c] = false;
                return true;
            }
        }

        visited[c] = false;
        return false;
    }
}
// 、、是否以某节点开始存在环
// √ Accepted
//   √ 111/111 cases passed (500 ms)
//   √ Your runtime beats 47.83 % of csharp submissions
//   √ Your memory usage beats 38.89 % of csharp submissions (46.8 MB)

