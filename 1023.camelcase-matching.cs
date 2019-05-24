/*
 * @lc app=leetcode id=1023 lang=csharp
 *
 * [1023] Camelcase Matching

 A query word matches a given pattern if we can insert lowercase letters to the pattern word so that it equals the query. (We may insert each character at any position, and may insert 0 characters.)

Given a list of queries, and a pattern, return an answer list of booleans, where answer[i] is true if and only if queries[i] matches the pattern.

 

Example 1:

Input: queries = ["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"], pattern = "FB"
Output: [true,false,true,true,false]
Explanation: 
"FooBar" can be generated like this "F" + "oo" + "B" + "ar".
"FootBall" can be generated like this "F" + "oot" + "B" + "all".
"FrameBuffer" can be generated like this "F" + "rame" + "B" + "uffer".
Example 2:

Input: queries = ["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"], pattern = "FoBa"
Output: [true,false,true,false,false]
Explanation: 
"FooBar" can be generated like this "Fo" + "o" + "Ba" + "r".
"FootBall" can be generated like this "Fo" + "ot" + "Ba" + "ll".
Example 3:

Input: queries = ["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"], pattern = "FoBaT"
Output: [false,true,false,false,false]
Explanation: 
"FooBarTest" can be generated like this "Fo" + "o" + "Ba" + "r" + "T" + "est".
 

Note:

1 <= queries.length <= 100
1 <= queries[i].length <= 100
1 <= pattern.length <= 100
All strings consists only of lower and upper case English letters.
 */
public class Solution {
    public IList<bool> CamelMatch(string[] queries, string pattern) {
        List<bool> res = new List<bool>();
        foreach (var query in queries)
        {
            res.Add(IsMatch(query, pattern));
        }

        return res;
    }

    private bool IsMatch(string q, string p)
    {
        if (q.Length < p.Length)
            return false;
        int i = 0, j = 0;
        for (; i < q.Length && j < p.Length;)
        {
            if (q[i] == p[j])
            {
                i++;
                j++;
                continue;
            }

            if (q[i] >= 'a' && q[i] <= 'z')
                i++;
            else
                return false;
        }

        if (j < p.Length)
            return false;
        for (; i < q.Length; i++)
        {
            if (q[i] >= 'A' && q[i] <= 'Z')
                return false;
        }

        return true;
    }

}

// √ Accepted
//   √ 36/36 cases passed (284 ms)
//   √ Your runtime beats 5.42 % of csharp submissions
//   √ Your memory usage beats 64.39 % of csharp submissions (28 MB)

