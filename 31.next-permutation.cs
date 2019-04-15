/*
 * @lc app=leetcode id=31 lang=csharp
 *
 * [31] Next Permutation
 *
 * https://leetcode.com/problems/next-permutation/description/
 *
 * algorithms
 * Medium (30.25%)
 * Total Accepted:    226.3K
 * Total Submissions: 747.5K
 * Testcase Example:  '[1,2,3]'
 *
 * Implement next permutation, which rearranges numbers into the
 * lexicographically next greater permutation of numbers.
 * 
 * If such arrangement is not possible, it must rearrange it as the lowest
 * possible order (ie, sorted in ascending order).
 * 
 * The replacement must be in-place and use only constant extra memory.
 * 
 * Here are some examples. Inputs are in the left-hand column and its
 * corresponding outputs are in the right-hand column.
 * 
 * 1,2,3 → 1,3,2
 * 3,2,1 → 1,2,3
 * 1,1,5 → 1,5,1
 * 
 */
public class Solution {
    public void NextPermutation(int[] nums)
    {
        if (nums.Length <= 1)
            return;
        if (nums.Length == 2)
        {
            Swap(ref nums, 0, 1);
            return;
        }

        int flag = nums.Length - 2;
        for (; flag >= 0; flag--)
        {
            if (nums[flag] < nums[flag + 1])
            {
                break;
            }
        }

        if (flag < 0)
        {
            Array.Sort(nums);
            return;
        }

        for (int i = nums.Length - 1; i > flag; i--)
        {
            if (nums[i] > nums[flag])
            {
                Swap(ref nums, flag, i);
                Array.Sort(nums, flag + 1, nums.Length - 1 - flag);
                break;
            }
        }
    }

    private void Swap(ref int[] nums, int a, int b)
    {
        int tem = nums[a];
        nums[a] = nums[b];
        nums[b] = tem;
    }
}

//从后往前找递增序列，如果前一个小于后一个，那么前一个一定是要交换的 。
    //再从后找大于上一步的目标值，交换后从目标值往后排序或反转
// √ Accepted
//   √ 265/265 cases passed (256 ms)
//   √ Your runtime beats 57.64 % of csharp submissions
//   √ Your memory usage beats 83.72 % of csharp submissions (29.5 MB)

