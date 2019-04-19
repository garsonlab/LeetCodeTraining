/*
 * @lc app=leetcode id=148 lang=csharp
 *
 * [148] Sort List
 *
 * https://leetcode.com/problems/sort-list/description/
 *
 * algorithms
 * Medium (34.62%)
 * Total Accepted:    178.4K
 * Total Submissions: 513.9K
 * Testcase Example:  '[4,2,1,3]'
 *
 * Sort a linked list in O(n log n) time using constant space complexity.
 * 
 * Example 1:
 * 
 * 
 * Input: 4->2->1->3
 * Output: 1->2->3->4
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: -1->5->3->4->0
 * Output: -1->0->3->4->5
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
    public ListNode SortList(ListNode head) {
        if (head == null)
            return head;

        ListNode root = new ListNode(-1);
        root.next = head;

        ListNode pre = root;
        ListNode p = head;
        ListNode q = root;

        while (p != null)
        {
            q = root;
            bool found = false;

            while (q.next != p)
            {
                if (q.next.val >= p.val)
                {
                    found = true;
                    break;
                }

                q = q.next;
            }

            if (found)
            {
                var tem = p.next;
                pre.next = tem;
                p.next = q.next;
                q.next = p;
                p = tem;

            }
            else
            {
                pre = p;
                p = p.next;
            }
        }

        return root.next;
    }
}
//同147快排完全满足题意要求
// √ Accepted
//   √ 16/16 cases passed (864 ms)
//   √ Your runtime beats 11.24 % of csharp submissions
//   √ Your memory usage beats 65 % of csharp submissions (26.7 MB)

