/*
 * @lc app=leetcode id=105 lang=csharp
 *
 * [105] Construct Binary Tree from Preorder and Inorder Traversal
 *
 * https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
 *
 * algorithms
 * Medium (40.29%)
 * Total Accepted:    213.1K
 * Total Submissions: 527.9K
 * Testcase Example:  '[3,9,20,15,7]\n[9,3,15,20,7]'
 *
 * Given preorder and inorder traversal of a tree, construct the binary tree.
 * 
 * Note:
 * You may assume that duplicates do not exist in the tree.
 * 
 * For example, given
 * 
 * 
 * preorder = [3,9,20,15,7]
 * inorder = [9,3,15,20,7]
 * 
 * Return the following binary tree:
 * 
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return CreatePINode(ref preorder, ref inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }

    private TreeNode CreatePINode(ref int[] preorder, ref int[] inorder, int pl, int pr, int il, int ir)
    {
        if (pl > pr || il > ir)
            return null;
        
        TreeNode node = new TreeNode(preorder[pl]);
        int idx = Array.IndexOf(inorder, preorder[pl]);
        int len = idx - il;
        
        node.left = CreatePINode(ref preorder, ref inorder, pl + 1, pl + len, il, idx - 1);
        node.right = CreatePINode(ref preorder, ref inorder, pl + len + 1, pr, idx + 1, ir);
        return node;
    }
}
//先序的第一个是根节点，在中序中找到根节点，左边左子树
// √ Accepted
//   √ 203/203 cases passed (108 ms)
//   √ Your runtime beats 68.22 % of csharp submissions
//   √ Your memory usage beats 65.71 % of csharp submissions (24.5 MB)

