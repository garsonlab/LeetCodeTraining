/*
 * @lc app=leetcode id=821 lang=csharp
 *
 * [821] Shortest Distance to a Character
 *
 * https://leetcode.com/problems/shortest-distance-to-a-character/description/
 *
 * algorithms
 * Easy (62.86%)
 * Total Accepted:    33.1K
 * Total Submissions: 52.6K
 * Testcase Example:  '"loveleetcode"\n"e"'
 *
 * Given a string S and a character C, return an array of integers representing
 * the shortest distance from the character C in the string.
 * 
 * Example 1:
 * 
 * 
 * Input: S = "loveleetcode", C = 'e'
 * Output: [3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * S string length is in [1, 10000].
 * C is a single character, and guaranteed to be in string S.
 * All letters in S and C are lowercase.
 * 
 * 
 */
public class Solution {
    public int[] ShortestToChar(string S, char C) {
        List<int> list = new List<int>();
        int[] ret = new int[S.Length];
        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == C)
            {
                ret[i] = 0;
                list.Add(i);
            }
            else
            {
                ret[i] = int.MaxValue;
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            int l = 0;
            for (int j = list[i]-1; j >= 0; j--)
            {
                if(l++ >= ret[j])
                    break;
                ret[j] = l;
            }

            l = 0;
            for (int j = list[i]+1; j < ret.Length; j++)
            {
                if (l++ >= ret[j])
                    break;
                ret[j] = l;
            }
        }
        
        return ret;
    }
}

// √ Accepted
//   √ 76/76 cases passed (260 ms)
//   √ Your runtime beats 63.8 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (29.1 MB)

