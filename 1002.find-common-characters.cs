/*
 * @lc app=leetcode id=1002 lang=csharp
 *
 * [1002] Find Common Characters
 *
 * https://leetcode.com/problems/find-common-characters/description/
 *
 * algorithms
 * Easy (68.22%)
 * Total Accepted:    14.9K
 * Total Submissions: 22.4K
 * Testcase Example:  '["bella","label","roller"]'
 *
 * Given an array A of strings made only from lowercase letters, return a list
 * of all characters that show up in all strings within the list (including
 * duplicates).  For example, if a character occurs 3 times in all strings but
 * not 4 times, you need to include that character three times in the final
 * answer.
 * 
 * You may return the answer in any order.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: ["bella","label","roller"]
 * Output: ["e","l","l"]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ["cool","lock","cook"]
 * Output: ["c","o"]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 100
 * 1 <= A[i].length <= 100
 * A[i][j] is a lowercase letter
 * 
 * 
 * 
 */
public class Solution {
    public IList<string> CommonChars(string[] A) {
        List<string> ret = new List<string>();
        List<string> tem = new List<string>();

        for (int i = 0; i < A[0].Length; i++)
        {
            ret.Add(A[0][i].ToString());
        }

        for (int i = 1; i < A.Length; i++)
        {
            for (int j = 0; j < A[i].Length; j++)
            {
                string s = A[i][j].ToString();
                if (ret.Contains(s))
                {
                    ret.Remove(s);
                    tem.Add(s);
                }
            }
            ret.Clear();
            ret.AddRange(tem);
            tem.Clear();
        }

        return ret;
    }
}

// √ Accepted
//   √ 83/83 cases passed (288 ms)
//   √ Your runtime beats 23.57 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (31.2 MB)

