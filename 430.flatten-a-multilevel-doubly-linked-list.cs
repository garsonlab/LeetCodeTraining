/*
 * @lc app=leetcode id=430 lang=csharp
 *
 * [430] Flatten a Multilevel Doubly Linked List

 You are given a doubly linked list which in addition to the next and previous pointers, it could have a child pointer, which may or may not point to a separate doubly linked list. These child lists may have one or more children of their own, and so on, to produce a multilevel data structure, as shown in the example below.

Flatten the list so that all the nodes appear in a single-level, doubly linked list. You are given the head of the first level of the list.

 

Example:

Input:
 1---2---3---4---5---6--NULL
         |
         7---8---9---10--NULL
             |
             11--12--NULL

Output:
1-2-3-7-8-11-12-9-10-4-5-6-NULL
 

Explanation for the above example:

Given the following multilevel doubly linked list:


 

We should return the following flattened doubly linked list:


 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;

    public Node(){}
    public Node(int _val,Node _prev,Node _next,Node _child) {
        val = _val;
        prev = _prev;
        next = _next;
        child = _child;
}
*/
public class Solution {
    public Node Flatten(Node head) {
        if(head == null)
            return head;

        Stack<Node> stack = new Stack<Node>();
        stack.Push(head);

        Node root = null, cur = null;

        while (stack.Count > 0)
        {
            var node = stack.Pop();

            if(root == null)
            {
                root = new Node();
                root.val = node.val;
                cur = root;
            }
            else
            {
                var tem = new Node();
                tem.val = node.val;
                cur.next = tem;
                tem.prev = cur;
                cur = tem;
            }

            if(node.next != null) {
                stack.Push(node.next);
            }

            if(node.child != null) {
                stack.Push(node.child);
            }
        }

        return root;
    }
}


// √ Accepted
//   √ 22/22 cases passed (172 ms)
//   √ Your runtime beats 69.09 % of csharp submissions
//   √ Your memory usage beats 10 % of csharp submissions (29.4 MB)
