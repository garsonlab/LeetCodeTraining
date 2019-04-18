/*
 * @lc app=leetcode id=109 lang=csharp
 *
 * [109] Convert Sorted List to Binary Search Tree
 *
 * https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/description/
 *
 * algorithms
 * Medium (40.19%)
 * Total Accepted:    170.6K
 * Total Submissions: 424K
 * Testcase Example:  '[-10,-3,0,5,9]'
 *
 * Given a singly linked list where elements are sorted in ascending order,
 * convert it to a height balanced BST.
 * 
 * For this problem, a height-balanced binary tree is defined as a binary tree
 * in which the depth of the two subtrees of every node never differ by more
 * than 1.
 * 
 * Example:
 * 
 * 
 * Given the sorted linked list: [-10,-3,0,5,9],
 * 
 * One possible answer is: [0,-3,9,-10,null,5], which represents the following
 * height balanced BST:
 * 
 * ⁠     0
 * ⁠    / \
 * ⁠  -3   9
 * ⁠  /   /
 * ⁠-10  5
 * 
 * 
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
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
    public TreeNode SortedListToBST(ListNode head) {
        List<int> list = new List<int>();

        ListNode cur = head;
        while (cur != null)
        {
            list.Add(cur.val);
            cur = cur.next;
        }

        return CreateBSTN(list, 0, list.Count - 1);
    }

    private TreeNode CreateBSTN(List<int> list, int l, int r)
    {
        if (l > r)
            return null;

        int mid = (l + r) / 2;
        TreeNode node = new TreeNode(list[mid]);
        node.left = CreateBSTN(list, l, mid - 1);
        node.right = CreateBSTN(list, mid + 1, r);
        return node;
    }
}

// √ Accepted
//   √ 32/32 cases passed (116 ms)
//   √ Your runtime beats 51.93 % of csharp submissions
//   √ Your memory usage beats 44.44 % of csharp submissions (25.3 MB)

