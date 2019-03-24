/*
 * @lc app=leetcode id=27 lang=csharp
 *
 * [27] Remove Element
 *
 * https://leetcode.com/problems/remove-element/description/
 *
 * algorithms
 * Easy (43.83%)
 * Total Accepted:    382.3K
 * Total Submissions: 872.3K
 * Testcase Example:  '[3,2,2,3]\n3'
 *
 * Given an array nums and a value val, remove all instances of that value
 * in-place and return the new length.
 * 
 * Do not allocate extra space for another array, you must do this by modifying
 * the input array in-place with O(1) extra memory.
 * 
 * The order of elements can be changed. It doesn't matter what you leave
 * beyond the new length.
 * 
 * Example 1:
 * 
 * 
 * Given nums = [3,2,2,3], val = 3,
 * 
 * Your function should return length = 2, with the first two elements of nums
 * being 2.
 * 
 * It doesn't matter what you leave beyond the returned length.
 * 
 * 
 * Example 2:
 * 
 * 
 * Given nums = [0,1,2,2,3,0,4,2], val = 2,
 * 
 * Your function should return length = 5, with the first five elements of nums
 * containing 0, 1, 3, 0, and 4.
 * 
 * Note that the order of those five elements can be arbitrary.
 * 
 * It doesn't matter what values are set beyond the returned length.
 * 
 * Clarification:
 * 
 * Confused why the returned value is an integer but your answer is an array?
 * 
 * Note that the input array is passed in by reference, which means
 * modification to the input array will be known to the caller as well.
 * 
 * Internally you can think of this:
 * 
 * 
 * // nums is passed in by reference. (i.e., without making a copy)
 * int len = removeElement(nums, val);
 * 
 * // any modification to nums in your function would be known by the caller.
 * // using the length returned by your function, it prints the first len
 * elements.
 * for (int i = 0; i < len; i++) {
 * print(nums[i]);
 * }
 * [2,54,7,8,2,5,3,6,1,2]\n5
 */
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        
        int flag = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                if (flag != i)
                {
                    int tem = nums[flag];
                    nums[flag] = nums[i];
                    nums[i] = tem;
                }
                
                flag++;
            }
        }
        return flag;
    }
}

// √ Accepted
//   √ 113/113 cases passed (248 ms)
//   √ Your runtime beats 81.63 % of csharp submissions
//   √ Your memory usage beats 96.2 % of csharp submissions (28.2 MB)

