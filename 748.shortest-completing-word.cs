/*
 * @lc app=leetcode id=748 lang=csharp
 *
 * [748] Shortest Completing Word
 *
 * https://leetcode.com/problems/shortest-completing-word/description/
 *
 * algorithms
 * Easy (53.65%)
 * Total Accepted:    18.3K
 * Total Submissions: 33.9K
 * Testcase Example:  '"1s3 PSt"\n["step","steps","stripe","stepple"]'
 *
 * 
 * Find the minimum length word from a given dictionary words, which has all
 * the letters from the string licensePlate.  Such a word is said to complete
 * the given string licensePlate
 * 
 * Here, for letters we ignore case.  For example, "P" on the licensePlate
 * still matches "p" on the word.
 * 
 * It is guaranteed an answer exists.  If there are multiple answers, return
 * the one that occurs first in the array.
 * 
 * The license plate might have the same letter occurring multiple times.  For
 * example, given a licensePlate of "PP", the word "pair" does not complete the
 * licensePlate, but the word "supper" does.
 * 
 * 
 * Example 1:
 * 
 * Input: licensePlate = "1s3 PSt", words = ["step", "steps", "stripe",
 * "stepple"]
 * Output: "steps"
 * Explanation: The smallest length word that contains the letters "S", "P",
 * "S", and "T".
 * Note that the answer is not "step", because the letter "s" must occur in the
 * word twice.
 * Also note that we ignored case for the purposes of comparing whether a
 * letter exists in the word.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: licensePlate = "1s3 456", words = ["looks", "pest", "stew", "show"]
 * Output: "pest"
 * Explanation: There are 3 smallest length words that contains the letters
 * "s".
 * We return the one that occurred first.
 * 
 * 
 * 
 * Note:
 * 
 * licensePlate will be a string with length in range [1, 7].
 * licensePlate will contain digits, spaces, or letters (uppercase or
 * lowercase).
 * words will have a length in the range [10, 1000].
 * Every words[i] will consist of lowercase letters, and have length in range
 * [1, 15].
 * 
 * 
 */
public class Solution {
       public string ShortestCompletingWord(string licensePlate, string[] words)
    {
        int[] plate = new int[26];
        GetWordNum(ref plate, licensePlate);
        int[] tem = new int[26];

        string ret = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (ret.Length == 0 || words[i].Length < ret.Length)
            {
                GetWordNum(ref tem, words[i]);
                bool comp = true;
                for (int j = 0; j < 26; j++)
                {
                    if (tem[j] < plate[j])
                    {
                        comp = false;
                        break;
                    }
                }

                if (comp)
                    ret = words[i];
            }
        }

        return ret;
    }


    private void GetWordNum(ref int[] nums, string s)
    {
        for (int i = 0; i < 26; i++)
        {
            nums[i] = 0;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] >= 'A' && s[i] <= 'Z')
                nums[s[i] - 'A']++;
            else if (s[i] >= 'a' && s[i] <= 'z')
                nums[s[i] - 'a']++;
        }
    }
}


// √ Accepted
//   √ 102/102 cases passed (104 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (24.3 MB)

