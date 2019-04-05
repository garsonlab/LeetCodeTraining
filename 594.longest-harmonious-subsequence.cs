/*
 * @lc app=leetcode id=594 lang=csharp
 *
 * [594] Longest Harmonious Subsequence
 *
 * https://leetcode.com/problems/longest-harmonious-subsequence/description/
 *
 * algorithms
 * Easy (43.18%)
 * Total Accepted:    34K
 * Total Submissions: 78.6K
 * Testcase Example:  '[1,3,2,2,5,2,3,7]'
 *
 * We define a harmonious array is an array where the difference between its
 * maximum value and its minimum value is exactly 1.
 * 
 * Now, given an integer array, you need to find the length of its longest
 * harmonious subsequence among all its possible subsequences.
 * 
 * Example 1:
 * 
 * Input: [1,3,2,2,5,2,3,7]
 * Output: 5
 * Explanation: The longest harmonious subsequence is [3,2,2,2,3].
 * 
 * 
 * 
 * Note:
 * The length of the input array will not exceed 20,000.
 * 
 * 
 * 
 */
public class Solution {
    public int FindLHS(int[] nums) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        List<int> list = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int n;
            if (!dic.TryGetValue(nums[i], out n))
            {
                n = 0;
                list.Add(nums[i]);
            }
            dic[nums[i]] = n + 1;
        }
        list.Sort();

        int max = 0;
        for (int i = 1; i < list.Count; i++)
        {
            if(list[i] - list[i-1] == 1){
                int len = dic[list[i]] + dic[list[i-1]];
                if(len > max)
                    max = len;
            }
        }

        return max;
    }
}

// √ Accepted
//   √ 201/201 cases passed (168 ms)
//   √ Your runtime beats 68.97 % of csharp submissions
//   √ Your memory usage beats 12.5 % of csharp submissions (41.4 MB)

