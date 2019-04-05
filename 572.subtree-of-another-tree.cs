/*
 * @lc app=leetcode id=572 lang=csharp
 *
 * [572] Subtree of Another Tree
 *
 * https://leetcode.com/problems/subtree-of-another-tree/description/
 *
 * algorithms
 * Easy (41.38%)
 * Total Accepted:    93.4K
 * Total Submissions: 225.4K
 * Testcase Example:  '[3,4,5,1,2]\n[4,1,2]'
 *
 * 
 * Given two non-empty binary trees s and t, check whether tree t has exactly
 * the same structure and node values with a subtree of s. A subtree of s is a
 * tree consists of a node in s and all of this node's descendants. The tree s
 * could also be considered as a subtree of itself.
 * 
 * 
 * Example 1:
 * 
 * Given tree s:
 * 
 * ⁠    3
 * ⁠   / \
 * ⁠  4   5
 * ⁠ / \
 * ⁠1   2
 * 
 * Given tree t:
 * 
 * ⁠  4 
 * ⁠ / \
 * ⁠1   2
 * 
 * Return true, because t has the same structure and node values with a subtree
 * of s.
 * 
 * 
 * Example 2:
 * 
 * Given tree s:
 * 
 * ⁠    3
 * ⁠   / \
 * ⁠  4   5
 * ⁠ / \
 * ⁠1   2
 * ⁠   /
 * ⁠  0
 * 
 * Given tree t:
 * 
 * ⁠  4
 * ⁠ / \
 * ⁠1   2
 * 
 * Return false.
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
    public bool IsSubtree(TreeNode s, TreeNode t)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(s);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node.val == t.val && IsSame(node, t))
            {
                return true;
            }
            if(node.left != null)
                queue.Enqueue(node.left);
            if(node.right != null)
                queue.Enqueue(node.right);
        }

        return false;
    }

    private bool IsSame(TreeNode a, TreeNode b)
    {
        if (a == null && b == null)
            return true;

        if (a != null && b != null)
        {
            if (a.val != b.val)
                return false;

            bool isSame = IsSame(a.left, b.left);
            if (!isSame)
                return false;
            return IsSame(a.right, b.right);
        }

        return false;
    }
}

// √ Accepted
//   √ 176/176 cases passed (116 ms)
//   √ Your runtime beats 72.55 % of csharp submissions
//   √ Your memory usage beats 87.5 % of csharp submissions (25.6 MB)

