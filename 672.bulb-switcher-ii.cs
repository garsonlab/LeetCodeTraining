/*
 * @lc app=leetcode id=672 lang=csharp
 *
 * [672] Bulb Switcher II

 There is a room with n lights which are turned on initially and 4 buttons on the wall. After performing exactly m unknown operations towards buttons, you need to return how many different kinds of status of the n lights could be.

Suppose n lights are labeled as number [1, 2, 3 ..., n], function of these 4 buttons are given below:

Flip all the lights.
Flip lights with even numbers.
Flip lights with odd numbers.
Flip lights with (3k + 1) numbers, k = 0, 1, 2, ...
 

Example 1:

Input: n = 1, m = 1.
Output: 2
Explanation: Status can be: [on], [off]
 

Example 2:

Input: n = 2, m = 1.
Output: 3
Explanation: Status can be: [on, off], [off, on], [off, off]
 

Example 3:

Input: n = 3, m = 1.
Output: 4
Explanation: Status can be: [off, on, off], [on, off, on], [off, off, off], [off, on, on].
 

Note: n and m both fit in range [0, 1000].
 */
public class Solution {
    public int FlipLights(int n, int m) {
        if (m == 0) return 1;
        if (n == 1) return 2;
        if (n == 2)
        {
            if (m == 1) return 3;
            else
            {
                return 4;
            }
        }
        if (m == 1) return 4;
        if (m == 2) return 7;
        return 8;
    }
}

// 我们将3k+1的值定义为内部值，非3k+1的值定义为外部值，

// 容易发现，当n>=4的时候，内部值和外部值都有计数和偶数，这里还有一个规律，就是对于一组n，m能够得到的灯泡状态，进行奇数次变换或者是偶数次变换之后能够变回开始的状态，因此对于n，m2，m2>=m+2包含n，m的所有状态

// 当n=1的时候，当m=1的时候包含全部两种状态，m=2的时候包含全部两种状态，m>2的时候包含m=1的时候的全部状态，所以返回2

// 当n=2的时候，当m=1的时候包含3种状态，m=2的时候包含4种状态，m=3包含全部状态，m>3的时候包含m=2的全部状态也就是全部2种状态

// 当n>2的时候，当m=1的时候包含7种状态，当m=2的时候包含8种状态，m=3的时候包含全部8种状态，m>3的时候包含m=2的全部状态也就是8种状态
// --------------------- 
// 作者：BoomHusky 
// 来源：CSDN 
// 原文：https://blog.csdn.net/u012737193/article/details/79232716 
// 版权声明：本文为博主原创文章，转载请附上博文链接！

// √ Accepted
//   √ 80/80 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.7 MB)

