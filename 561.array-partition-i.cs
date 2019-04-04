/*
 * @lc app=leetcode id=561 lang=csharp
 *
 * [561] Array Partition I
 *
 * https://leetcode.com/problems/array-partition-i/description/
 *
 * algorithms
 * Easy (68.46%)
 * Total Accepted:    135.4K
 * Total Submissions: 197.5K
 * Testcase Example:  '[1,4,3,2]'
 *
 * 
 * Given an array of 2n integers, your task is to group these integers into n
 * pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of
 * min(ai, bi) for all i from 1 to n as large as possible.
 * 
 * 
 * Example 1:
 * 
 * Input: [1,4,3,2]
 * 
 * Output: 4
 * Explanation: n is 2, and the maximum sum of pairs is 4 = min(1, 2) + min(3,
 * 4).
 * 
 * 
 * 
 * Note:
 * 
 * n is a positive integer, which is in the range of [1, 10000].
 * All the integers in the array will be in the range of [-10000, 10000].
 * 
 * 
 */
public class Solution {
    public int ArrayPairSum(int[] nums) {
        List<int> list = new List<int>(nums);
        list.Sort();

        int sum = 0;
        for (int i = 0; i < list.Count;)
        {
            sum += list[i];
            i += 2;
        }

        return sum;
    }
}

// √ Accepted
//   √ 81/81 cases passed (160 ms)
//   √ Your runtime beats 88.07 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (33.7 MB)

