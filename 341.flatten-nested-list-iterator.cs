/*
 * @lc app=leetcode id=341 lang=csharp
 *
 * [341] Flatten Nested List Iterator

 Given a nested list of integers, implement an iterator to flatten it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Example 1:

Input: [[1,1],2,[1,1]]
Output: [1,1,2,1,1]
Explanation: By calling next repeatedly until hasNext returns false, 
             the order of elements returned by next should be: [1,1,2,1,1].
Example 2:

Input: [1,[4,[6]]]
Output: [1,4,6]
Explanation: By calling next repeatedly until hasNext returns false, 
             the order of elements returned by next should be: [1,4,6].
 */
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {

    private Stack<int> stack;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            stack = new Stack<int>();
            Parse(nestedList);
        }

        private void Parse(IList<NestedInteger> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].IsInteger())
                    stack.Push(list[i].GetInteger());
                else
                {
                    var t = list[i].GetList();
                    Parse(t);
                }
            }
        }


        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public int Next()
        {
            return stack.Pop();
        }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */

//  √ Accepted
//   √ 44/44 cases passed (244 ms)
//   √ Your runtime beats 91.11 % of csharp submissions
//   √ Your memory usage beats 8.33 % of csharp submissions (30.1 MB)

