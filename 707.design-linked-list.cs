/*
 * @lc app=leetcode id=707 lang=csharp
 *
 * [707] Design Linked List
 *
 * https://leetcode.com/problems/design-linked-list/description/
 *
 * algorithms
 * Easy (23.43%)
 * Total Accepted:    23K
 * Total Submissions: 96.8K
 * Testcase Example:  '["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"]\n[[],[1],[3],[1,2],[1],[1],[1]]'
 *
 * Design your implementation of the linked list. You can choose to use the
 * singly linked list or the doubly linked list. A node in a singly linked list
 * should have two attributes: val and next. val is the value of the current
 * node, and next is a pointer/reference to the next node. If you want to use
 * the doubly linked list, you will need one more attribute prev to indicate
 * the previous node in the linked list. Assume all nodes in the linked list
 * are 0-indexed.
 * 
 * Implement these functions in your linked list class:
 * 
 * 
 * get(index) : Get the value of the index-th node in the linked list. If the
 * index is invalid, return -1.
 * addAtHead(val) : Add a node of value val before the first element of the
 * linked list. After the insertion, the new node will be the first node of the
 * linked list.
 * addAtTail(val) : Append a node of value val to the last element of the
 * linked list.
 * addAtIndex(index, val) : Add a node of value val before the index-th node in
 * the linked list. If index equals to the length of linked list, the node will
 * be appended to the end of linked list. If index is greater than the length,
 * the node will not be inserted.
 * deleteAtIndex(index) : Delete the index-th node in the linked list, if the
 * index is valid.
 * 
 * 
 * Example:
 * 
 * 
 * MyLinkedList linkedList = new MyLinkedList();
 * linkedList.addAtHead(1);
 * linkedList.addAtTail(3);
 * linkedList.addAtIndex(1, 2);  // linked list becomes 1->2->3
 * linkedList.get(1);            // returns 2
 * linkedList.deleteAtIndex(1);  // now the linked list is 1->3
 * linkedList.get(1);            // returns 3
 * 
 * 
 * Note:
 * 
 * 
 * All values will be in the range of [1, 1000].
 * The number of operations will be in the range of [1, 1000].
 * Please do not use the built-in LinkedList library.
 * 
 * 
 */
public class MyLinkedList
{
    int[] nums = new int[1000];
    int count = 0;

    /** Initialize your data structure here. */
    public MyLinkedList()
    {

    }

    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index)
    {
        if (count > index)
            return nums[index];
        return -1;
    }

    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val)
    {
        for (int i = count-1; i >= 0; i--)
        {
            nums[i + 1] = nums[i];
        }

        nums[0] = val;
        count++;
    }

    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val)
    {
        nums[count++] = val;
    }

    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val)
    {
        if (index > count)
            return;
        for (int i = count - 1; i >= index; i--)
        {
            nums[i + 1] = nums[i];
        }

        nums[index] = val;
        count++;
    }

    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index)
    {
        if(index >= count)
            return;
        for (int i = index; i < count-1; i++)
        {
            nums[i] = nums[i + 1];
        }

        nums[count - 1] = 0;
        count--;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */


//  √ Accepted
//   √ 53/53 cases passed (164 ms)
//   √ Your runtime beats 89.7 % of csharp submissions
//   √ Your memory usage beats 45.83 % of csharp submissions (35.1 MB)

