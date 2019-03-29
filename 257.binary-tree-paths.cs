/*
 * @lc app=leetcode id=257 lang=csharp
 *
 * [257] Binary Tree Paths
 *
 * https://leetcode.com/problems/binary-tree-paths/description/
 *
 * algorithms
 * Easy (45.24%)
 * Total Accepted:    215.5K
 * Total Submissions: 475.5K
 * Testcase Example:  '[1,2,3,null,5]'
 *
 * Given a binary tree, return all root-to-leaf paths.
 * 
 * Note: A leaf is a node with no children.
 * 
 * Example:
 * 
 * 
 * Input:
 * 
 * ⁠  1
 * ⁠/   \
 * 2     3
 * ⁠\
 * ⁠ 5
 * 
 * Output: ["1->2->5", "1->3"]
 * 
 * Explanation: All root-to-leaf paths are: 1->2->5, 1->3
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
    public IList<string> BinaryTreePaths(TreeNode root) {
        IList<string> list = new List<string>();

        if (root != null)
        {
            string path = "";
            GetBinaryTreePath(root, list, path);
        }

        return list;
    }

    private void GetBinaryTreePath(TreeNode root, IList<string> list, string path)
    {
        if (string.IsNullOrEmpty(path))
            path = root.val.ToString();
        else
            path = path + "->" + root.val;

        if(root.left == null && root.right == null)
            list.Add(path);
        else
        {
            if(root.left != null)
                GetBinaryTreePath(root.left, list, path);
            if(root.right != null)
                GetBinaryTreePath(root.right, list, path);
        }
    }

}


// √ Accepted
//   √ 209/209 cases passed (280 ms)
//   √ Your runtime beats 57.77 % of csharp submissions
//   √ Your memory usage beats 96.43 % of csharp submissions (29.6 MB)


