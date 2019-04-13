/*
 * @lc app=leetcode id=1010 lang=csharp
 *
 * [1010] Pairs of Songs With Total Durations Divisible by 60
 *
 * https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/description/
 *
 * algorithms
 * Easy (44.29%)
 * Total Accepted:    8K
 * Total Submissions: 18K
 * Testcase Example:  '[30,20,150,100,40]'
 *
 * In a list of songs, the i-th song has a duration of time[i] seconds. 
 * 
 * Return the number of pairs of songs for which their total duration in
 * seconds is divisible by 60.  Formally, we want the number of indices i < j
 * with (time[i] + time[j]) % 60 == 0.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [30,20,150,100,40]
 * Output: 3
 * Explanation: Three pairs have a total duration divisible by 60:
 * (time[0] = 30, time[2] = 150): total duration 180
 * (time[1] = 20, time[3] = 100): total duration 120
 * (time[1] = 20, time[4] = 40): total duration 60
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [60,60,60]
 * Output: 3
 * Explanation: All three pairs have a total duration of 120, which is
 * divisible by 60.
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= time.length <= 60000
 * 1 <= time[i] <= 500
 * 
 */
public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        int count = 0;
        int[] flags = new int[60];
        for (int i = 0; i < time.Length; i++)
        {
            flags[time[i] % 60]++;
        }

        for (int i = 31; i < 60; i++)
        {
            count += flags[i] * flags[60 - i];
        }

        return count + flags[0]*(flags[0]-1)/2 + flags[30]*(flags[30]-1)/2;
    }
}

// √ Accepted
//   √ 34/34 cases passed (120 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (30.2 MB)

