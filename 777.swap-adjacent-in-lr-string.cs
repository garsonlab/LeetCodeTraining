/*
 * @lc app=leetcode id=777 lang=csharp
 *
 * [777] Swap Adjacent in LR String

 In a string composed of 'L', 'R', and 'X' characters, like "RXXLRXRXL", a move consists of either replacing one occurrence of "XL" with "LX", or replacing one occurrence of "RX" with "XR". Given the starting string start and the ending string end, return True if and only if there exists a sequence of moves to transform one string to the other.

Example:

Input: start = "RXXLRXRXL", end = "XRLXXRRLX"
Output: True
Explanation:
We can transform start to end following these steps:
RXXLRXRXL ->
XRXLRXRXL ->
XRLXRXRXL ->
XRLXXRRXL ->
XRLXXRRLX
Note:

1 <= len(start) = len(end) <= 10000.
Both start and end will only consist of characters in {'L', 'R', 'X'}.
 */
public class Solution {
    public bool CanTransform(string start, string end) {
        Stack<int> s = new Stack<int>();
        for (int i = 0; i < start.Length; i++)
        {
            if (end[i] == 'L') s.Push(1);
            if (start[i] == 'L' && s.Count > 0)
            {
                if (s.Peek() == 1) s.Pop();
                else return false;
            }

            if (start[i] == 'R') s.Push(2);
            if (end[i] == 'R' && s.Count > 0)
            {
                if (s.Peek() == 2) s.Pop();
                else return false;
            }
        }

        return s.Count == 0;
    }
}

// 从两种变换考虑 XL ->LX 意味着只要L左边是X那么L可以移动到左边任意的位置，同理RX->XR意味着R可以移动到右边任意位置。从左往右比较start ，如果i位置上的字符和end上不同 ，如果start上是R，end上是X那么就找到start上右边第一个X，贪心的交换；从右往左考虑不同位置上的L。

// √ Accepted
//   √ 78/78 cases passed (84 ms)
//   √ Your runtime beats 64.18 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.7 MB)

