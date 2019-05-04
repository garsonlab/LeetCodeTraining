/*
 * @lc app=leetcode id=450 lang=csharp
 *
 * [450] Delete Node in a BST

 Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Basically, the deletion can be divided into two stages:

Search for a node to remove.
If the node is found, delete the node.
Note: Time complexity should be O(height of tree).

Example:

root = [5,3,6,2,4,null,7]
key = 3

    5
   / \
  3   6
 / \   \
2   4   7

Given key to delete is 3. So we find the node with value 3 and delete it.

One valid answer is [5,4,6,2,null,null,7], shown in the following BST.

    5
   / \
  4   6
 /     \
2       7

Another valid answer is [5,2,6,null,4,null,7].

    5
   / \
  2   6
   \   \
    4   7
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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if(root == null)
            return null;
        
        if(root.val > key)
            root.left = DeleteNode(root.left, key);
        else if(root.val < key)
            root.right = DeleteNode(root.right, key);
        else
        {
            if(root.left == null)
                return root.right;
            if(root.right == null)
                return root.left;
            
            TreeNode rightMin = root.right;

            while (rightMin.left != null)
            {
                rightMin = rightMin.left;
            }

            root.val = rightMin.val;
            root.right = DeleteNode(root.right, root.val);
        }
        return root;
    }
}


// √ Accepted
//   √ 85/85 cases passed (124 ms)
//   √ Your runtime beats 46.96 % of csharp submissions
//   √ Your memory usage beats 72.22 % of csharp submissions (28.5 MB)

