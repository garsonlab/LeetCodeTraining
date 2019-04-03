/*
 * @lc app=leetcode id=506 lang=csharp
 *
 * [506] Relative Ranks
 *
 * https://leetcode.com/problems/relative-ranks/description/
 *
 * algorithms
 * Easy (47.99%)
 * Total Accepted:    40.7K
 * Total Submissions: 84.7K
 * Testcase Example:  '[5,4,3,2,1]'
 *
 * 
 * Given scores of N athletes, find their relative ranks and the people with
 * the top three highest scores, who will be awarded medals: "Gold Medal",
 * "Silver Medal" and "Bronze Medal".
 * 
 * Example 1:
 * 
 * Input: [5, 4, 3, 2, 1]
 * Output: ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"]
 * Explanation: The first three athletes got the top three highest scores, so
 * they got "Gold Medal", "Silver Medal" and "Bronze Medal". For the left two
 * athletes, you just need to output their relative ranks according to their
 * scores.
 * 
 * 
 * 
 * Note:
 * 
 * N is a positive integer and won't exceed 10,000.
 * All the scores of athletes are guaranteed to be unique.
 * 
 * 
 * 
 */
public class Solution {
    public string[] FindRelativeRanks(int[] nums) {
        List<int> ori = new List<int>(nums);
        List<int> list = new List<int>(nums);
        list.Sort();

        string[] r = new string[nums.Length];
        int f = 0;
        for (int i = list.Count-1; i >= 0; i--)
        {
            int idx = ori.IndexOf(list[i]);
            switch (++f)
            {
                case 1:
                    r[idx] = "Gold Medal";
                    break;
                case 2:
                    r[idx] = "Silver Medal";
                    break;
                case 3:
                    r[idx] = "Bronze Medal";
                    break;
                default:
                    r[idx] = f.ToString();
                    break;
            }
        }
        
        return r;
    }
}

// √ Accepted
//   √ 17/17 cases passed (352 ms)
//   √ Your runtime beats 26.79 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (32.4 MB)

