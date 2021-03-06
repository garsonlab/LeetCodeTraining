/*
 * @lc app=leetcode id=701 lang=csharp
 *
 * [701] Insert into a Binary Search Tree

 Given the root node of a binary search tree (BST) and a value to be inserted into the tree, insert the value into the BST. Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.

Note that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

For example, 

Given the tree:
        4
       / \
      2   7
     / \
    1   3
And the value to insert: 5
You can return this binary search tree:

4
       /   \
      2     7
     / \   /
    1   3 5
This tree is also valid:

5
       /   \
      2     7
     / \   
    1   3
         \
          4
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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null)
            return new TreeNode(val);
        if (val < root.val)
            root.left = InsertIntoBST(root.left, val);
        else
            root.right = InsertIntoBST(root.right, val);
        return root;
    }
}

// √ Accepted
//   √ 34/34 cases passed (144 ms)
//   √ Your runtime beats 46.38 % of csharp submissions
//   √ Your memory usage beats 25.64 % of csharp submissions (36.5 MB)

