/*
 * @lc app=leetcode id=872 lang=csharp
 *
 * [872] Leaf-Similar Trees
 *
 * https://leetcode.com/problems/leaf-similar-trees/description/
 *
 * algorithms
 * Easy (62.39%)
 * Total Accepted:    39.1K
 * Total Submissions: 62.5K
 * Testcase Example:  '[3,5,1,6,2,9,8,null,null,7,4]\n[3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]'
 *
 * Consider all the leaves of a binary tree.  From left to right order, the
 * values of those leaves form a leaf value sequence.
 * 
 * 
 * 
 * For example, in the given tree above, the leaf value sequence is (6, 7, 4,
 * 9, 8).
 * 
 * Two binary trees are considered leaf-similar if their leaf value sequence is
 * the same.
 * 
 * Return true if and only if the two given trees with head nodes root1 and
 * root2 are leaf-similar.
 * 
 * 
 * 
 * Note:
 * 
 * 
 * Both of the given trees will have between 1 and 100 nodes.
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        GetLeaf(root1, list1);
        GetLeaf(root2, list2);

        if (list1.Count != list2.Count)
            return false;
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }

        return true;
    }

    private void GetLeaf(TreeNode node, List<int> list)
    {
        if (node == null)
            return;

        if (node.left == null && node.right == null)
        {
            list.Add(node.val);
        }
        else
        {
            GetLeaf(node.left, list);
            GetLeaf(node.right, list);
        }
    }
}

// √ Accepted
//   √ 36/36 cases passed (92 ms)
//   √ Your runtime beats 96.89 % of csharp submissions
//   √ Your memory usage beats 6.67 % of csharp submissions (22.6 MB)

