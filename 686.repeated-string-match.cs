/*
 * @lc app=leetcode id=686 lang=csharp
 *
 * [686] Repeated String Match
 *
 * https://leetcode.com/problems/repeated-string-match/description/
 *
 * algorithms
 * Easy (31.33%)
 * Total Accepted:    63.6K
 * Total Submissions: 203K
 * Testcase Example:  '"abcd"\n"cdabcdab"'
 *
 * Given two strings A and B, find the minimum number of times A has to be
 * repeated such that B is a substring of it. If no such solution, return -1.
 * 
 * For example, with A = "abcd" and B = "cdabcdab".
 * 
 * Return 3, because by repeating A three times (“abcdabcdabcd”), B is a
 * substring of it; and B is not a substring of A repeated two times
 * ("abcdabcd").
 * 
 * Note:
 * The length of A and B will be between 1 and 10000.
 * 
 */
public class Solution {
    public int RepeatedStringMatch(string A, string B) {
        int n = (int)Math.Ceiling(B.Length * 1d / A.Length);
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            builder.Append(A);
        }

        if (builder.ToString().Contains(B))
            return n;
        builder.Append(A);
        if (builder.ToString().Contains(B))
            return n+1;
        return -1;
    }
}

// √ Accepted
//   √ 55/55 cases passed (428 ms)
//   √ Your runtime beats 78.57 % of csharp submissions
//   √ Your memory usage beats 57.14 % of csharp submissions (20.7 MB)

