/*
 * @lc app=leetcode id=655 lang=csharp
 *
 * [655] Print Binary Tree

 Print a binary tree in an m*n 2D string array following these rules:

The row number m should be equal to the height of the given binary tree.
The column number n should always be an odd number.
The root node's value (in string format) should be put in the exactly middle of the first row it can be put. The column and the row where the root node belongs will separate the rest space into two parts (left-bottom part and right-bottom part). You should print the left subtree in the left-bottom part and print the right subtree in the right-bottom part. The left-bottom part and the right-bottom part should have the same size. Even if one subtree is none while the other is not, you don't need to print anything for the none subtree but still need to leave the space as large as that for the other subtree. However, if two subtrees are none, then you don't need to leave space for both of them.
Each unused space should contain an empty string "".
Print the subtrees following the same rules.
Example 1:
Input:
     1
    /
   2
Output:
[["", "1", ""],
 ["2", "", ""]]
Example 2:
Input:
     1
    / \
   2   3
    \
     4
Output:
[["", "", "", "1", "", "", ""],
 ["", "2", "", "", "", "3", ""],
 ["", "", "4", "", "", "", ""]]
Example 3:
Input:
      1
     / \
    2   5
   / 
  3 
 / 
4 
Output:

[["",  "",  "", "",  "", "", "", "1", "",  "",  "",  "",  "", "", ""]
 ["",  "",  "", "2", "", "", "", "",  "",  "",  "",  "5", "", "", ""]
 ["",  "3", "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]
 ["4", "",  "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]]
Note: The height of binary tree is in the range of [1, 10].
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
    public IList<IList<string>> PrintTree(TreeNode root) {
        IList<IList<string>> res = new List<IList<string>>();
        GetDep(root, res, 0);

        int dep = res.Count;
        if (dep == 0)
            return res;
        
        int col = (1 << dep) - 1;
        for (int i = 0; i < dep; i++)
        {
            for (int j = 0; j < col; j++)
            {
                res[i].Add("");
            }
        }

        DFSPrint(root, res, 0, 0, col - 1);
        return res;
    }

    private void DFSPrint(TreeNode node, IList<IList<string>> res, int dep, int start, int end)
    {
        if(node == null)
            return;

        int mid = (start + end) / 2;
        res[dep][mid] = node.val.ToString();

        DFSPrint(node.left, res, dep+1, start, mid-1);
        DFSPrint(node.right, res, dep + 1, mid+1, end);
    }

    private void GetDep(TreeNode node, IList<IList<string>> res, int dep)
    {
        if (node == null)
            return;

        if (res.Count <= dep)
        {
            res.Add(new List<string>());
        }

        GetDep(node.left, res, dep + 1);
        GetDep(node.right, res, dep + 1);
    }

}

// √ Accepted
//   √ 73/73 cases passed (316 ms)
//   √ Your runtime beats 11.94 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (31.4 MB)

