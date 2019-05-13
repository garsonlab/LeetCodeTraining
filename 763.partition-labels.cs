/*
 * @lc app=leetcode id=763 lang=csharp
 *
 * [763] Partition Labels

 A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, and return a list of integers representing the size of these parts.

Example 1:
Input: S = "ababcbacadefegdehijhklij"
Output: [9,7,8]
Explanation:
The partition is "ababcbaca", "defegde", "hijhklij".
This is a partition so that each letter appears in at most one part.
A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
Note:

S will have length in range [1, 500].
S will consist of lowercase letters ('a' to 'z') only.
 */
public class Solution {
    public IList<int> PartitionLabels(string S) {
        int[][] range = new int[26][];
        for (int i = 0; i < 26; i++)
        {
            range[i] = new[] {-1, -1};
        }

        for (int i = 0; i < S.Length; i++)
        {
            int idx = S[i] - 'a';
            if (range[idx][0] < 0)
                range[idx][0] = i;
            range[idx][1] = i;
        }

        Array.Sort(range, (a, b) => { return a[0] - b[0]; });

        List<int> ans = new List<int>();
        int start = -1, end = -1;
        foreach (var i in range)
        {
            if(i[1] < 0)
                continue;
            if (start == -1)
            {
                start = i[0];
                end = i[1];
            }
            else
            {
                if (i[0] < end)
                    end = Math.Max(end, i[1]);
                else
                {
                    ans.Add(end - start + 1);
                    start = i[0];
                    end = i[1];
                }
            }
        }

        if (start >= 0)
        {
            ans.Add(end - start + 1);
        }

        return ans;
    }
}

// √ Accepted
//   √ 116/116 cases passed (300 ms)
//   √ Your runtime beats 5.47 % of csharp submissions
//   √ Your memory usage beats 10 % of csharp submissions (29.3 MB)

