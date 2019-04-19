/*
 * @lc app=leetcode id=144 lang=csharp
 *
 * [144] Binary Tree Preorder Traversal
 *
 * https://leetcode.com/problems/binary-tree-preorder-traversal/description/
 *
 * algorithms
 * Medium (50.83%)
 * Total Accepted:    324.2K
 * Total Submissions: 637K
 * Testcase Example:  '[1,null,2,3]'
 *
 * Given a binary tree, return the preorder traversal of its nodes' values.
 * 
 * Example:
 * 
 * 
 * Input: [1,null,2,3]
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  3
 * 
 * Output: [1,2,3]
 * 
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
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> list = new List<int>();
        if (root == null)
            return list;

        TreeNode pre = root;
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while (pre!=null || stack.Count > 0)
        {
            if (pre != null)
            {
                while (pre != null)
                {
                    stack.Push(pre);
                    list.Add(pre.val);
                    pre = pre.left;
                }
            }
            else
            {
                var tem = stack.Pop();
                pre = tem.right;
            }
        }
        
        return list;
    }
}

// √ Accepted
//   √ 68/68 cases passed (248 ms)
//   √ Your runtime beats 75.36 % of csharp submissions
//   √ Your memory usage beats 48.91 % of csharp submissions (28 MB)
