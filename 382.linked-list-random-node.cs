/*
 * @lc app=leetcode id=382 lang=csharp
 *
 * [382] Linked List Random Node

 Given a singly linked list, return a random node's value from the linked list. Each node must have the same probability of being chosen.

Follow up:
What if the linked list is extremely large and its length is unknown to you? Could you solve this efficiently without using extra space?

Example:

// Init a singly linked list [1,2,3].
ListNode head = new ListNode(1);
head.next = new ListNode(2);
head.next.next = new ListNode(3);
Solution solution = new Solution(head);

// getRandom() should return either 1, 2, or 3 randomly. Each element should have equal probability of returning.
solution.getRandom();
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

    ListNode head;
    Random random;
    /** @param head The linked list's head.
        Note that the head is guaranteed to be not null, so it contains at least one node. */
    public Solution(ListNode head) {
        this.head = head;
        random = new Random();

    }
    
    /** Returns a random node's value. */
    public int GetRandom() {
        ListNode tem = head;
        int res = head.val;
        for (int i = 0; tem != null; i++)
        {
            if(random.Next(i+1) == i)
                res = tem.val;
            tem = tem.next;
        }
        return res;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */

//  √ Accepted
//   √ 7/7 cases passed (140 ms)
//   √ Your runtime beats 71.43 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (34 MB)

