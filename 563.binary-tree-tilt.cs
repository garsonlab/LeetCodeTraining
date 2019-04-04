/*
 * @lc app=leetcode id=563 lang=csharp
 *
 * [563] Binary Tree Tilt
 *
 * https://leetcode.com/problems/binary-tree-tilt/description/
 *
 * algorithms
 * Easy (46.85%)
 * Total Accepted:    48.3K
 * Total Submissions: 103.1K
 * Testcase Example:  '[1,2,3]'
 *
 * Given a binary tree, return the tilt of the whole tree.
 * 
 * The tilt of a tree node is defined as the absolute difference between the
 * sum of all left subtree node values and the sum of all right subtree node
 * values. Null node has tilt 0.
 * 
 * The tilt of the whole tree is defined as the sum of all nodes' tilt.
 * 
 * Example:
 * 
 * Input: 
 * ⁠        1
 * ⁠      /   \
 * ⁠     2     3
 * Output: 1
 * Explanation: 
 * Tilt of node 2 : 0
 * Tilt of node 3 : 0
 * Tilt of node 1 : |2-3| = 1
 * Tilt of binary tree : 0 + 0 + 1 = 1
 * 
 * 
 * 
 * Note:
 * 
 * The sum of node values in any subtree won't exceed the range of 32-bit
 * integer. 
 * All the tilt values won't exceed the range of 32-bit integer.
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
    private int tilt = 0;
    public int FindTilt(TreeNode root)
    {
        tilt = 0;
        GetTilt(root);
        return tilt;
    }

    private int GetTilt(TreeNode node)
    {
        if (node == null)
            return 0;

        int left = GetTilt(node.left);
        int right = GetTilt(node.right);

        tilt += Math.Abs(left - right);

        return left + right + node.val;
    }
}

// √ Accepted
//   √ 75/75 cases passed (100 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (26.3 MB)

