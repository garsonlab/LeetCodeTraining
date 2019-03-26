/*
 * @lc app=leetcode id=155 lang=csharp
 *
 * [155] Min Stack
 *
 * https://leetcode.com/problems/min-stack/description/
 *
 * algorithms
 * Easy (35.99%)
 * Total Accepted:    278.4K
 * Total Submissions: 772.1K
 * Testcase Example:  '["MinStack","push","push","push","getMin","pop","top","getMin"]\n[[],[-2],[0],[-3],[],[],[],[]]'
 *
 * 
 * Design a stack that supports push, pop, top, and retrieving the minimum
 * element in constant time.
 * 
 * 
 * push(x) -- Push element x onto stack.
 * 
 * 
 * pop() -- Removes the element on top of the stack.
 * 
 * 
 * top() -- Get the top element.
 * 
 * 
 * getMin() -- Retrieve the minimum element in the stack.
 * 
 * 
 * 
 * 
 * Example:
 * 
 * MinStack minStack = new MinStack();
 * minStack.push(-2);
 * minStack.push(0);
 * minStack.push(-3);
 * minStack.getMin();   --> Returns -3.
 * minStack.pop();
 * minStack.top();      --> Returns 0.
 * minStack.getMin();   --> Returns -2.
 * 
 * 
 */
public class MinStack {

    const int stackSize = 1024;
    int[] stack;
    int[] min;
    int count;

    /** initialize your data structure here. */
    public MinStack() {
        stack = new int[stackSize];
        min = new int[stackSize];
        count = 0;
    }
    
    public void Push(int x) {
        if(count+1 >= stackSize)
            return;
        
        if(count > 0) {
            min[count] = min[count-1] < x? min[count-1]: x;
        }else {
            min[count] = x;
        }

        stack[count++] = x;
    }
    
    public void Pop() {
        if(count > 0)
            count--;
    }
    
    public int Top() {
        if(count <= 0)
            return 0;
        
        return stack[count-1];
    }
    
    public int GetMin() {
        if(count <= 0)
            return 0;
        return min[count-1];
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

// √ Accepted
//   √ 18/18 cases passed (132 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 81.63 % of csharp submissions (33.3 MB)


