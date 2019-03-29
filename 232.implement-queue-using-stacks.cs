/*
 * @lc app=leetcode id=232 lang=csharp
 *
 * [232] Implement Queue using Stacks
 *
 * https://leetcode.com/problems/implement-queue-using-stacks/description/
 *
 * algorithms
 * Easy (42.35%)
 * Total Accepted:    141.6K
 * Total Submissions: 333.4K
 * Testcase Example:  '["MyQueue","push","push","peek","pop","empty"]\n[[],[1],[2],[],[],[]]'
 *
 * Implement the following operations of a queue using stacks.
 * 
 * 
 * push(x) -- Push element x to the back of queue.
 * pop() -- Removes the element from in front of queue.
 * peek() -- Get the front element.
 * empty() -- Return whether the queue is empty.
 * 
 * 
 * Example:
 * 
 * 
 * MyQueue queue = new MyQueue();
 * 
 * queue.push(1);
 * queue.push(2);  
 * queue.peek();  // returns 1
 * queue.pop();   // returns 1
 * queue.empty(); // returns false
 * 
 * Notes:
 * 
 * 
 * You must use only standard operations of a stack -- which means only push to
 * top, peek/pop from top, size, and is empty operations are valid.
 * Depending on your language, stack may not be supported natively. You may
 * simulate a stack by using a list or deque (double-ended queue), as long as
 * you use only standard operations of a stack.
 * You may assume that all operations are valid (for example, no pop or peek
 * operations will be called on an empty queue).
 * 
 * 
 */
public class MyQueue {

     private readonly Stack<int> stack;
    private readonly Stack<int> assist;

    /** Initialize your data structure here. */
    public MyQueue()
    {
        stack = new Stack<int>();
        assist = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        while (stack.Count > 0)
        {
            assist.Push(stack.Pop());
        }
        stack.Push(x);

        while (assist.Count > 0)
        {
            stack.Push(assist.Pop());
        }
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        return stack.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        return stack.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return stack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

// √ Accepted
//   √ 17/17 cases passed (104 ms)
//   √ Your runtime beats 97.64 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (22.1 MB)



