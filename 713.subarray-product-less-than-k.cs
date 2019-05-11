/*
 * @lc app=leetcode id=713 lang=csharp
 *
 * [713] Subarray Product Less Than K
 Your are given an array of positive integers nums.

Count and print the number of (contiguous) subarrays where the product of all the elements in the subarray is less than k.

Example 1:
Input: nums = [10, 5, 2, 6], k = 100
Output: 8
Explanation: The 8 subarrays that have product less than 100 are: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6].
Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.
Note:

0 < nums.length <= 50000.
0 < nums[i] < 1000.
0 <= k < 10^6.
 */
public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int numsSize = nums.Length, result = 0;
        int left = 0, right = 0, tempK = 1;
        while (left < numsSize)
        {
            //一直移动right，直到出界或者子数组乘积不小于k
            while (right < numsSize && tempK * nums[right] < k)
            {
                tempK *= nums[right++];
            }
            if (right <= left)
            {
                //此时是特殊情况，需要修正两个指针，比如[10, 5, 1], k = 5,出现了比k大的元素，此时right无法移动，需要矫正
                right = ++left;
                tempK = 1;
            }
            else
            {
                //计算以nums[left]为左边界的子数组个数
                result += (right - left);
                tempK /= nums[left++];//右移左边界，并且将nums[left]移出子数组的乘积
            }
        }
        return result;
    }


    public int NumSubarrayProductLessThanK_111(int[] nums, int k) {
        int numsSize = nums.Length, result = 0;
        for (int right = 0; right < numsSize; ++right)
        {//子数组以nums[right]为结尾
            int left = right, tempK = 1;
            while (left >= 0 && nums[left] * tempK < k)
            {//一直往前扩展子数组，直到出边界或者大小超过了K
                tempK *= nums[left--];
                result += 1;
            }
        }
        return result;
    }
}

// √ Accepted
//   √ 84/84 cases passed (268 ms)
//   √ Your runtime beats 45.54 % of csharp submissions
//   √ Your memory usage beats 44.44 % of csharp submissions (42.2 MB)

