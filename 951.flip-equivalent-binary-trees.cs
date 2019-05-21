/*
 * @lc app=leetcode id=951 lang=csharp
 *
 * [951] Flip Equivalent Binary Trees

 For a binary tree T, we can define a flip operation as follows: choose any node, and swap the left and right child subtrees.

A binary tree X is flip equivalent to a binary tree Y if and only if we can make X equal to Y after some number of flip operations.

Write a function that determines whether two binary trees are flip equivalent.  The trees are given by root nodes root1 and root2.

 

Example 1:

Input: root1 = [1,2,3,4,5,6,null,null,null,7,8], root2 = [1,3,2,null,6,4,5,null,null,null,null,8,7]
Output: true
Explanation: We flipped at nodes with values 1, 3, and 5.
Flipped Trees Diagram
 

Note:

Each tree will have at most 100 nodes.
Each value in each tree will be a unique integer in the range [0, 99].
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
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        if (root1 == null && root2 == null)
            return true;
        if (root1 == null || root2 == null)
            return false;
        if (root1.val != root2.val)
            return false;

        if (root1.left == null && root2.left == null)
        {
            //左同时为空
        }
        else if (root1.left != null && root2.left != null && root1.left.val == root2.left.val)
        {
            //左都不为空且不等
        }
        else
        {
            var tem = root1.left;
            root1.left = root1.right;
            root1.right = tem;
        }

        return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right);
    }
}

// √ Accepted
//   √ 72/72 cases passed (100 ms)
//   √ Your runtime beats 38.04 % of csharp submissions
//   √ Your memory usage beats 26.09 % of csharp submissions (22.7 MB)

