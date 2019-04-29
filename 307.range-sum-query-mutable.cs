/*
 * @lc app=leetcode id=307 lang=csharp
 *
 * [307] Range Sum Query - Mutable

 Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

The update(i, val) function modifies nums by updating the element at index i to val.

Example:

Given nums = [1, 3, 5]

sumRange(0, 2) -> 9
update(1, 2)
sumRange(0, 2) -> 8
Note:

The array is only modifiable by the update function.
You may assume the number of calls to update and sumRange function is distributed evenly.
 */
public class NumArray {

    private int[] nums;
    private int[] sum;

    public NumArray(int[] nums)
    {
        this.nums = nums;
        sum = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
                sum[i] = nums[i];
            else
                sum[i] = sum[i - 1] + nums[i];
        }
    }

    public void Update(int i, int val)
    {
        int d = val - nums[i];
        for (int j = i; j < nums.Length; j++)
        {
            sum[j] += d;
        }

        nums[i] = val;
    }

    public int SumRange(int i, int j)
    {
        if (i == 0)
            return sum[j];
        return sum[j] - sum[i - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(i,val);
 * int param_2 = obj.SumRange(i,j);
 */

//  √ Accepted
//   √ 10/10 cases passed (336 ms)
//   √ Your runtime beats 27.5 % of csharp submissions
//   √ Your memory usage beats 41.67 % of csharp submissions (35.9 MB)

