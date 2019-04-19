/*
 * @lc app=leetcode id=143 lang=csharp
 *
 * [143] Reorder List
 *
 * https://leetcode.com/problems/reorder-list/description/
 *
 * algorithms
 * Medium (30.30%)
 * Total Accepted:    149.2K
 * Total Submissions: 491.4K
 * Testcase Example:  '[1,2,3,4]'
 *
 * Given a singly linked list L: L0→L1→…→Ln-1→Ln,
 * reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…
 * 
 * You may not modify the values in the list's nodes, only nodes itself may be
 * changed.
 * 
 * Example 1:
 * 
 * 
 * Given 1->2->3->4, reorder it to 1->4->2->3.
 * 
 * Example 2:
 * 
 * 
 * Given 1->2->3->4->5, reorder it to 1->5->2->4->3.
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
    public void ReorderList(ListNode head) {
        List<ListNode> list = new List<ListNode>();
        List<ListNode> pre = new List<ListNode>(){null};

        ListNode tem = head;
        while (tem != null)
        {
            list.Add(tem);
            pre.Add(tem);
            tem = tem.next;
        }

        for (int i = 0, j = list.Count-1; i < j; i++, j--)
        {
            var n = list[j];
            pre[j].next = null;
            n.next = list[i].next;
            list[i].next = n;
        }
    }
}

// √ Accepted
//   √ 13/13 cases passed (112 ms)
//   √ Your runtime beats 63.12 % of csharp submissions
//   √ Your memory usage beats 12.5 % of csharp submissions (31.5 MB)

