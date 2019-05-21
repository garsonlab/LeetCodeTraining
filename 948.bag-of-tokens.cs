/*
 * @lc app=leetcode id=948 lang=csharp
 *
 * [948] Bag of Tokens

 You have an initial power P, an initial score of 0 points, and a bag of tokens.

Each token can be used at most once, has a value token[i], and has potentially two ways to use it.

If we have at least token[i] power, we may play the token face up, losing token[i] power, and gaining 1 point.
If we have at least 1 point, we may play the token face down, gaining token[i] power, and losing 1 point.
Return the largest number of points we can have after playing any number of tokens.

 

Example 1:

Input: tokens = [100], P = 50
Output: 0
Example 2:

Input: tokens = [100,200], P = 150
Output: 1
Example 3:

Input: tokens = [100,200,300,400], P = 200
Output: 2
 

Note:

tokens.length <= 1000
0 <= tokens[i] < 10000
0 <= P < 10000
 */
public class Solution {
    public int BagOfTokensScore(int[] tokens, int P) {
        if (tokens.Length == 0)
            return 0;

        Array.Sort(tokens);
        int maxScore = 0;
        int curScore = 0;
        int lIndex = 0;
        int rIndex = tokens.Length - 1;
        while (lIndex <= rIndex)
        {
            if (P >= tokens[lIndex])
            {
                P -= tokens[lIndex++];
                curScore++;
                maxScore = Math.Max(curScore, maxScore);
            }
            else if (curScore > 0)
            {
                P += tokens[rIndex--];
                curScore--;
            }
            else
            {
                break;
            }
        }
        return maxScore;
    }
}
//能量充足减左侧，能量不够兑换右侧
// √ Accepted
//   √ 147/147 cases passed (100 ms)
//   √ Your runtime beats 45.83 % of csharp submissions
//   √ Your memory usage beats 45 % of csharp submissions (22.9 MB)

