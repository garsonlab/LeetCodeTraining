/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 *
 * https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
 *
 * algorithms
 * Medium (41.02%)
 * Total Accepted:    369.7K
 * Total Submissions: 900.9K
 * Testcase Example:  '"23"'
 *
 * Given a string containing digits from 2-9 inclusive, return all possible
 * letter combinations that the number could represent.
 * 
 * A mapping of digit to letters (just like on the telephone buttons) is given
 * below. Note that 1 does not map to any letters.
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Input: "23"
 * Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
 * 
 * 
 * Note:
 * 
 * Although the above answer is in lexicographical order, your answer could be
 * in any order you want.
 * 
 */
public class Solution {
    public IList<string> LetterCombinations(string digits)
    {
        IList<string> list = new List<string>();
        if (digits.Length <= 0)
            return list;

        string[] strs = new[]
        {
            "",
            "",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz",
        };
        GetANN(list, ref strs, ref digits, 0, "");
        return list;
    }

    private void GetANN(IList<string> list, ref string[] strs, ref string digits, int dep, string r)
    {
        string s = strs[digits[dep] - '0'];
        for (int i = 0; i < s.Length; i++)
        {
            string tem = r + s[i];
            if (dep == digits.Length - 1)
            {
                list.Add(tem);
            }
            else
            {
                GetANN(list, ref strs, ref digits, dep+1, tem);
            }
        }
    }

}

// √ Accepted
//   √ 25/25 cases passed (244 ms)
//   √ Your runtime beats 97.87 % of csharp submissions
//   √ Your memory usage beats 45.78 % of csharp submissions (29.3 MB)

