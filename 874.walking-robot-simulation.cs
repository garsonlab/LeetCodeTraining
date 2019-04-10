/*
 * @lc app=leetcode id=874 lang=csharp
 *
 * [874] Walking Robot Simulation
 *
 * https://leetcode.com/problems/walking-robot-simulation/description/
 *
 * algorithms
 * Easy (31.11%)
 * Total Accepted:    8.7K
 * Total Submissions: 27.8K
 * Testcase Example:  '[4,-1,3]\n[]'
 *
 * A robot on an infinite grid starts at point (0, 0) and faces north.  The
 * robot can receive one of three possible types of commands:
 * 
 * 
 * -2: turn left 90 degrees
 * -1: turn right 90 degrees
 * 1 <= x <= 9: move forward x units
 * 
 * 
 * Some of the grid squares are obstacles. 
 * 
 * The i-th obstacle is at grid point (obstacles[i][0], obstacles[i][1])
 * 
 * If the robot would try to move onto them, the robot stays on the previous
 * grid square instead (but still continues following the rest of the route.)
 * 
 * Return the square of the maximum Euclidean distance that the robot will be
 * from the origin.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: commands = [4,-1,3], obstacles = []
 * Output: 25
 * Explanation: robot will go to (3, 4)
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: commands = [4,-1,4,-2,4], obstacles = [[2,4]]
 * Output: 65
 * Explanation: robot will be stuck at (1, 4) before turning left and going to
 * (1, 8)
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 0 <= commands.length <= 10000
 * 0 <= obstacles.length <= 10000
 * -30000 <= obstacle[i][0] <= 30000
 * -30000 <= obstacle[i][1] <= 30000
 * The answer is guaranteed to be less than 2 ^ 31.
 * 
 * 
 */
public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        int[][] dirs = new[] {new[] {0, 1}, new[] {-1, 0}, new[] {0, -1}, new[] {1, 0}};
        int max = 0;
        int dir = 0;

        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < obstacles.Length; i++)
        {
            dic[obstacles[i][0] + "," + obstacles[i][1]] = 1;
        }
        int curX = 0, curY = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] == -1)
                dir = (dir + 3) % 4;
            else if (commands[i] == -2)
                dir = (dir + 1) % 4;
            else
            {
                for (int j = 0; j < commands[i]; j++)
                {
                    int temX = curX + dirs[dir][0];
                    int temY = curY + dirs[dir][1];

                    if (dic.ContainsKey(temX + "," + temY))
                    {
                        break;
                    }
                    else
                    {
                        curX = temX;
                        curY = temY;
                    }
                }

                max = Math.Max(max, curX * curX + curY * curY);
            }
        }

        return max;
    }
}

// √ Accepted
//   √ 47/47 cases passed (308 ms)
//   √ Your runtime beats 55 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (40.8 MB)

