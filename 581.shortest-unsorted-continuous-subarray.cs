/*
 * @lc app=leetcode id=581 lang=csharp
 *
 * [581] Shortest Unsorted Continuous Subarray
 *
 * https://leetcode.com/problems/shortest-unsorted-continuous-subarray/description/
 *
 * algorithms
 * Easy (29.75%)
 * Total Accepted:    61.6K
 * Total Submissions: 206.7K
 * Testcase Example:  '[2,6,4,8,10,9,15]'
 *
 * Given an integer array, you need to find one continuous subarray that if you
 * only sort this subarray in ascending order, then the whole array will be
 * sorted in ascending order, too.  
 * 
 * You need to find the shortest such subarray and output its length.
 * 
 * Example 1:
 * 
 * Input: [2, 6, 4, 8, 10, 9, 15]
 * Output: 5
 * Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make
 * the whole array sorted in ascending order.
 * 
 * 
 * 
 * Note:
 * 
 * Then length of the input array is in range [1, 10,000].
 * The input array may contain duplicates, so ascending order here means . 
 * 
 * 
 */
public class Solution {
    public int FindUnsortedSubarray(int[] nums)
    {
        if (nums.Length <= 1)
            return 0;
        List<int> list = new List<int>(nums);
        list.Sort();

        int i = 0, j = nums.Length - 1;
        for (; i < nums.Length && nums[i] == list[i]; i++)
        {
        }

        for (; j >= 0 && nums[j] == list[j]; j--)
        {
        }

        return Math.Max(j - i + 1, 0);
    }
    
    //测试失败 13333257769
    public int FindUnsortedSubarray2(int[] nums) {
        if (nums.Length <= 1)
            return 0;
        int s = 0, e=0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                s = i - 1;
                break;
            }
        }

        for (int i = nums.Length-2; i >= 0; i--)
        {
            if (nums[i] > nums[i + 1])
            {
                e = i + 1;
                break;
            }
        }

        return e == s ? 0 : e - s + 1;
    }
}

// √ Accepted
//   √ 307/307 cases passed (136 ms)
//   √ Your runtime beats 61.83 % of csharp submissions
//   √ Your memory usage beats 6.67 % of csharp submissions (30.1 MB)

