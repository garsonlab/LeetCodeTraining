/*
 * @lc app=leetcode id=754 lang=csharp
 *
 * [754] Reach a Number
 *
 * https://leetcode.com/problems/reach-a-number/description/
 *
 * algorithms
 * Easy (31.85%)
 * Total Accepted:    9.2K
 * Total Submissions: 28.8K
 * Testcase Example:  '1'
 *
 * 
 * You are standing at position 0 on an infinite number line.  There is a goal
 * at position target.
 * 
 * On each move, you can either go left or right.  During the n-th move
 * (starting from 1), you take n steps.
 * 
 * Return the minimum number of steps required to reach the destination.
 * 
 * 
 * Example 1:
 * 
 * Input: target = 3
 * Output: 2
 * Explanation:
 * On the first move we step from 0 to 1.
 * On the second step we step from 1 to 3.
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: target = 2
 * Output: 3
 * Explanation:
 * On the first move we step from 0 to 1.
 * On the second move we step  from 1 to -1.
 * On the third move we step from -1 to 2.
 * 
 * 
 * 
 * Note:
 * target will be a non-zero integer in the range [-10^9, 10^9].
 * 
 */
public class Solution {
    public int ReachNumber(int target) {
        target = Math.Abs(target);
        int sum = 0;
        int k = 0;

        while (sum < target)
        {
            sum += ++k;
        }

        if ((sum - target) % 2 == 0)
            return k;

        if (k % 2 == 0)
            return k + 1;
        return k + 2;
    }
}

//https://blog.csdn.net/weixin_37373020/article/details/80963488 规律
// √ Accepted
//   √ 73/73 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (12.8 MB)

