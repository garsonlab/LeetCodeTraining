/*
 * @lc app=leetcode id=643 lang=csharp
 *
 * [643] Maximum Average Subarray I
 *
 * https://leetcode.com/problems/maximum-average-subarray-i/description/
 *
 * algorithms
 * Easy (39.13%)
 * Total Accepted:    48.2K
 * Total Submissions: 123.1K
 * Testcase Example:  '[1,12,-5,-6,50,3]\n4'
 *
 * Given an array consisting of n integers, find the contiguous subarray of
 * given length k that has the maximum average value. And you need to output
 * the maximum average value.
 * 
 * Example 1:
 * 
 * 
 * Input: [1,12,-5,-6,50,3], k = 4
 * Output: 12.75
 * Explanation: Maximum average is (12-5-6+50)/4 = 51/4 = 12.75
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= k <= n <= 30,000.
 * Elements of the given array will be in the range [-10,000, 10,000].
 * 
 * 
 * 
 * 
 */
public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        double r = 0;
        double p = 0;
        for (int i = 0; i < k; i++)
        {
            p += nums[i];
        }
        r = p;

        for (int i = k; i < nums.Length; i++)
        {
            double tem = p - nums[i - k] + nums[i];
            if (tem > r)
                r = tem;
            p = tem;
        }

        return r / k;
    }
}



// √ Accepted
//   √ 123/123 cases passed (264 ms)
//   √ Your runtime beats 61.46 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (42.1 MB)
