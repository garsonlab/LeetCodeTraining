/*
 * @lc app=leetcode id=113 lang=csharp
 *
 * [113] Path Sum II
 *
 * https://leetcode.com/problems/path-sum-ii/description/
 *
 * algorithms
 * Medium (40.05%)
 * Total Accepted:    223.5K
 * Total Submissions: 557K
 * Testcase Example:  '[5,4,8,11,null,13,4,7,2,null,null,5,1]\n22'
 *
 * Given a binary tree and a sum, find all root-to-leaf paths where each path's
 * sum equals the given sum.
 * 
 * Note: A leaf is a node with no children.
 * 
 * Example:
 * 
 * Given the below binary tree and sum = 22,
 * 
 * 
 * ⁠     5
 * ⁠    / \
 * ⁠   4   8
 * ⁠  /   / \
 * ⁠ 11  13  4
 * ⁠/  \    / \
 * 7    2  5   1
 * 
 * 
 * Return:
 * 
 * 
 * [
 * ⁠  [5,4,11,2],
 * ⁠  [5,8,4,5]
 * ]
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
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        IList<IList<int>> list = new List<IList<int>>();
        if (root == null)
            return list;

        GetSum(list, root, new List<int>(), sum);
        return list;
    }

    private void GetSum(IList<IList<int>> list, TreeNode node, List<int> cur, int target)
    {
        cur.Add(node.val);
        target -= node.val;

        if (node.left == null && node.right == null)
        {
            if(target == 0)
                list.Add(cur);
        }
        else
        {
            if (node.left != null)
            {
                var tem = new List<int>(cur);
                GetSum(list, node.left, tem, target);
            }

            if (node.right != null)
            {
                var tem = new List<int>(cur);
                GetSum(list, node.right, tem, target);
            }
        }
    }

}

// √ Accepted
//   √ 114/114 cases passed (260 ms)
//   √ Your runtime beats 76.8 % of csharp submissions
//   √ Your memory usage beats 5.09 % of csharp submissions (33.9 MB)

