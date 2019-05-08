/*
 * @lc app=leetcode id=593 lang=csharp
 *
 * [593] Valid Square

 Given the coordinates of four points in 2D space, return whether the four points could construct a square.

The coordinate (x,y) of a point is represented by an integer array with two integers.

Example:
Input: p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
Output: True
Note:

All the input integers are in the range [-10000, 10000].
A valid square has four equal sides with positive length and four equal angles (90-degree angles).
Input points have no order.
 */
public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        double x1 = (p1[0] + p2[0]) * 0.5;
        double y1 = (p1[1] + p2[1]) * 0.5;
        double x2 = (p3[0] + p4[0]) * 0.5;
        double y2 = (p3[1] + p4[1]) * 0.5;

        p1[0] = p2[0] - p1[0];
        p1[1] = p2[1] - p1[1];


        p3[0] = p4[0] - p3[0];
        p3[1] = p4[1] - p3[1];

        if (p1[0] == 0 && p1[1] == 0)//0
            return false;
        if (p3[0] == 0 && p3[1] == 0)
            return false;

        if (p1[0] * p1[0] + p1[1] * p1[1] != p3[0] * p3[0] + p3[1] * p3[1]) //len
            return false;

        if (p1[0] * p3[0] + p1[1] * p3[1] == 0) //T
        {
            return x1 == x2 && y1 == y2;
        }

        if (p1[0] == p3[0] || p1[1] == p3[1] ||  p1[0] * 1.0 / p3[0] == p1[1] * 1.0 / p3[1]) // ||
        {
            double temx = x1 - x2;
            double temy = y1 - y2;
            if (p1[0] * p1[0] + p1[1] * p1[1] != temx * temx + temy * temy) //len
                return false;

            return temx * p3[0] + temy * p3[1] == 0;
        }

        return false;
    }
}


// √ Accepted
//   √ 244/244 cases passed (96 ms)
//   √ Your runtime beats 60.61 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (24.7 MB)
