/*
 * @lc app=leetcode id=851 lang=csharp
 *
 * [851] Loud and Rich

 In a group of N people (labelled 0, 1, 2, ..., N-1), each person has different amounts of money, and different levels of quietness.

For convenience, we'll call the person with label x, simply "person x".

We'll say that richer[i] = [x, y] if person x definitely has more money than person y.  Note that richer may only be a subset of valid observations.

Also, we'll say quiet[x] = q if person x has quietness q.

Now, return answer, where answer[x] = y if y is the least quiet person (that is, the person y with the smallest value of quiet[y]), among all people who definitely have equal to or more money than person x.

 

Example 1:

Input: richer = [[1,0],[2,1],[3,1],[3,7],[4,3],[5,3],[6,3]], quiet = [3,2,5,4,6,1,7,0]
Output: [5,5,2,5,4,5,6,7]
Explanation: 
answer[0] = 5.
Person 5 has more money than 3, which has more money than 1, which has more money than 0.
The only person who is quieter (has lower quiet[x]) is person 7, but
it isn't clear if they have more money than person 0.

answer[7] = 7.
Among all people that definitely have equal to or more money than person 7
(which could be persons 3, 4, 5, 6, or 7), the person who is the quietest (has lower quiet[x])
is person 7.

The other answers can be filled out with similar reasoning.
Note:

1 <= quiet.length = N <= 500
0 <= quiet[i] < N, all quiet[i] are different.
0 <= richer.length <= N * (N-1) / 2
0 <= richer[i][j] < N
richer[i][0] != richer[i][1]
richer[i]'s are all different.
The observations in richer are all logically consistent.
 */
public class Solution {
    public int[] LoudAndRich(int[][] richer, int[] quiet) {
        List<int>[] map = new List<int>[quiet.Length];
        int[] res = new int[quiet.Length];

        for (int i = 0; i < quiet.Length; i++)
        {
            map[i] = new List<int>();
            res[i] = -1;
        }
        foreach (int[] r in richer)
        {
            map[r[1]].Add(r[0]);
        }

        for (int i = 0; i < quiet.Length; i++)
        {
            dfs(i, map, res, quiet);
        }
        return res;

    }

    private int dfs(int i, List<int>[] map, int[] res, int[] quiet)
    {
        if (res[i] >= 0) return res[i];
        res[i] = i;
        foreach (int j in map[i])
        {
            if (quiet[res[i]] > quiet[dfs(j, map, res, quiet)])
            {
                res[i] = res[j];
            }
        }
        return res[i];
    }
}

// √ Accepted
//   √ 86/86 cases passed (472 ms)
//   √ Your runtime beats 6.67 % of csharp submissions
//   √ Your memory usage beats 58.33 % of csharp submissions (41.3 MB)

