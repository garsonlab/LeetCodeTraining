/*
 * @lc app=leetcode id=402 lang=csharp
 *
 * [402] Remove K Digits

 Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.

Note:
The length of num is less than 10002 and will be ≥ k.
The given num does not contain any leading zero.
Example 1:

Input: num = "1432219", k = 3
Output: "1219"
Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
Example 2:

Input: num = "10200", k = 1
Output: "200"
Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.
Example 3:

Input: num = "10", k = 2
Output: "0"
Explanation: Remove all the digits from the number and it is left with nothing which is 0.
 */
public class Solution {
    public string RemoveKdigits(string num, int k) {
        if (k >= num.Length || num.Length <= 0)
            return "0";

        Stack<char> stack = new Stack<char>();
        stack.Push(num[0]);

        for (int i = 1; i < num.Length; i++)
        {
            char c = num[i];

            //可能好几个值都比当前值大，那么我们就在k允许的情况下，去去除它。
            while (stack.Count > 0 && k > 0 && c < stack.Peek())
            {
                stack.Pop();
                k--;
            }

            if(c != '0' || stack.Count > 0)
                stack.Push(c);
        }

        while (k > 0)
        {
            stack.Pop();
            k--;
        }

        if(stack.Count <= 0)
            return "0";
        
        string res = "";
        while (stack.Count > 0)
        {
            res = stack.Pop() + res;
        }
        return res;
    }
}

// √ Accepted
//   √ 33/33 cases passed (364 ms)
//   √ Your runtime beats 9.36 % of csharp submissions
//   √ Your memory usage beats 28.57 % of csharp submissions (44.9 MB)

