/*
 * @lc app=leetcode id=108 lang=csharp
 *
 * [108] Convert Sorted Array to Binary Search Tree
 *
 * https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
 *
 * algorithms
 * Easy (49.57%)
 * Total Accepted:    244.8K
 * Total Submissions: 493.3K
 * Testcase Example:  '[-10,-3,0,5,9]'
 *
 * Given an array where elements are sorted in ascending order, convert it to a
 * height balanced BST.
 * 
 * For this problem, a height-balanced binary tree is defined as a binary tree
 * in which the depth of the two subtrees of every node never differ by more
 * than 1.
 * 
 * Example:
 * 
 * 
 * Given the sorted array: [-10,-3,0,5,9],
 * 
 * One possible answer is: [0,-3,9,-10,null,5], which represents the following
 * height balanced BST:
 * 
 * ⁠     0
 * ⁠    / \
 * ⁠  -3   9
 * ⁠  /   /
 * ⁠-10  5
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
    public TreeNode SortedArrayToBST(int[] nums) {
        
        if (nums.Length <= 0)
            return null;

        return CreateBSTNode(ref nums, 0, nums.Length-1);
    }
    
    public TreeNode CreateBSTNode(ref int[] nums, int start, int end)
    {
        int mid = (end + start) / 2;
        TreeNode node = new TreeNode(nums[mid]);

        if (mid != start)
        {
            node.left = CreateBSTNode(ref nums, start, mid - 1);
        }

        if (mid != end)
        {
            node.right = CreateBSTNode(ref nums, mid + 1, end);
        }

        return node;
    }
}

// √ Accepted
//   √ 32/32 cases passed (96 ms)
//   √ Your runtime beats 96.64 % of csharp submissions
//   √ Your memory usage beats 10.53 % of csharp submissions (23.8 MB)


