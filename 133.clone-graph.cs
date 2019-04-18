/*
 * @lc app=leetcode id=133 lang=csharp
 *
 * [133] Clone Graph
 *
 * https://leetcode.com/problems/clone-graph/description/
 *
 * algorithms
 * Medium (25.88%)
 * Total Accepted:    209.3K
 * Total Submissions: 806.1K
 * Testcase Example:  '{"$id":"1","neighbors":[{"$id":"2","neighbors":[{"$ref":"1"},{"$id":"3","neighbors":[{"$ref":"2"},{"$id":"4","neighbors":[{"$ref":"3"},{"$ref":"1"}],"val":4}],"val":3}],"val":2},{"$ref":"4"}],"val":1}'
 *
 * Given a reference of a node in a connected undirected graph, return a deep
 * copy (clone) of the graph. Each node in the graph contains a val (int) and a
 * list (List[Node]) of its neighbors.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * 
 * 
 * Input:
 * 
 * {"$id":"1","neighbors":[{"$id":"2","neighbors":[{"$ref":"1"},{"$id":"3","neighbors":[{"$ref":"2"},{"$id":"4","neighbors":[{"$ref":"3"},{"$ref":"1"}],"val":4}],"val":3}],"val":2},{"$ref":"4"}],"val":1}
 * 
 * Explanation:
 * Node 1's value is 1, and it has two neighbors: Node 2 and 4.
 * Node 2's value is 2, and it has two neighbors: Node 1 and 3.
 * Node 3's value is 3, and it has two neighbors: Node 2 and 4.
 * Node 4's value is 4, and it has two neighbors: Node 1 and 3.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The number of nodes will be between 1 and 100.
 * The undirected graph is a simple graph, which means no repeated edges and no
 * self-loops in the graph.
 * Since the graph is undirected, if node p has node q as neighbor, then node q
 * must have node p as neighbor too.
 * You must return the copy of the given node as a reference to the cloned
 * graph.
 * 
 * 
 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node(){}
    public Node(int _val,IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
}
*/
public class Solution {
    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        Node root = new Node();
        root.val = node.val;
        Dictionary<Node, Node> dic = new Dictionary<Node, Node>() {{node, root}};
        List<Node> cloned = new List<Node>();

        while (queue.Count > 0)
        {
            var ori = queue.Dequeue();
            var clo = dic[ori];

            cloned.Add(ori);

            if (ori.neighbors != null)
            {
                if (clo.neighbors == null)
                    clo.neighbors = new List<Node>();

                foreach (var neighbor in ori.neighbors)
                {
                    if (neighbor == null)
                    {
                        clo.neighbors.Add(null);
                        continue;
                    }
                    Node tem;
                    if (!dic.TryGetValue(neighbor, out tem))
                    {
                        tem = new Node();
                        tem.val = neighbor.val;

                        dic[neighbor] = tem;
                    }

                    if (!clo.neighbors.Contains(tem))
                        clo.neighbors.Add(tem);

                    if (!cloned.Contains(neighbor) && !queue.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
        }

        return root;
    }
}

// √ Accepted
//   √ 20/20 cases passed (164 ms)
//   √ Your runtime beats 59.31 % of csharp submissions
//   √ Your memory usage beats 6.9 % of csharp submissions (25 MB)

