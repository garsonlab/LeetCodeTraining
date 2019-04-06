/*
 * @lc app=leetcode id=657 lang=csharp
 *
 * [657] Robot Return to Origin
 *
 * https://leetcode.com/problems/robot-return-to-origin/description/
 *
 * algorithms
 * Easy (70.93%)
 * Total Accepted:    148.9K
 * Total Submissions: 209.7K
 * Testcase Example:  '"UD"'
 *
 * There is a robot starting at position (0, 0), the origin, on a 2D plane.
 * Given a sequence of its moves, judge if this robot ends up at (0, 0) after
 * it completes its moves.
 * 
 * The move sequence is represented by a string, and the character moves[i]
 * represents its ith move. Valid moves are R (right), L (left), U (up), and D
 * (down). If the robot returns to the origin after it finishes all of its
 * moves, return true. Otherwise, return false.
 * 
 * Note: The way that the robot is "facing" is irrelevant. "R" will always make
 * the robot move to the right once, "L" will always make it move left, etc.
 * Also, assume that the magnitude of the robot's movement is the same for each
 * move.
 * 
 * Example 1:
 * 
 * 
 * Input: "UD"
 * Output: true 
 * Explanation: The robot moves up once, and then down once. All moves have the
 * same magnitude, so it ended up at the origin where it started. Therefore, we
 * return true.
 * 
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "LL"
 * Output: false
 * Explanation: The robot moves left twice. It ends up two "moves" to the left
 * of the origin. We return false because it is not at the origin at the end of
 * its moves.
 * 
 * 
 */
public class Solution {
    public bool JudgeCircle(string moves) {
        if(moves.Length%2 > 0)
            return false;

        int[] cmds = new int[4];
        for (int i = 0; i < moves.Length; i++)
        {
            if(moves[i] == 'R')
                cmds[0] ++;
            else if(moves[i] == 'L')
                cmds[1] ++;
            else if(moves[i] == 'U')
                cmds[2] ++;
            else if(moves[i] == 'D')
                cmds[3] ++;
        }

        return cmds[0]==cmds[1] && cmds[2] == cmds[3];
    }
}

//向左向右次数相同
// √ Accepted
//   √ 63/63 cases passed (80 ms)
//   √ Your runtime beats 87 % of csharp submissions
//   √ Your memory usage beats 13.89 % of csharp submissions (23.9 MB)

