/*
 * @lc app=leetcode id=988 lang=csharp
 *
 * [988] Smallest String Starting From Leaf

 Given the root of a binary tree, each node has a value from 0 to 25 representing the letters 'a' to 'z': a value of 0 represents 'a', a value of 1 represents 'b', and so on.

Find the lexicographically smallest string that starts at a leaf of this tree and ends at the root.

(As a reminder, any shorter prefix of a string is lexicographically smaller: for example, "ab" is lexicographically smaller than "aba".  A leaf of a node is a node that has no children.)

 

Example 1:



Input: [0,1,2,3,4,3,4]
Output: "dba"
Example 2:



Input: [25,1,3,1,3,0,2]
Output: "adz"
Example 3:



Input: [2,2,1,null,1,0,null,0]
Output: "abc"
 

Note:

The number of nodes in the given tree will be between 1 and 8500.
Each node in the tree will have a value between 0 and 25.
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
    public string SmallestFromLeaf(TreeNode root) {
        List<TreeNode> leaves = new List<TreeNode>();
        StringBuilder builder = new StringBuilder();
        GetLeaves(leaves, root);

        while (leaves.Count > 0)
        {
            leaves.Sort((a, b) => { return a.val - b.val; });

            int min = leaves[0].val;
            builder.Append((char)(leaves[0].val + 'a'));
            for (int i = leaves.Count-1; i >= 0; i--)
            {
                if(leaves[i].val > min)
                    leaves.RemoveAt(i);
            }

            int count = leaves.Count;
            while (count-- > 0)
            {
                if (leaves[0].left == null)
                {
                    leaves.Clear();
                    break;
                }
                leaves.Add(leaves[0].left);;
                leaves.RemoveAt(0);
            }
        }

        return builder.ToString();
    }

    private void GetLeaves(List<TreeNode> leaves, TreeNode node)
    {
        if(node == null)
            return;

        GetLeaves(leaves, node.left);
        GetLeaves(leaves, node.right);
        
        if (node.left == null && node.right == null)
        {
            leaves.Add(node);
        }
        else
        {
            if (node.left != null)
                node.left.left = node;
            if (node.right != null)
                node.right.left = node;

            node.left = null;
        }
    }
}

// √ Accepted
//   √ 67/67 cases passed (528 ms)
//   √ Your runtime beats 5.05 % of csharp submissions
//   √ Your memory usage beats 62.34 % of csharp submissions (24.2 MB)

