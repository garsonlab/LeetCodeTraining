/*
 * @lc app=leetcode id=662 lang=csharp
 *
 * [662] Maximum Width of Binary Tree

 Given a binary tree, write a function to get the maximum width of the given tree. The width of a tree is the maximum width among all levels. The binary tree has the same structure as a full binary tree, but some nodes are null.

The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.

Example 1:

Input: 

           1
         /   \
        3     2
       / \     \  
      5   3     9 

Output: 4
Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).
Example 2:

Input: 

          1
         /  
        3    
       / \       
      5   3     

Output: 2
Explanation: The maximum width existing in the third level with the length 2 (5,3).
Example 3:

Input: 

          1
         / \
        3   2 
       /        
      5      

Output: 2
Explanation: The maximum width existing in the second level with the length 2 (3,2).
Example 4:

Input: 

          1
         / \
        3   2
       /     \  
      5       9 
     /         \
    6           7
Output: 8
Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).
Note: Answer will in the range of 32-bit signed integer.
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
    public int WidthOfBinaryTree(TreeNode root) {
        if (root == null)
            return 0;

        List<TreeNode> cur = new List<TreeNode>();
        List<TreeNode> next = new List<TreeNode>();

        cur.Add(root);
        int res = 0;
        while (cur.Count > 0)
        {
            for (int i = cur.Count-1; i >= 0; i--)
            {
                if(cur[i] == null)
                    cur.RemoveAt(i);
                else
                    break;
            }

            res = Math.Max(res, cur.Count);
            foreach (var node in cur)
            {
                if (node == null)
                {
                    if (next.Count > 0)
                    {
                        next.Add(null);
                        next.Add(null);
                    }
                }
                else
                {
                    if (node.left != null)
                        next.Add(node.left);
                    else if(next.Count > 0)
                        next.Add(null);

                    if (node.right != null)
                        next.Add(node.right);
                    else if (next.Count > 0)
                        next.Add(null);
                }
            }

            cur.Clear();
            cur.AddRange(next);
            next.Clear();
        }

        return res;
    }
}

// √ Accepted
//   √ 108/108 cases passed (144 ms)
//   √ Your runtime beats 6.25 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (35 MB)

