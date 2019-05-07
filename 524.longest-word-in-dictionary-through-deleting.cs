/*
 * @lc app=leetcode id=524 lang=csharp
 *
 * [524] Longest Word in Dictionary through Deleting

 Given a string and a string dictionary, find the longest string in the dictionary that can be formed by deleting some characters of the given string. If there are more than one possible results, return the longest word with the smallest lexicographical order. If there is no possible result, return the empty string.

Example 1:
Input:
s = "abpcplea", d = ["ale","apple","monkey","plea"]

Output: 
"apple"
Example 2:
Input:
s = "abpcplea", d = ["a","b","c"]

Output: 
"a"
Note:
All the strings in the input will only contain lower-case letters.
The size of the dictionary won't exceed 1,000.
The length of all the strings in the input won't exceed 1,000.
 */
public class Solution {
    public string FindLongestWord(string s, IList<string> d) {
        List<string> list = (List<string>) d;
        list.Sort((a, b) =>
        {
            if (a.Length == b.Length)
                return a.CompareTo(b);
            return b.Length - a.Length;
        });

        foreach (var str in list)
        {
            if (IsContainWord(s, str))
                return str;
        }

        return "";
    }

    private bool IsContainWord(string s, string w)
    {
        if (w.Length == 0)
            return true;
        int idx = 0, j = 0;
        while (j < s.Length)
        {
            if (s[j] == w[idx])
            {
                idx++;
                if (idx >= w.Length)
                    return true;
            }
            j++;
        }

        return false;
    }

}

// √ Accepted
//   √ 31/31 cases passed (148 ms)
//   √ Your runtime beats 57.43 % of csharp submissions
//   √ Your memory usage beats 12.5 % of csharp submissions (34.1 MB)

