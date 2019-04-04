/*
 * @lc app=leetcode id=538 lang=csharp
 *
 * [538] Convert BST to Greater Tree
 *
 * https://leetcode.com/problems/convert-bst-to-greater-tree/description/
 *
 * algorithms
 * Easy (50.18%)
 * Total Accepted:    72.7K
 * Total Submissions: 144.5K
 * Testcase Example:  '[5,2,13]'
 *
 * Given a Binary Search Tree (BST), convert it to a Greater Tree such that
 * every key of the original BST is changed to the original key plus sum of all
 * keys greater than the original key in BST.
 * 
 * 
 * Example:
 * 
 * Input: The root of a Binary Search Tree like this:
 * ⁠             5
 * ⁠           /   \
 * ⁠          2     13
 * 
 * Output: The root of a Greater Tree like this:
 * ⁠            18
 * ⁠           /   \
 * ⁠         20     13
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
    private int greater = 0;
    public TreeNode ConvertBST(TreeNode root)
    {
        if (root == null)
            return null;

        ConvertBST(root.right);
        greater += root.val;
        root.val = greater;
        ConvertBST(root.left);


        //var right = ConvertBST(root.right);
        //if (right != null)
        //    root.val += right.val;
        
        //if (root.left != null)
        //{
        //    root.left.val += root.val;
        //    ConvertBST(root.left);
        //}

        return root;
    }
}

// √ Accepted
//   √ 212/212 cases passed (108 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (27.6 MB)

