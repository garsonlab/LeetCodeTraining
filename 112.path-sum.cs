/*
 * @lc app=leetcode id=112 lang=csharp
 *
 * [112] Path Sum
 *
 * https://leetcode.com/problems/path-sum/description/
 *
 * algorithms
 * Easy (37.20%)
 * Total Accepted:    293.9K
 * Total Submissions: 789.4K
 * Testcase Example:  '[5,4,8,11,null,13,4,7,2,null,null,null,1]\n22'
 *
 * Given a binary tree and a sum, determine if the tree has a root-to-leaf path
 * such that adding up all the values along the path equals the given sum.
 * 
 * Note: A leaf is a node with no children.
 * 
 * Example:
 * 
 * Given the below binary tree and sum = 22,
 * 
 * 
 * ⁠     5
 * ⁠    / \
 * ⁠   4   8
 * ⁠  /   / \
 * ⁠ 11  13  4
 * ⁠/  \      \
 * 7    2      1
 * 
 * 
 * return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
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
    public bool HasPathSum(TreeNode root, int sum) {
        if (root == null)
        {
            return false;
        }

        if (root.left == null && root.right == null && root.val == sum)
            return true;

        // if (sum <= root.val)
        //     return false;
        bool left = HasPathSum(root.left, sum - root.val);
        if (left)
            return true;
        bool right = HasPathSum(root.right, sum - root.val);
        return right;
    }
}

// √ Accepted
//   √ 114/114 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 27.08 % of csharp submissions (24.1 MB)

