/*
 * @lc app=leetcode id=547 lang=csharp
 *
 * [547] Friend Circles


 There are N students in a class. Some of them are friends, while some are not. Their friendship is transitive in nature. For example, if A is a direct friend of B, and B is a direct friend of C, then A is an indirect friend of C. And we defined a friend circle is a group of students who are direct or indirect friends.

Given a N*N matrix M representing the friend relationship between students in the class. If M[i][j] = 1, then the ith and jth students are direct friends with each other, otherwise not. And you have to output the total number of friend circles among all the students.

Example 1:
Input: 
[[1,1,0],
 [1,1,0],
 [0,0,1]]
Output: 2
Explanation:The 0th and 1st students are direct friends, so they are in a friend circle. 
The 2nd student himself is in a friend circle. So return 2.
Example 2:
Input: 
[[1,1,0],
 [1,1,1],
 [0,1,1]]
Output: 1
Explanation:The 0th and 1st students are direct friends, the 1st and 2nd students are direct friends, 
so the 0th and 2nd students are indirect friends. All of them are in the same friend circle, so return 1.
Note:
N is in range [1,200].
M[i][i] = 1 for all students.
If M[i][j] = 1, then M[j][i] = 1.
 */
public class Solution {
    public int FindCircleNum(int[][] M) {
        if (M.Length <= 1)
            return M.Length;

        int res = 0;
        int m = M.Length;
        List<int> visited = new List<int>();
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < m; i++)
        {
            if(visited.Contains(i))
                continue;

            res++;

            queue.Enqueue(i);
            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                visited.Add(t);

                int[] n = M[t];
                for (int j = 0; j < n.Length; j++)
                {
                    if (n[j] == 1 && !visited.Contains(j) && !queue.Contains(j))
                        queue.Enqueue(j);
                }
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 113/113 cases passed (148 ms)
//   √ Your runtime beats 66.35 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (26.5 MB)

