/*
 * @lc app=leetcode id=739 lang=csharp
 *
 * [739] Daily Temperatures

 Given a list of daily temperatures T, return a list such that, for each day in the input, tells you how many days you would have to wait until a warmer temperature. If there is no future day for which this is possible, put 0 instead.

For example, given the list of temperatures T = [73, 74, 75, 71, 69, 72, 76, 73], your output should be [1, 1, 4, 2, 1, 1, 0, 0].

Note: The length of temperatures will be in the range [1, 30000]. Each temperature will be an integer in the range [30, 100].
 */
public class Solution {
    public int[] DailyTemperatures(int[] T) {
        int[] res = new int[T.Length];
        res[T.Length - 1] = 0;
        for (int i = T.Length - 2; i >= 0; i--) {
            for (int j = i + 1; j < T.Length; j += res[j]) {
                if (T[i] < T[j]) {
                    res[i] = j - i;
                    break;
                } else if (res[j] == 0) {
                    res[i] = 0;
                    break;
                }
            }
        }
        return res;
    }
}

// √ Accepted
//   √ 37/37 cases passed (332 ms)
//   √ Your runtime beats 80.31 % of csharp submissions
//   √ Your memory usage beats 28 % of csharp submissions (41.1 MB)

