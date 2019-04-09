/*
 * @lc app=leetcode id=783 lang=csharp
 *
 * [783] Minimum Distance Between BST Nodes
 *
 * https://leetcode.com/problems/minimum-distance-between-bst-nodes/description/
 *
 * algorithms
 * Easy (49.99%)
 * Total Accepted:    29.7K
 * Total Submissions: 59.3K
 * Testcase Example:  '[4,2,6,1,3,null,null]'
 *
 * Given a Binary Search Tree (BST) with the root node root, return the minimum
 * difference between the values of any two different nodes in the tree.
 * 
 * Example :
 * 
 * 
 * Input: root = [4,2,6,1,3,null,null]
 * Output: 1
 * Explanation:
 * Note that root is a TreeNode object, not an array.
 * 
 * The given tree [4,2,6,1,3,null,null] is represented by the following
 * diagram:
 * 
 * ⁠         4
 * ⁠       /   \
 * ⁠     2      6
 * ⁠    / \    
 * ⁠   1   3  
 * 
 * while the minimum difference in this tree is 1, it occurs between node 1 and
 * node 2, also between node 3 and node 2.
 * 
 * 
 * Note:
 * 
 * 
 * The size of the BST will be between 2 and 100.
 * The BST is always valid, each node's value is an integer, and each node's
 * value is different.
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
    public int MinDiffInBST(TreeNode root)
    {
        List<int> list = new List<int>();
        int min = int.MaxValue;

        GetOrderMin(root, list, ref min);
        return min;
    }

    private void GetOrderMin(TreeNode node, List<int> list, ref int min)
    {
        if (node == null)
            return;

        for (int i = 0; i < list.Count; i++)
        {
            min = Math.Min(Math.Abs(list[i] - node.val), min);
        }
        list.Add(node.val);

        GetOrderMin(node.left, list, ref min);
        GetOrderMin(node.right, list, ref min);
    }
}

// √ Accepted
//   √ 45/45 cases passed (92 ms)
//   √ Your runtime beats 99.21 % of csharp submissions
//   √ Your memory usage beats 78.57 % of csharp submissions (22.1 MB)

