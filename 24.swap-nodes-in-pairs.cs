/*
 * @lc app=leetcode id=24 lang=csharp
 *
 * [24] Swap Nodes in Pairs
 *
 * https://leetcode.com/problems/swap-nodes-in-pairs/description/
 *
 * algorithms
 * Medium (43.96%)
 * Total Accepted:    299.3K
 * Total Submissions: 680.4K
 * Testcase Example:  '[1,2,3,4]'
 *
 * Given a linked list, swap every two adjacent nodes and return its head.
 * 
 * You may not modify the values in the list's nodes, only nodes itself may be
 * changed.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Given 1->2->3->4, you should return the list as 2->1->4->3.
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
public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null)
            return head;

        ListNode root = new ListNode(-1);
        root.next = head;

        ListNode p = head;
        ListNode q = head.next;

        ListNode c = root;
        while (p != null && q != null)
        {
            c.next = q;
            var tem = q.next;
            c.next.next = p;
            c = p;
            c.next = null;

            p = tem;
            q = tem != null ? tem.next : null;
        }

        if (p != null)
        {
            p.next = null;
            c.next = p;
        }

        return root.next;
    }
}

// √ Accepted
//   √ 55/55 cases passed (100 ms)
//   √ Your runtime beats 51.13 % of csharp submissions
//   √ Your memory usage beats 9.68 % of csharp submissions (22 MB)

