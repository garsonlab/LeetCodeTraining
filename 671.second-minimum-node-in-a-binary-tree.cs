/*
 * @lc app=leetcode id=671 lang=csharp
 *
 * [671] Second Minimum Node In a Binary Tree
 *
 * https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/description/
 *
 * algorithms
 * Easy (43.51%)
 * Total Accepted:    44.7K
 * Total Submissions: 102.7K
 * Testcase Example:  '[2,2,5,null,null,5,7]'
 *
 * 
 * Given a non-empty special binary tree consisting of nodes with the
 * non-negative value, where each node in this tree has exactly two or zero
 * sub-node. If the node has two sub-nodes, then this node's value is the
 * smaller value among its two sub-nodes. 
 * 
 * 
 * 
 * Given such a binary tree, you need to output the second minimum value in the
 * set made of all the nodes' value in the whole tree. 
 * 
 * 
 * 
 * If no such second minimum value exists, output -1 instead.
 * 
 * 
 * Example 1:
 * 
 * Input: 
 * ⁠   2
 * ⁠  / \
 * ⁠ 2   5
 * ⁠    / \
 * ⁠   5   7
 * 
 * Output: 5
 * Explanation: The smallest value is 2, the second smallest value is 5.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: 
 * ⁠   2
 * ⁠  / \
 * ⁠ 2   2
 * 
 * Output: -1
 * Explanation: The smallest value is 2, but there isn't any second smallest
 * value.
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
    public int FindSecondMinimumValue(TreeNode root) {
        int min = root.val;
        int r = int.MaxValue;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node.val > min && node.val < r)
            {
                r = node.val;
            }
            if(node.left != null)
                queue.Enqueue(node.left);
            if(node.right != null)
                queue.Enqueue(node.right);
        }

        if(r == int.MaxValue)
            return -1;

        return r;
    }
}

// √ Accepted
//   √ 34/34 cases passed (108 ms)
//   √ Your runtime beats 57.41 % of csharp submissions
//   √ Your memory usage beats 81.82 % of csharp submissions (21.8 MB)

