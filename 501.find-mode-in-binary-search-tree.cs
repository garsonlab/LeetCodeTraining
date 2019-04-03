/*
 * @lc app=leetcode id=501 lang=csharp
 *
 * [501] Find Mode in Binary Search Tree
 *
 * https://leetcode.com/problems/find-mode-in-binary-search-tree/description/
 *
 * algorithms
 * Easy (39.04%)
 * Total Accepted:    53K
 * Total Submissions: 135.5K
 * Testcase Example:  '[1,null,2,2]'
 *
 * Given a binary search tree (BST) with duplicates, find all the mode(s) (the
 * most frequently occurred element) in the given BST.
 * 
 * Assume a BST is defined as follows:
 * 
 * 
 * The left subtree of a node contains only nodes with keys less than or equal
 * to the node's key.
 * The right subtree of a node contains only nodes with keys greater than or
 * equal to the node's key.
 * Both the left and right subtrees must also be binary search trees.
 * 
 * 
 * 
 * 
 * For example:
 * Given BST [1,null,2,2],
 * 
 * 
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  2
 * 
 * 
 * 
 * 
 * return [2].
 * 
 * Note: If a tree has more than one mode, you can return them in any order.
 * 
 * Follow up: Could you do that without using any extra space? (Assume that the
 * implicit stack space incurred due to recursion does not count).
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
    public int[] FindMode(TreeNode root)
    {
        List<int> list = new List<int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int max = 0;
        FindVal(root, ref max, dic, list);
        return list.ToArray();
    }


    private void FindVal(TreeNode node, ref int max, Dictionary<int, int> dic, List<int> list)
    {
        if(node == null)
            return;

        int n;
        if (!dic.TryGetValue(node.val, out n))
            n = 0;
        dic[node.val] = n + 1;

        if (n + 1 > max)
        {
            list.Clear();
            list.Add(node.val);
            max = n + 1;
        }
        else if(n+1 == max)
            list.Add(node.val);

        FindVal(node.left, ref max, dic, list);
        FindVal(node.right, ref max, dic, list);
    }
}

// √ Accepted
//   √ 25/25 cases passed (260 ms)
//   √ Your runtime beats 79.05 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (33 MB)

