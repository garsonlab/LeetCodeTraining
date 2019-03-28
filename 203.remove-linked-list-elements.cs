/*
 * @lc app=leetcode id=203 lang=csharp
 *
 * [203] Remove Linked List Elements
 *
 * https://leetcode.com/problems/remove-linked-list-elements/description/
 *
 * algorithms
 * Easy (35.38%)
 * Total Accepted:    212.7K
 * Total Submissions: 600.2K
 * Testcase Example:  '[1,2,6,3,4,5,6]\n6'
 *
 * Remove all elements from a linked list of integers that have value val.
 * 
 * Example:
 * 
 * 
 * Input:  1->2->6->3->4->5->6, val = 6
 * Output: 1->2->3->4->5
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
    public ListNode RemoveElements(ListNode head, int val) {
        while (head != null && head.val == val)
        {
            head = head.next;
        }

        ListNode tem = head;
        while (tem != null && tem.next != null)
        {
            if (tem.next.val == val)
            {
                tem.next = tem.next.next;
            }
            else
            {
                tem = tem.next;
            }
        }

        return head;
    }
}


// √ Accepted
//   √ 65/65 cases passed (112 ms)
//   √ Your runtime beats 64.58 % of csharp submissions
//   √ Your memory usage beats 28 % of csharp submissions (26.1 MB)


