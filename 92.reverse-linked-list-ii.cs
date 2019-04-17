/*
 * @lc app=leetcode id=92 lang=csharp
 *
 * [92] Reverse Linked List II
 *
 * https://leetcode.com/problems/reverse-linked-list-ii/description/
 *
 * algorithms
 * Medium (34.49%)
 * Total Accepted:    187.3K
 * Total Submissions: 542.3K
 * Testcase Example:  '[1,2,3,4,5]\n2\n4'
 *
 * Reverse a linked list from position m to n. Do it in one-pass.
 * 
 * Note: 1 ≤ m ≤ n ≤ length of list.
 * 
 * Example:
 * 
 * 
 * Input: 1->2->3->4->5->NULL, m = 2, n = 4
 * Output: 1->4->3->2->5->NULL
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
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        ListNode root = new ListNode(-1);
        root.next = head;

        int idx = 0;
        ListNode pre = null;
        ListNode last = null;
        ListNode cur = root;

        while (cur != null)
        {
            if (idx < m)
            {
                if (idx == m - 1)
                {
                    pre = cur;
                    cur = cur.next;
                    pre.next = null;
                    idx++;
                }
                else
                {
                    cur = cur.next;
                    idx++;
                }
            }
            else if (idx <= n)
            {
                if (idx == m)
                    last = cur;

                var tem = cur.next;
                cur.next = pre.next;
                pre.next = cur;
                cur = tem;
                idx++;
            }
            else
            {
                last.next = cur;
                break;
            }
        }

        return root.next;
    }
}

// √ Accepted
//   √ 44/44 cases passed (92 ms)
//   √ Your runtime beats 88.64 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (21.9 MB)

