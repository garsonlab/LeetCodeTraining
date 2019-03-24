/*
 * @lc app=leetcode id=21 lang=csharp
 *
 * [21] Merge Two Sorted Lists
 *
 * https://leetcode.com/problems/merge-two-sorted-lists/description/
 *
 * algorithms
 * Easy (46.21%)
 * Total Accepted:    531K
 * Total Submissions: 1.1M
 * Testcase Example:  '[1,2,4]\n[1,3,4]'
 *
 * Merge two sorted linked lists and return it as a new list. The new list
 * should be made by splicing together the nodes of the first two lists.
 * 
 * Example:
 * 
 * Input: 1->2->4, 1->3->4
 * Output: 1->1->2->3->4->4
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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode root = null, cur = null;
        while (l1!=null && l2!=null)
        {
            ListNode tem;
            if (l1.val <= l2.val) {
                tem = l1;
                l1 = l1.next;
            } else {
                tem = l2;
                l2 = l2.next;
            }

            if(root == null){
                root = tem;
            }else {
                cur.next = tem;
            }
            
            cur = tem;
            cur.next = null;
        }

        ListNode left = null;
        if(l1 != null)
            left = l1;
        else if(l2 != null)
            left = l2;
        
        if(left != null)
        {
            if(root == null)
                root = left;
            else
                cur.next = left;
        }
        
        return root;
    }
}

