/*
 * @lc app=leetcode id=94 lang=csharp
 *
 * [94] Binary Tree Inorder Traversal
 *
 * https://leetcode.com/problems/binary-tree-inorder-traversal/description/
 *
 * algorithms
 * Medium (55.89%)
 * Total Accepted:    438.7K
 * Total Submissions: 784K
 * Testcase Example:  '[1,null,2,3]'
 *
 * Given a binary tree, return the inorder traversal of its nodes' values.
 * 
 * Example:
 * 
 * 
 * Input: [1,null,2,3]
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  3
 * 
 * Output: [1,3,2]
 * 
 * Follow up: Recursive solution is trivial, could you do it iteratively?
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
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> list = new List<int>();

        if (root == null)
            return list;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        // stack.Push(root);
        // while (stack.Count > 0)
        // {
        //     var node = stack.Peek();
        //     if (node.left != null)
        //     {
        //         stack.Push(node.left);
        //         node.left = null;//有破坏性
        //     }
        //     else
        //     {
        //         node = stack.Pop();
        //         list.Add(node.val);
        //         if (node.right != null)
        //         {
        //             stack.Push(node.right);
        //             node.right = null;
        //         }
        //     }
        // }

        TreeNode node = root;

        while (node != null || stack.Count > 0)
        {
            if (node != null)
            {
                stack.Push(node);
                node = node.left;
            }
            else
            {
                node = stack.Pop();
                list.Add(node.val);
                node = node.right;
            }
        }

        return list;
    }
}

// √ Accepted
//   √ 68/68 cases passed (244 ms)
//   √ Your runtime beats 98.21 % of csharp submissions
//   √ Your memory usage beats 5.64 % of csharp submissions (28.2 MB)

