/*
 * @lc app=leetcode id=540 lang=csharp
 *
 * [540] Single Element in a Sorted Array

 Given a sorted array consisting of only integers where every element appears exactly twice except for one element which appears exactly once. Find this single element that appears only once.

 

Example 1:

Input: [1,1,2,3,3,4,4,8,8]
Output: 2
Example 2:

Input: [3,3,7,7,10,11,11]
Output: 10
 

Note: Your solution should run in O(log n) time and O(1) space.
 */
public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] == nums[mid - 1])
            {//中点跟左边的相等，则判断除开中点，左边还剩几位数；
                if ((mid - left) % 2 == 0)
                {//若为偶数，则说明左边的存在答案值，改变right的值
                    right = mid - 2;
                }
                else
                {//若为奇数，则说明右边的存在答案值，改变left的值
                    left = mid + 1;
                }
            }
            else if (nums[mid] == nums[mid + 1])
            {//中点跟右边的相等，则判断除开中点，右边还剩几位数；
                if ((right - mid) % 2 == 0)
                {//若为偶数，则说明右边的存在答案值，改变left的值
                    left = mid + 2;
                }
                else
                {//若为奇数，则说明左边的存在答案值，改变right的值
                    right = mid - 1;
                }
            }
            else
            {//中点跟左右都不相等，直接返回
                return nums[mid];
            }
        }

        return nums[right];
    }
}

// √ Accepted
//   √ 12/12 cases passed (104 ms)
//   √ Your runtime beats 38.04 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (23.7 MB)

