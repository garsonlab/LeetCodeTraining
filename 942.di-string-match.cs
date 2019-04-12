/*
 * @lc app=leetcode id=942 lang=csharp
 *
 * [942] DI String Match
 *
 * https://leetcode.com/problems/di-string-match/description/
 *
 * algorithms
 * Easy (70.19%)
 * Total Accepted:    25.3K
 * Total Submissions: 36.2K
 * Testcase Example:  '"IDID"'
 *
 * Given a string S that only contains "I" (increase) or "D" (decrease), let N
 * = S.length.
 * 
 * Return any permutation A of [0, 1, ..., N] such that for all i = 0, ...,
 * N-1:
 * 
 * 
 * If S[i] == "I", then A[i] < A[i+1]
 * If S[i] == "D", then A[i] > A[i+1]
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: "IDID"
 * Output: [0,4,1,3,2]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: "III"
 * Output: [0,1,2,3]
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: "DDI"
 * Output: [3,2,0,1]
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= S.length <= 10000
 * S only contains characters "I" or "D".
 * 
 */
public class Solution {
    public int[] DiStringMatch(string S) {
        int[] ret = new int[S.Length+1];
        int s = 0, e = S.Length;

        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] == 'I')
                ret[i] = s++;
            else
                ret[i] = e--;
        }

        ret[S.Length] = e;
        
        return ret;
    }
}

// √ Accepted
//   √ 95/95 cases passed (248 ms)
//   √ Your runtime beats 97.47 % of csharp submissions
//   √ Your memory usage beats 42.42 % of csharp submissions (32.3 MB)

