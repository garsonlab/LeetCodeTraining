/*
 * @lc app=leetcode id=817 lang=csharp
 *
 * [817] Linked List Components

 We are given head, the head node of a linked list containing unique integer values.

We are also given the list G, a subset of the values in the linked list.

Return the number of connected components in G, where two values are connected if they appear consecutively in the linked list.

Example 1:

Input: 
head: 0->1->2->3
G = [0, 1, 3]
Output: 2
Explanation: 
0 and 1 are connected, so [0, 1] and [3] are the two connected components.
Example 2:

Input: 
head: 0->1->2->3->4
G = [0, 3, 1, 4]
Output: 2
Explanation: 
0 and 1 are connected, 3 and 4 are connected, so [0, 1] and [3, 4] are the two connected components.
Note:

If N is the length of the linked list given by head, 1 <= N <= 10000.
The value of each node in the linked list will be in the range [0, N - 1].
1 <= G.length <= 10000.
G is a subset of all values in the linked list.
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
    public int NumComponents(ListNode head, int[] G) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var i in G)
        {
            int n;
            if (!dic.TryGetValue(i, out n))
                n = 0;
            dic[i] = n + 1;
        }

        int ans = 0;
        bool pre = false;
        ListNode tem = head;
        while (tem != null)
        {
            int n;
            if (dic.TryGetValue(tem.val, out n))
            {
                if (n == 1)
                    dic.Remove(tem.val);
                else
                    dic[tem.val] = n - 1;

                if (!pre)
                {
                    ans++;
                    pre = true;
                }
            }
            else
            {
                pre = false;
            }

            tem = tem.next;
        }

        return ans;
    }
}

// √ Accepted
//   √ 57/57 cases passed (120 ms)
//   √ Your runtime beats 56.12 % of csharp submissions
//   √ Your memory usage beats 13.25 % of csharp submissions (29.6 MB)
