/*
 * @lc app=leetcode id=234 lang=csharp
 *
 * [234] Palindrome Linked List
 *
 * https://leetcode.com/problems/palindrome-linked-list/description/
 *
 * algorithms
 * Easy (35.48%)
 * Total Accepted:    240.5K
 * Total Submissions: 676.9K
 * Testcase Example:  '[1,2]'
 *
 * Given a singly linked list, determine if it is a palindrome.
 * 
 * Example 1:
 * 
 * 
 * Input: 1->2
 * Output: false
 * 
 * Example 2:
 * 
 * 
 * Input: 1->2->2->1
 * Output: true
 * 
 * Follow up:
 * Could you do it in O(n) time and O(1) space?
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
    public bool IsPalindrome(ListNode head) {
        int len = 0;
        ListNode tem = head;
        while (tem != null)
        {
            len++;
            tem = tem.next;
        }

        if (len <= 1)
            return true;

        int mid = (len + 1) / 2;
        int n = 0;
        ListNode tail = null;
        tem = head;
        while (tem != null)
        {
            if (n == mid)
            {
                tail = tem;
                tem = tem.next;
                tail.next = null;
            }
            else if (n > mid)
            {
                var t = tem.next;
                tem.next = tail;
                tail = tem;
                tem = t;
            }
            else
            {
                tem = tem.next;
            }
            n++;
        }

        while (head != null && tail != null)
        {
            if (head.val != tail.val)
                return false;
            head = head.next;
            tail = tail.next;
        }

        return true;
    }
}

// √ Accepted
//   √ 26/26 cases passed (100 ms)
//   √ Your runtime beats 99.81 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (25.8 MB)


