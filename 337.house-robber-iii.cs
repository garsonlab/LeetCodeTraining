/*
 * @lc app=leetcode id=337 lang=csharp
 *
 * [337] House Robber III

 The thief has found himself a new place for his thievery again. There is only one entrance to this area, called the "root." Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that "all houses in this place forms a binary tree". It will automatically contact the police if two directly-linked houses were broken into on the same night.

Determine the maximum amount of money the thief can rob tonight without alerting the police.

Example 1:

Input: [3,2,3,null,3,null,1]

     3
    / \
   2   3
    \   \ 
     3   1

Output: 7 
Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.
Example 2:

Input: [3,4,5,1,3,null,1]

     3
    / \
   4   5
  / \   \ 
 1   3   1

Output: 9
Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.
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
    public int Rob(TreeNode root) {
        if (root == null)
            return 0;

        int left = Rob(root.left);
        int right = Rob(root.right);
        int leftSon = root.left != null ? Rob(root.left.left)+ Rob(root.left.right) : 0;
        int rightSon = root.right != null ? Rob(root.right.left) + Rob(root.right.right) : 0;

        return Math.Max(root.val + leftSon + rightSon, left + right);
    }
}

// √ Accepted
//   √ 124/124 cases passed (1260 ms)
//   √ Your runtime beats 23.08 % of csharp submissions
//   √ Your memory usage beats 66.67 % of csharp submissions (24.2 MB)

