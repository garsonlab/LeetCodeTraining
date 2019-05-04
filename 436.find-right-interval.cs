/*
 * @lc app=leetcode id=436 lang=csharp
 *
 * [436] Find Right Interval

 Given a set of intervals, for each of the interval i, check if there exists an interval j whose start point is bigger than or equal to the end point of the interval i, which can be called that j is on the "right" of i.

For any interval i, you need to store the minimum interval j's index, which means that the interval j has the minimum start point to build the "right" relationship for interval i. If the interval j doesn't exist, store -1 for the interval i. Finally, you need output the stored value of each interval as an array.

Note:

You may assume the interval's end point is always bigger than its start point.
You may assume none of these intervals have the same start point.
 

Example 1:

Input: [ [1,2] ]

Output: [-1]

Explanation: There is only one interval in the collection, so it outputs -1.
 

Example 2:

Input: [ [3,4], [2,3], [1,2] ]

Output: [-1, 0, 1]

Explanation: There is no satisfied "right" interval for [3,4].
For [2,3], the interval [3,4] has minimum-"right" start point;
For [1,2], the interval [2,3] has minimum-"right" start point.
 

Example 3:

Input: [ [1,4], [2,3], [3,4] ]

Output: [-1, 2, -1]

Explanation: There is no satisfied "right" interval for [1,4] and [3,4].
For [2,3], the interval [3,4] has minimum-"right" start point.
NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
 */
public class Solution {
    public int[] FindRightInterval(int[][] intervals) {
        int len = intervals.Length;
        if(len <= 0)
            return new int[0];
        if(len == 1)
            return new []{-1};

        int[] res = new int[len];
        int[][] flag = new int[len][];
        for (int i = 0; i < len; i++)
        {
            flag[i] = new int[]{intervals[i][0], i};
        }
        Array.Sort(flag, (a, b) => {
            return a[0]-b[0];
        });

        for (int i = 0; i < len; i++)
        {
            res[i] = BSearch(flag, intervals[i][1], 0, len-1);
        }
        return res;
    }

    private int BSearch(int[][] flag, int v, int s, int e) {
        if(s > e) return -1;
        if(s == e) return flag[s][0] < v? -1 : flag[s][1];

        int mid = (s+e)/2;
        if(flag[mid][0] < v)
            return BSearch(flag, v, mid+1, e);
        else
        {
            if(mid == e)
                return flag[mid][1];
            return BSearch(flag, v, s, mid);
        }
    }
}


// √ Accepted
//   √ 17/17 cases passed (364 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (40.2 MB)

