/*
 * @lc app=leetcode id=110 lang=csharp
 *
 * [110] Balanced Binary Tree
 *
 * https://leetcode.com/problems/balanced-binary-tree/description/
 *
 * algorithms
 * Easy (40.50%)
 * Total Accepted:    301.9K
 * Total Submissions: 745K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Given a binary tree, determine if it is height-balanced.
 * 
 * For this problem, a height-balanced binary tree is defined as:
 * 
 * 
 * a binary tree in which the depth of the two subtrees of every node never
 * differ by more than 1.
 * 
 * 
 * Example 1:
 * 
 * Given the following tree [3,9,20,null,null,15,7]:
 * 
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * Return true.
 * 
 * Example 2:
 * 
 * Given the following tree [1,2,2,3,3,null,null,4,4]:
 * 
 * 
 * ⁠      1
 * ⁠     / \
 * ⁠    2   2
 * ⁠   / \
 * ⁠  3   3
 * ⁠ / \
 * ⁠4   4
 * 
 * 
 * Return false.
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
    public bool IsBalanced(TreeNode root) {
        if (root == null)
        {
            return true;
        }

        return GetDep(root) >= 0;
    }

    public int GetDep(TreeNode node)
    {
        if (node == null)
            return 0;

        int left = GetDep(node.left);
        int right = GetDep(node.right);

        if (left < 0 || right < 0 || Math.Abs(left-right) > 1)
            return -1;

        return 1 + Math.Max(left, right);
    }
}

// √ Accepted
//   √ 227/227 cases passed (100 ms)
//   √ Your runtime beats 92.86 % of csharp submissions
//   √ Your memory usage beats 37.14 % of csharp submissions (25.3 MB)

