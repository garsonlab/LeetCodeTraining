/*
 * @lc app=leetcode id=744 lang=csharp
 *
 * [744] Find Smallest Letter Greater Than Target
 *
 * https://leetcode.com/problems/find-smallest-letter-greater-than-target/description/
 *
 * algorithms
 * Easy (43.66%)
 * Total Accepted:    37.2K
 * Total Submissions: 85K
 * Testcase Example:  '["c","f","j"]\n"a"'
 *
 * 
 * Given a list of sorted characters letters containing only lowercase letters,
 * and given a target letter target, find the smallest element in the list that
 * is larger than the given target.
 * 
 * Letters also wrap around.  For example, if the target is target = 'z' and
 * letters = ['a', 'b'], the answer is 'a'.
 * 
 * 
 * Examples:
 * 
 * Input:
 * letters = ["c", "f", "j"]
 * target = "a"
 * Output: "c"
 * 
 * Input:
 * letters = ["c", "f", "j"]
 * target = "c"
 * Output: "f"
 * 
 * Input:
 * letters = ["c", "f", "j"]
 * target = "d"
 * Output: "f"
 * 
 * Input:
 * letters = ["c", "f", "j"]
 * target = "g"
 * Output: "j"
 * 
 * Input:
 * letters = ["c", "f", "j"]
 * target = "j"
 * Output: "c"
 * 
 * Input:
 * letters = ["c", "f", "j"]
 * target = "k"
 * Output: "c"
 * 
 * 
 * 
 * Note:
 * 
 * letters has a length in range [2, 10000].
 * letters consists of lowercase letters, and contains at least 2 unique
 * letters.
 * target is a lowercase letter.
 * 
 * 
 */
public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > target)
                return letters[i];
        }

        return letters[0];
    }
}

// √ Accepted
//   √ 165/165 cases passed (112 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (25.9 MB)

