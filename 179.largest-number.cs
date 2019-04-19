/*
 * @lc app=leetcode id=179 lang=csharp
 *
 * [179] Largest Number
 *
 * https://leetcode.com/problems/largest-number/description/
 *
 * algorithms
 * Medium (25.51%)
 * Total Accepted:    125.5K
 * Total Submissions: 491.2K
 * Testcase Example:  '[10,2]'
 *
 * Given a list of non negative integers, arrange them such that they form the
 * largest number.
 * 
 * Example 1:
 * 
 * 
 * Input: [10,2]
 * Output: "210"
 * 
 * Example 2:
 * 
 * 
 * Input: [3,30,34,5,9]
 * Output: "9534330"
 * 
 * 
 * Note: The result may be very large, so you need to return a string instead
 * of an integer.
 * 
 */
public class Solution {
    public string LargestNumber(int[] nums) {
        List<string> list = new List<string>();
        foreach (var num in nums)
        {
            list.Add(num.ToString());
        }

        list.Sort((a, b) => { return (a + b).CompareTo(b + a); });

        StringBuilder builder = new StringBuilder();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if(builder.Length == 0 && list[i] == "0")
                continue;
            builder.Append(list[i]);
        }

        if (builder.Length == 0)
            builder.Append("0");

        return builder.ToString();
    }
}

// √ Accepted
//   √ 222/222 cases passed (144 ms)
//   √ Your runtime beats 50 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (24.6 MB)

