/*
 * @lc app=leetcode id=101 lang=csharp
 *
 * [101] Symmetric Tree
 *
 * https://leetcode.com/problems/symmetric-tree/description/
 *
 * algorithms
 * Easy (42.90%)
 * Total Accepted:    371.2K
 * Total Submissions: 865K
 * Testcase Example:  '[1,2,2,3,4,4,3]'
 *
 * Given a binary tree, check whether it is a mirror of itself (ie, symmetric
 * around its center).
 * 
 * 
 * For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   2
 * ⁠/ \ / \
 * 3  4 4  3
 * 
 * 
 * 
 * But the following [1,2,2,null,3,null,3]  is not:
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   2
 * ⁠  \   \
 * ⁠  3    3
 * 
 * 
 * 
 * 
 * Note:
 * Bonus points if you could solve it both recursively and iteratively.
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
    public bool IsSymmetric(TreeNode root) {
        
        if (root == null || (root.left == null && root.right == null))
            return true;

        List<TreeNode> nodes = new List<TreeNode>();
        nodes.Add(root.left);
        nodes.Add(root.right);

        while (nodes.Count > 0)
        {
            int count = nodes.Count;
            for (int i = 0, j = count - 1; i < j; i++, j--)
            {
                if ((nodes[i]==null && nodes[j] == null)
                    || (nodes[i] != null && nodes[j] != null && nodes[i].val == nodes[j].val))
                {}
                else
                {
                    return false;
                }
            }

            while (count > 0)
            {
                if (nodes[0] != null)
                {
                    nodes.Add(nodes[0].left);
                    nodes.Add(nodes[0].right);
                }
                nodes.RemoveAt(0);

                count--;
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 193/193 cases passed (92 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 79.31 % of csharp submissions (23 MB)

