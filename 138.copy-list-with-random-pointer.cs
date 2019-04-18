/*
 * @lc app=leetcode id=138 lang=csharp
 *
 * [138] Copy List with Random Pointer
 *
 * https://leetcode.com/problems/copy-list-with-random-pointer/description/
 *
 * algorithms
 * Medium (26.43%)
 * Total Accepted:    236.6K
 * Total Submissions: 892.2K
 * Testcase Example:  '{"$id":"1","next":{"$id":"2","next":null,"random":{"$ref":"2"},"val":2},"random":{"$ref":"2"},"val":1}'
 *
 * A linked list is given such that each node contains an additional random
 * pointer which could point to any node in the list or null.
 * 
 * Return a deep copy of the list.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * 
 * Input:
 * 
 * {"$id":"1","next":{"$id":"2","next":null,"random":{"$ref":"2"},"val":2},"random":{"$ref":"2"},"val":1}
 * 
 * Explanation:
 * Node 1's value is 1, both of its next and random pointer points to Node 2.
 * Node 2's value is 2, its next pointer points to null and its random pointer
 * points to itself.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * You must return the copy of the given head as a reference to the cloned
 * list.
 * 
 * 
 */
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(){}
    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
}
*/
public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null)
            return null;

        Queue<Node> queue = new Queue<Node>();
        Node root = new Node();
        root.val = head.val;
        queue.Enqueue(head);

        Dictionary<Node, Node> dic = new Dictionary<Node, Node>(){{head, root}};
        List<Node> cloned = new List<Node>();

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var clone = dic[node];
            cloned.Add(node);

            if (node.next != null)
            {
                Node tem;
                if (!dic.TryGetValue(node.next, out tem))
                {
                    tem = new Node();
                    tem.val = node.next.val;
                    dic[node.next] = tem;
                }

                clone.next = tem;

                if(!cloned.Contains(node.next) && !queue.Contains(node.next))
                    queue.Enqueue(node.next);
            }

            if (node.random != null)
            {
                Node tem;
                if (!dic.TryGetValue(node.random, out tem))
                {
                    tem = new Node();
                    tem.val = node.random.val;
                    dic[node.random] = tem;
                }

                clone.random = tem;

                if (!cloned.Contains(node.random) && !queue.Contains(node.random))
                    queue.Enqueue(node.random);
            }
        }

        return root;
    }
}

// √ Accepted
//   √ 9/9 cases passed (160 ms)
//   √ Your runtime beats 36.07 % of csharp submissions
//   √ Your memory usage beats 5 % of csharp submissions (26.8 MB)

