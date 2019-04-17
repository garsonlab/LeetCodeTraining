/*
 * @lc app=leetcode id=95 lang=csharp
 *
 * [95] Unique Binary Search Trees II
 *
 * https://leetcode.com/problems/unique-binary-search-trees-ii/description/
 *
 * algorithms
 * Medium (35.23%)
 * Total Accepted:    133.8K
 * Total Submissions: 379.4K
 * Testcase Example:  '3'
 *
 * Given an integer n, generate all structurally unique BST's (binary search
 * trees) that store values 1 ... n.
 * 
 * Example:
 * 
 * 
 * Input: 3
 * Output:
 * [
 * [1,null,3,2],
 * [3,2,null,1],
 * [3,1,null,null,2],
 * [2,1,3],
 * [1,null,2,null,3]
 * ]
 * Explanation:
 * The above output corresponds to the 5 unique BST's shown below:
 * 
 * ⁠  1         3     3      2      1
 * ⁠   \       /     /      / \      \
 * ⁠    3     2     1      1   3      2
 * ⁠   /     /       \                 \
 * ⁠  2     1         2                 3
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
   
    public IList<TreeNode> GenerateTrees(int n)
    {
        if (n == 0)
            return new List<TreeNode>();

        return GenegrateTree(1, n);
    }

    private List<TreeNode> GenegrateTree(int left, int right)
    {
        List <TreeNode> res = new List<TreeNode>();
        if (left > right)
        {
            res.Add(null);
            return res;
        }

        for (int i = left; i <= right; i++)
        {
            var leftList = GenegrateTree(left, i - 1);
            var rightList = GenegrateTree(i + 1, right);

            foreach (var leftNode in leftList)
            {
                foreach (var rightNode in rightList)
                {
                    TreeNode root = new TreeNode(i);
                    root.left = leftNode;
                    root.right = rightNode;
                    res.Add(root);
                }
            }
        }

        return res;
    }

}

// √ Accepted
//   √ 9/9 cases passed (220 ms)
//   √ Your runtime beats 81.66 % of csharp submissions
//   √ Your memory usage beats 37.5 % of csharp submissions (26.8 MB)

