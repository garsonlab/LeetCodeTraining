/*
 * @lc app=leetcode id=228 lang=csharp
 *
 * [228] Summary Ranges

 Given a sorted integer array without duplicates, return the summary of its ranges.

Example 1:

Input:  [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: 0,1,2 form a continuous range; 4,5 form a continuous range.
Example 2:

Input:  [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: 2,3,4 form a continuous range; 8,9 form a continuous range.
 */
public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        List<string> list = new List<string>();
        if (nums.Length <= 0)
            return list;
        
        int fir = nums[0];
        int pre = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] - pre == 1)
            {
                pre = nums[i];
            }
            else
            {
                if(fir == pre)
                    list.Add(fir.ToString());
                else
                    list.Add(fir + "->" + pre);

                fir = nums[i];
                pre = nums[i];
            }
        }
        if (fir == pre)
            list.Add(fir.ToString());
        else
            list.Add(fir + "->" + pre);
        
        return list;
    }
}

// √ Accepted
//   √ 28/28 cases passed (348 ms)
//   √ Your runtime beats 6.04 % of csharp submissions
//   √ Your memory usage beats 85.71 % of csharp submissions (28.1 MB)

