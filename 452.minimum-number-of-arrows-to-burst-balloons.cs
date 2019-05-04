/*
 * @lc app=leetcode id=452 lang=csharp
 *
 * [452] Minimum Number of Arrows to Burst Balloons

 There are a number of spherical balloons spread in two-dimensional space. For each balloon, provided input is the start and end coordinates of the horizontal diameter. Since it's horizontal, y-coordinates don't matter and hence the x-coordinates of start and end of the diameter suffice. Start is always smaller than end. There will be at most 104 balloons.

An arrow can be shot up exactly vertically from different points along the x-axis. A balloon with xstart and xend bursts by an arrow shot at x if xstart ≤ x ≤ xend. There is no limit to the number of arrows that can be shot. An arrow once shot keeps travelling up infinitely. The problem is to find the minimum number of arrows that must be shot to burst all balloons.

Example:

Input:
[[10,16], [2,8], [1,6], [7,12]]

Output:
2

Explanation:
One way is to shoot one arrow for example at x = 6 (bursting the balloons [2,8] and [1,6]) and another arrow at x = 11 (bursting the other two balloons).
 */
public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if(points.Length <= 1)
            return points.Length;
        
        Array.Sort(points, (a, b) => {
            return a[0]-b[0];
        });

        int res = 1;
        int start = points[0][0];
        int end = points[0][1];
        for (int i = 1; i < points.Length; i++)
        {
            if (points[i][0] <= end){
	    		start = points[i][0]; //新气球左端点小于设计区间右端点，那么说明可以击穿，更新射击区间左端点
    			if (points[i][1] < end){
			    	end = points[i][1];//新球右端点小于设计区间左端点，那么说明可以击穿，更新设计区间右端点
                    //设计区间维护其实就是在不断缩小射击区间
			    }
	    	}
	    	else{//不满足情况时，多用一个弓箭
	    		res++;
	    		start = points[i][0];
	    		end = points[i][1];//初始化新的弓箭设计区域
	    	}
        }
        return res;
    }
}

// √ Accepted
//   √ 43/43 cases passed (284 ms)
//   √ Your runtime beats 78.31 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (38.1 MB)

