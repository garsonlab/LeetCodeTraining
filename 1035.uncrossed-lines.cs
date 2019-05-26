/*
 * @lc app=leetcode id=1035 lang=csharp
 *
 * [1035] Uncrossed Lines

 We write the integers of A and B (in the order they are given) on two separate horizontal lines.

Now, we may draw connecting lines: a straight line connecting two numbers A[i] and B[j] such that:

A[i] == B[j];
The line we draw does not intersect any other connecting (non-horizontal) line.
Note that a connecting lines cannot intersect even at the endpoints: each number can only belong to one connecting line.

Return the maximum number of connecting lines we can draw in this way.

 

Example 1:


Input: A = [1,4,2], B = [1,2,4]
Output: 2
Explanation: We can draw 2 uncrossed lines as in the diagram.
We cannot draw 3 uncrossed lines, because the line from A[1]=4 to B[2]=4 will intersect the line from A[2]=2 to B[1]=2.
Example 2:

Input: A = [2,5,1,2,5], B = [10,5,2,1,5,2]
Output: 3
Example 3:

Input: A = [1,3,7,1,7,5], B = [1,9,2,5,1]
Output: 2
 

Note:

1 <= A.length <= 500
1 <= B.length <= 500
1 <= A[i], B[i] <= 2000
 */
public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B) {
        int x = A.Length;
        int y = B.Length;

        int [,] dp = new int[x+1, y+1];
        for (int i = 1; i <= x; i++)
        {
            for (int j = 1; j <= y; j++)
            {
                if(A[i-1] == B[j-1])
                    dp[i, j] = dp[i-1, j-1]+1;
                else
                    dp[i, j] = Math.Max(dp[i, j-1], dp[i-1, j]);
            }
        }

        return dp[x, y];
    }
}

// 设 A[0] ~ A[x] 与 B[0] ~ B[y] 的最大连线数为 f(x, y)，那么对于任意位置的 f(i, j) 而言：

// 如果 A[i] == B[j]，即 A[i] 和 B[j] 可连线，此时 f(i, j) = f(i - 1, j - 1) + 1
// 如果 A[i] != B[j]，即 A[i] 和 B[j] 不可连线，此时最大连线数取决于 f(i - 1, j) 和 f(i, j - 1) 的较大值
// √ Accepted
//   √ 74/74 cases passed (104 ms)
//   √ Your runtime beats 39.78 % of csharp submissions
//   √ Your memory usage beats 21.67 % of csharp submissions (24.3 MB)
