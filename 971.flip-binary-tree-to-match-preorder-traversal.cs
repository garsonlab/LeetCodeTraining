/*
 * @lc app=leetcode id=971 lang=csharp
 *
 * [971] Flip Binary Tree To Match Preorder Traversal

 Given a binary tree with N nodes, each node has a different value from {1, ..., N}.

A node in this binary tree can be flipped by swapping the left child and the right child of that node.

Consider the sequence of N values reported by a preorder traversal starting from the root.  Call such a sequence of N values the voyage of the tree.

(Recall that a preorder traversal of a node means we report the current node's value, then preorder-traverse the left child, then preorder-traverse the right child.)

Our goal is to flip the least number of nodes in the tree so that the voyage of the tree matches the voyage we are given.

If we can do so, then return a list of the values of all nodes flipped.  You may return the answer in any order.

If we cannot do so, then return the list [-1].

 

Example 1:



Input: root = [1,2], voyage = [2,1]
Output: [-1]
Example 2:



Input: root = [1,2,3], voyage = [1,3,2]
Output: [1]
Example 3:



Input: root = [1,2,3], voyage = [1,2,3]
Output: []
 

Note:

1 <= N <= 100
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
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage) {
        List<int> res = new List<int>();
        if (voyage.Length <= 1)
            return res;

        int idx = 0;
        if (!DFSFMV(res, root, voyage, ref idx))
        {
            res.Clear();
            res.Add(-1);
        }

        return res;
    }

    private bool DFSFMV(List<int> list, TreeNode node, int[] voyage, ref int idx)
    {
        if (node.val != voyage[idx++])
            return false;

        if (node.left != null && node.left.val != voyage[idx])
        {
            list.Add(node.val);

            var tem = node.left;
            node.left = node.right;
            node.right = tem;
        }

        if (node.left != null)
            if (!DFSFMV(list, node.left, voyage, ref idx))
                return false;
        if (node.right != null)
            if (!DFSFMV(list, node.right, voyage, ref idx))
                return false;
        return true;
    }
}

// √ Accepted
//   √ 96/96 cases passed (260 ms)
//   √ Your runtime beats 39.39 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (29 MB)

