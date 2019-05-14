/*
 * @lc app=leetcode id=797 lang=csharp
 *
 * [797] All Paths From Source to Target

 Given a directed, acyclic graph of N nodes.  Find all possible paths from node 0 to node N-1, and return them in any order.

The graph is given as follows:  the nodes are 0, 1, ..., graph.length - 1.  graph[i] is a list of all nodes j for which the edge (i, j) exists.

Example:
Input: [[1,2], [3], [3], []] 
Output: [[0,1,3],[0,2,3]] 
Explanation: The graph looks like this:
0--->1
|    |
v    v
2--->3
There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.
Note:

The number of nodes in the graph will be in the range [2, 15].
You can print different paths in any order, but you should keep the order of nodes inside one path.
 */
public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        IList<IList<int>> res = new List<IList<int>>();
        DFSPST(res, graph, new List<int>(), 0);
        return res;
    }

    private void DFSPST(IList<IList<int>> res, int[][] graph, List<int> cur, int t)
    {
        cur.Add(t);
        if (t == graph.Length - 1)
        {
            res.Add(cur);
            return;
        }

        int[] g = graph[t];
        foreach (var i in g)
        {
            var tem = new List<int>(cur);
            DFSPST(res, graph, tem, i);
        }
    }
}

// √ Accepted
//   √ 26/26 cases passed (284 ms)
//   √ Your runtime beats 47.41 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (33.8 MB)

