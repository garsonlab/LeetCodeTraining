/*
 * @lc app=leetcode id=1008 lang=csharp
 *
 * [1008] Construct Binary Search Tree from Preorder Traversal

 Return the root node of a binary search tree that matches the given preorder traversal.

(Recall that a binary search tree is a binary tree where for every node, any descendant of node.left has a value < node.val, and any descendant of node.right has a value > node.val.  Also recall that a preorder traversal displays the value of the node first, then traverses node.left, then traverses node.right.)

 

Example 1:

Input: [8,5,1,7,10,12]
Output: [8,5,10,1,7,null,12]

 

Note: 

1 <= preorder.length <= 100
The values of preorder are distinct.
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
    public TreeNode BstFromPreorder(int[] preorder) {
        if (preorder.Length == 0)
            return null;
        return BFPC(preorder, 0, preorder.Length - 1);
    }

    private TreeNode BFPC(int[] preorder, int l, int r)
    {
        if (l > r)
            return null;
        TreeNode node = new TreeNode(preorder[l]);

        int ri = -1;
        for (int i = l+1; i <= r; i++)
        {
            if (preorder[i] >= preorder[l])
            {
                ri = i;
                break;
            }
        }

        if (ri > 0)
        {
            node.left = BFPC(preorder, l + 1, ri - 1);
            node.right = BFPC(preorder, ri, r);
        }
        else
        {
            node.left = BFPC(preorder, l + 1, r);
        }

        return node;
    }

}


// √ Accepted
//   √ 110/110 cases passed (100 ms)
//   √ Your runtime beats 22.05 % of csharp submissions
//   √ Your memory usage beats 18.7 % of csharp submissions (22.6 MB)

