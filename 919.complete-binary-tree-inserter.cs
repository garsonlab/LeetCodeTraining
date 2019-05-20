/*
 * @lc app=leetcode id=919 lang=csharp
 *
 * [919] Complete Binary Tree Inserter

 A complete binary tree is a binary tree in which every level, except possibly the last, is completely filled, and all nodes are as far left as possible.

Write a data structure CBTInserter that is initialized with a complete binary tree and supports the following operations:

CBTInserter(TreeNode root) initializes the data structure on a given tree with head node root;
CBTInserter.insert(int v) will insert a TreeNode into the tree with value node.val = v so that the tree remains complete, and returns the value of the parent of the inserted TreeNode;
CBTInserter.get_root() will return the head node of the tree.
 

Example 1:

Input: inputs = ["CBTInserter","insert","get_root"], inputs = [[[1]],[2],[]]
Output: [null,1,[1,2]]
Example 2:

Input: inputs = ["CBTInserter","insert","insert","get_root"], inputs = [[[1,2,3,4,5,6]],[7],[8],[]]
Output: [null,3,4,[1,2,3,4,5,6,7,8]]
 

Note:

The initial given tree is complete and contains between 1 and 1000 nodes.
CBTInserter.insert is called at most 10000 times per test case.
Every value of a given or inserted node is between 0 and 5000.
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
public class CBTInserter {

    private TreeNode root;
        private Queue<TreeNode> queue;

        public CBTInserter(TreeNode root)
        {
            this.root = root;
            queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        }

        public int Insert(int v)
        {
            TreeNode node = null;

            while (queue.Count > 0)
            {
                node = queue.Peek();

                if (node.left != null && node.right != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                    queue.Dequeue();
                    continue;
                }

                if (node.left == null)
                    node.left = new TreeNode(v);
                else
                    node.right = new TreeNode(v);
                break;
            }

            return node.val;
        }

        public TreeNode Get_root()
        {
            return root;
        }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */

//  √ Accepted
//   √ 83/83 cases passed (128 ms)
//   √ Your runtime beats 97.22 % of csharp submissions
//   √ Your memory usage beats 66.67 % of csharp submissions (28.2 MB)

