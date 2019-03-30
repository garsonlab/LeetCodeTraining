/*
 * @lc app=leetcode id=268 lang=csharp
 *
 * [268] Missing Number
 *
 * https://leetcode.com/problems/missing-number/description/
 *
 * algorithms
 * Easy (47.72%)
 * Total Accepted:    256.7K
 * Total Submissions: 537K
 * Testcase Example:  '[3,0,1]'
 *
 * Given an array containing n distinct numbers taken from 0, 1, 2, ..., n,
 * find the one that is missing from the array.
 * 
 * Example 1:
 * 
 * 
 * Input: [3,0,1]
 * Output: 2
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [9,6,4,2,3,5,7,0,1]
 * Output: 8
 * 
 * 
 * Note:
 * Your algorithm should run in linear runtime complexity. Could you implement
 * it using only constant extra space complexity?
 */
public class Solution {
    public int MissingNumber(int[] nums) {
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            if (nums[i] != i && nums[i] != len)
            {
                int idx = nums[i];
                while (nums[idx] != idx)
                {
                    int n = nums[idx];
                    nums[idx] = idx;
                    if (n == len)
                        break;
                    else
                        idx = n;
                }
            }
        }

        for (int i = 0; i < len; i++)
        {
            if (nums[i] == len || nums[i] != i)
                return i;
        }

        return nums.Length;
    }
}


// √ Accepted
//   √ 122/122 cases passed (112 ms)
//   √ Your runtime beats 75.5 % of csharp submissions
//   √ Your memory usage beats 80.36 % of csharp submissions (27.3 MB)



