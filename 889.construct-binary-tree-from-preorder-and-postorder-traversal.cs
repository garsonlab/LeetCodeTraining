/*
 * @lc app=leetcode id=889 lang=csharp
 *
 * [889] Construct Binary Tree from Preorder and Postorder Traversal

 Return any binary tree that matches the given preorder and postorder traversals.

Values in the traversals pre and post are distinct positive integers.

 

Example 1:

Input: pre = [1,2,4,5,3,6,7], post = [4,5,2,6,7,3,1]
Output: [1,2,3,4,5,6,7]
 

Note:

1 <= pre.length == post.length <= 30
pre[] and post[] are both permutations of 1, 2, ..., pre.length.
It is guaranteed an answer exists. If there exists multiple answers, you can return any of them.
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
    public TreeNode ConstructFromPrePost(int[] pre, int[] post) {
        return CNode(pre, post, 0, pre.Length-1, 0, post.Length-1);
    }

    private TreeNode CNode(int[] pre,int[] post,int prestart,int preend,int poststart,int postend) {
        if(prestart>preend || poststart>postend)
            return null;

        TreeNode root=new TreeNode(pre[prestart]);
        if (prestart == preend)
			return root;
        int index=0;
        while(post[index]!=pre[prestart+1]){
            index++;
        }
        root.left=CNode(pre,post,prestart+1,prestart+1+index-poststart,poststart,index);
        root.right=CNode(pre,post,prestart+2+index-poststart,preend,index+1,preend-1);
        return root;
        
    }


    public TreeNode ConstructFromPrePost_Err(int[] pre, int[] post) {
        return CreateNode(pre, post, 0, pre.Length, 0, post.Length);
    }

    private TreeNode CreateNode(int[] pre, int[] post, int s1, int e1, int s2, int e2) {
        if(s1 >= e1)
            return null;
        TreeNode node = new TreeNode(pre[s1]);

        List<int> s = new List<int>();
        int left_len = -1;
        for (int i = s1+1, j=s2; i < e1 && j < e2-1; i++, j++)
        {
            s.Add(pre[i]);
            s.Add(post[j]);
            if(s.Count == i-s1) {
                left_len = i-s1;
                break;
            }
        }

        if(left_len < 0)
            return node;

        node.left = CreateNode(pre, post, s1+1, s1+1+left_len, s2, s2+left_len);
        node.right = CreateNode(pre, post, s1+1+left_len, e1, s2+left_len, e2-1);
        return node;
    }
}

// √ Accepted
//   √ 306/306 cases passed (96 ms)
//   √ Your runtime beats 98.41 % of csharp submissions
//   √ Your memory usage beats 56.1 % of csharp submissions (24.8 MB)

