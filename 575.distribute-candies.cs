/*
 * @lc app=leetcode id=575 lang=csharp
 *
 * [575] Distribute Candies
 *
 * https://leetcode.com/problems/distribute-candies/description/
 *
 * algorithms
 * Easy (59.25%)
 * Total Accepted:    68.5K
 * Total Submissions: 115.5K
 * Testcase Example:  '[1,1,2,2,3,3]'
 *
 * Given an integer array with even length, where different numbers in this
 * array represent different kinds of candies. Each number means one candy of
 * the corresponding kind. You need to distribute these candies equally in
 * number to brother and sister. Return the maximum number of kinds of candies
 * the sister could gain. 
 * 
 * Example 1:
 * 
 * Input: candies = [1,1,2,2,3,3]
 * Output: 3
 * Explanation:
 * There are three different kinds of candies (1, 2 and 3), and two candies for
 * each kind.
 * Optimal distribution: The sister has candies [1,2,3] and the brother has
 * candies [1,2,3], too. 
 * The sister has three different kinds of candies. 
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: candies = [1,1,2,3]
 * Output: 2
 * Explanation: For example, the sister has candies [2,3] and the brother has
 * candies [1,1]. 
 * The sister has two different kinds of candies, the brother has only one kind
 * of candies. 
 * 
 * 
 * 
 * Note:
 * 
 * The length of the given array is in range [2, 10,000], and will be even.
 * The number in given array is in range [-100,000, 100,000].
 * 
 * 
 */
public class Solution {
    public int DistributeCandies(int[] candies) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var c in candies)
        {
            dic[c] = 1;
        }

        return (dic.Count >= candies.Length / 2) ? candies.Length/2 : dic.Count;
    }
}

// √ Accepted
//   √ 205/205 cases passed (276 ms)
//   √ Your runtime beats 81.67 % of csharp submissions
//   √ Your memory usage beats 27.27 % of csharp submissions (42.8 MB)

