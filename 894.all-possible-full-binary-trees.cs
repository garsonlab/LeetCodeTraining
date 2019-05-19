/*
 * @lc app=leetcode id=894 lang=csharp
 *
 * [894] All Possible Full Binary Trees
 A full binary tree is a binary tree where each node has exactly 0 or 2 children.

Return a list of all possible full binary trees with N nodes.  Each element of the answer is the root node of one possible tree.

Each node of each tree in the answer must have node.val = 0.

You may return the final list of trees in any order.

 

Example 1:

Input: 7
Output: [[0,0,0,null,null,0,0,null,null,0,0],[0,0,0,null,null,0,0,0,0],[0,0,0,0,0,0,0],[0,0,0,0,0,null,null,null,null,0,0],[0,0,0,0,0,null,null,0,0]]
Explanation:

 

Note:

1 <= N <= 20
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
    public IList<TreeNode> AllPossibleFBT(int N) {
        List<TreeNode> list = new List<TreeNode>();
        if(N%2 == 0)
            return list;//not full

        if(N == 1){
            list.Add(new TreeNode(0));
            return list;
        }

        for (int i = 1; i < N; i+=2)
        {
            IList<TreeNode> left = AllPossibleFBT(i);
            IList<TreeNode> right = AllPossibleFBT(N - 1 - i);
            foreach (TreeNode l in left) {
                foreach (TreeNode r in right) {
                    TreeNode head = new TreeNode(0);
                    head.left = l;
                    head.right = r;
                    list.Add(head);
                }
            }
        }

        return list;
    }
}

// √ Accepted
//   √ 20/20 cases passed (260 ms)
//   √ Your runtime beats 59.48 % of csharp submissions
//   √ Your memory usage beats 31.11 % of csharp submissions (33 MB)

