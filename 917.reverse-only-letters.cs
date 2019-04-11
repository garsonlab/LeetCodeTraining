/*
 * @lc app=leetcode id=917 lang=csharp
 *
 * [917] Reverse Only Letters
 *
 * https://leetcode.com/problems/reverse-only-letters/description/
 *
 * algorithms
 * Easy (55.98%)
 * Total Accepted:    22.9K
 * Total Submissions: 40.8K
 * Testcase Example:  '"ab-cd"'
 *
 * Given a string S, return the "reversed" string where all characters that are
 * not a letter stay in the same place, and all letters reverse their
 * positions.
 * 
 * 
 * 
 * 
 * 
 * 
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
 * Input: "ab-cd"
 * Output: "dc-ba"
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "a-bC-dEf-ghIj"
 * Output: "j-Ih-gfE-dCba"
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "Test1ng-Leet=code-Q!"
 * Output: "Qedo1ct-eeLg=ntse-T!"
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * S.length <= 100
 * 33 <= S[i].ASCIIcode <= 122 
 * S doesn't contain \ or "
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public string ReverseOnlyLetters(string S) {
        if (S.Length <= 1)
            return S;
        char[] chars = new char[S.Length];

        for (int i = 0, j = S.Length-1; i <= j; i++, j--)
        {
            if (!IsLetter(S[i]))
            {
                chars[i] = S[i];
                j++;
                continue;
            }

            if (!IsLetter(S[j]))
            {
                chars[j] = S[j];
                i--;
                continue;
            }

            chars[i] = S[j];
            chars[j] = S[i];
        }

        return new string(chars);
    }

    private bool IsLetter(char c)
    {
        return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';
    }
}

// √ Accepted
//   √ 116/116 cases passed (84 ms)
//   √ Your runtime beats 86.15 % of csharp submissions
//   √ Your memory usage beats 9.38 % of csharp submissions (21.2 MB)

