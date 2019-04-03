/*
 * @lc app=leetcode id=485 lang=csharp
 *
 * [485] Max Consecutive Ones
 *
 * https://leetcode.com/problems/max-consecutive-ones/description/
 *
 * algorithms
 * Easy (54.63%)
 * Total Accepted:    129.1K
 * Total Submissions: 235.9K
 * Testcase Example:  '[1,0,1,1,0,1]'
 *
 * Given a binary array, find the maximum number of consecutive 1s in this
 * array.
 * 
 * Example 1:
 * 
 * Input: [1,1,0,1,1,1]
 * Output: 3
 * Explanation: The first two digits or the last three digits are consecutive
 * 1s.
 * ⁠   The maximum number of consecutive 1s is 3.
 * 
 * 
 * 
 * Note:
 * 
 * The input array will only contain 0 and 1.
 * The length of input array is a positive integer and will not exceed 10,000
 * 
 * 
 */
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int max = 0;
        int cur = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 1)
            {
                if (cur > max)
                    max = cur;
                cur = 0;
            }
            else
            {
                cur++;
            }
        }
        if (cur > max)
            max = cur;
        return max;
    }
}

// √ Accepted
//   √ 41/41 cases passed (136 ms)
//   √ Your runtime beats 95.12 % of csharp submissions
//   √ Your memory usage beats 30.43 % of csharp submissions (33 MB)

