/*
 * @lc app=leetcode id=806 lang=csharp
 *
 * [806] Number of Lines To Write String
 *
 * https://leetcode.com/problems/number-of-lines-to-write-string/description/
 *
 * algorithms
 * Easy (62.60%)
 * Total Accepted:    25.9K
 * Total Submissions: 41.2K
 * Testcase Example:  '[10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10]\n"abcdefghijklmnopqrstuvwxyz"'
 *
 * We are to write the letters of a given string S, from left to right into
 * lines. Each line has maximum width 100 units, and if writing a letter would
 * cause the width of the line to exceed 100 units, it is written on the next
 * line. We are given an array widths, an array where widths[0] is the width of
 * 'a', widths[1] is the width of 'b', ..., and widths[25] is the width of
 * 'z'.
 * 
 * Now answer two questions: how many lines have at least one character from S,
 * and what is the width used by the last such line? Return your answer as an
 * integer list of length 2.
 * 
 * 
 * 
 * 
 * Example :
 * Input: 
 * widths =
 * [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10]
 * S = "abcdefghijklmnopqrstuvwxyz"
 * Output: [3, 60]
 * Explanation: 
 * All letters have the same length of 10. To write all 26 letters,
 * we need two full lines and one line with 60 units.
 * 
 * 
 * 
 * Example :
 * Input: 
 * widths =
 * [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10]
 * S = "bbbcccdddaaa"
 * Output: [2, 4]
 * Explanation: 
 * All letters except 'a' have the same length of 10, and 
 * "bbbcccdddaa" will cover 9 * 10 + 2 * 4 = 98 units.
 * For the last 'a', it is written on the second line because
 * there is only 2 units left in the first line.
 * So the answer is 2 lines, plus 4 units in the second line.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The length of S will be in the range [1, 1000].
 * S will only contain lowercase letters.
 * widths is an array of length 26.
 * widths[i] will be in the range of [2, 10].
 * 
 * 
 */
public class Solution {
    public int[] NumberOfLines(int[] widths, string S) {
        int l = 0;
        int c = 0;
        for (int i = 0; i < S.Length; i++)
        {
            int w = widths[S[i] - 'a'];
            if (c + w > 100)
            {
                l++;
                c = w;
            }
            else
            {
                c += w;
            }
        }

        return new[] {l + (int) Math.Ceiling(c * 0.01d), c};
    }
}

// √ Accepted
//   √ 26/26 cases passed (244 ms)
//   √ Your runtime beats 96.97 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (28.1 MB)

