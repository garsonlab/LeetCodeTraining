/*
 * @lc app=leetcode id=106 lang=csharp
 *
 * [106] Construct Binary Tree from Inorder and Postorder Traversal
 *
 * https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
 *
 * algorithms
 * Medium (38.63%)
 * Total Accepted:    147.6K
 * Total Submissions: 381.5K
 * Testcase Example:  '[9,3,15,20,7]\n[9,15,7,20,3]'
 *
 * Given inorder and postorder traversal of a tree, construct the binary tree.
 * 
 * Note:
 * You may assume that duplicates do not exist in the tree.
 * 
 * For example, given
 * 
 * 
 * inorder = [9,3,15,20,7]
 * postorder = [9,15,7,20,3]
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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return CreateIPNode(ref inorder, ref postorder, 0, inorder.Length-1, 0, postorder.Length-1);
    }

    private TreeNode CreateIPNode(ref int[] inorder, ref int[] postorder, int il, int ir, int pl, int pr)
    {
        if (pl > pr || il > ir)
            return null;

        TreeNode node = new TreeNode(postorder[pr]);//后续的最后一个是根节点
        int idx = Array.IndexOf(inorder, postorder[pr]);//找到在中序中的位置
        int len = ir - idx;

        node.left = CreateIPNode(ref inorder, ref postorder, il, idx - 1, pl, pr-len-1);
        node.right = CreateIPNode(ref inorder, ref postorder, idx + 1, ir, pr-len, pr-1);
        return node;
    }
}
// √ Accepted
//   √ 203/203 cases passed (108 ms)
//   √ Your runtime beats 65.97 % of csharp submissions
//   √ Your memory usage beats 45 % of csharp submissions (24.6 MB)
