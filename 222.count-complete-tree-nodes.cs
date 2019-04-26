/*
 * @lc app=leetcode id=222 lang=csharp
 *
 * [222] Count Complete Tree Nodes

    Given a complete binary tree, count the number of nodes.

    Note:

    Definition of a complete binary tree from Wikipedia:
    In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

    Example:

    Input: 
        1
    / \
    2   3
    / \  /
    4  5 6

    Output: 6

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
    public int CountNodes(TreeNode root)
    {
        if (root == null)
            return 0;
        
        int leftDepth = 1;//最左边的叶子结点深度
        int rightDepth = 1;//最右边的叶子结点的深度
        TreeNode tmp = root;
        while (tmp.left != null)
        {
            leftDepth++;
            tmp = tmp.left;
        }
        tmp = root;
        while (tmp.right != null)
        {
            rightDepth++;
            tmp = tmp.right;
        }
        if (leftDepth == rightDepth)  //是满二叉树
            return (1 << leftDepth) - 1;
        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }


    public int CountNodes22(TreeNode root) {
        if (root == null)
            return 0;

        int ret = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var n = queue.Dequeue();
            ret++;

            if(n.left != null)
                queue.Enqueue(n.left);
            if(n.right != null)
                queue.Enqueue(n.right);
        }

        return ret;
    }
    
}

// √ Accepted
//   √ 18/18 cases passed (128 ms)
//   √ Your runtime beats 29.57 % of csharp submissions
//   √ Your memory usage beats 65 % of csharp submissions (30.6 MB)

// √ Accepted
//   √ 18/18 cases passed (116 ms)
//   √ Your runtime beats 40.86 % of csharp submissions
//   √ Your memory usage beats 5 % of csharp submissions (31.5 MB)

