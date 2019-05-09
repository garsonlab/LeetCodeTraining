/*
 * @lc app=leetcode id=623 lang=csharp
 *
 * [623] Add One Row to Tree

 Given the root of a binary tree, then value v and depth d, you need to add a row of nodes with value v at the given depth d. The root node is at depth 1.

The adding rule is: given a positive integer depth d, for each NOT null tree nodes N in depth d-1, create two tree nodes with value v as N's left subtree root and right subtree root. And N's original left subtree should be the left subtree of the new left subtree root, its original right subtree should be the right subtree of the new right subtree root. If depth d is 1 that means there is no depth d-1 at all, then create a tree node with value v as the new root of the whole original tree, and the original tree is the new root's left subtree.

Example 1:
Input: 
A binary tree as following:
       4
     /   \
    2     6
   / \   / 
  3   1 5   

v = 1

d = 2

Output: 
       4
      / \
     1   1
    /     \
   2       6
  / \     / 
 3   1   5
Example 2:
Input: 
A binary tree as following:
      4
     /   
    2    
   / \   
  3   1    

v = 1

d = 3

Output: 
      4
     /   
    2
   / \    
  1   1
 /     \  
3       1
Note:
The given d is in range [1, maximum depth of the given tree + 1].
The given binary tree has at least one tree node.
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
    public TreeNode AddOneRow(TreeNode root, int v, int d) {
        if (root == null || d == 0)
            return root;
        
        if (d == 1)
        {
            TreeNode n1 = new TreeNode(v);
            n1.left = root;
            return n1;
        }
        else
            RowDFS(root, v, d);
        
        return root;
    }

    private void RowDFS(TreeNode node, int v, int d)
    {
        if(node == null)
            return;
        d--;
        if (d == 1)
        {
            TreeNode n1 = new TreeNode(v);
            n1.left = node.left;
            node.left = n1;

            TreeNode n2 = new TreeNode(v);
            n2.right = node.right;
            node.right = n2;
        }
        else
        {
            RowDFS(node.left, v, d);
            RowDFS(node.right, v, d);
        }
    }
}


// √ Accepted
//   √ 109/109 cases passed (124 ms)
//   √ Your runtime beats 13.75 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (25 MB)
