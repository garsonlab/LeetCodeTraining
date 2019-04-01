/*
 * @lc app=leetcode id=429 lang=csharp
 *
 * [429] N-ary Tree Level Order Traversal
 *
 * https://leetcode.com/problems/n-ary-tree-level-order-traversal/description/
 *
 * algorithms
 * Easy (58.52%)
 * Total Accepted:    26.9K
 * Total Submissions: 45.8K
 * Testcase Example:  '{"$id":"1","children":[{"$id":"2","children":[{"$id":"5","children":[],"val":5},{"$id":"6","children":[],"val":6}],"val":3},{"$id":"3","children":[],"val":2},{"$id":"4","children":[],"val":4}],"val":1}'
 *
 * Given an n-ary tree, return the level order traversal of its nodes' values.
 * (ie, from left to right, level by level).
 * 
 * For example, given a 3-ary tree:
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * We should return its level order traversal:
 * 
 * 
 * [
 * ⁠    [1],
 * ⁠    [3,2,4],
 * ⁠    [5,6]
 * ]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The depth of the tree is at most 1000.
 * The total number of nodes is at most 5000.
 * 
 * 
 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node(){}
    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
}
*/
public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        IList<IList<int>> vals = new List<IList<int>>();
        if (root == null)
            return vals;

        List<Node> cur = new List<Node>();
        List<Node> children = new List<Node>();
        cur.Add(root);

        while (cur.Count > 0)
        {
            var list = new List<int>();
            
            foreach (var node in cur)
            {
                list.Add(node.val);

                if(node.children != null)
                    children.AddRange(node.children);
            }

            vals.Add(list);
            cur.Clear();
            cur.AddRange(children);
            children.Clear();
        }

        return vals;
    }
}

// √ Accepted
//   √ 36/36 cases passed (376 ms)
//   √ Your runtime beats 52.43 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (38.7 MB)

