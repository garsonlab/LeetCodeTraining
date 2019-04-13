/*
 * @lc app=leetcode id=14 lang=csharp
 *
 * [14] Longest Common Prefix
 *
 * https://leetcode.com/problems/longest-common-prefix/description/
 *
 * algorithms
 * Easy (33.25%)
 * Total Accepted:    439.2K
 * Total Submissions: 1.3M
 * Testcase Example:  '["flower","flow","flight"]'
 *
 * Write a function to find the longest common prefix string amongst an array
 * of strings.
 * 
 * If there is no common prefix, return an empty string "".
 * 
 * Example 1:
 * 
 * 
 * Input: ["flower","flow","flight"]
 * Output: "fl"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ["dog","racecar","car"]
 * Output: ""
 * Explanation: There is no common prefix among the input strings.
 * 
 * 
 * Note:
 * 
 * All given inputs are in lowercase letters a-z.
 * 
 */
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs.Length <= 0)
            return "";
        if (strs.Length == 1)
            return strs[0];

        List<char> list = new List<char>();
        int len = strs[0].Length;
        for (int i = 1; i < strs.Length; i++)
        {
            len = Math.Min(len, strs[i].Length);
        }

        for (int i = 0; i < len; i++)
        {
            char c = strs[0][i];
            bool diff = false;
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][i] != c)
                {
                    diff = true;
                    break;
                }
            }

            if (diff)
                break;
            else
                list.Add(c);
        }
        return new string(list.ToArray());
    }
}

// √ Accepted
//   √ 118/118 cases passed (116 ms)
//   √ Your runtime beats 53.86 % of csharp submissions
//   √ Your memory usage beats 60.98 % of csharp submissions (22.5 MB)

