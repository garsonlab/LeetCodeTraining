/*
 * @lc app=leetcode id=223 lang=csharp
 *
 * [223] Rectangle Area

    Find the total area covered by two rectilinear rectangles in a 2D plane.

    Each rectangle is defined by its bottom left corner and top right corner as shown in the figure.

    Rectangle Area

    Example:

    Input: A = -3, B = 0, C = 3, D = 4, E = 0, F = -1, G = 9, H = 2
    Output: 45
    Note:

    Assume that the total area is never beyond the maximum possible value of int.

 */
public class Solution {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        int con = 0;
        if (A >= G || E >= C || B >= H || F >= D)
        {
            con = 0;
        }
        else
        {
            int a = Math.Max(A, E);
            int b = Math.Max(B, F);

            int c = Math.Min(C, G);
            int d = Math.Min(D, H);
            con = (c - a) * (d - b);
        }

        return (C - A) * (D - B) + (G - E) * (H - F) - con;
    }
}

// √ Accepted
//   √ 3082/3082 cases passed (56 ms)
//   √ Your runtime beats 54.9 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (13.9 MB)

