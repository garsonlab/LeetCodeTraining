/*
 * @lc app=leetcode id=424 lang=csharp
 *
 * [424] Longest Repeating Character Replacement

 Given a string that consists of only uppercase English letters, you can replace any letter in the string with another letter at most k times. Find the length of a longest substring containing all repeating letters you can get after performing the above operations.

Note:
Both the string's length and k will not exceed 104.

Example 1:

Input:
s = "ABAB", k = 2

Output:
4

Explanation:
Replace the two 'A's with two 'B's or vice versa.
Example 2:

Input:
s = "AABABBA", k = 1

Output:
4

Explanation:
Replace the one 'A' in the middle with 'B' and form "AABBBBA".
The substring "BBBB" has the longest repeating letters, which is 4.
 */
public class Solution {
    public int CharacterReplacement(string s, int k) {
        int left = 0, right = 0, max = 0, cur = 0;
        int[] count = new int[26];

        while (right < s.Length)
        {
            cur = Math.Max(cur, ++count[s[right] - 'A']);

            while (right - left + 1 - cur > k)
            {
                count[s[left++] - 'A']--;
            }
            max = Math.Max(max, right-left+1);
            right++;
        }
        return max;
    }
}

// 思路分析：双指针窗口滑动法。使用两个指针分别作为窗口的left、right，不断右移动right指针（扩大窗口），
// 将窗口中的字符数作为一个中间结果（替换后的最长重复字符），当窗口大小 - 窗口中出现次数最多的字符数即是需要替换的字母数。
// 如果需要替换的字母数超过了k，则说明需要缩小窗口（右移left）。

// √ Accepted
//   √ 37/37 cases passed (76 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 75 % of csharp submissions (21.1 MB)

