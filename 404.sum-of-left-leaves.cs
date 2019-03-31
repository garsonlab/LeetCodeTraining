/*
 * @lc app=leetcode id=404 lang=csharp
 *
 * [404] Sum of Left Leaves
 *
 * https://leetcode.com/problems/sum-of-left-leaves/description/
 *
 * algorithms
 * Easy (48.76%)
 * Total Accepted:    119.6K
 * Total Submissions: 245K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * Find the sum of all left leaves in a given binary tree.
 * 
 * Example:
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * There are two left leaves in the binary tree, with values 9 and 15
 * respectively. Return 24.
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
    public int SumOfLeftLeaves(TreeNode root) {
        return GetLeft(root, false);
    }

    private int GetLeft(TreeNode node, bool isLeft){
        if(node == null)
            return 0;
        
        if(isLeft && node.left == null && node.right == null)
            return node.val;
        
        return GetLeft(node.left, true) + GetLeft(node.right, false);
    }
}

// √ Accepted
//   √ 102/102 cases passed (92 ms)
//   √ Your runtime beats 99.46 % of csharp submissions
//   √ Your memory usage beats 95 % of csharp submissions (22.3 MB)

