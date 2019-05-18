/*
 * @lc app=leetcode id=865 lang=csharp
 *
 * [865] Smallest Subtree with all the Deepest Nodes

 Given a binary tree rooted at root, the depth of each node is the shortest distance to the root.

A node is deepest if it has the largest depth possible among any node in the entire tree.

The subtree of a node is that node, plus the set of all descendants of that node.

Return the node with the largest depth such that it contains all the deepest nodes in its subtree.

 

Example 1:

Input: [3,5,1,6,2,0,8,null,null,7,4]
Output: [2,7,4]
Explanation:



We return the node with value 2, colored in yellow in the diagram.
The nodes colored in blue are the deepest nodes of the tree.
The input "[3, 5, 1, 6, 2, 0, 8, null, null, 7, 4]" is a serialization of the given tree.
The output "[2, 7, 4]" is a serialization of the subtree rooted at the node with value 2.
Both the input and output have TreeNode type.
 

Note:

The number of nodes in the tree will be between 1 and 500.
The values of each node are unique.
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
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        if(root == null)
            return root;

        int left = GetDep(root.left);
        int right = GetDep(root.right);
        if(left == right)
            return root;
        
        return left>right? SubtreeWithAllDeepest(root.left) : SubtreeWithAllDeepest(root.right);
    }

    private int GetDep(TreeNode node) {
        if(node == null)
            return 0;
        return 1 + Math.Max(GetDep(node.left), GetDep(node.right));
    }


    public TreeNode SubtreeWithAllDeepest_Err(TreeNode root) {
        TreeNode depNode = root;
        int max = 1;
        GetDepNode(root, ref depNode, 1, ref max);

        return depNode;
    }

    private void GetDepNode(TreeNode node, ref TreeNode depNode, int cur, ref int max) {
        if(node == null)
            return;
        ++cur;
        
        if(node.left != null || node.right != null) {
            if(cur >= max) {
                depNode = node;
                max = cur;
            }
        }

        GetDepNode(node.left, ref depNode, cur, ref max);
        GetDepNode(node.right, ref depNode, cur, ref max);
    }
}

// √ Accepted
//   √ 57/57 cases passed (92 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 53.57 % of csharp submissions (22.6 MB)

