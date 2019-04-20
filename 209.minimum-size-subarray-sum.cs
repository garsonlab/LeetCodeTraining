/*
 * @lc app=leetcode id=209 lang=csharp
 *
 * [209] Minimum Size Subarray Sum
 *
 * https://leetcode.com/problems/minimum-size-subarray-sum/description/
 *
 * algorithms
 * Medium (34.54%)
 * Total Accepted:    170.8K
 * Total Submissions: 494K
 * Testcase Example:  '7\n[2,3,1,2,4,3]'
 *
 * Given an array of n positive integers and a positive integer s, find the
 * minimal length of a contiguous subarray of which the sum ≥ s. If there isn't
 * one, return 0 instead.
 * 
 * Example: 
 * 
 * 
 * Input: s = 7, nums = [2,3,1,2,4,3]
 * Output: 2
 * Explanation: the subarray [4,3] has the minimal length under the problem
 * constraint.
 * 
 * Follow up:
 * 
 * If you have figured out the O(n) solution, try coding another solution of
 * which the time complexity is O(n log n). 
 * 
 */
public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        if (nums.Length == 0)
            return 0;
        if (nums[0] >= s)
            return 1;

        int minLen = nums.Length+1;

        int curIdx = 0, curVal = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int tem = curVal + nums[i];
            if (tem < s)
            {
                curVal = tem;
                continue;
            }
            else
            {
                minLen = Math.Min(minLen, i - curIdx + 1);
                for (int j = curIdx+1; j <= i; j++)
                {
                    tem -= nums[j-1];
                    if (tem >= s)
                    {
                        minLen = Math.Min(minLen, i - j + 1);
                    }
                    else
                    {
                        curIdx = j;
                        curVal = tem;
                        break;
                    }
                }

                if (minLen == 1)
                    return minLen;

            }
        }

        return minLen > nums.Length ? 0 : minLen;
    }
}


// √ Accepted
//   √ 15/15 cases passed (96 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 95.45 % of csharp submissions (23.2 MB)

