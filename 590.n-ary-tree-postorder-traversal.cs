/*
 * @lc app=leetcode id=590 lang=csharp
 *
 * [590] N-ary Tree Postorder Traversal
 *
 * https://leetcode.com/problems/n-ary-tree-postorder-traversal/description/
 *
 * algorithms
 * Easy (66.41%)
 * Total Accepted:    32.4K
 * Total Submissions: 48.5K
 * Testcase Example:  '{"$id":"1","children":[{"$id":"2","children":[{"$id":"5","children":[],"val":5},{"$id":"6","children":[],"val":6}],"val":3},{"$id":"3","children":[],"val":2},{"$id":"4","children":[],"val":4}],"val":1}'
 *
 * Given an n-ary tree, return the postorder traversal of its nodes' values.
 * 
 * For example, given a 3-ary tree:
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Return its postorder traversal as: [5,6,3,2,4,1].
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
    public IList<int> Postorder(Node root) {
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

        if (node.children != null)
            foreach (var child in node.children)
            {
                GetVal(child, list);
            }

        list.Add(node.val);
    }
}

// √ Accepted
//   √ 36/36 cases passed (332 ms)
//   √ Your runtime beats 76.35 % of csharp submissions
//   √ Your memory usage beats 71.43 % of csharp submissions (38.3 MB)

