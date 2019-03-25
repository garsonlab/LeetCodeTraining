/*
 * @lc app=leetcode id=111 lang=csharp
 *
 * [111] Minimum Depth of Binary Tree
 *
 * https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
 *
 * algorithms
 * Easy (34.95%)
 * Total Accepted:    279.9K
 * Total Submissions: 800.3K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given a binary tree, find its minimum depth.
 * 
 * The minimum depth is the number of nodes along the shortest path from the
 * root node down to the nearest leaf node.
 * 
 * Note: A leaf is a node with no children.
 * 
 * Example:
 * 
 * Given binary tree [3,9,20,null,null,15,7],
 * 
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * return its minimum depth = 2.
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
    public int MinDepth(TreeNode root) {
        
        if (root == null)
        {
            return 0;
        }

        int left = MinDepth(root.left);
        int right = MinDepth(root.right);

        if (left > 0 && right > 0)
            return 1 + Math.Min(left, right);
        return 1 + Math.Max(left, right);
    }
}

// √ Accepted
//   √ 41/41 cases passed (96 ms)
//   √ Your runtime beats 99.18 % of csharp submissions
//   √ Your memory usage beats 74.07 % of csharp submissions (24.1 MB)

