/*
 * @lc app=leetcode id=897 lang=csharp
 *
 * [897] Increasing Order Search Tree
 *
 * https://leetcode.com/problems/increasing-order-search-tree/description/
 *
 * algorithms
 * Easy (63.40%)
 * Total Accepted:    25.8K
 * Total Submissions: 40.5K
 * Testcase Example:  '[5,3,6,2,4,null,8,1,null,null,null,7,9]'
 *
 * Given a tree, rearrange the tree in in-order so that the leftmost node in
 * the tree is now the root of the tree, and every node has no left child and
 * only 1 right child.
 * 
 * 
 * Example 1:
 * Input: [5,3,6,2,4,null,8,1,null,null,null,7,9]
 * 
 * ⁠      5
 * ⁠     / \
 * ⁠   3    6
 * ⁠  / \    \
 * ⁠ 2   4    8
 * /        / \ 
 * 1        7   9
 * 
 * Output: [1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]
 * 
 * ⁠1
 * \
 * 2
 * \
 * 3
 * \
 * 4
 * \
 * 5
 * \
 * 6
 * \
 * 7
 * \
 * 8
 * \
 * ⁠                9  
 * 
 * Note:
 * 
 * 
 * The number of nodes in the given tree will be between 1 and 100.
 * Each node will have a unique integer value from 0 to 1000.
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
    public TreeNode IncreasingBST(TreeNode root) {
        if (root == null)
            return null;

        List<TreeNode> list = new List<TreeNode>();
        GetNode(root, list);

        TreeNode r = null, cur = null;
        foreach (var node in list)
        {
            if (r == null)
            {
                r = node;
                cur = node;
            }
            else
            {
                cur.right = node;
                cur = node;
            }

            cur.left = null;
            cur.right = null;
        }

        return r;
    }

    
    private void GetNode(TreeNode node, List<TreeNode> list)
    {
        if (node == null)
            return;

        GetNode(node.left, list);
        list.Add(node);
        GetNode(node.right, list);
    }

}

// √ Accepted
//   √ 2156/2156 cases passed (124 ms)
//   √ Your runtime beats 94.27 % of csharp submissions
//   √ Your memory usage beats 42.86 % of csharp submissions (25.7 MB)

