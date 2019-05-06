/*
 * @lc app=leetcode id=515 lang=csharp
 *
 * [515] Find Largest Value in Each Tree Row

 You need to find the largest value in each row of a binary tree.

Example:
Input: 

          1
         / \
        3   2
       / \   \  
      5   3   9 

Output: [1, 3, 9]
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
    public IList<int> LargestValues(TreeNode root) {
        List<int> res = new List<int>();
        if (root == null)
            return res;


        List<TreeNode> floor = new List<TreeNode>();
        List<TreeNode> tem = new List<TreeNode>();
        floor.Add(root);

        while (floor.Count > 0)
        {
            int max = int.MinValue;
            foreach (var node in floor)
            {
                if (node.left != null)
                    tem.Add(node.left);
                if (node.right != null)
                    tem.Add(node.right);

                max = Math.Max(max, node.val);
            }

            res.Add(max);

            floor.Clear();
            floor.AddRange(tem);
            tem.Clear();
        }

        return res;
    }
}

// √ Accepted
//   √ 78/78 cases passed (256 ms)
//   √ Your runtime beats 75.21 % of csharp submissions
//   √ Your memory usage beats 55.56 % of csharp submissions (30.7 MB)

