/*
 * @lc app=leetcode id=365 lang=csharp
 *
 * [365] Water and Jug Problem

 You are given two jugs with capacities x and y litres. There is an infinite amount of water supply available. You need to determine whether it is possible to measure exactly z litres using these two jugs.

If z liters of water is measurable, you must have z liters of water contained within one or both buckets by the end.

Operations allowed:

Fill any of the jugs completely with water.
Empty any of the jugs.
Pour water from one jug into another till the other jug is completely full or the first jug itself is empty.
Example 1: (From the famous "Die Hard" example)

Input: x = 3, y = 5, z = 4
Output: True
Example 2:

Input: x = 2, y = 6, z = 5
Output: False
 */
public class Solution {
    public bool CanMeasureWater(int x, int y, int z)
    {
        if (z < 0 || z > x + y)
            return false;
        if (z == 0 || z == x || z == y)
            return true;
        int g = GDC(x, y);
        return g != 0 && z % g == 0;
    }

    private int GDC(int a, int b)
    {
        if (a == 0 || b == 0)
            return 0;
        if (a == b)
            return a;

        if (a > b)
            return GDC(b, a - b);
        return GDC(a, b - a);
    }
}
//ax+by=z,故z可整除x\y的最大公约数
// √ Accepted
//   √ 34/34 cases passed (40 ms)
//   √ Your runtime beats 61.36 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (16.9 MB)

