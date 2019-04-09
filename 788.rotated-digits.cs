/*
 * @lc app=leetcode id=788 lang=csharp
 *
 * [788] Rotated Digits
 *
 * https://leetcode.com/problems/rotated-digits/description/
 *
 * algorithms
 * Easy (53.38%)
 * Total Accepted:    24.6K
 * Total Submissions: 45.8K
 * Testcase Example:  '10'
 *
 * X is a good number if after rotating each digit individually by 180 degrees,
 * we get a valid number that is different from X.  Each digit must be rotated
 * - we cannot choose to leave it alone.
 * 
 * A number is valid if each digit remains a digit after rotation. 0, 1, and 8
 * rotate to themselves; 2 and 5 rotate to each other; 6 and 9 rotate to each
 * other, and the rest of the numbers do not rotate to any other number and
 * become invalid.
 * 
 * Now given a positive number N, how many numbers X from 1 to N are good?
 * 
 * 
 * Example:
 * Input: 10
 * Output: 4
 * Explanation: 
 * There are four good numbers in the range [1, 10] : 2, 5, 6, 9.
 * Note that 1 and 10 are not good numbers, since they remain unchanged after
 * rotating.
 * 
 * 
 * Note:
 * 
 * 
 * N  will be in range [1, 10000].
 * 
 * 
 */
public class Solution {
    public int RotatedDigits(int N) {
        if (N <= 1)
            return 0;

        Dictionary<char, int> dic = new Dictionary<char, int>()
        {
            {'0', 0},
            {'1', 0},
            {'2', 5},
            {'5', 2},
            {'6', 9},
            {'8', 0},
            {'9', 6}
        };
        int num = 0;
       
        for (int i = 2; i <= N; i++)
        {
            string v = i.ToString();
            int r = 0;
            bool act = true;
            for (int j = 0; j < v.Length; j++)
            {
                int n;
                if (!dic.TryGetValue(v[j], out n))
                {
                    act = false;
                    break;
                }

                r += n;
            }

            if (act && r > 0)
                num++;
        }

        return num;
    }
}
//只包含0125689， 必包含2569
// √ Accepted
//   √ 50/50 cases passed (64 ms)
//   √ Your runtime beats 59.38 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (16.8 MB)

