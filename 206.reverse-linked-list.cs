/*
 * @lc app=leetcode id=206 lang=csharp
 *
 * [206] Reverse Linked List
 *
 * https://leetcode.com/problems/reverse-linked-list/description/
 *
 * algorithms
 * Easy (53.23%)
 * Total Accepted:    539.8K
 * Total Submissions: 1M
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * Reverse a singly linked list.
 * 
 * Example:
 * 
 * 
 * Input: 1->2->3->4->5->NULL
 * Output: 5->4->3->2->1->NULL
 * 
 * 
 * Follow up:
 * 
 * A linked list can be reversed either iteratively or recursively. Could you
 * implement both?
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
    public ListNode ReverseList(ListNode head) {
        if (head == null)
            return head;
        var cur = head.next;
        head.next = null;
        while (cur != null)
        {
            var tem = cur.next;
            cur.next = head;
            head = cur;
            cur = tem;
        }

        return head;
    }
}

// √ Accepted
//   √ 27/27 cases passed (92 ms)
//   √ Your runtime beats 92.95 % of csharp submissions
//   √ Your memory usage beats 66.03 % of csharp submissions (22.2 MB)


