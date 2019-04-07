/*
 * @lc app=leetcode id=687 lang=csharp
 *
 * [687] Longest Univalue Path
 *
 * https://leetcode.com/problems/longest-univalue-path/description/
 *
 * algorithms
 * Easy (33.40%)
 * Total Accepted:    54.9K
 * Total Submissions: 164K
 * Testcase Example:  '[5,4,5,1,1,5]'
 *
 * Given a binary tree, find the length of the longest path where each node in
 * the path has the same value. This path may or may not pass through the
 * root.
 * 
 * Note: The length of path between two nodes is represented by the number of
 * edges between them.
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input:
 * 
 * ⁠             5
 * ⁠            / \
 * ⁠           4   5
 * ⁠          / \   \
 * ⁠         1   1   5
 * 
 * 
 * 
 * 
 * Output:
 * 
 * 2
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * 
 * Input:
 * 
 * ⁠             1
 * ⁠            / \
 * ⁠           4   5
 * ⁠          / \   \
 * ⁠         4   4   5
 * 
 * 
 * 
 * 
 * Output:
 * 
 * 2
 * 
 * 
 * 
 * Note:
 * The given binary tree has not more than 10000 nodes.  The height of the tree
 * is not more than 1000.
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
    private int maxSama = 0;
    public int LongestUnivaluePath(TreeNode root)
    {
        if(root == null)
            return 0;
        maxSama = 0;
        GetSameNum(root, root.val);
        return maxSama;
    }

    public int GetSameNum(TreeNode node, int val)
    {
        if (node == null)
            return 0;

        int left = GetSameNum(node.left, node.val);
        int right = GetSameNum(node.right, node.val);

        maxSama = Math.Max(maxSama, left + right);
        if (node.val == val)
            return 1 + Math.Max(left, right);
        return 0;
    }
}

// √ Accepted
//   √ 68/68 cases passed (192 ms)
//   √ Your runtime beats 50.56 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (42.9 MB)

