/*
 * @lc app=leetcode id=100 lang=csharp
 *
 * [100] Same Tree
 *
 * https://leetcode.com/problems/same-tree/description/
 *
 * algorithms
 * Easy (49.56%)
 * Total Accepted:    357.2K
 * Total Submissions: 720.5K
 * Testcase Example:  '[1,2,3]\n[1,2,3]'
 *
 * Given two binary trees, write a function to check if they are the same or
 * not.
 * 
 * Two binary trees are considered the same if they are structurally identical
 * and the nodes have the same value.
 * 
 * Example 1:
 * 
 * 
 * Input:     1         1
 * ⁠         / \       / \
 * ⁠        2   3     2   3
 * 
 * ⁠       [1,2,3],   [1,2,3]
 * 
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input:     1         1
 * ⁠         /           \
 * ⁠        2             2
 * 
 * ⁠       [1,2],     [1,null,2]
 * 
 * Output: false
 * 
 * 
 * Example 3:
 * 
 * 
 * Input:     1         1
 * ⁠         / \       / \
 * ⁠        2   1     1   2
 * 
 * ⁠       [1,2,1],   [1,1,2]
 * 
 * Output: false
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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        
        if ((p == null && q != null) || (p != null && q == null))
        {
            return false;
        }
        if(p == null && q == null)
            return true;

        if (!IsSameTree(p.left, q.left))
        {
            return false;
        }
        if (!IsSameTree(p.right, q.right))
        {
            return false;
        }

        return p.val == q.val;
    }
}

// √ Accepted
//   √ 57/57 cases passed (152 ms)
//   √ Your runtime beats 5.96 % of csharp submissions
//   √ Your memory usage beats 94.12 % of csharp submissions (22 MB)

