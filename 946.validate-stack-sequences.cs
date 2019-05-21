/*
 * @lc app=leetcode id=946 lang=csharp
 *
 * [946] Validate Stack Sequences
 Given two sequences pushed and popped with distinct values, return true if and only if this could have been the result of a sequence of push and pop operations on an initially empty stack.

 

Example 1:

Input: pushed = [1,2,3,4,5], popped = [4,5,3,2,1]
Output: true
Explanation: We might do the following sequence:
push(1), push(2), push(3), push(4), pop() -> 4,
push(5), pop() -> 5, pop() -> 3, pop() -> 2, pop() -> 1
Example 2:

Input: pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
Output: false
Explanation: 1 cannot be popped before 2.
 

Note:

0 <= pushed.length == popped.length <= 1000
0 <= pushed[i], popped[i] < 1000
pushed is a permutation of popped.
pushed and popped have distinct values.
 */
public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        if (pushed.Length == 0)
            return true;
        Stack<int> stack = new Stack<int>();
        int idx = 0;
        while (pushed[idx] != popped[0])
            stack.Push(pushed[idx++]);
        idx++;
        for (int i = 1; i < popped.Length; i++)
        {
            if (stack.Count > 0 && stack.Peek() == popped[i])
                stack.Pop();
            else
            {
                while (idx < pushed.Length && pushed[idx++] != popped[i])
                {
                    stack.Push(pushed[idx - 1]);
                }
                if (idx == pushed.Length && pushed[idx - 1] != popped[i])
                    return false;
            }
        }
        return true;
    }
}

// √ Accepted
//   √ 151/151 cases passed (100 ms)
//   √ Your runtime beats 56.32 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (24.7 MB)

