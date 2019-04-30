/*
 * @lc app=leetcode id=331 lang=csharp
 *
 * [331] Verify Preorder Serialization of a Binary Tree

 One way to serialize a binary tree is to use pre-order traversal. When we encounter a non-null node, we record the node's value. If it is a null node, we record using a sentinel value such as #.

_9_
    /   \
   3     2
  / \   / \
 4   1  #  6
/ \ / \   / \
# # # #   # #
For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#", where # represents a null node.

Given a string of comma separated values, verify whether it is a correct preorder traversal serialization of a binary tree. Find an algorithm without reconstructing the tree.

Each comma separated value in the string must be either an integer or a character '#' representing null pointer.

You may assume that the input format is always valid, for example it could never contain two consecutive commas such as "1,,3".

Example 1:

Input: "9,3,4,#,#,1,#,#,2,#,6,#,#"
Output: true
Example 2:

Input: "1,#"
Output: false
Example 3:

Input: "9,#,#,1"
Output: false
 */
public class Solution {
    public bool IsValidSerialization(string preorder) {
        string[] ps = preorder.Split(',');
        Stack<string> stack = new Stack<string>();

        for (int i = 0; i < ps.Length; i++)
        {
            if (i > 0 && ps[i - 1] == "#")
            {
                if (stack.Count == 0)
                    return false;
                stack.Pop();
            }

            if (ps[i] == "#")
            {
            }
            else
            {
                stack.Push(ps[i]);
            }
        }

        return stack.Count == 0;
    }
}

// √ Accepted
//   √ 150/150 cases passed (80 ms)
//   √ Your runtime beats 88.37 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (21.7 MB)

