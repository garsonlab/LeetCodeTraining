/*
 * @lc app=leetcode id=520 lang=csharp
 *
 * [520] Detect Capital
 *
 * https://leetcode.com/problems/detect-capital/description/
 *
 * algorithms
 * Easy (52.27%)
 * Total Accepted:    81K
 * Total Submissions: 154.9K
 * Testcase Example:  '"USA"'
 *
 * 
 * Given a word, you need to judge whether the usage of capitals in it is right
 * or not.
 * 
 * 
 * 
 * We define the usage of capitals in a word to be right when one of the
 * following cases holds:
 * 
 * All letters in this word are capitals, like "USA".
 * All letters in this word are not capitals, like "leetcode".
 * Only the first letter in this word is capital if it has more than one
 * letter, like "Google".
 * 
 * Otherwise, we define that this word doesn't use capitals in a right way.
 * 
 * 
 * 
 * Example 1:
 * 
 * Input: "USA"
 * Output: True
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: "FlaG"
 * Output: False
 * 
 * 
 * 
 * Note:
 * The input will be a non-empty word consisting of uppercase and lowercase
 * latin letters.
 * 
 */
public class Solution {
    public bool DetectCapitalUse(string word)
    {
        if (word.Length <= 1)
            return true;

        if (!IsUpper(word[0]))
        {
            for (int i = 1; i < word.Length; i++)
            {
                if (IsUpper(word[i]))
                    return false;
            }
        }
        else
        {
            if (IsUpper(word[1]))
            {
                for (int i = 2; i < word.Length; i++)
                {
                    if (!IsUpper(word[i]))
                        return false;
                }
            }
            else
            {
                for (int i = 2; i < word.Length; i++)
                {
                    if (IsUpper(word[i]))
                        return false;
                }
            }
        }

        return true;
    }

    private bool IsUpper(char c)
    {
        return c >= 'A' && c <= 'Z';
    }
}

// √ Accepted
//   √ 550/550 cases passed (92 ms)
//   √ Your runtime beats 33.74 % of csharp submissions
//   √ Your memory usage beats 57.89 % of csharp submissions (21.1 MB)

