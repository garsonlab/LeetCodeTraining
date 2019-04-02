/*
 * @lc app=leetcode id=443 lang=csharp
 *
 * [443] String Compression
 *
 * https://leetcode.com/problems/string-compression/description/
 *
 * algorithms
 * Easy (37.04%)
 * Total Accepted:    46.1K
 * Total Submissions: 124.1K
 * Testcase Example:  '["a","a","b","b","c","c","c"]'
 *
 * Given an array of characters, compress it in-place.
 * 
 * The length after compression must always be smaller than or equal to the
 * original array.
 * 
 * Every element of the array should be a character (not int) of length 1.
 * 
 * After you are done modifying the input array in-place, return the new length
 * of the array.
 * 
 * 
 * Follow up:
 * Could you solve it using only O(1) extra space?
 * 
 * 
 * Example 1:
 * 
 * 
 * Input:
 * ["a","a","b","b","c","c","c"]
 * 
 * Output:
 * Return 6, and the first 6 characters of the input array should be:
 * ["a","2","b","2","c","3"]
 * 
 * Explanation:
 * "aa" is replaced by "a2". "bb" is replaced by "b2". "ccc" is replaced by
 * "c3".
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input:
 * ["a"]
 * 
 * Output:
 * Return 1, and the first 1 characters of the input array should be: ["a"]
 * 
 * Explanation:
 * Nothing is replaced.
 * 
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input:
 * ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
 * 
 * Output:
 * Return 4, and the first 4 characters of the input array should be:
 * ["a","b","1","2"].
 * 
 * Explanation:
 * Since the character "a" does not repeat, it is not compressed.
 * "bbbbbbbbbbbb" is replaced by "b12".
 * Notice each digit has it's own entry in the array.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * All characters have an ASCII value in [35, 126].
 * 1 <= len(chars) <= 1000.
 * 
 * 
 */
public class Solution {
    public int Compress(char[] chars) {
        if (chars.Length <= 0)
            return 0;

        int n = 0;
        char pre = chars[0];
        int len = 1;
        for (int i = 1; i <= chars.Length; i++)
        {
            if (i == chars.Length || chars[i] != pre)
            {
                if (len == 1)
                {
                    chars[n++] = pre;
                }
                else
                {
                    chars[n++] = pre;
                    if (len < 10)
                        chars[n++] = (char) (len + '0');
                    else if (len < 100)
                    {
                        chars[n++] = (char) ((len / 10) + '0');
                        chars[n++] = (char) ((len % 10) + '0');
                    }
                    else if (len < 1000)
                    {
                        chars[n++] = (char) ((len / 100) + '0');
                        chars[n++] = (char) ((len / 10) + '0');
                        chars[n++] = (char) ((len % 10) + '0');
                    }
                    else
                    {
                        chars[n++] = (char) ((len / 1000) + '0');
                        chars[n++] = (char) ((len / 100) + '0');
                        chars[n++] = (char) ((len / 10) + '0');
                        chars[n++] = (char) ((len % 10) + '0');
                    }
                }

                if (i < chars.Length)
                {
                    pre = chars[i];
                    len = 1;
                }
            }
            else
            {
                len++;
            }
        }

        return n;
    }
}


// √ Accepted
//   √ 70/70 cases passed (296 ms)
//   √ Your runtime beats 54.67 % of csharp submissions
//   √ Your memory usage beats 56.25 % of csharp submissions (31 MB)

