/*
 * @lc app=leetcode id=859 lang=csharp
 *
 * [859] Buddy Strings
 *
 * https://leetcode.com/problems/buddy-strings/description/
 *
 * algorithms
 * Easy (27.48%)
 * Total Accepted:    22K
 * Total Submissions: 80.1K
 * Testcase Example:  '"ab"\n"ba"'
 *
 * Given two strings A and B of lowercase letters, return true if and only if
 * we can swap two letters in A so that the result equals B.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * 
 * Input: A = "ab", B = "ba"
 * Output: true
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: A = "ab", B = "ab"
 * Output: false
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: A = "aa", B = "aa"
 * Output: true
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: A = "aaaaaaabc", B = "aaaaaaacb"
 * Output: true
 * 
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: A = "", B = "aa"
 * Output: false
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 0 <= A.length <= 20000
 * 0 <= B.length <= 20000
 * A and B consist only of lowercase letters.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool BuddyStrings(string A, string B) {
        if (A.Length != B.Length || A.Length < 2)
            return false;

        List<int> list = new List<int>();
        Dictionary<char, int> dic = new Dictionary<char, int>();
        bool hasSame = false;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] != B[i])
            {
                list.Add(i);
                if (list.Count > 2)
                    return false;
            }
            else
            {
                if (dic.ContainsKey(A[i]))
                    hasSame = true;
                else
                    dic[A[i]] = 1;
            }
        }

        if (list.Count == 0)
            return hasSame;
        return list.Count == 2 && A[list[0]] == B[list[1]] && A[list[1]] == B[list[0]];
    }
}

// √ Accepted
//   √ 23/23 cases passed (76 ms)
//   √ Your runtime beats 83.18 % of csharp submissions
//   √ Your memory usage beats 69.23 % of csharp submissions (21.1 MB)

