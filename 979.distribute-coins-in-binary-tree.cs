/*
 * @lc app=leetcode id=979 lang=csharp
 *
 * [979] Distribute Coins in Binary Tree
 Given the root of a binary tree with N nodes, each node in the tree has node.val coins, and there are N coins total.

In one move, we may choose two adjacent nodes and move one coin from one node to another.  (The move may be from parent to child, or from child to parent.)

Return the number of moves required to make every node have exactly one coin.

 

Example 1:



Input: [3,0,0]
Output: 2
Explanation: From the root of the tree, we move one coin to its left child, and one coin to its right child.
Example 2:



Input: [0,3,0]
Output: 3
Explanation: From the left child of the root, we move two coins to the root [taking two moves].  Then, we move one coin from the root of the tree to the right child.
Example 3:



Input: [1,0,2]
Output: 2
Example 4:



Input: [1,0,0,null,3]
Output: 4
 

Note:

1<= N <= 100
0 <= node.val <= N
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
    public int DistributeCoins(TreeNode root) {
        if (root == null)
            return 0;
        int res = 0;
        GetCStep(root, ref res);
        return res;
    }

    private int GetCStep(TreeNode node, ref int step)
    {
        if (node == null)
            return 0;

        int left = GetCStep(node.left, ref step);
        int right = GetCStep(node.right, ref step);
        int v = node.val + left + right - 1;

        step += Math.Abs(v);
        return v;
    }
}


// √ Accepted
//   √ 148/148 cases passed (100 ms)
//   √ Your runtime beats 46.76 % of csharp submissions
//   √ Your memory usage beats 18.85 % of csharp submissions (23.4 MB)
