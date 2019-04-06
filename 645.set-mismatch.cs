/*
 * @lc app=leetcode id=645 lang=csharp
 *
 * [645] Set Mismatch
 *
 * https://leetcode.com/problems/set-mismatch/description/
 *
 * algorithms
 * Easy (40.49%)
 * Total Accepted:    44.5K
 * Total Submissions: 109.8K
 * Testcase Example:  '[1,2,2,4]'
 *
 * 
 * The set S originally contains numbers from 1 to n. But unfortunately, due to
 * the data error, one of the numbers in the set got duplicated to another
 * number in the set, which results in repetition of one number and loss of
 * another number. 
 * 
 * 
 * 
 * Given an array nums representing the data status of this set after the
 * error. Your task is to firstly find the number occurs twice and then find
 * the number that is missing. Return them in the form of an array.
 * 
 * 
 * 
 * Example 1:
 * 
 * Input: nums = [1,2,2,4]
 * Output: [2,3]
 * 
 * 
 * 
 * Note:
 * 
 * The given array size will in the range [2, 10000].
 * The given array's numbers won't have any order.
 * 
 * 
 */
public class Solution {
    public int[] FindErrorNums(int[] nums) {
        int[] r = new int[2];
        int[] flag = new int[nums.Length+1];
        for (int i = 0; i < nums.Length; i++)
        {
            if (flag[nums[i]] == 0)
            {
                flag[nums[i]] = 1;
            }
            else
            {
                r[0] = nums[i];
            }
        }

        for (int i = 1; i < flag.Length; i++)
        {
            if (flag[i] == 0)
                r[1] = i;
        }

        return r;
    }
}

// √ Accepted
//   √ 49/49 cases passed (272 ms)
//   √ Your runtime beats 98.92 % of csharp submissions
//   √ Your memory usage beats 40 % of csharp submissions (36.2 MB)

