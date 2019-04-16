/*
 * @lc app=leetcode id=61 lang=csharp
 *
 * [61] Rotate List
 *
 * https://leetcode.com/problems/rotate-list/description/
 *
 * algorithms
 * Medium (26.83%)
 * Total Accepted:    185.5K
 * Total Submissions: 690.8K
 * Testcase Example:  '[1,2,3,4,5]\n2'
 *
 * Given a linked list, rotate the list to the right by k places, where k is
 * non-negative.
 * 
 * Example 1:
 * 
 * 
 * Input: 1->2->3->4->5->NULL, k = 2
 * Output: 4->5->1->2->3->NULL
 * Explanation:
 * rotate 1 steps to the right: 5->1->2->3->4->NULL
 * rotate 2 steps to the right: 4->5->1->2->3->NULL
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 0->1->2->NULL, k = 4
 * Output: 2->0->1->NULL
 * Explanation:
 * rotate 1 steps to the right: 2->0->1->NULL
 * rotate 2 steps to the right: 1->2->0->NULL
 * rotate 3 steps to the right: 0->1->2->NULL
 * rotate 4 steps to the right: 2->0->1->NULL
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
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || k == 0)
            return head;

        int len = 0;
        ListNode root = new ListNode(-1);
        int aa = 0;

        ListNode cur = head;
        while (cur != null)
        {
            var t = cur.next;
            cur.next = root.next;
            root.next = cur;
            len++;
            cur = t;
        }
        

        k %= len;
        if (k == 0)
        {
            cur = root.next;
            root.next = null;
            while (cur != null)
            {
                var t = cur.next;
                cur.next = root.next;
                root.next = cur;
                cur = t;
            }

            return root.next;
        }


        ListNode pre = root.next;
        cur = root.next;
        root.next = null;
        while (k-- > 0)
        {
            var t = cur.next;
            cur.next = root.next;
            root.next = cur;
            cur = t;
        }

        pre.next = null;
        while (cur != null)
        {
            var t = cur.next;
            cur.next = pre.next;
            pre.next = cur;
            cur = t;
        }

        return root.next;
    }
}

// √ Accepted
//   √ 231/231 cases passed (96 ms)
//   √ Your runtime beats 71.88 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (23.2 MB)

