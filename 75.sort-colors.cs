/*
 * @lc app=leetcode id=75 lang=csharp
 *
 * [75] Sort Colors
 *
 * https://leetcode.com/problems/sort-colors/description/
 *
 * algorithms
 * Medium (41.73%)
 * Total Accepted:    305.8K
 * Total Submissions: 732.2K
 * Testcase Example:  '[2,0,2,1,1,0]'
 *
 * Given an array with n objects colored red, white or blue, sort them in-place
 * so that objects of the same color are adjacent, with the colors in the order
 * red, white and blue.
 * 
 * Here, we will use the integers 0, 1, and 2 to represent the color red,
 * white, and blue respectively.
 * 
 * Note: You are not suppose to use the library's sort function for this
 * problem.
 * 
 * Example:
 * 
 * 
 * Input: [2,0,2,1,1,0]
 * Output: [0,0,1,1,2,2]
 * 
 * Follow up:
 * 
 * 
 * A rather straight forward solution is a two-pass algorithm using counting
 * sort.
 * First, iterate the array counting number of 0's, 1's, and 2's, then
 * overwrite array with total number of 0's, then 1's and followed by 2's.
 * Could you come up with a one-pass algorithm using only constant space?
 * 
 * 
 */
public class Solution {
    public void SortColors(int[] nums) {
        for (int i = 0, j = nums.Length-1; i < j;)
        {
            if (nums[i] == 0)
            {
                i++;
                continue;
            }

            if (nums[j] == 2)
            {
                j--;
                continue;
            }

            bool found = false;
            for (int k = i; k <= j; k++)
            {
                if (nums[k] == 0)
                {
                    Swap(ref nums, i, k);
                    found = true;
                    break;
                }

                if (nums[k] == 2)
                {
                    Swap(ref nums, j, k);
                    found = true;
                    break;
                }
            }
            if(!found)
                break;
        }
    }
    private void Swap(ref int[] nums, int a, int b)
    {
        int tem = nums[a];
        nums[a] = nums[b];
        nums[b] = tem;
    }
}

// √ Accepted
//   √ 87/87 cases passed (244 ms)
//   √ Your runtime beats 89.26 % of csharp submissions
//   √ Your memory usage beats 13.89 % of csharp submissions (28.3 MB)

