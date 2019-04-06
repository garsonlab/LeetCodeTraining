/*
 * @lc app=leetcode id=637 lang=csharp
 *
 * [637] Average of Levels in Binary Tree
 *
 * https://leetcode.com/problems/average-of-levels-in-binary-tree/description/
 *
 * algorithms
 * Easy (58.19%)
 * Total Accepted:    74.3K
 * Total Submissions: 127.5K
 * Testcase Example:  '[3,9,20,15,7]'
 *
 * Given a non-empty binary tree, return the average value of the nodes on each
 * level in the form of an array.
 * 
 * Example 1:
 * 
 * Input:
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * Output: [3, 14.5, 11]
 * Explanation:
 * The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on
 * level 2 is 11. Hence return [3, 14.5, 11].
 * 
 * 
 * 
 * Note:
 * 
 * The range of node's value is in the range of 32-bit signed integer.
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
    public IList<double> AverageOfLevels(TreeNode root)
    {
        IList<double> list = new List<double>();
        if (root == null)
            return list;
        
        List<TreeNode> nodes = new List<TreeNode>();
        List<TreeNode> tem = new List<TreeNode>();

        nodes.Add(root);

        while (nodes.Count > 0)
        {
            int count = nodes.Count;
            double r = 0;
            foreach (var node in nodes)
            {
                r += node.val;// * 1d / count;

                if(node.left != null)
                    tem.Add(node.left);
                if(node.right != null)
                    tem.Add(node.right);
            }

            list.Add(r/count);
            nodes.Clear();
            nodes.AddRange(tem);
            tem.Clear();
        }
        return list;
    }

}
// √ Accepted
//   √ 65/65 cases passed (292 ms)
//   √ Your runtime beats 48.7 % of csharp submissions
//   √ Your memory usage beats 52.63 % of csharp submissions (31.8 MB)

