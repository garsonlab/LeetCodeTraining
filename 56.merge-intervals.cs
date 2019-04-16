/*
 * @lc app=leetcode id=56 lang=csharp
 *
 * [56] Merge Intervals
 *
 * https://leetcode.com/problems/merge-intervals/description/
 *
 * algorithms
 * Medium (35.30%)
 * Total Accepted:    329.5K
 * Total Submissions: 932.7K
 * Testcase Example:  '[[1,3],[2,6],[8,10],[15,18]]'
 *
 * Given a collection of intervals, merge all overlapping intervals.
 * 
 * Example 1:
 * 
 * 
 * Input: [[1,3],[2,6],[8,10],[15,18]]
 * Output: [[1,6],[8,10],[15,18]]
 * Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into
 * [1,6].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [[1,4],[4,5]]
 * Output: [[1,5]]
 * Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 * 
 * NOTE: input types have been changed on April 15, 2019. Please reset to
 * default code definition to get new method signature.
 * 
 */
public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> list = new List<int[]>();
        
        Array.Sort(intervals, (a1, a2) => { return a1[0].CompareTo(a2[0]); } );
        int start = -1;
        int end = -1;
        for (int i = 0; i < intervals.Length; i++)
        {
            if (start == -1)
            {
                start = intervals[i][0];
                end = intervals[i][1];
            }
            else
            {
                if (intervals[i][0] <= end)
                {
                    end = Math.Max(end, intervals[i][1]);
                }
                else
                {
                    list.Add(new []{start, end});
                    start = intervals[i][0];
                    end = intervals[i][1];
                }
            }
        }

        if (start >= 0)
            list.Add(new[] { start, end });

        return list.ToArray();
    }
}

// √ Accepted
//   √ 169/169 cases passed (300 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (31.4 MB)

