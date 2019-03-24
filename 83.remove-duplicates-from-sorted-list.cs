/*
 * @lc app=leetcode id=83 lang=csharp
 *
 * [83] Remove Duplicates from Sorted List
 *
 * https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
 *
 * algorithms
 * Easy (42.05%)
 * Total Accepted:    308.7K
 * Total Submissions: 733.8K
 * Testcase Example:  '[1,1,2]'
 *
 * Given a sorted linked list, delete all duplicates such that each element
 * appear only once.
 * 
 * Example 1:
 * 
 * 
 * Input: 1->1->2
 * Output: 1->2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 1->1->2->3->3
 * Output: 1->2->3
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
        {
            return null;
        }

        ListNode root=null, tem=null;
        
        while (head != null)
        {
            if (root == null)
            {
                root = head;
                tem = head;
                head = head.next;
                tem.next = null;
            }
            else
            {
                if (head.val != tem.val)
                {
                    tem.next = head;
                    tem = head;
                }
                head = head.next;
                tem.next = null;
            }
        }

        return root;
    }
}

// √ Accepted
//   √ 165/165 cases passed (92 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 37.21 % of csharp submissions (23.7 MB)

