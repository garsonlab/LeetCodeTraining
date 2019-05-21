/*
 * @lc app=leetcode id=958 lang=csharp
 *
 * [958] Check Completeness of a Binary Tree

 Given a binary tree, determine if it is a complete binary tree.

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

 

Example 1:



Input: [1,2,3,4,5,6]
Output: true
Explanation: Every level before the last is full (ie. levels with node-values {1} and {2, 3}), and all nodes in the last level ({4, 5, 6}) are as far left as possible.
Example 2:



Input: [1,2,3,4,5,null,7]
Output: false
Explanation: The node with value 7 isn't as far left as possible.
 
Note:

The tree will have between 1 and 100 nodes.
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
    public bool IsCompleteTree(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0 && queue.Peek() != null)
        {
            TreeNode node = queue.Dequeue();
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
        while (queue.Count > 0 && queue.Peek() == null)
        {
            queue.Dequeue();
        }
        return queue.Count == 0;
    }
}

// √ Accepted
//   √ 119/119 cases passed (112 ms)
//   √ Your runtime beats 24.6 % of csharp submissions
//   √ Your memory usage beats 37 % of csharp submissions (23.3 MB)

