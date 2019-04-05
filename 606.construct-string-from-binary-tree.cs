/*
 * @lc app=leetcode id=606 lang=csharp
 *
 * [606] Construct String from Binary Tree
 *
 * https://leetcode.com/problems/construct-string-from-binary-tree/description/
 *
 * algorithms
 * Easy (51.20%)
 * Total Accepted:    55.3K
 * Total Submissions: 107.9K
 * Testcase Example:  '[1,2,3,4]'
 *
 * You need to construct a string consists of parenthesis and integers from a
 * binary tree with the preorder traversing way.
 * 
 * The null node needs to be represented by empty parenthesis pair "()". And
 * you need to omit all the empty parenthesis pairs that don't affect the
 * one-to-one mapping relationship between the string and the original binary
 * tree.
 * 
 * Example 1:
 * 
 * Input: Binary tree: [1,2,3,4]
 * ⁠      1
 * ⁠    /   \
 * ⁠   2     3
 * ⁠  /    
 * ⁠ 4     
 * 
 * Output: "1(2(4))(3)"
 * Explanation: Originallay it needs to be "1(2(4)())(3()())", but you need to
 * omit all the unnecessary empty parenthesis pairs. And it will be
 * "1(2(4))(3)".
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: Binary tree: [1,2,3,null,4]
 * ⁠      1
 * ⁠    /   \
 * ⁠   2     3
 * ⁠    \  
 * ⁠     4 
 * 
 * Output: "1(2()(4))(3)"
 * Explanation: Almost the same as the first example, except we can't omit the
 * first parenthesis pair to break the one-to-one mapping relationship between
 * the input and the output.
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
    public string Tree2str(TreeNode t)
    {
        List<char> list = new List<char>();

        PrintTree(t, list, true);
        return new string(list.ToArray());
    }

    private void PrintTree(TreeNode node, List<char> list, bool isRoot)
    {
        if(node == null)
            return;
        if(!isRoot)
            list.Add('(');
        
        list.AddRange(node.val.ToString().ToCharArray());

        if(node.left == null && node.right == null) { }
        else
        {
            if (node.left == null)
            {
                list.Add('(');
                list.Add(')');
            }
            else
            {
                PrintTree(node.left, list, false);
            }

            if(node.right != null)
                PrintTree(node.right, list, false);
        }
        if(!isRoot)
            list.Add(')');

    }
}

// √ Accepted
//   √ 162/162 cases passed (116 ms)
//   √ Your runtime beats 90.27 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (27.7 MB)

