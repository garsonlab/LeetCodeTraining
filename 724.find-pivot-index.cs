/*
 * @lc app=leetcode id=724 lang=csharp
 *
 * [724] Find Pivot Index
 *
 * https://leetcode.com/problems/find-pivot-index/description/
 *
 * algorithms
 * Easy (40.67%)
 * Total Accepted:    62.1K
 * Total Submissions: 152.3K
 * Testcase Example:  '[1,7,3,6,5,6]'
 *
 * Given an array of integers nums, write a method that returns the "pivot"
 * index of this array.
 * 
 * We define the pivot index as the index where the sum of the numbers to the
 * left of the index is equal to the sum of the numbers to the right of the
 * index.
 * 
 * If no such index exists, we should return -1. If there are multiple pivot
 * indexes, you should return the left-most pivot index.
 * 
 * Example 1:
 * 
 * 
 * Input: 
 * nums = [1, 7, 3, 6, 5, 6]
 * Output: 3
 * Explanation: 
 * The sum of the numbers to the left of index 3 (nums[3] = 6) is equal to the
 * sum of numbers to the right of index 3.
 * Also, 3 is the first index where this occurs.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 
 * nums = [1, 2, 3]
 * Output: -1
 * Explanation: 
 * There is no index that satisfies the conditions in the problem
 * statement.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * The length of nums will be in the range [0, 10000].
 * Each element nums[i] will be an integer in the range [-1000, 1000].
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int PivotIndex(int[] nums) {
        if (nums.Length == 0)
            return -1;
        if (nums.Length == 1)
            return 0;

        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        int tem = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            tem += nums[i];
            if (sum - tem == tem - nums[i])
                return i;
            // if (tem * 2 > sum)
            // {
            //     if (sum - tem == tem - nums[i])
            //         return i;
            //     return -1;
            // }
        }

        return -1;
    }
}

// √ Accepted
//   √ 741/741 cases passed (116 ms)
//   √ Your runtime beats 80.08 % of csharp submissions
//   √ Your memory usage beats 84.62 % of csharp submissions (28.7 MB)

