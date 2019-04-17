/*
 * @lc app=leetcode id=82 lang=csharp
 *
 * [82] Remove Duplicates from Sorted List II
 *
 * https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/description/
 *
 * algorithms
 * Medium (32.58%)
 * Total Accepted:    175.6K
 * Total Submissions: 538.4K
 * Testcase Example:  '[1,2,3,3,4,4,5]'
 *
 * Given a sorted linked list, delete all nodes that have duplicate numbers,
 * leaving only distinct numbers from the original list.
 * 
 * Example 1:
 * 
 * 
 * Input: 1->2->3->3->4->4->5
 * Output: 1->2->5
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 1->1->1->2->3
 * Output: 2->3
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
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null)
            return head;

        ListNode root = new ListNode(-1);

        ListNode cur = root;
        ListNode pre = head;
        ListNode tem = head.next;
        bool same = false;

        while (tem != null)
        {
            if (tem.val != pre.val)
            {
                if (!same)
                {
                    cur.next = pre;
                    cur = pre;
                    cur.next = null;
                }

                same = false;
                pre = tem;
            }
            else
                same = true;
            tem = tem.next;
        }
        if (!same)
        {
            cur.next = pre;
            cur = pre;
            cur.next = null;
        }

        return root.next;
    }
}

// √ Accepted
//   √ 168/168 cases passed (112 ms)
//   √ Your runtime beats 31.42 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (23.6 MB)

