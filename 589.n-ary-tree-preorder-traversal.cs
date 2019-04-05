/*
 * @lc app=leetcode id=589 lang=csharp
 *
 * [589] N-ary Tree Preorder Traversal
 *
 * https://leetcode.com/problems/n-ary-tree-preorder-traversal/description/
 *
 * algorithms
 * Easy (66.41%)
 * Total Accepted:    35.2K
 * Total Submissions: 52.8K
 * Testcase Example:  '{"$id":"1","children":[{"$id":"2","children":[{"$id":"5","children":[],"val":5},{"$id":"6","children":[],"val":6}],"val":3},{"$id":"3","children":[],"val":2},{"$id":"4","children":[],"val":4}],"val":1}'
 *
 * Given an n-ary tree, return the preorder traversal of its nodes' values.
 * 
 * For example, given a 3-ary tree:
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Return its preorder traversal as: [1,3,5,6,2,4].
 * 
 * 
 * 
 * Note:
 * 
 * Recursive solution is trivial, could you do it iteratively?
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
    public IList<int> Preorder(Node root)
    {
        IList<int> list = new List<int>();
        if (root == null)
            return list;
        GetVal(root, list);
        return list;
    }

    private void GetVal(Node node, IList<int> list)
    {
        if (node == null)
            return;

        list.Add(node.val);

        if (node.children == null)
            return;
        foreach (var child in node.children)
        {
            GetVal(child, list);
        }
    }



    //Time Limit Exceeded
    public IList<int> Preorder2(Node root) {
        IList<int> list = new List<int>();
        if (root == null)
            return list;

        List<Node> nodes = new List<Node>();
        nodes.Add(root);

        while (nodes.Count > 0)
        {
            var node = nodes[0];
            list.Add(node.val);
            list.RemoveAt(0);
            if (node.children != null)
            {
                for (int i = node.children.Count-1; i >= 0; i--)
                {
                    nodes.Insert(0, node.children[i]);
                }
            }
        }

        return list;
    }
}

// √ Accepted
//   √ 36/36 cases passed (332 ms)
//   √ Your runtime beats 74.82 % of csharp submissions
//   √ Your memory usage beats 90.32 % of csharp submissions (38.2 MB)

