/*
 * @lc app=leetcode id=652 lang=csharp
 *
 * [652] Find Duplicate Subtrees

 Given a binary tree, return all duplicate subtrees. For each kind of duplicate subtrees, you only need to return the root node of any one of them.

Two trees are duplicate if they have the same structure with same node values.

Example 1:

1
       / \
      2   3
     /   / \
    4   2   4
       /
      4
The following are two duplicate subtrees:

2
     /
    4
and

4
Therefore, you need to return above trees' root in the form of a list.
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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        List<TreeNode> res = new List<TreeNode>();
        Dictionary<string, int> flag = new Dictionary<string, int>();
        DFSDup(root, res, flag);
        return res;
    }
    string DFSDup(TreeNode node, List<TreeNode> res, Dictionary<string, int> flag)
    {
        if (node == null) return "#";
        string left = DFSDup(node.left, res, flag);
        string right = DFSDup(node.right, res, flag);
        string cur = node.val + left + right;

        int n = 0;
        if (flag.TryGetValue(cur, out n))
        {
            if(n == 1)
                res.Add(node);
        }

        flag[cur] = n + 1;
        return cur;
    }
}

//后续遍历并记录
// √ Accepted
//   √ 168/168 cases passed (352 ms)
//   √ Your runtime beats 89.8 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (41.3 MB)

