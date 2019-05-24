/*
 * @lc app=leetcode id=1026 lang=csharp
 *
 * [1026] Maximum Difference Between Node and Ancestor

 Given the root of a binary tree, find the maximum value V for which there exists different nodes A and B where V = |A.val - B.val| and A is an ancestor of B.

(A node A is an ancestor of B if either: any child of A is equal to B, or any child of A is an ancestor of B.)

 

Example 1:



Input: [8,3,10,1,6,null,14,null,null,4,7,13]
Output: 7
Explanation: 
We have various ancestor-node differences, some of which are given below :
|8 - 3| = 5
|3 - 7| = 4
|8 - 1| = 7
|10 - 13| = 3
Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.
 

Note:

The number of nodes in the tree is between 2 and 5000.
Each node will have value between 0 and 100000.
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
    public int MaxAncestorDiff(TreeNode root) {
        int res = 0;
        DFSMAD(root, ref res, root.val, root.val);
        return res;
    }

    private void DFSMAD(TreeNode node, ref int res, int min, int max)
    {
        if (node == null)
            return;

        res = Math.Max(res, Math.Abs(node.val - min));
        res = Math.Max(res, Math.Abs(node.val - max));

        min = Math.Min(min, node.val);
        max = Math.Max(max, node.val);

        DFSMAD(node.left, ref res, min, max);
        DFSMAD(node.right, ref res, min, max);
    }

}


// √ Accepted
//   √ 27/27 cases passed (96 ms)
//   √ Your runtime beats 52.81 % of csharp submissions
//   √ Your memory usage beats 39.61 % of csharp submissions (23.1 MB)

