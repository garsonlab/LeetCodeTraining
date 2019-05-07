/*
 * @lc app=leetcode id=525 lang=csharp
 *
 * [525] Contiguous Array

 Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

Example 1:
Input: [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
Example 2:
Input: [0,1,0]
Output: 2
Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
Note: The length of the given binary array will not exceed 50,000.
 */
public class Solution {
    public int FindMaxLength(int[] nums) {
        int length = 0, sum = 0;
        Dictionary<int, int> dic= new Dictionary<int, int>();
        dic[0] = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i] == 1 ? 1 : -1;
            if (dic.ContainsKey(sum))
                length = Math.Max(length, i - dic[sum]);
            else
                dic[sum] = i;
        }

        return length;
    }
}

// √ Accepted
//   √ 555/555 cases passed (240 ms)
//   √ Your runtime beats 30.77 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (41.8 MB)

