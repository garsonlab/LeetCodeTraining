/*
 * @lc app=leetcode id=102 lang=csharp
 *
 * [102] Binary Tree Level Order Traversal
 *
 * https://leetcode.com/problems/binary-tree-level-order-traversal/description/
 *
 * algorithms
 * Medium (47.78%)
 * Total Accepted:    359.4K
 * Total Submissions: 751.2K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given a binary tree, return the level order traversal of its nodes' values.
 * (ie, from left to right, level by level).
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
 * return its level order traversal as:
 * 
 * [
 * ⁠ [3],
 * ⁠ [9,20],
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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> list = new List<IList<int>>();
        if (root == null)
            return list;

        List<TreeNode> cur = new List<TreeNode>(){root};
        List<TreeNode> tem = new List<TreeNode>();

        while (cur.Count > 0)
        {
            List<int> t = new List<int>();
            foreach (var node in cur)
            {
                t.Add(node.val);
                if (node.left != null)
                    tem.Add(node.left);
                if(node.right != null)
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
//   √ 34/34 cases passed (252 ms)
//   √ Your runtime beats 86.17 % of csharp submissions
//   √ Your memory usage beats 67.92 % of csharp submissions (29.1 MB)

