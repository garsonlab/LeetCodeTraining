/*
 * @lc app=leetcode id=310 lang=csharp
 *
 * [310] Minimum Height Trees

 For an undirected graph with tree characteristics, we can choose any node as the root. The result graph is then a rooted tree. Among all possible rooted trees, those with minimum height are called minimum height trees (MHTs). Given such a graph, write a function to find all the MHTs and return a list of their root labels.

Format
The graph contains n nodes which are labeled from 0 to n - 1. You will be given the number n and a list of undirected edges (each edge is a pair of labels).

You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1] is the same as [1, 0] and thus will not appear together in edges.

Example 1 :

Input: n = 4, edges = [[1, 0], [1, 2], [1, 3]]

        0
        |
        1
       / \
      2   3 

Output: [1]
Example 2 :

Input: n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]

     0  1  2
      \ | /
        3
        |
        4
        |
        5 

Output: [3, 4]
Note:

According to the definition of tree on Wikipedia: “a tree is an undirected graph in which any two vertices are connected by exactly one path. In other words, any connected graph without simple cycles is a tree.”
The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.
 */
public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        List<int>[] list = new List<int>[n];
        List<int> ret = new List<int>();
        List<int> tem = new List<int>();
        for (int i = 0; i < n; i++)
        {
            list[i] = new List<int>();
            ret.Add(i);
        }

        for (int i = 0; i < edges.Length; i++)
        {
            list[edges[i][0]].Add(edges[i][1]);
            list[edges[i][1]].Add(edges[i][0]);
        }

        while (ret.Count > 2)
        {
            while (ret.Count > 0)
            {
                int r = ret[0];
                var l = list[r];
                ret.RemoveAt(0);

                if (l.Count == 1)
                {
                    int a = l[0];
                    list[a].Remove(r);
                    ret.Remove(a);

                    if(list[a].Count > 0 && !tem.Contains(a))
                        tem.Add(a);
                }
                else if (l.Count > 1)
                {
                    tem.Add(r);
                }
            }

            ret.AddRange(tem);
            tem.Clear();
        }

        return ret;
    }
}

//剥洋葱，不断去除叶子节点
// √ Accepted
//   √ 66/66 cases passed (1236 ms)
//   √ Your runtime beats 10.29 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (38.8 MB)

