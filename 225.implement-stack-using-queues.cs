/*
 * @lc app=leetcode id=225 lang=csharp
 *
 * [225] Implement Stack using Queues
 *
 * https://leetcode.com/problems/implement-stack-using-queues/description/
 *
 * algorithms
 * Easy (38.28%)
 * Total Accepted:    122.8K
 * Total Submissions: 319.9K
 * Testcase Example:  '["MyStack","push","push","top","pop","empty"]\n[[],[1],[2],[],[],[]]'
 *
 * Implement the following operations of a stack using queues.
 * 
 * 
 * push(x) -- Push element x onto stack.
 * pop() -- Removes the element on top of the stack.
 * top() -- Get the top element.
 * empty() -- Return whether the stack is empty.
 * 
 * 
 * Example:
 * 
 * 
 * MyStack stack = new MyStack();
 * 
 * stack.push(1);
 * stack.push(2);  
 * stack.top();   // returns 2
 * stack.pop();   // returns 2
 * stack.empty(); // returns false
 * 
 * Notes:
 * 
 * 
 * You must use only standard operations of a queue -- which means only push to
 * back, peek/pop from front, size, and is empty operations are valid.
 * Depending on your language, queue may not be supported natively. You may
 * simulate a queue by using a list or deque (double-ended queue), as long as
 * you use only standard operations of a queue.
 * You may assume that all operations are valid (for example, no pop or top
 * operations will be called on an empty stack).
 * 
 * 
 */
public class MyStack {

    private readonly Queue<int> queue;
    private readonly Queue<int> assist;

    /** Initialize your data structure here. */
    public MyStack()
    {
        queue = new Queue<int>();
        assist = new Queue<int>();
    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
        while (queue.Count > 0)
        {
            assist.Enqueue(queue.Dequeue());
        }
        queue.Enqueue(x);
        while (assist.Count > 0)
        {
            queue.Enqueue(assist.Dequeue());
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        return queue.Dequeue();
    }

    /** Get the top element. */
    public int Top()
    {
        return queue.Peek();
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return queue.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */

// √ Accepted
//   √ 16/16 cases passed (104 ms)
//   √ Your runtime beats 98.09 % of csharp submissions
//   √ Your memory usage beats 80.65 % of csharp submissions (22 MB)


