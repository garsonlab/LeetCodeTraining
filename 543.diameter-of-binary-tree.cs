/*
 * @lc app=leetcode id=543 lang=csharp
 *
 * [543] Diameter of Binary Tree
 *
 * https://leetcode.com/problems/diameter-of-binary-tree/description/
 *
 * algorithms
 * Easy (46.31%)
 * Total Accepted:    119.9K
 * Total Submissions: 258.4K
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * 
 * Given a binary tree, you need to compute the length of the diameter of the
 * tree. The diameter of a binary tree is the length of the longest path
 * between any two nodes in a tree. This path may or may not pass through the
 * root.
 * 
 * 
 * 
 * Example:
 * Given a binary tree 
 * 
 * ⁠         1
 * ⁠        / \
 * ⁠       2   3
 * ⁠      / \     
 * ⁠     4   5    
 * 
 * 
 * 
 * Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].
 * 
 * 
 * Note:
 * The length of path between two nodes is represented by the number of edges
 * between them.
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
    int r;
    public int DiameterOfBinaryTree(TreeNode root) {
        r = 0;
        GetDepth(root);
        return r;
    }

    private int GetDepth(TreeNode node)
    {
        if (node == null)
            return 0;

        int left = GetDepth(node.left);
        int right = GetDepth(node.right);
        r = Math.Max(r, left + right);
        return Math.Max(left, right) + 1;
    }
}

//获取左右深度的和即为路径
// √ Accepted
//   √ 106/106 cases passed (96 ms)
//   √ Your runtime beats 97.46 % of csharp submissions
//   √ Your memory usage beats 5.88 % of csharp submissions (24 MB)

