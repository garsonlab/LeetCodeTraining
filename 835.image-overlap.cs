/*
 * @lc app=leetcode id=835 lang=csharp
 *
 * [835] Image Overlap

 Two images A and B are given, represented as binary, square matrices of the same size.  (A binary matrix has only 0s and 1s as values.)

We translate one image however we choose (sliding it left, right, up, or down any number of units), and place it on top of the other image.  After, the overlap of this translation is the number of positions that have a 1 in both images.

(Note also that a translation does not include any kind of rotation.)

What is the largest possible overlap?

Example 1:

Input: A = [[1,1,0],
            [0,1,0],
            [0,1,0]]
       B = [[0,0,0],
            [0,1,1],
            [0,0,1]]
Output: 3
Explanation: We slide A to right by 1 unit and down by 1 unit.
Notes: 

1 <= A.length = A[0].length = B.length = B[0].length <= 30
0 <= A[i][j], B[i][j] <= 1
 */
public class Solution {
    public int LargestOverlap(int[][] A, int[][] B) {
        int N = A.Length;
        List<int> LA = new List<int>();
        List<int> LB = new List<int>();
        Dictionary<int, int> count = new Dictionary<int, int>();
        for (int i = 0; i < N * N; ++i)
        {
            if (A[i / N][i % N] == 1) LA.Add(i / N * 100 + i % N);
            if (B[i / N][i % N] == 1) LB.Add(i / N * 100 + i % N);
        }

        foreach (var i in LA)
        {
            foreach (var j in LB)
            {
                if (count.ContainsKey(i - j))
                    count[i - j]++;
                else
                    count[i - j] = 1;
            }
        }

        int res = 0;
        foreach (var i in count.Values)
        {
            res = Math.Max(res, i);
        }
        return res;
    }
}
//找相差位置相同最多的
// √ Accepted
//   √ 49/49 cases passed (184 ms)
//   √ Your runtime beats 46.43 % of csharp submissions
//   √ Your memory usage beats 23.91 % of csharp submissions (24.7 MB)

