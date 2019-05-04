/*
 * @lc app=leetcode id=445 lang=csharp
 *
 * [445] Add Two Numbers II

 You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Follow up:
What if you cannot modify the input lists? In other words, reversing the lists is not allowed.

Example:

Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 8 -> 0 -> 7
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
        if(l1 == null)
            return l2;
        if(l2 == null)
            return l1;

        l1 = Reverse(l1);
        l2 = Reverse(l2);

        int add = 0;
        ListNode root = null;
        while (l1 != null && l2 != null)
        {
            int v = l1.val+l2.val+add;

            var node = new ListNode(v%10);
            add = v/10;

            if(root == null)
                root = node;
            else {
                node.next = root;
                root = node;
            }

            l1 = l1.next;
            l2 = l2.next;
        }

        while (l1 != null)
        {
            int v = l1.val+add;
            var node = new ListNode(v%10);
            add = v/10;

            node.next = root;
            root = node;
            l1 = l1.next;
        }

        while (l2 != null)
        {
            int v = l2.val+add;
            var node = new ListNode(v%10);
            add = v/10;

            node.next = root;
            root = node;
            l2 = l2.next;
        }

        if (add > 0)
        {
            var node = new ListNode(add%10);
            node.next = root;
            root = node;
        }
        return root;
    }

    private ListNode Reverse(ListNode node) {
        ListNode root = node;
        node = node.next;
        root.next = null;

        while (node != null)
        {
            var tem = node.next;
            node.next = root;
            root = node;

            node = tem;
        }
        return root;
    }
}

// √ Accepted
//   √ 1563/1563 cases passed (108 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (25.5 MB)

