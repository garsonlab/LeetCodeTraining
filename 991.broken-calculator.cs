/*
 * @lc app=leetcode id=991 lang=csharp
 *
 * [991] Broken Calculator

 On a broken calculator that has a number showing on its display, we can perform two operations:

Double: Multiply the number on the display by 2, or;
Decrement: Subtract 1 from the number on the display.
Initially, the calculator is displaying the number X.

Return the minimum number of operations needed to display the number Y.

 

Example 1:

Input: X = 2, Y = 3
Output: 2
Explanation: Use double operation and then decrement operation {2 -> 4 -> 3}.
Example 2:

Input: X = 5, Y = 8
Output: 2
Explanation: Use decrement and then double {5 -> 4 -> 8}.
Example 3:

Input: X = 3, Y = 10
Output: 3
Explanation:  Use double, decrement and double {3 -> 6 -> 5 -> 10}.
Example 4:

Input: X = 1024, Y = 1
Output: 1023
Explanation: Use decrement operations 1023 times.
 

Note:

1 <= X <= 10^9
1 <= Y <= 10^9
 */
public class Solution {
    public int BrokenCalc(int X, int Y) {
        if (X >= Y)
            return X - Y;

        int res = 0;
        while (X != Y)
        {
            res++;
            if (Y > X && Y % 2 == 0)
                Y = Y / 2;
            else
                Y++;
        }

        return res;
    }
}
// 要增加X只能做乘法操作，要减小X只能做减法。如果X>Y的话，那么只需要一直对X做减法操作直到X=Y为止，operation的次数是X-Y；对于X<Y的情况，我们可以由Y的值反推X，即如果Y是偶数，那么令Y=Y/2，如果Y是奇数，令Y=Y-1，直至Y=X为止。
// √ Accepted
//   √ 84/84 cases passed (72 ms)
//   √ Your runtime beats 5.71 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.6 MB)

