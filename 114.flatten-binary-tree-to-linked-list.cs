/*
 * @lc app=leetcode id=114 lang=csharp
 *
 * [114] Flatten Binary Tree to Linked List
 *
 * https://leetcode.com/problems/flatten-binary-tree-to-linked-list/description/
 *
 * algorithms
 * Medium (41.76%)
 * Total Accepted:    229.8K
 * Total Submissions: 549.5K
 * Testcase Example:  '[1,2,5,3,4,null,6]'
 *
 * Given a binary tree, flatten it to a linked list in-place.
 * 
 * For example, given the following tree:
 * 
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   5
 * ⁠/ \   \
 * 3   4   6
 * 
 * 
 * The flattened tree should look like:
 * 
 * 
 * 1
 * ⁠\
 * ⁠ 2
 * ⁠  \
 * ⁠   3
 * ⁠    \
 * ⁠     4
 * ⁠      \
 * ⁠       5
 * ⁠        \
 * ⁠         6
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
    private TreeNode pre;
    public void Flatten(TreeNode root)
    {
        if(root == null)
            return;

        var left = root.left;
        var right = root.right;
        root.left = null;
        root.right = null;
        
        if (pre == null)
        {
            pre = root;
        }
        else
        {
            pre.right = root;
            pre = root;
        }

        if(left != null)
            Flatten(left);
        if(right != null)
            Flatten(right);

    }
}

// √ Accepted
//   √ 225/225 cases passed (96 ms)
//   √ Your runtime beats 93.87 % of csharp submissions
//   √ Your memory usage beats 44.44 % of csharp submissions (23.2 MB)

