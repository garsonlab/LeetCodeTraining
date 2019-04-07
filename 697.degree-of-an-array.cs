/*
 * @lc app=leetcode id=697 lang=csharp
 *
 * [697] Degree of an Array
 *
 * https://leetcode.com/problems/degree-of-an-array/description/
 *
 * algorithms
 * Easy (49.53%)
 * Total Accepted:    45.2K
 * Total Submissions: 90.7K
 * Testcase Example:  '[1,2,2,3,1]'
 *
 * Given a non-empty array of non-negative integers nums, the degree of this
 * array is defined as the maximum frequency of any one of its elements.
 * Your task is to find the smallest possible length of a (contiguous) subarray
 * of nums, that has the same degree as nums.
 * 
 * Example 1:
 * 
 * Input: [1, 2, 2, 3, 1]
 * Output: 2
 * Explanation: 
 * The input array has a degree of 2 because both elements 1 and 2 appear
 * twice.
 * Of the subarrays that have the same degree:
 * [1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
 * The shortest length is 2. So return 2.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: [1,2,2,3,1,4,2]
 * Output: 6
 * 
 * 
 * 
 * Note:
 * nums.length will be between 1 and 50,000.
 * nums[i] will be an integer between 0 and 49,999.
 * 
 */
public class Solution {
    public int FindShortestSubArray(int[] nums) {
        if (nums.Length <= 0)
            return 0;

        int max = -1;

        Dictionary<int, int> dic= new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int n;
            if (!dic.TryGetValue(nums[i], out n))
                n = 0;
            dic[nums[i]] = n + 1;

            if (n + 1 > max)
            {
                max = n + 1;
            }
        }

        int min = int.MaxValue;
        foreach (var element in dic)
        {
            if (element.Value == max)
            {
                int s = Array.IndexOf(nums, element.Key);
                int e = Array.LastIndexOf(nums, element.Key);
                min = Math.Min(min, e - s + 1);
            }
        }

        return min;
    }
}

// √ Accepted
//   √ 89/89 cases passed (240 ms)
//   √ Your runtime beats 11.86 % of csharp submissions
//   √ Your memory usage beats 88.89 % of csharp submissions (29.6 MB)

