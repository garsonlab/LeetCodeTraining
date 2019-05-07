/*
 * @lc app=leetcode id=539 lang=csharp
 *
 * [539] Minimum Time Difference

 Given a list of 24-hour clock time points in "Hour:Minutes" format, find the minimum minutes difference between any two time points in the list.
Example 1:
Input: ["23:59","00:00"]
Output: 1
Note:
The number of time points in the given list is at least 2 and won't exceed 20000.
The input time is legal and ranges from 00:00 to 23:59.
 */
public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        List<int> list = new List<int>();
        foreach (var time in timePoints)
        {
            string[] ps = time.Split(':');
            int h = int.Parse(ps[0]);
            int m = int.Parse(ps[1]);
            
            list.Add(h*60+m);
            // if(h == 0)
            //     list.Add(24*60+m);
        }
        list.Sort();

        int min = int.MaxValue;
        for (int i = 1; i < list.Count; i++)
        {
            min = Math.Min(min, list[i]-list[i-1]);
        }

        int t0 = 24*60+list[0];
        min = Math.Min(min, t0-list[list.Count-1]);

        return min;
    }
}


// √ Accepted
//   √ 112/112 cases passed (116 ms)
//   √ Your runtime beats 79.37 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (26.4 MB)

