/*
 * @lc app=leetcode id=771 lang=csharp
 *
 * [771] Jewels and Stones
 *
 * https://leetcode.com/problems/jewels-and-stones/description/
 *
 * algorithms
 * Easy (82.84%)
 * Total Accepted:    222.6K
 * Total Submissions: 268.3K
 * Testcase Example:  '"aA"\n"aAAbbbb"'
 *
 * You're given strings J representing the types of stones that are jewels, and
 * S representing the stones you have.  Each character in S is a type of stone
 * you have.  You want to know how many of the stones you have are also
 * jewels.
 * 
 * The letters in J are guaranteed distinct, and all characters in J and S are
 * letters. Letters are case sensitive, so "a" is considered a different type
 * of stone from "A".
 * 
 * Example 1:
 * 
 * 
 * Input: J = "aA", S = "aAAbbbb"
 * Output: 3
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: J = "z", S = "ZZ"
 * Output: 0
 * 
 * 
 * Note:
 * 
 * 
 * S and J will consist of letters and have length at most 50.
 * The characters in J are distinct.
 * 
 * 
 */
public class Solution {
    public int NumJewelsInStones(string J, string S) {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        for (int i = 0; i < J.Length; i++)
        {
            dic[J[i]] = 1;
        }

        int n = 0;
        for (int i = 0; i < S.Length; i++)
        {
            if (dic.ContainsKey(S[i]))
                n++;
        }

        return n;
    }
}

// √ Accepted
//   √ 254/254 cases passed (72 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 41.02 % of csharp submissions (21.2 MB)

