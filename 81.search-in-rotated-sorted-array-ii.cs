/*
 * @lc app=leetcode id=81 lang=csharp
 *
 * [81] Search in Rotated Sorted Array II
 *
 * https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/
 *
 * algorithms
 * Medium (32.54%)
 * Total Accepted:    165.2K
 * Total Submissions: 507.5K
 * Testcase Example:  '[2,5,6,0,0,1,2]\n0'
 *
 * Suppose an array sorted in ascending order is rotated at some pivot unknown
 * to you beforehand.
 * 
 * (i.e., [0,0,1,2,2,5,6] might become [2,5,6,0,0,1,2]).
 * 
 * You are given a target value to search. If found in the array return true,
 * otherwise return false.
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,5,6,0,0,1,2], target = 0
 * Output: true
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,5,6,0,0,1,2], target = 3
 * Output: false
 * 
 * Follow up:
 * 
 * 
 * This is a follow up problem to Search in Rotated Sorted Array, where nums
 * may contain duplicates.
 * Would this affect the run-time complexity? How and why?
 * 
 * 
 */
public class Solution {

    public bool Search(int[] nums, int target)
    {
        int start = 0, end = nums.Length - 1;
        while (start <= end)
        {
            int mid = (start + end) / 2;

            if (nums[mid] == target)
                return true;

            if (nums[start] < nums[mid])
            {
                if (nums[mid] > target && target >= nums[start])
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            else if (nums[mid] < nums[end])
            {
                if (nums[mid] < target && target <= nums[end])
                    start = mid + 1;
                else
                    end = mid - 1;
            }
            else
            {
                if (nums[start] == nums[mid])
                    start++;
                else
                    end--;
            }
        }

        return false;
    }
    
    public bool Searcho(int[] nums, int target)
    {
        return MidSearch(ref nums, 0, nums.Length - 1, target);
    }

    private bool MidSearch(ref int[] nums, int l, int r, int target)
    {
        if (r < l || (l == r && nums[l] != target))
            return false;

        int mid = (l + r) / 2;
        if (nums[mid] == target)
            return true;
        if (r - l == 1)
        {
            return nums[r] == target ? true : false;
        }

        if (nums[l] < nums[mid])
        {
            if (nums[mid] > target && nums[l] <= target)
                return MidSearch(ref nums, l, mid - 1, target);
            else
                return MidSearch(ref nums, mid + 1, r, target);
        }
        else if(nums[mid] < nums[r])
        {
            if (nums[mid] < target && nums[r] >= target)
                return MidSearch(ref nums, mid + 1, r, target);
            else
                return MidSearch(ref nums, l, mid - 1, target);
        }
        else
        {
            if (nums[l] == nums[mid])
                return MidSearch(ref nums, l++, r, target);
            return MidSearch(ref nums, l, r--, target);
        }
    }

}

// √ Accepted
//   √ 275/275 cases passed (96 ms)
//   √ Your runtime beats 96.76 % of csharp submissions
//   √ Your memory usage beats 9.52 % of csharp submissions (23.3 MB)

