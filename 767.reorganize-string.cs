/*
 * @lc app=leetcode id=767 lang=csharp
 *
 * [767] Reorganize String

 Given a string S, check if the letters can be rearranged so that two characters that are adjacent to each other are not the same.

If possible, output any possible result.  If not possible, return the empty string.

Example 1:

Input: S = "aab"
Output: "aba"
Example 2:

Input: S = "aaab"
Output: ""
Note:

S will consist of lowercase letters and have length in range [1, 500].
 */
public class Solution {
    public string ReorganizeString(string S)
    {
        int len = S.Length;
        int[] mp = new int[26];
        List<int[]> list = new List<int[]>();

        for (int i = 0; i < len; i++)
            mp[S[i] - 'a']++;

        for (int i = 0; i < 26; i++)
        {
            if (mp[i] > (len + 1) / 2)
                return "";

            if (mp[i] > 0)
                list.Add(new[] { mp[i], i + 'a' });
        }
        list.Sort((a, b) => { return a[0] - b[0]; });
        char[] ans = new char[len];

        int p = 1;
        foreach (var t in list)
        {
            char ch = (char)t[1];
            int ct = t[0];

            while (ct-- > 0)
            {
                if (p >= len)
                    p = 0;
                ans[p] = ch;
                p += 2;
            }
        }
        return new string(ans);
    }

    public string ReorganizeString_Err(string S) {
        int len = S.Length;
        StringBuilder ans = new StringBuilder();
        int[] mp = new int[26];
        List<int[]> list = new List<int[]>();

        for (int i = 0; i < len; i++)
            mp[S[i]-'a']++;

        for (int i = 0; i < 26; i++)
        {
            if (mp[i] > (len + 1) / 2)
                return ans.ToString();

            if(mp[i] > 0)
                list.Add(new[] { mp[i], i + 'a' });
        }
        list.Sort((a, b) => { return b[0] - a[0]; });

        while (list.Count >= 2)
        {
            var t1 = list[0];
            var t2 = list[1];
            ans.Append((char) t1[1]);
            ans.Append((char) t2[1]);

            if(--list[1][0] <= 0)
                list.RemoveAt(1);
            if (--list[0][0] <= 0)
                list.RemoveAt(0);

            if (list.Count > 0)
            {
                if (list[0][1] == t2[1])
                {
                    var tem = list[0];
                    list.RemoveAt(0);
                    if(list.Count > 1)
                        list.Insert(1, tem);
                    else
                        list.Add(tem);
                }
            }
        }

        if (list.Count > 0)
            if (list[0][1] == ans[ans.Length - 1])
                ans.Insert(0, (char) list[0][1]);
            else
                ans.Append((char) list[0][1]);
        return ans.ToString();
    }
}

// √ Accepted
//   √ 62/62 cases passed (96 ms)
//   √ Your runtime beats 40 % of csharp submissions
//   √ Your memory usage beats 42.86 % of csharp submissions (20.9 MB)

