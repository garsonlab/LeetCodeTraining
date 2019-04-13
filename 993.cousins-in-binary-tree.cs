/*
 * @lc app=leetcode id=993 lang=csharp
 *
 * [993] Cousins in Binary Tree
 *
 * https://leetcode.com/problems/cousins-in-binary-tree/description/
 *
 * algorithms
 * Easy (53.07%)
 * Total Accepted:    11.5K
 * Total Submissions: 21.9K
 * Testcase Example:  '[1,2,3,4]\n4\n3'
 *
 * In a binary tree, the root node is at depth 0, and children of each depth k
 * node are at depth k+1.
 * 
 * Two nodes of a binary tree are cousins if they have the same depth, but have
 * different parents.
 * 
 * We are given the root of a binary tree with unique values, and the values x
 * and y of two different nodes in the tree.
 * 
 * Return true if and only if the nodes corresponding to the values x and y are
 * cousins.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * Input: root = [1,2,3,4], x = 4, y = 3
 * Output: false
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * 
 * Input: root = [1,2,3,null,4,null,5], x = 5, y = 4
 * Output: true
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * 
 * 
 * Input: root = [1,2,3,null,4], x = 2, y = 3
 * Output: false
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The number of nodes in the tree will be between 2 and 100.
 * Each node has a unique integer value from 1 to 100.
 * 
 * 
 * 
 * 
 * 
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
    private int xDep, yDep;
    public bool IsCousins(TreeNode root, int x, int y)
    {
        xDep = 0;
        yDep = 0;
        GetDepth(root, 0, x, y);

        return xDep > 0 && yDep > 0 && xDep == yDep;
    }

    private void GetDepth(TreeNode node, int lv, int x, int y)
    {
        if (node == null)
            return;

        if (node.val == x)
            xDep = lv + 1;
        if (node.val == y)
            yDep = lv + 1;

        if (node.left != null && node.right != null)
        {
            if ((node.left.val == x && node.right.val == y)
                || (node.left.val == y && node.right.val == x))
            {
                xDep = -1;
                yDep = -1;
                return;
            }
        }
        GetDepth(node.left, lv+1, x, y);
        GetDepth(node.right, lv + 1, x, y);
    }
}

// √ Accepted
//   √ 103/103 cases passed (92 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 11.11 % of csharp submissions (22.7 MB)

