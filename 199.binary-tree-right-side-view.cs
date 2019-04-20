/*
 * @lc app=leetcode id=199 lang=csharp
 *
 * [199] Binary Tree Right Side View
 *
 * https://leetcode.com/problems/binary-tree-right-side-view/description/
 *
 * algorithms
 * Medium (47.28%)
 * Total Accepted:    161K
 * Total Submissions: 339.6K
 * Testcase Example:  '[1,2,3,null,5,null,4]'
 *
 * Given a binary tree, imagine yourself standing on the right side of it,
 * return the values of the nodes you can see ordered from top to bottom.
 * 
 * Example:
 * 
 * 
 * Input: [1,2,3,null,5,null,4]
 * Output: [1, 3, 4]
 * Explanation:
 * 
 * ⁠  1            <---
 * ⁠/   \
 * 2     3         <---
 * ⁠\     \
 * ⁠ 5     4       <---
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
    public IList<int> RightSideView(TreeNode root)
    {
        List<int> list = new List<int>();

        PreSearch(root, list, 0);
        return list;
    }

    private void PreSearch(TreeNode node, List<int> list, int dep)
    {
        if(node == null)
            return;

        if (list.Count > dep)
            list[dep] = node.val;
        else
            list.Add(node.val);

        PreSearch(node.left, list, dep + 1);
        PreSearch(node.right, list, dep + 1);
    }
}


// √ Accepted
//   √ 211/211 cases passed (252 ms)
//   √ Your runtime beats 61.73 % of csharp submissions
//   √ Your memory usage beats 29.63 % of csharp submissions (28.8 MB)
