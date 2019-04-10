/*
 * @lc app=leetcode id=830 lang=csharp
 *
 * [830] Positions of Large Groups
 *
 * https://leetcode.com/problems/positions-of-large-groups/description/
 *
 * algorithms
 * Easy (47.58%)
 * Total Accepted:    24.1K
 * Total Submissions: 50.6K
 * Testcase Example:  '"abbxxxxzzy"'
 *
 * In a string S of lowercase letters, these letters form consecutive groups of
 * the same character.
 * 
 * For example, a string like S = "abbxxxxzyy" has the groups "a", "bb",
 * "xxxx", "z" and "yy".
 * 
 * Call a group large if it has 3 or more characters.  We would like the
 * starting and ending positions of every large group.
 * 
 * The final answer should be in lexicographic order.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "abbxxxxzzy"
 * Output: [[3,6]]
 * Explanation: "xxxx" is the single large group with starting  3 and ending
 * positions 6.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "abc"
 * Output: []
 * Explanation: We have "a","b" and "c" but no large group.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "abcdddeeeeaabbbcd"
 * Output: [[3,5],[6,9],[12,14]]
 * 
 * 
 * 
 * Note:  1 <= S.length <= 1000
 * 
 */
public class Solution {
    public IList<IList<int>> LargeGroupPositions(string S) {
        IList<IList<int>> list = new List<IList<int>>();

        int start = 0;
        for (int i = 1; i < S.Length; i++)
        {
            if (S[i] != S[start])
            {
                if (i - start >= 3)
                {
                    list.Add(new List<int>() { start, i - 1 });
                }

                start = i;
            }
        }

        if(S.Length-start >= 3)
            list.Add(new List<int>() { start, S.Length - 1 });
        return list;
    }
}

// √ Accepted
//   √ 202/202 cases passed (244 ms)
//   √ Your runtime beats 83.72 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (29.7 MB)

