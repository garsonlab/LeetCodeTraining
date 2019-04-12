/*
 * @lc app=leetcode id=965 lang=csharp
 *
 * [965] Univalued Binary Tree
 *
 * https://leetcode.com/problems/univalued-binary-tree/description/
 *
 * algorithms
 * Easy (67.41%)
 * Total Accepted:    26.8K
 * Total Submissions: 40K
 * Testcase Example:  '[1,1,1,1,1,null,1]'
 *
 * A binary tree is univalued if every node in the tree has the same value.
 * 
 * Return true if and only if the given tree is univalued.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,1,1,1,1,null,1]
 * Output: true
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [2,2,2,5,2]
 * Output: false
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The number of nodes in the given tree will be in the range [1, 100].
 * Each node's value will be an integer in the range [0, 99].
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
    public bool IsUnivalTree(TreeNode root)
    {
        if (root == null)
            return true;

        return IsSameVal(root, root.val);
    }

    private bool IsSameVal(TreeNode node, int val)
    {
        if (node == null)
            return true;

        if (node.val != val)
            return false;

        return IsSameVal(node.left, val) && IsSameVal(node.right, val);
    }
}

// √ Accepted
//   √ 72/72 cases passed (92 ms)
//   √ Your runtime beats 94.53 % of csharp submissions
//   √ Your memory usage beats 72.41 % of csharp submissions (22.2 MB)

