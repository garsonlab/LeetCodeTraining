/*
 * @lc app=leetcode id=893 lang=csharp
 *
 * [893] Groups of Special-Equivalent Strings
 *
 * https://leetcode.com/problems/groups-of-special-equivalent-strings/description/
 *
 * algorithms
 * Easy (61.80%)
 * Total Accepted:    13.1K
 * Total Submissions: 21.2K
 * Testcase Example:  '["a","b","c","a","c","c"]'
 *
 * You are given an array A of strings.
 * 
 * Two strings S and T are special-equivalent if after any number of moves, S
 * == T.
 * 
 * A move consists of choosing two indices i and j with i % 2 == j % 2, and
 * swapping S[i] with S[j].
 * 
 * Now, a group of special-equivalent strings from A is a non-empty subset S of
 * A such that any string not in S is not special-equivalent with any string in
 * S.
 * 
 * Return the number of groups of special-equivalent strings from A.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: ["a","b","c","a","c","c"]
 * Output: 3
 * Explanation: 3 groups ["a","a"], ["b"], ["c","c","c"]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ["aa","bb","ab","ba"]
 * Output: 4
 * Explanation: 4 groups ["aa"], ["bb"], ["ab"], ["ba"]
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: ["abc","acb","bac","bca","cab","cba"]
 * Output: 3
 * Explanation: 3 groups ["abc","cba"], ["acb","bca"], ["bac","cab"]
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: ["abcd","cdab","adcb","cbad"]
 * Output: 1
 * Explanation: 1 group ["abcd","cdab","adcb","cbad"]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 1000
 * 1 <= A[i].length <= 20
 * All A[i] have the same length.
 * All A[i] consist of only lowercase letters.
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int NumSpecialEquivGroups(string[] A) {
        List<string> r = new List<string>();
        List<char> s = new List<char>();
        List<char> d = new List<char>();

        foreach (var str in A)
        {
            s.Clear();
            d.Clear();
            for (int i = 0; i < str.Length; i++)
            {
                if(i%2 == 0)
                    d.Add(str[i]);
                else
                    s.Add(str[i]);
            }
            s.Sort();
            d.Sort();

            string ss = s.Count > 0 ? new string(s.ToArray()) : "";
            string sd = d.Count > 0 ? new string(d.ToArray()) : "";

            bool has = false;
            for (int i = 0; i < r.Count;)
            {
                if (ss == r[i] && sd == r[i + 1])
                {
                    has = true;
                    break;
                }

                i += 2;
            }

            if (!has)
            {
                r.Add(ss);
                r.Add(sd);
            }
        }

        return r.Count / 2;
    }
}

// √ Accepted
//   √ 35/35 cases passed (148 ms)
//   √ Your runtime beats 54.39 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (23.8 MB)

