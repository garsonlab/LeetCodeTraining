/*
 * @lc app=leetcode id=1025 lang=csharp
 *
 * [1025] Divisor Game

 Alice and Bob take turns playing a game, with Alice starting first.

Initially, there is a number N on the chalkboard.  On each player's turn, that player makes a move consisting of:

Choosing any x with 0 < x < N and N % x == 0.
Replacing the number N on the chalkboard with N - x.
Also, if a player cannot make a move, they lose the game.

Return True if and only if Alice wins the game, assuming both players play optimally.

 

Example 1:

Input: 2
Output: true
Explanation: Alice chooses 1, and Bob has no more moves.
Example 2:

Input: 3
Output: false
Explanation: Alice chooses 1, Bob chooses 1, and Alice has no more moves.
 

Note:

1 <= N <= 1000
 */
public class Solution {
    public bool DivisorGame(int N) {
        if(N%2==0)
            return true;
        else
            return false;
    }
}

// 若N是偶数，在爱丽丝每步都是以最佳状态 // 选择的情况下，爱丽丝可以赢得比赛；若N是奇数，在鲍勃以最佳状态选择的情况下，鲍勃可以赢得比赛
// √ Accepted
//   √ 40/40 cases passed (32 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.6 MB)

