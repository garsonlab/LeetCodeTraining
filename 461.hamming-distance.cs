/*
 * @lc app=leetcode id=461 lang=csharp
 *
 * [461] Hamming Distance
 *
 * https://leetcode.com/problems/hamming-distance/description/
 *
 * algorithms
 * Easy (70.10%)
 * Total Accepted:    226.2K
 * Total Submissions: 322.6K
 * Testcase Example:  '1\n4'
 *
 * The Hamming distance between two integers is the number of positions at
 * which the corresponding bits are different.
 * 
 * Given two integers x and y, calculate the Hamming distance.
 * 
 * Note:
 * 0 ≤ x, y < 2^31.
 * 
 * 
 * Example:
 * 
 * Input: x = 1, y = 4
 * 
 * Output: 2
 * 
 * Explanation:
 * 1   (0 0 0 1)
 * 4   (0 1 0 0)
 * ⁠      ↑   ↑
 * 
 * The above arrows point to positions where the corresponding bits are
 * different.
 * 
 * 
 */
public class Solution {
    public int HammingDistance(int x, int y) {
        int n = 0;

        while (x > 0 || y > 0)
        {
            if (x % 2 != y % 2)
            {
                n++;
            }

            x /= 2;
            y /= 2;
        }

        return n;
    }
}

// √ Accepted
//   √ 149/149 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.7 MB)

