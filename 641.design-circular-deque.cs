/*
 * @lc app=leetcode id=641 lang=csharp
 *
 * [641] Design Circular Deque

 Design your implementation of the circular double-ended queue (deque).

Your implementation should support following operations:

MyCircularDeque(k): Constructor, set the size of the deque to be k.
insertFront(): Adds an item at the front of Deque. Return true if the operation is successful.
insertLast(): Adds an item at the rear of Deque. Return true if the operation is successful.
deleteFront(): Deletes an item from the front of Deque. Return true if the operation is successful.
deleteLast(): Deletes an item from the rear of Deque. Return true if the operation is successful.
getFront(): Gets the front item from the Deque. If the deque is empty, return -1.
getRear(): Gets the last item from Deque. If the deque is empty, return -1.
isEmpty(): Checks whether Deque is empty or not. 
isFull(): Checks whether Deque is full or not.
 

Example:

MyCircularDeque circularDeque = new MycircularDeque(3); // set the size to be 3
circularDeque.insertLast(1);			// return true
circularDeque.insertLast(2);			// return true
circularDeque.insertFront(3);			// return true
circularDeque.insertFront(4);			// return false, the queue is full
circularDeque.getRear();  			// return 2
circularDeque.isFull();				// return true
circularDeque.deleteLast();			// return true
circularDeque.insertFront(4);			// return true
circularDeque.getFront();			// return 4
 

Note:

All values will be in the range of [0, 1000].
The number of operations will be in the range of [1, 1000].
Please do not use the built-in Deque library.
 */
public class MyCircularDeque
    {
        private int[] nums;
        private int head, tail, n, count;


        /** Initialize your data structure here. Set the size of the deque to be k. */
        public MyCircularDeque(int k)
        {
            nums = new int[k];
            head = 0;
            tail = 0;
            n = k;
            count = 0;
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (IsFull())
                return false;
            int pre = (head + n - 1) % n;
            nums[pre] = value;
            count++;
            head = pre;
            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (IsFull())
                return false;
            nums[tail] = value;
            tail = (tail + 1) % n;
            count++;
            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (IsEmpty())
                return false;
            head = (head + 1) % n;
            count--;
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (IsEmpty())
                return false;
            tail = (tail + n - 1) % n;
            count--;
            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (IsEmpty())
                return -1;
            return nums[head];
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if (IsEmpty())
                return -1;
            return nums[(tail+n-1)%n];
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            return count == 0;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            return count == n;
        }
    }


/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */


// √ Accepted
//   √ 51/51 cases passed (140 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (33.5 MB)
