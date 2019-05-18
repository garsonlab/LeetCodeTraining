/*
 * @lc app=leetcode id=863 lang=csharp
 *
 * [863] All Nodes Distance K in Binary Tree

 We are given a binary tree (with root node root), a target node, and an integer value K.

Return a list of the values of all nodes that have a distance K from the target node.  The answer can be returned in any order.

 

Example 1:

Input: root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, K = 2

Output: [7,4,1]

Explanation: 
The nodes that are a distance 2 from the target node (with value 5)
have values 7, 4, and 1.



Note that the inputs "root" and "target" are actually TreeNodes.
The descriptions of the inputs above are just serializations of these objects.
 

Note:

The given tree is non-empty.
Each node in the tree has unique values 0 <= node.val <= 500.
The target node is a node in the tree.
0 <= K <= 1000.
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
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        List<int> res = new List<int>();
        if(K == 0) {
            res.Add(target.val);
            return res;
        }

        TreeNode node = root;
        Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();
        GetParent(node, target, parents);

        node = target;
        int dir = 0;
        for (int i = 0; i <= K; i++)
        {
            if(node == null)
                break;
            GetKNode(res, node, K-i, dir);
            
            if(parents.ContainsKey(node)) {
                var tem = parents[node];
                if(tem.left == node)
                    dir = -1;
                else
                    dir = 1;
                node = tem;
            }
            else
                node = null;
        }
        return res;
    }

    private bool GetParent(TreeNode node, TreeNode target, Dictionary<TreeNode, TreeNode> parents) {
        if (node == target)
            return true;

        if (node.left != null) {
            parents[node.left] = node;
            if(GetParent(node.left, target, parents))
                return true;
        }
        if (node.right != null) {
            parents[node.right] = node;
            if(GetParent(node.right, target, parents))
                return true;
        }
        return false;
    }

    private void GetKNode(List<int> res, TreeNode node, int k, int fromDir) {
        if(node == null)
            return;

        if(k == 0) {
            res.Add(node.val);
            return;
        }

        if(fromDir >= 0)
            GetKNode(res, node.left, k-1, 0);
        if(fromDir <= 0)
            GetKNode(res, node.right, k-1, 0);
    }

}

// √ Accepted
//   √ 57/57 cases passed (252 ms)
//   √ Your runtime beats 81.55 % of csharp submissions
//   √ Your memory usage beats 70.51 % of csharp submissions (28.8 MB)

