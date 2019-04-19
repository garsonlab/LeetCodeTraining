/*
 * @lc app=leetcode id=147 lang=csharp
 *
 * [147] Insertion Sort List
 *
 * https://leetcode.com/problems/insertion-sort-list/description/
 *
 * algorithms
 * Medium (36.79%)
 * Total Accepted:    145.9K
 * Total Submissions: 395.7K
 * Testcase Example:  '[4,2,1,3]'
 *
 * Sort a linked list using insertion sort.
 * 
 * 
 * 
 * 
 * 
 * A graphical example of insertion sort. The partial sorted list (black)
 * initially contains only the first element in the list.
 * With each iteration one element (red) is removed from the input data and
 * inserted in-place into the sorted list
 * 
 * 
 * 
 * 
 * 
 * Algorithm of Insertion Sort:
 * 
 * 
 * Insertion sort iterates, consuming one input element each repetition, and
 * growing a sorted output list.
 * At each iteration, insertion sort removes one element from the input data,
 * finds the location it belongs within the sorted list, and inserts it
 * there.
 * It repeats until no input elements remain.
 * 
 * 
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
    public ListNode InsertionSortList(ListNode head) {
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

// √ Accepted
//   √ 22/22 cases passed (128 ms)
//   √ Your runtime beats 75 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (23.4 MB)

