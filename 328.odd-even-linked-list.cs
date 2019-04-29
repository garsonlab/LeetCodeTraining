/*
 * @lc app=leetcode id=328 lang=csharp
 *
 * [328] Odd Even Linked List

 Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.

Example 1:

Input: 1->2->3->4->5->NULL
Output: 1->3->5->2->4->NULL
Example 2:

Input: 2->1->3->5->6->4->7->NULL
Output: 2->3->6->7->1->5->4->NULL
Note:

The relative order inside both the even and odd groups should remain as it was in the input.
The first node is considered odd, the second node even and so on ...
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
    public ListNode OddEvenList(ListNode head) {
        ListNode s = new ListNode(-1);
        ListNode d = new ListNode(-1);
        ListNode sc = s, dc = d;

        int idx = 1;
        while (head != null)
        {
            var tem = head.next;
            head.next = null;
            if (idx++ % 2 == 1)
            {
                sc.next = head;
                sc = head;
            }
            else
            {
                dc.next = head;
                dc = head;
            }

            head = tem;
        }

        sc.next = d.next;
        return s.next;
    }
}

// √ Accepted
//   √ 71/71 cases passed (96 ms)
//   √ Your runtime beats 84.99 % of csharp submissions
//   √ Your memory usage beats 71.43 % of csharp submissions (23.5 MB)

