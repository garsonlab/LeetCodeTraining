/*
 * @lc app=leetcode id=653 lang=csharp
 *
 * [653] Two Sum IV - Input is a BST
 *
 * https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/
 *
 * algorithms
 * Easy (52.05%)
 * Total Accepted:    80.9K
 * Total Submissions: 155.1K
 * Testcase Example:  '[5,3,6,2,4,null,7]\n9'
 *
 * Given a Binary Search Tree and a target number, return true if there exist
 * two elements in the BST such that their sum is equal to the given target.
 * 
 * Example 1:
 * 
 * 
 * Input: 
 * ⁠   5
 * ⁠  / \
 * ⁠ 3   6
 * ⁠/ \   \
 * 2   4   7
 * 
 * Target = 9
 * 
 * Output: True
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 
 * ⁠   5
 * ⁠  / \
 * ⁠ 3   6
 * ⁠/ \   \
 * 2   4   7
 * 
 * Target = 28
 * 
 * Output: False
 * 
 * 
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
    public bool FindTarget(TreeNode root, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        return FindTarget2(root, k, dic);
    }

    private bool FindTarget2(TreeNode node, int k, Dictionary<int, int> dic)
    {
        if (node == null)
            return false;

        if (dic.ContainsKey(node.val))
            return true;
        dic[k - node.val] = 1;

        bool f = FindTarget2(node.left, k, dic);
        if (f)
            return true;
        return FindTarget2(node.right, k, dic);
    }
}

// √ Accepted
//   √ 421/421 cases passed (116 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 28 % of csharp submissions (28.3 MB)

