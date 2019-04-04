/*
 * @lc app=leetcode id=530 lang=csharp
 *
 * [530] Minimum Absolute Difference in BST
 *
 * https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
 *
 * algorithms
 * Easy (49.95%)
 * Total Accepted:    55.8K
 * Total Submissions: 111.5K
 * Testcase Example:  '[1,null,3,2]'
 *
 * Given a binary search tree with non-negative values, find the minimum
 * absolute difference between values of any two nodes.
 * 
 * Example:
 * 
 * 
 * Input:
 * 
 * ⁠  1
 * ⁠   \
 * ⁠    3
 * ⁠   /
 * ⁠  2
 * 
 * Output:
 * 1
 * 
 * Explanation:
 * The minimum absolute difference is 1, which is the difference between 2 and
 * 1 (or between 2 and 3).
 * 
 * 
 * 
 * 
 * Note: There are at least two nodes in this BST.
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
    public int GetMinimumDifference(TreeNode root)
    {
        List<int> list = new List<int>();
        GetVal(root, list);
        int min = int.MaxValue;
        for (int i = 1; i < list.Count; i++)
        {
            min = Math.Min(min, Math.Abs(list[i - 1] - list[i]));
        }

        return min;
    }

    private void GetVal(TreeNode node, List<int> list)
    {
        if (node == null)
            return;
        GetVal(node.left, list);
        list.Add(node.val);
        GetVal(node.right, list);
    }








    //时间、空间太高
    public int GetMinimumDifference2(TreeNode root)
    {
        List<int> list = new List<int>();
        GetVal2(root, list);
        int min = int.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i+1; j < list.Count; j++)
            {
                int v = Math.Abs(list[i] - list[j]);
                if (v < min)
                    min = v;
            }
        }

        return min;
    }

    private void GetVal2(TreeNode node, List<int> list)
    {
        if (node == null)
            return;
        list.Add(node.val);

        GetVal2(node.left, list);
        GetVal2(node.right, list);
    }
}

// √ Accepted
//   √ 186/186 cases passed (504 ms)
//   √ Your runtime beats 5.88 % of csharp submissions
//   √ Your memory usage beats 8.33 % of csharp submissions (26.6 MB)


// √ Accepted
//   √ 186/186 cases passed (100 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 8.33 % of csharp submissions (26.6 MB)


