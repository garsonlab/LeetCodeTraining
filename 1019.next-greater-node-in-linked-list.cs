/*
 * @lc app=leetcode id=1019 lang=csharp
 *
 * [1019] Next Greater Node In Linked List

 We are given a linked list with head as the first node.  Let's number the nodes in the list: node_1, node_2, node_3, ... etc.

Each node may have a next larger value: for node_i, next_larger(node_i) is the node_j.val such that j > i, node_j.val > node_i.val, and j is the smallest possible choice.  If such a j does not exist, the next larger value is 0.

Return an array of integers answer, where answer[i] = next_larger(node_{i+1}).

Note that in the example inputs (not outputs) below, arrays such as [2,1,5] represent the serialization of a linked list with a head node value of 2, second node value of 1, and third node value of 5.

 

Example 1:

Input: [2,1,5]
Output: [5,5,0]
Example 2:

Input: [2,7,4,3,5]
Output: [7,0,5,5,0]
Example 3:

Input: [1,7,5,1,9,2,5,1]
Output: [7,9,9,9,0,5,0,0]
 

Note:

1 <= node.val <= 10^9 for each node in the linked list.
The given list has length in the range [0, 10000].
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
    public int[] NextLargerNodes(ListNode head) {
        List<int> res = new List<int>();
        Stack<int> mem = new Stack<int>();
        int i = 0;

        while (head != null)
        {
            while (mem.Count > 0 && head.val > res[mem.Peek()])
            {
                res[mem.Pop()] = head.val;
            }

            res.Add(head.val);
            mem.Push(i++);
            head = head.next;
        }

        while (mem.Count > 0)
        {
            res[mem.Pop()] = 0;
        }

        return res.ToArray();
    }
}

// √ Accepted
//   √ 76/76 cases passed (392 ms)
//   √ Your runtime beats 27.91 % of csharp submissions
//   √ Your memory usage beats 14.38 % of csharp submissions (46.9 MB)

