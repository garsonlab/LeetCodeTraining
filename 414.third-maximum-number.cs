/*
 * @lc app=leetcode id=414 lang=csharp
 *
 * [414] Third Maximum Number
 *
 * https://leetcode.com/problems/third-maximum-number/description/
 *
 * algorithms
 * Easy (28.75%)
 * Total Accepted:    87.2K
 * Total Submissions: 302.9K
 * Testcase Example:  '[3,2,1]'
 *
 * Given a non-empty array of integers, return the third maximum number in this
 * array. If it does not exist, return the maximum number. The time complexity
 * must be in O(n).
 * 
 * Example 1:
 * 
 * Input: [3, 2, 1]
 * 
 * Output: 1
 * 
 * Explanation: The third maximum is 1.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: [1, 2]
 * 
 * Output: 2
 * 
 * Explanation: The third maximum does not exist, so the maximum (2) is
 * returned instead.
 * 
 * 
 * 
 * Example 3:
 * 
 * Input: [2, 2, 3, 1]
 * 
 * Output: 1
 * 
 * Explanation: Note that the third maximum here means the third maximum
 * distinct number.
 * Both numbers with value 2 are both considered as second maximum.
 * 
 * 
 */
public class Solution {
    public int ThirdMax(int[] nums) {
        List<int> list = new List<int>(nums);
        list.Sort();

        int val = list[list.Count - 1];
        int idx = 1;
        for (int i = list.Count-2; i >= 0; i--)
        {
            if (val != list[i])
            {
                val = list[i];
                idx++;

                if (idx == 3)
                    return val;
            }
        }

        return list[list.Count - 1];
    }
}


// √ Accepted
//   √ 26/26 cases passed (96 ms)
//   √ Your runtime beats 77.86 % of csharp submissions
//   √ Your memory usage beats 61.11 % of csharp submissions (22.5 MB)

