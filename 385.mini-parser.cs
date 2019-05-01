/*
 * @lc app=leetcode id=385 lang=csharp
 *
 * [385] Mini Parser

 Given a nested list of integers represented as a string, implement a parser to deserialize it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Note: You may assume that the string is well-formed:

String is non-empty.
String does not contain white spaces.
String contains only digits 0-9, [, - ,, ].
Example 1:

Given s = "324",

You should return a NestedInteger object which contains a single integer 324.
Example 2:

Given s = "[123,[456,[789]]]",

Return a NestedInteger object containing a nested list with 2 elements:

1. An integer containing value 123.
2. A nested list containing two elements:
    i.  An integer containing value 456.
    ii. A nested list with one element:
         a. An integer containing value 789.
 */
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    public NestedInteger Deserialize(string s)
    {
        Stack<NestedInteger> stack = new Stack<NestedInteger>();
        NestedInteger root = null;
        int tem = 0, flag = 1;
        bool isNum = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                isNum = true;
                tem = tem * 10 + (s[i] - '0');
            }
            else
            {
                if (isNum)
                {
                    if (root == null)
                        root = new NestedInteger(tem * flag);
                    else
                        stack.Peek().Add(new NestedInteger(tem * flag));
                }


                tem = 0;
                flag = 1;
                isNum = false;
            }

            if (s[i] == '[')
            {
                NestedInteger gn = new NestedInteger();
                if (root == null)
                    root = gn;

                if(stack.Count == 0)
                    stack.Push(gn);
                else
                {
                    stack.Peek().Add(gn);
                    stack.Push(gn);
                }
            }
            else if (s[i] == '-')
            {
                isNum = true;
                flag = -1;
            }
            else if(s[i] == ',')
            {
                
            }
            else if (s[i] == ']')
            {
                stack.Pop();
            }
        }

        if (root == null)
        {
            if(isNum)
                root = new NestedInteger(tem*flag);
            else
                root = new NestedInteger();
        }

        return root;
    }

     public class GNestedInteger : NestedInteger
    {
        private int val;
        private List<NestedInteger> list;
        private bool isInt;

        public GNestedInteger()
        {
            this.list = new List<NestedInteger>();
            isInt = false;
        }

        public GNestedInteger(int val)
        {
            this.val = val;
            isInt = true;
        }

        public bool IsInteger()
        {
            return isInt;
        }

        public int GetInteger()
        {
            return val;
        }

        public void SetInteger(int value)
        {
            val = value;
        }

        public IList<NestedInteger> GetList()
        {
            return list;
        }

        public void Add(NestedInteger ni)
        {
            list.Add(ni);
        }
    }

}

// √ Accepted
//   √ 57/57 cases passed (240 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (30.9 MB)

