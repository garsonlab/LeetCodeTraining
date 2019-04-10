/*
 * @lc app=leetcode id=849 lang=csharp
 *
 * [849] Maximize Distance to Closest Person
 *
 * https://leetcode.com/problems/maximize-distance-to-closest-person/description/
 *
 * algorithms
 * Easy (40.44%)
 * Total Accepted:    28.6K
 * Total Submissions: 70.4K
 * Testcase Example:  '[1,0,0,0,1,0,1]'
 *
 * In a row of seats, 1 represents a person sitting in that seat, and 0
 * represents that the seat is empty. 
 * 
 * There is at least one empty seat, and at least one person sitting.
 * 
 * Alex wants to sit in the seat such that the distance between him and the
 * closest person to him is maximized. 
 * 
 * Return that maximum distance to closest person.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,0,0,0,1,0,1]
 * Output: 2
 * Explanation: 
 * If Alex sits in the second open seat (seats[2]), then the closest person has
 * distance 2.
 * If Alex sits in any other open seat, the closest person has distance 1.
 * Thus, the maximum distance to the closest person is 2.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,0,0,0]
 * Output: 3
 * Explanation: 
 * If Alex sits in the last seat, the closest person is 3 seats away.
 * This is the maximum distance possible, so the answer is 3.
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= seats.length <= 20000
 * seats contains only 0s or 1s, at least one 0, and at least one 1.
 * 
 * 
 * 
 * 
 */
public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int max = 0;
        int start = -1;
        for (int i = 0; i < seats.Length; i++)
        {
            if (seats[i] == 0)
            {
                if (start == -1)
                    start = i;
            }
            else
            {
                if (start == 0)
                    max = i;
                else if(start > 0)
                    max = Math.Max(max, (i - start + 1) / 2);

                start = -1;
            }
        }

        if (start != -1)
        {
            max = Math.Max(max, seats.Length - start);
        }

        return max;
    }
}

// √ Accepted
//   √ 79/79 cases passed (104 ms)
//   √ Your runtime beats 95.2 % of csharp submissions
//   √ Your memory usage beats 45.45 % of csharp submissions (25.9 MB)

