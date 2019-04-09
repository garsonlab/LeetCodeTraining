/*
 * @lc app=leetcode id=824 lang=csharp
 *
 * [824] Goat Latin
 *
 * https://leetcode.com/problems/goat-latin/description/
 *
 * algorithms
 * Easy (57.04%)
 * Total Accepted:    28.6K
 * Total Submissions: 50K
 * Testcase Example:  '"I speak Goat Latin"'
 *
 * A sentence S is given, composed of words separated by spaces. Each word
 * consists of lowercase and uppercase letters only.
 * 
 * We would like to convert the sentence to "Goat Latin" (a made-up language
 * similar to Pig Latin.)
 * 
 * The rules of Goat Latin are as follows:
 * 
 * 
 * If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of
 * the word.
 * For example, the word 'apple' becomes 'applema'.
 * 
 * If a word begins with a consonant (i.e. not a vowel), remove the first
 * letter and append it to the end, then add "ma".
 * For example, the word "goat" becomes "oatgma".
 * 
 * Add one letter 'a' to the end of each word per its word index in the
 * sentence, starting with 1.
 * For example, the first word gets "a" added to the end, the second word gets
 * "aa" added to the end and so on.
 * 
 * 
 * Return the final sentence representing the conversion from S to Goat
 * Latin. 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "I speak Goat Latin"
 * Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "The quick brown fox jumped over the lazy dog"
 * Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa
 * hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"
 * 
 * 
 * 
 * 
 * Notes:
 * 
 * 
 * S contains only uppercase, lowercase and spaces. Exactly one space between
 * each word.
 * 1 <= S.length <= 150.
 * 
 * 
 */
public class Solution {
    public string ToGoatLatin(string S) {
        string[] ps = S.Split(' ');
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < ps.Length; i++)
        {
            if (i != 0)
                builder.Append(" ");

            string s = ps[i];
            if (!IsVowel(s[0]))
            {
                char t = s[0];
                s = s.Substring(1) + t;
            }

            builder.Append(s);
            builder.Append("ma");
            
            for (int j = 0; j <= i; j++)
            {
                builder.Append("a");
            }
        }

        return builder.ToString();
    }
    
    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
               || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
    }

}

// √ Accepted
//   √ 99/99 cases passed (84 ms)
//   √ Your runtime beats 97.12 % of csharp submissions
//   √ Your memory usage beats 93.33 % of csharp submissions (21.1 MB)

