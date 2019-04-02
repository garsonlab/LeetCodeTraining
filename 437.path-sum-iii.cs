/*
 * @lc app=leetcode id=437 lang=csharp
 *
 * [437] Path Sum III
 *
 * https://leetcode.com/problems/path-sum-iii/description/
 *
 * algorithms
 * Easy (42.14%)
 * Total Accepted:    97.5K
 * Total Submissions: 230.9K
 * Testcase Example:  '[10,5,-3,3,2,null,11,3,-2,null,1]\n8'
 *
 * You are given a binary tree in which each node contains an integer value.
 * 
 * Find the number of paths that sum to a given value.
 * 
 * The path does not need to start or end at the root or a leaf, but it must go
 * downwards
 * (traveling only from parent nodes to child nodes).
 * 
 * The tree has no more than 1,000 nodes and the values are in the range
 * -1,000,000 to 1,000,000.
 * 
 * Example:
 * 
 * root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8
 * 
 * ⁠     10
 * ⁠    /  \
 * ⁠   5   -3
 * ⁠  / \    \
 * ⁠ 3   2   11
 * ⁠/ \   \
 * 3  -2   1
 * 
 * Return 3. The paths that sum to 8 are:
 * 
 * 1.  5 -> 3
 * 2.  5 -> 2 -> 1
 * 3. -3 -> 11
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
    public int PathSum(TreeNode root, int sum)
    {
        if (root == null)
            return 0;
        return PathAdd(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
    }
    private int PathAdd(TreeNode root, int sum)
    {
        if (root == null)
            return 0;
        return (root.val == sum ? 1 : 0) + PathAdd(root.left, sum - root.val) + PathAdd(root.right, sum - root.val);
    }


    // public int PathSum(TreeNode root, int sum)
    // {
    //     int count = 0;
    //     PathAdd(root, sum, 0, true, ref count);
    //     return count;
    // }

    // void PathAdd(TreeNode node, int sum, int val, bool asRoot, ref int count)
    // {
    //     if(node == null)
    //         return;

    //     if (node.val + val == sum)
    //         count++;

    //     PathAdd(node.left, sum, node.val+val, true, ref count);//以上个节点
    //     PathAdd(node.right, sum, node.val + val, true, ref count);
        
    //     if(asRoot)
    //     {
    //         PathAdd(node.left, sum, 0, false, ref count);//以上个节点
    //         PathAdd(node.right, sum, 0, false, ref count);
    //     }
    // }
}


// √ Accepted
//   √ 126/126 cases passed (112 ms)
//   √ Your runtime beats 82.72 % of csharp submissions
//   √ Your memory usage beats 90 % of csharp submissions (23.8 MB)

