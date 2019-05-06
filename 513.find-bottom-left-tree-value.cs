/*
 * @lc app=leetcode id=513 lang=csharp
 *
 * [513] Find Bottom Left Tree Value

 Given a binary tree, find the leftmost value in the last row of the tree.

Example 1:
Input:

    2
   / \
  1   3

Output:
1
Example 2: 
Input:

        1
       / \
      2   3
     /   / \
    4   5   6
       /
      7

Output:
7
Note: You may assume the tree (i.e., the given root node) is not NULL.
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
    public int FindBottomLeftValue(TreeNode root) {
        List<TreeNode> floor = new List<TreeNode>();
        List<TreeNode> tem = new List<TreeNode>();

        floor.Add(root);

        while (floor.Count > 0)
        {
            foreach (var node in floor)
            {
                if(node.left != null)
                    tem.Add(node.left);
                if(node.right != null)
                    tem.Add(node.right);
            }

            if (tem.Count == 0)
                return floor[0].val;

            floor.Clear();
            floor.AddRange(tem);
            tem.Clear();
        }

        return -1;
    }
}

// √ Accepted
//   √ 74/74 cases passed (116 ms)
//   √ Your runtime beats 29.37 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (24.2 MB)

