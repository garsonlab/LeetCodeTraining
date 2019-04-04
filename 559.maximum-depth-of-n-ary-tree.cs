/*
 * @lc app=leetcode id=559 lang=csharp
 *
 * [559] Maximum Depth of N-ary Tree
 *
 * https://leetcode.com/problems/maximum-depth-of-n-ary-tree/description/
 *
 * algorithms
 * Easy (64.69%)
 * Total Accepted:    38.9K
 * Total Submissions: 60K
 * Testcase Example:  '{"$id":"1","children":[{"$id":"2","children":[{"$id":"5","children":[],"val":5},{"$id":"6","children":[],"val":6}],"val":3},{"$id":"3","children":[],"val":2},{"$id":"4","children":[],"val":4}],"val":1}'
 *
 * Given a n-ary tree, find its maximum depth.
 * 
 * The maximum depth is the number of nodes along the longest path from the
 * root node down to the farthest leaf node.
 * 
 * For example, given a 3-ary tree:
 * 
 * 
 * 
 * 
 * 
 * 
 * We should return its max depth, which is 3.
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
    public int MaxDepth(Node root) {
        if (root == null)
            return 0;
        int max = 0;
        if(root.children != null) {
            for(int i=0; i<root.children.Count; i++) {
                int v = MaxDepth(root.children[i]);
                if(v > max)
                    max = v;
            }
        }
        return 1+max;
    }
}


// √ Accepted
//   √ 36/36 cases passed (180 ms)
//   √ Your runtime beats 89.61 % of csharp submissions
//   √ Your memory usage beats 9.09 % of csharp submissions (33.1 MB)

