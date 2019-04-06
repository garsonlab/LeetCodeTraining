/*
 * @lc app=leetcode id=674 lang=csharp
 *
 * [674] Longest Continuous Increasing Subsequence
 *
 * https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
 *
 * algorithms
 * Easy (43.88%)
 * Total Accepted:    62.1K
 * Total Submissions: 141.3K
 * Testcase Example:  '[1,3,5,4,7]'
 *
 * 
 * Given an unsorted array of integers, find the length of longest continuous
 * increasing subsequence (subarray).
 * 
 * 
 * Example 1:
 * 
 * Input: [1,3,5,4,7]
 * Output: 3
 * Explanation: The longest continuous increasing subsequence is [1,3,5], its
 * length is 3. 
 * Even though [1,3,5,7] is also an increasing subsequence, it's not a
 * continuous one where 5 and 7 are separated by 4. 
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: [2,2,2,2,2]
 * Output: 1
 * Explanation: The longest continuous increasing subsequence is [2], its
 * length is 1. 
 * 
 * 
 * 
 * Note:
 * Length of the array will not exceed 10,000.
 * 
 */
public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        if(nums.Length <= 0)
            return 0;
        int max = 1;
        int cur = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                max = Math.Max(max, cur);
                cur = 1;
            }
            else
            {
                cur++;
            }
        }
        max = Math.Max(max, cur);
        return max;
    }
}

// √ Accepted
//   √ 36/36 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 55.56 % of csharp submissions (24.1 MB)

