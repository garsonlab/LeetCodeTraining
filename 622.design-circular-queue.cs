/*
 * @lc app=leetcode id=622 lang=csharp
 *
 * [622] Design Circular Queue

 Design your implementation of the circular queue. The circular queue is a linear data structure in which the operations are performed based on FIFO (First In First Out) principle and the last position is connected back to the first position to make a circle. It is also called "Ring Buffer".

One of the benefits of the circular queue is that we can make use of the spaces in front of the queue. In a normal queue, once the queue becomes full, we cannot insert the next element even if there is a space in front of the queue. But using the circular queue, we can use the space to store new values.

Your implementation should support following operations:

MyCircularQueue(k): Constructor, set the size of the queue to be k.
Front: Get the front item from the queue. If the queue is empty, return -1.
Rear: Get the last item from the queue. If the queue is empty, return -1.
enQueue(value): Insert an element into the circular queue. Return true if the operation is successful.
deQueue(): Delete an element from the circular queue. Return true if the operation is successful.
isEmpty(): Checks whether the circular queue is empty or not.
isFull(): Checks whether the circular queue is full or not.
 */
public class MyCircularQueue
{
    private int[] nums;
    private int head, tail, n, count;

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k)
    {
        nums = new int[k];
        head = 0;
        tail = 0;
        n = k;
        count = 0;
    }

    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value)
    {
        if (IsFull())
            return false;
        nums[tail] = value;
        tail = (tail + 1) % n;
        count++;
        return true;
    }

    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue()
    {
        if (IsEmpty())
            return false;
        head = (head + 1) % n;
        count--;
        return true;
    }

    /** Get the front item from the queue. */
    public int Front()
    {
        if (IsEmpty())
            return -1;
        return nums[head];
    }

    /** Get the last item from the queue. */
    public int Rear()
    {
        if (IsEmpty())
            return -1;
            return nums[(tail+n-1)%n];
    }

    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty()
    {
        return count == 0;
    }

    /** Checks whether the circular queue is full or not. */
    public bool IsFull()
    {
        return count == n;
    }
}


/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */


// √ Accepted
//   √ 52/52 cases passed (144 ms)
//   √ Your runtime beats 51.54 % of csharp submissions
//   √ Your memory usage beats 37.5 % of csharp submissions (33.4 MB)
