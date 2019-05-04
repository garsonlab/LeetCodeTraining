/*
 * @lc app=leetcode id=449 lang=csharp
 *
 * [449] Serialize and Deserialize BST

 Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary search tree can be serialized to a string and this string can be deserialized to the original tree structure.

The encoded string should be as compact as possible.

Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.
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
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null)
            return "";

        StringBuilder builder = new StringBuilder();
        ser(root, builder);
        return builder.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data.Length == 0)
            return null;
        
        string[] ps = data.Split(',');
        return deser(ps, 0, ps.Length);
    }

    private void ser(TreeNode node, StringBuilder builder) {
        if(node == null)
            return;

        if(builder.Length == 0)
            builder.Append(node.val);
        else {
            builder.Append(",");
            builder.Append(node.val);
        }

        ser(node.left, builder);
        ser(node.right, builder);
    }

    TreeNode deser(string[] s, int start, int end){
        if(start == end)
            return null;
        TreeNode root = new TreeNode(int.Parse(s[start]));
        int i;
        for(i=start+1; i<end; i++) {
            if(int.Parse(s[i]) > int.Parse(s[start]))
                break;
        }
        root.left = deser(s, start+1, i);
        root.right = deser(s, i, end);
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));


// √ Accepted
//   √ 62/62 cases passed (140 ms)
//   √ Your runtime beats 33.61 % of csharp submissions
//   √ Your memory usage beats 90.91 % of csharp submissions (27.4 MB)

