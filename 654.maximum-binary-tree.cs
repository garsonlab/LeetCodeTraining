/*
 * @lc app=leetcode id=654 lang=csharp
 *
 * [654] Maximum Binary Tree

 Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

The root is the maximum number in the array.
The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
Construct the maximum tree by the given array and output the root node of this tree.

Example 1:
Input: [3,2,1,6,0,5]
Output: return the tree root node representing the following tree:

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1
Note:
The size of the given array will be in the range [1,1000].
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
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        return DFSMBT(nums, 0, nums.Length - 1);
    }

    private TreeNode DFSMBT(int[] nums, int start, int end)
    {
        int idx = GetMaxIdx(nums, start, end);
        if (idx < 0)
            return null;

        TreeNode node = new TreeNode(nums[idx]);
        node.left = DFSMBT(nums, start, idx - 1);
        node.right = DFSMBT(nums, idx + 1, end);
        return node;
    }

    private int GetMaxIdx(int[] nums, int start, int end)
    {
        if (start > end)
            return -1;

        int max = start;
        for (int i = start+1; i <= end; i++)
        {
            if (nums[i] > nums[max])
                max = i;
        }

        return max;
    }

}

// √ Accepted
//   √ 107/107 cases passed (120 ms)
//   √ Your runtime beats 55.91 % of csharp submissions
//   √ Your memory usage beats 83.33 % of csharp submissions (27.8 MB)

