/*
 * @lc app=leetcode id=508 lang=csharp
 *
 * [508] Most Frequent Subtree Sum

 Given the root of a tree, you are asked to find the most frequent subtree sum. The subtree sum of a node is defined as the sum of all the node values formed by the subtree rooted at that node (including the node itself). So what is the most frequent subtree sum value? If there is a tie, return all the values with the highest frequency in any order.

Examples 1
Input:

5
 /  \
2   -3
return [2, -3, 4], since all the values happen only once, return all of them in any order.
Examples 2
Input:

5
 /  \
2   -5
return [2], since 2 happens twice, however -5 only occur once.
Note: You may assume the sum of values in any subtree is in the range of 32-bit signed integer.
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
    public int[] FindFrequentTreeSum(TreeNode root) {
        if (root == null)
            return new int[0];

        int max = 0;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        GetChildrenSum(dic, root, ref max);
        
        List<int> res = new List<int>();
        foreach (var d in dic)
        {
            if(d.Value == max)
                res.Add(d.Key);
        }

        return res.ToArray();
    }

    private int GetChildrenSum(Dictionary<int, int> dic, TreeNode node, ref int max)
    {
        if (node == null)
            return 0;

        int left = GetChildrenSum(dic, node.left, ref max);
        int right = GetChildrenSum(dic, node.right, ref max);

        int v = left + right + node.val;

        int n;
        if (!dic.TryGetValue(v, out n))
            n = 0;
        dic[v] = n + 1;

        max = Math.Max(max, n + 1);
        return v;
    }
}

// √ Accepted
//   √ 61/61 cases passed (280 ms)
//   √ Your runtime beats 42.48 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (31.5 MB)

