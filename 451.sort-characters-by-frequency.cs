/*
 * @lc app=leetcode id=451 lang=csharp
 *
 * [451] Sort Characters By Frequency

 Given a string, sort it in decreasing order based on the frequency of characters.

Example 1:

Input:
"tree"

Output:
"eert"

Explanation:
'e' appears twice while 'r' and 't' both appear once.
So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
Example 2:

Input:
"cccaaa"

Output:
"cccaaa"

Explanation:
Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
Note that "cacaca" is incorrect, as the same characters must be together.
Example 3:

Input:
"Aabb"

Output:
"bbAa"

Explanation:
"bbaA" is also a valid answer, but "Aabb" is incorrect.
Note that 'A' and 'a' are treated as two different characters.
 */
public class Solution {
    public string FrequencySort(string s) {
        if(s.Length <= 2)
            return s;

        Dictionary<char, int> dic = new Dictionary<char, int>();
        foreach (var c in s)
        {
            int n;
            if(!dic.TryGetValue(c, out n))
                n = 0;
            dic[c] = ++n;
        }

        int[][] f = new int[dic.Count][];
        int idx = 0;
        foreach (var item in dic)
        {
            f[idx++] = new int[]{item.Value, item.Key};
        }
        Array.Sort(f, (a, b) => {
            return b[0]-a[0];
        });
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < dic.Count; i++)
        {
            for (int j = 0; j < f[i][0]; j++)
            {
                builder.Append((char)(f[i][1]));
            }
        }
        return builder.ToString();
    }


    public string FrequencySort_onlyChar(string s) {
        if(s.Length <= 2)
            return s;

        int[][] f = new int[52][];
        for (int i = 0; i < 52; i++)
        {
            if(i < 26)
                f[i] = new int[]{0, i+'a'};
            else
                f[i] = new int[]{0, i-26+'A'};
        }

        for (int i = 0; i < s.Length; i++)
        {
            if(s[i] >= 'a' && s[i] <= 'z')
                f[s[i]-'a'][0]++;
            else if(s[i] >= 'A' && s[i] <= 'Z')
                f[s[i]-'A'+26][0]++;
        }

        Array.Sort(f, (a, b) => {
            return b[0]-a[0];
        });

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 52; i++)
        {
            for (int j = 0; j < f[i][0]; j++)
            {
                builder.Append((char)(f[i][1]));
            }
        }
        return builder.ToString();
    }
}


// √ Accepted
//   √ 35/35 cases passed (96 ms)
//   √ Your runtime beats 95.87 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (24.5 MB)

