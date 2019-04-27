/*
 * @lc app=leetcode id=230 lang=csharp
 *
 * [230] Kth Smallest Element in a BST

 Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

Note: 
You may assume k is always valid, 1 ≤ k ≤ BST's total elements.

Example 1:

Input: root = [3,1,4,null,2], k = 1
   3
  / \
 1   4
  \
   2
Output: 1
Example 2:

Input: root = [5,3,6,2,4,null,null,1], k = 3
       5
      / \
     3   6
    / \
   2   4
  /
 1
Output: 3
Follow up:
What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?
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
    int idx;
    public int KthSmallest(TreeNode root, int k) {
        idx = k;

        var n = GetKNode(root);
        return n != null? n.val : 0;
    }

    private TreeNode GetKNode(TreeNode node) {
        if(node == null)
            return null;
        
        var left = GetKNode(node.left);
        if(left != null)
            return left;

        if(--idx == 0)
            return node;

        return GetKNode(node.right);
    }
}

// √ Accepted
//   √ 91/91 cases passed (104 ms)
//   √ Your runtime beats 90.68 % of csharp submissions
//   √ Your memory usage beats 16 % of csharp submissions (26.2 MB)

