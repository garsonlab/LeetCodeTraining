/*
 * @lc app=leetcode id=303 lang=csharp
 *
 * [303] Range Sum Query - Immutable
 *
 * https://leetcode.com/problems/range-sum-query-immutable/description/
 *
 * algorithms
 * Easy (36.94%)
 * Total Accepted:    131K
 * Total Submissions: 353.5K
 * Testcase Example:  '["NumArray","sumRange","sumRange","sumRange"]\n[[[-2,0,3,-5,2,-1]],[0,2],[2,5],[0,5]]'
 *
 * Given an integer array nums, find the sum of the elements between indices i
 * and j (i ≤ j), inclusive.
 * 
 * Example:
 * 
 * Given nums = [-2, 0, 3, -5, 2, -1]
 * 
 * sumRange(0, 2) -> 1
 * sumRange(2, 5) -> -1
 * sumRange(0, 5) -> -3
 * 
 * 
 * 
 * Note:
 * 
 * You may assume that the array does not change.
 * There are many calls to sumRange function.
 * 
 * 
 */
public class NumArray {

    private int[] nums;
    private int[] sums;
    private int sumLen;

    public NumArray(int[] nums)
    {
        this.nums = nums;
        sums = new int[nums.Length];
        if(nums.Length > 0)
        {
            sums[0] = nums[0];
            sumLen = 0;
        }
        else
        {
            sumLen = -1;
        }
    }

    public int SumRange(int i, int j)
    {
        if (sumLen < i)
        {
            for (int k = sumLen+1; k <= i; k++)
            {
                sums[k] = sums[k - 1] + nums[k];
            }

            sumLen = i;
        }

        if (sumLen < j)
        {
            for (int k = sumLen + 1; k <= j; k++)
            {
                sums[k] = sums[k - 1] + nums[k];
            }

            sumLen = j;
        }

        if (i == 0)
            return sums[j];
        else
            return sums[j] - sums[i - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */


// √ Accepted
//   √ 16/16 cases passed (148 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 52.94 % of csharp submissions (33.8 MB)


