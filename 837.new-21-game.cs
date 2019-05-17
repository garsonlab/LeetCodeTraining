/*
 * @lc app=leetcode id=837 lang=csharp
 *
 * [837] New 21 Game

 Alice plays the following game, loosely based on the card game "21".

Alice starts with 0 points, and draws numbers while she has less than K points.  During each draw, she gains an integer number of points randomly from the range [1, W], where W is an integer.  Each draw is independent and the outcomes have equal probabilities.

Alice stops drawing numbers when she gets K or more points.  What is the probability that she has N or less points?

Example 1:

Input: N = 10, K = 1, W = 10
Output: 1.00000
Explanation:  Alice gets a single card, then stops.
Example 2:

Input: N = 6, K = 1, W = 10
Output: 0.60000
Explanation:  Alice gets a single card, then stops.
In 6 out of W = 10 possibilities, she is at or below N = 6 points.
Example 3:

Input: N = 21, K = 17, W = 10
Output: 0.73278
Note:

0 <= K <= N <= 10000
1 <= W <= 10000
Answers will be accepted as correct if they are within 10^-5 of the correct answer.
The judging time limit has been reduced for this question.
 */
public class Solution {
    public double New21Game(int N, int K, int W) {
        if (K == 0 || N >= K + W)
            return 1.0;

        double[] dp = new double[N+1];
        dp[0] = 1.0;
        double Wsum = 1.0, res = 0.0;

        for (int i = 1; i <= N; ++i)
        {
            dp[i] = Wsum / W;
            if (i < K) Wsum += dp[i];
            else res += dp[i];
            if (i - W >= 0)
                Wsum -= dp[i - W];
        }

        return res;
    }
}
// https://blog.csdn.net/qq_30818049/article/details/87926548 
// √ Accepted
//   √ 146/146 cases passed (48 ms)
//   √ Your runtime beats 48.28 % of csharp submissions
//   √ Your memory usage beats 48 % of csharp submissions (14.9 MB)

