/*
 * @lc app=leetcode id=434 lang=csharp
 *
 * [434] Number of Segments in a String
 *
 * https://leetcode.com/problems/number-of-segments-in-a-string/description/
 *
 * algorithms
 * Easy (36.72%)
 * Total Accepted:    52.9K
 * Total Submissions: 143.9K
 * Testcase Example:  '"Hello, my name is John"'
 *
 * Count the number of segments in a string, where a segment is defined to be a
 * contiguous sequence of non-space characters.
 * 
 * Please note that the string does not contain any non-printable characters.
 * 
 * Example:
 * 
 * Input: "Hello, my name is John"
 * Output: 5
 * 
 * 
 */
public class Solution {
    public int CountSegments(string s) {
        string[] ps = s.Split(' ');
        int num = 0;
        for (int i = 0; i < ps.Length; i++)
        {
            if(!string.IsNullOrEmpty(ps[i]))
                num++;
        }

        return num;
    }
}
// √ Accepted
//   √ 26/26 cases passed (84 ms)
//   √ Your runtime beats 61.4 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (19.6 MB)

