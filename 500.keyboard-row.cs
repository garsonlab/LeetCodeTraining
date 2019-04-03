/*
 * @lc app=leetcode id=500 lang=csharp
 *
 * [500] Keyboard Row
 *
 * https://leetcode.com/problems/keyboard-row/description/
 *
 * algorithms
 * Easy (61.78%)
 * Total Accepted:    84.6K
 * Total Submissions: 136.8K
 * Testcase Example:  '["Hello","Alaska","Dad","Peace"]'
 *
 * Given a List of words, return the words that can be typed using letters of
 * alphabet on only one row's of American keyboard like the image
 * below.
 * 
 * 
 * 
 * 
 * 
 * 
 * Example:
 * 
 * 
 * Input: ["Hello", "Alaska", "Dad", "Peace"]
 * Output: ["Alaska", "Dad"]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * You may use one character in the keyboard more than once.
 * You may assume the input string will only contain letters of alphabet.
 * 
 * 
 */
public class Solution {
    public string[] FindWords(string[] words) {
        string[] lines = new[]
        {
            "QWERTYUIOPqwertyuiop",
            "ASDFGHJKLasdfghjkl",
            "ZXCVBNMzxcvbnm"
        };
        List<string> list = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            int idx = 0;
            bool found = true;
            for (int j = 0; j < 3; j++)
            {
                if (lines[j].Contains(words[i][0].ToString()))
                {
                    idx = j;
                    break;
                }
            }

            for (int j = 0; j < words[i].Length; j++)
            {
                if (!lines[idx].Contains(words[i][j].ToString()))
                {
                    found = false;
                    break;
                }
            }
            if(found)
                list.Add(words[i]);
        }
        
        return list.ToArray();
    }
}

// √ Accepted
//   √ 22/22 cases passed (252 ms)
//   √ Your runtime beats 96.82 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (28.2 MB)

