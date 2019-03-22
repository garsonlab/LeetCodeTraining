/*
 * @lc app=leetcode id=2 lang=csharp
 *
 * [2] Add Two Numbers
 *
 * https://leetcode.com/problems/add-two-numbers/description/
 *
 * algorithms
 * Medium (30.75%)
 * Total Accepted:    798.1K
 * Total Submissions: 2.6M
 * Testcase Example:  '[2,4,3]\n[5,6,4]'
 *
 * You are given two non-empty linked lists representing two non-negative
 * integers. The digits are stored in reverse order and each of their nodes
 * contain a single digit. Add the two numbers and return it as a linked list.
 * 
 * You may assume the two numbers do not contain any leading zero, except the
 * number 0 itself.
 * 
 * Example:
 * 
 * 
 * Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
 * Output: 7 -> 0 -> 8
 * Explanation: 342 + 465 = 807.
 * 
 * [9]\n[1,9,9,9,9,9,9,9,9,9][5]\n[5]
 * [1,8]\n[0]
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int add = 0, r = 0;
        ListNode node = null;
        ListNode tem = null;
        while (l1 != null || l2 != null)
        {
            r = (l1!=null?l1.val:0) + (l2!=null?l2.val:0) + add;
            add = r/10;

            var n = new ListNode(r%10);

            if (node == null)
            {
                node = n;
                tem = n;
            }
            else
            {
                tem.next = n;
                tem = n;
            }
            l1 = l1!=null?l1.next:null;
            l2 = l2!=null?l2.next:null;
        }
        if (add > 0)
        {
            var m = new ListNode(add);
            tem.next = m;
        }
        return node;
    }
}

