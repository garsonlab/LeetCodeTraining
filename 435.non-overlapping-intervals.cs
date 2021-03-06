/*
 * @lc app=leetcode id=435 lang=csharp
 *
 * [435] Non-overlapping Intervals
 Given a collection of intervals, find the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.

Note:

You may assume the interval's end point is always bigger than its start point.
Intervals like [1,2] and [2,3] have borders "touching" but they don't overlap each other.
 

Example 1:

Input: [ [1,2], [2,3], [3,4], [1,3] ]

Output: 1

Explanation: [1,3] can be removed and the rest of intervals are non-overlapping.
 

Example 2:

Input: [ [1,2], [1,2], [1,2] ]

Output: 2

Explanation: You need to remove two [1,2] to make the rest of intervals non-overlapping.
 

Example 3:

Input: [ [1,2], [2,3] ]

Output: 0

Explanation: You don't need to remove any of the intervals since they're already non-overlapping.
NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
 */
public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length <= 0 || intervals[0].Length <= 0)
            return 0;

        Array.Sort(intervals, (a, b) => {
            if(a[1] != b[1])
                return a[1] - b[1];
            return a[0] - b[0];
        });

        int len = 1;
        int pre = 0;
        for (int i = 1; i < intervals.Length; i++) {
            if (intervals[i][0] >= intervals[pre][1]) {
                len++;
                pre = i;
            }
        }
        return intervals.Length - len;
    }
}


// √ Accepted
//   √ 18/18 cases passed (108 ms)
//   √ Your runtime beats 98.81 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (24.4 MB)
