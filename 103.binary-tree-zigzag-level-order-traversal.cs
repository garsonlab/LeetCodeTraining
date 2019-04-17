/*
 * @lc app=leetcode id=103 lang=csharp
 *
 * [103] Binary Tree Zigzag Level Order Traversal
 *
 * https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
 *
 * algorithms
 * Medium (41.12%)
 * Total Accepted:    208.5K
 * Total Submissions: 506.2K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given a binary tree, return the zigzag level order traversal of its nodes'
 * values. (ie, from left to right, then right to left for the next level and
 * alternate between).
 * 
 * 
 * For example:
 * Given binary tree [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 
 * return its zigzag level order traversal as:
 * 
 * [
 * ⁠ [3],
 * ⁠ [20,9],
 * ⁠ [15,7]
 * ]
 * 
 * 
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> list = new List<IList<int>>();
        if (root == null)
            return list;

        List<TreeNode> cur = new List<TreeNode>() { root };
        List<TreeNode> tem = new List<TreeNode>();

        while (cur.Count > 0)
        {
            List<int> t = new List<int>();
            foreach (var node in cur)
            {
                if(list.Count % 2 == 0)
                    t.Add(node.val);
                else
                    t.Insert(0, node.val);
                if (node.left != null)
                    tem.Add(node.left);
                if (node.right != null)
                    tem.Add(node.right);
            }
            list.Add(t);
            cur.Clear();
            cur.AddRange(tem);
            tem.Clear();
        }

        return list;
    }
}

// √ Accepted
//   √ 33/33 cases passed (248 ms)
//   √ Your runtime beats 99.07 % of csharp submissions
//   √ Your memory usage beats 25.64 % of csharp submissions (28.7 MB)

