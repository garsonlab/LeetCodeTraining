/*
 * @lc app=leetcode id=456 lang=csharp
 *
 * [456] 132 Pattern

 Given a sequence of n integers a1, a2, ..., an, a 132 pattern is a subsequence ai, aj, ak such that i < j < k and ai < ak < aj. Design an algorithm that takes a list of n numbers as input and checks whether there is a 132 pattern in the list.

Note: n will be less than 15,000.

Example 1:
Input: [1, 2, 3, 4]

Output: False

Explanation: There is no 132 pattern in the sequence.
Example 2:
Input: [3, 1, 4, 2]

Output: True

Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
Example 3:
Input: [-1, 3, 2, 0]

Output: True

Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].
 */
public class Solution {
    public bool Find132pattern(int[] nums) {
        if (nums.Length < 3)
                return false;

            int third = int.MinValue;
            Stack<int> stack = new Stack<int>();
            for (int i = nums.Length-1; i >= 0; i--)
            {
                if (nums[i] < third)
                    return true;

                // 若当前值大于或等于2则更新2（2为栈中小于当前值的最大元素）
                while (stack.Count > 0 && stack.Peek() < nums[i])
                {
                    third = stack.Pop();
                }
                stack.Push(nums[i]);
            }

            return false;
    }
}


// √ Accepted
//   √ 95/95 cases passed (128 ms)
//   √ Your runtime beats 78.67 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (27.5 MB)
