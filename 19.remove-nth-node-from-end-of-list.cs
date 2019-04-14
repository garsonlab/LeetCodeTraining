/*
 * @lc app=leetcode id=19 lang=csharp
 *
 * [19] Remove Nth Node From End of List
 *
 * https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
 *
 * algorithms
 * Medium (34.13%)
 * Total Accepted:    375.2K
 * Total Submissions: 1.1M
 * Testcase Example:  '[1,2,3,4,5]\n2'
 *
 * Given a linked list, remove the n-th node from the end of list and return
 * its head.
 * 
 * Example:
 * 
 * 
 * Given linked list: 1->2->3->4->5, and n = 2.
 * 
 * After removing the second node from the end, the linked list becomes
 * 1->2->3->5.
 * 
 * 
 * Note:
 * 
 * Given n will always be valid.
 * 
 * Follow up:
 * 
 * Could you do this in one pass?
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode header = new ListNode(-1);
        header.next = head;
        ListNode p = header;
        ListNode q = header;
        for(int i = 0; i < n; i++)
        {
            p=p.next;
        }
        while(p.next!=null)
        {
            q=q.next;
            p=p.next;
        }
        q.next = q.next.next;
        return header.next;
    }
}

// √ Accepted
//   √ 208/208 cases passed (108 ms)
//   √ Your runtime beats 44.18 % of csharp submissions
//   √ Your memory usage beats 22.79 % of csharp submissions (22.6 MB)

