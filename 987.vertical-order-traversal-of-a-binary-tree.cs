/*
 * @lc app=leetcode id=987 lang=csharp
 *
 * [987] Vertical Order Traversal of a Binary Tree

 Given a binary tree, return the vertical order traversal of its nodes values.

For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).

Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes, we report the values of the nodes in order from top to bottom (decreasing Y coordinates).

If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.

Return an list of non-empty reports in order of X coordinate.  Every report will have a list of values of nodes.

 

Example 1:



Input: [3,9,20,null,null,15,7]
Output: [[9],[3,15],[20],[7]]
Explanation: 
Without loss of generality, we can assume the root node is at position (0, 0):
Then, the node with value 9 occurs at position (-1, -1);
The nodes with values 3 and 15 occur at positions (0, 0) and (0, -2);
The node with value 20 occurs at position (1, -1);
The node with value 7 occurs at position (2, -2).
Example 2:



Input: [1,2,3,4,5,6,7]
Output: [[4],[2],[1,5,6],[3],[7]]
Explanation: 
The node with value 5 and the node with value 6 have the same position according to the given scheme.
However, in the report "[1,5,6]", the node value of 5 comes first since 5 is smaller than 6.
 

Note:

The tree will have between 1 and 1000 nodes.
Each node's value will be between 0 and 1000.
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
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();
        DFSVT(map, root, 0, 0);

        IList<IList<int>> res = new List<IList<int>>();
        List<int> keys = new List<int>(map.Keys);
        keys.Sort();

        foreach (var key in keys)
        {
            var list = map[key];
            list.Sort((a, b) =>
            {
                if (a[0] == b[0])
                {
                    return a[1] - b[1];
                }
                return a[0] - b[0];
            });

            List<int> l = new List<int>();
            foreach (var li in list)
            {
                l.Add(li[1]);
            }
            res.Add(l);
        }
        
        return res;
    }

    private void DFSVT(Dictionary<int, List<int[]>> map, TreeNode node, int x, int y)
    {
        if(node == null)
            return;

        List<int[]> list;
        if (!map.TryGetValue(x, out list))
        {
            list = new List<int[]>();
            map[x] = list;
        }

        list.Add(new []{y, node.val});
        DFSVT(map, node.left, x - 1, y + 1);
        DFSVT(map, node.right, x + 1, y + 1);
    }
    

}

// √ Accepted
//   √ 30/30 cases passed (264 ms)
//   √ Your runtime beats 52.75 % of csharp submissions
//   √ Your memory usage beats 74.68 % of csharp submissions (29 MB)

