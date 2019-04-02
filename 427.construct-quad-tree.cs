/*
 * @lc app=leetcode id=427 lang=csharp
 *
 * [427] Construct Quad Tree
 *
 * https://leetcode.com/problems/construct-quad-tree/description/
 *
 * algorithms
 * Easy (55.00%)
 * Total Accepted:    8.4K
 * Total Submissions: 15.3K
 * Testcase Example:  '[[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0],[1,1,1,1,0,0,0,0]]'
 *
 * We want to use quad trees to store an N x N boolean grid. Each cell in the
 * grid can only be true or false. The root node represents the whole grid. For
 * each node, it will be subdivided into four children nodes until the values
 * in the region it represents are all the same.
 * 
 * Each node has another two boolean attributes : isLeaf and val. isLeaf is
 * true if and only if the node is a leaf node. The val attribute for a leaf
 * node contains the value of the region it represents.
 * 
 * Your task is to use a quad tree to represent a given grid. The following
 * example may help you understand the problem better:
 * 
 * Given the 8 x 8 grid below, we want to construct the corresponding quad
 * tree:
 * 
 * 
 * 
 * It can be divided according to the definition above:
 * 
 * 
 * 
 * 
 * 
 * The corresponding quad tree should be as following, where each node is
 * represented as a (isLeaf, val) pair.
 * 
 * For the non-leaf nodes, val can be arbitrary, so it is represented as *.
 * 
 * 
 * 
 * Note:
 * 
 * 
 * N is less than 1000 and guaranteened to be a power of 2.
 * If you want to know more about the quad tree, you can refer to its wiki.
 * 
 * 
 */
/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node(){}
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
}
*/
public class Solution {
    public Node Construct(int[][] grid)
    {
        bool m;
        return CreateQuad(ref grid, 0, 0, grid.Length, out m);
    }

    private Node CreateQuad(ref int[][] grid, int x, int y, int s, out bool canMerge)
    {
        Node node = new Node();

        if (s == 1)
        {
            node.val = grid[x][y] == 1;
            node.isLeaf = true;
            canMerge = true;
        }
        else
        {
            bool[] merges = new bool[4];
            Node tl = CreateQuad(ref grid, x, y + s / 2, s / 2, out merges[0]);
            Node tr = CreateQuad(ref grid, x + s / 2, y + s / 2, s / 2, out merges[1]);
            Node bl = CreateQuad(ref grid, x, y, s / 2, out merges[2]);
            Node br = CreateQuad(ref grid, x + s / 2, y, s / 2, out merges[3]);

            if (tl.val == tr.val && tr.val == bl.val && bl.val == br.val && merges[0] && merges[1] && merges[2] && merges[3])
            {
                node.val = tl.val;
                node.isLeaf = true;
                canMerge = true;
            }
            else
            {
                node.val = tl.val || tr.val || bl.val || br.val;
                node.isLeaf = false;
                node.topLeft = bl;
                node.topRight = tl;
                node.bottomLeft = br;
                node.bottomRight = tr;
                canMerge = false;
            }
        }

        return node;
    }

}

// √ Accepted
//   √ 20/20 cases passed (188 ms)
//   √ Your runtime beats 53.16 % of csharp submissions
//   √ Your memory usage beats 12.5 % of csharp submissions (34.2 MB)

