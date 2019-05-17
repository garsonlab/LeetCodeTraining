/*
 * @lc app=leetcode id=858 lang=csharp
 *
 * [858] Mirror Reflection

 There is a special square room with mirrors on each of the four walls.  Except for the southwest corner, there are receptors on each of the remaining corners, numbered 0, 1, and 2.

The square room has walls of length p, and a laser ray from the southwest corner first meets the east wall at a distance q from the 0th receptor.

Return the number of the receptor that the ray meets first.  (It is guaranteed that the ray will meet a receptor eventually.)

 

Example 1:

Input: p = 2, q = 1
Output: 2
Explanation: The ray meets receptor 2 the first time it gets reflected back to the left wall.


Note:

1 <= p <= 1000
0 <= q <= p
 */
public class Solution {
    public int MirrorReflection(int p, int q) {
        int dist = 0;
        int d = 0;
        int remain;

        while (true)
        {
            d++;
            dist += q;
            remain = dist % (2 * p);

            if (remain == p)
            {
                if (d % 2 == 1)
                    return 1;
                else
                    return 2;
            }
            if (remain == 0)
                return 0;
        }
    }
}

// 如果没有上下两面镜子，光线会一直向上反射，这两面镜子的作用仅仅是改变了光线的走向而已。
// 那么可以这样理解，假设没有上下两面镜子，无限延长左右两边的镜子长度，光线一直向上反射。
// 同时，可以通过光线走过的纵向距离来判断光线是否到达接收点，如果此距离是p的奇数倍，那么光线到达上面的接收器，若此距离是p的偶数倍则光线到到下面的接收器，即接收器0。
// 变量d记录光线与左右镜子接触的次数，同上，可根据d来判断光线到达接收器1和2。如果距离为p的奇数倍且d为奇数，则到达接收器1，若d为偶数则到达接收器2。
// --------------------- 
// 作者：凛寒 
// 来源：CSDN 
// 原文：https://blog.csdn.net/g1269420003/article/details/80851877 
// 版权声明：本文为博主原创文章，转载请附上博文链接！
// √ Accepted
//   √ 69/69 cases passed (40 ms)
//   √ Your runtime beats 35.71 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.6 MB)
