/*
 * @lc app=leetcode id=142 lang=csharp
 *
 * [142] Linked List Cycle II
 *
 * https://leetcode.com/problems/linked-list-cycle-ii/description/
 *
 * algorithms
 * Medium (31.48%)
 * Total Accepted:    206.4K
 * Total Submissions: 654K
 * Testcase Example:  '[3,2,0,-4]\n1'
 *
 * Given a linked list, return the node where the cycle begins. If there is no
 * cycle, return null.
 * 
 * To represent a cycle in the given linked list, we use an integer pos which
 * represents the position (0-indexed) in the linked list where tail connects
 * to. If pos is -1, then there is no cycle in the linked list.
 * 
 * Note: Do not modify the linked list.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: head = [3,2,0,-4], pos = 1
 * Output: tail connects to node index 1
 * Explanation: There is a cycle in the linked list, where tail connects to the
 * second node.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: head = [1,2], pos = 0
 * Output: tail connects to node index 0
 * Explanation: There is a cycle in the linked list, where tail connects to the
 * first node.
 * 
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: head = [1], pos = -1
 * Output: no cycle
 * Explanation: There is no cycle in the linked list.
 * 
 * 
 * 
 * 
 * 
 * 
 * Follow up:
 * Can you solve it without using extra space?
 * 
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {

    public ListNode DetectCycle(ListNode head)
    {
        if (head == null || head.next == null || head.next.next == null) return null;
        ListNode fast = head.next.next;
        ListNode slow = head.next;
        while (fast != null && fast.next != null && slow != null && fast != slow)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        if (fast != slow) return null;
        ListNode node = head;
        while (node != slow)
        {
            node = node.next;
            slow = slow.next;
        }
        return node;
    }

    public ListNode DetectCycle222(ListNode head) {
        if (head == null || head.next == null)
            return null;

        ListNode fast = head, slow = head;

        while (fast != null && fast.next != null && fast != slow)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        if (fast == null || fast.next == null)//证明是无环的
            return null;


        slow = head;

        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return fast;
    }
}
//起始点A,循环的B,相遇点C, AB=a, BC=b, CB=c 
        // slow=a+b
        // fast=a+b+c
        // fast = 2*slow
        // a+b=c
        // 故最后从起始点开始与从fast的继续能遇到
// √ Accepted
//   √ 16/16 cases passed (96 ms)
//   √ Your runtime beats 98.09 % of csharp submissions
//   √ Your memory usage beats 42.31 % of csharp submissions (23.7 MB)

