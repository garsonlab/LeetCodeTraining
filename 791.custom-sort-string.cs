/*
 * @lc app=leetcode id=791 lang=csharp
 *
 * [791] Custom Sort String

 S and T are strings composed of lowercase letters. In S, no letter occurs more than once.

S was sorted in some custom order previously. We want to permute the characters of T so that they match the order that S was sorted. More specifically, if x occurs before y in S, then x should occur before y in the returned string.

Return any permutation of T (as a string) that satisfies this property.

Example :
Input: 
S = "cba"
T = "abcd"
Output: "cbad"
Explanation: 
"a", "b", "c" appear in S, so the order of "a", "b", "c" should be "c", "b", and "a". 
Since "d" does not appear in S, it can be at any position in T. "dcba", "cdba", "cbda" are also valid outputs.
 

Note:

S has length at most 26, and no character is repeated in S.
T has length at most 200.
S and T consist of lowercase letters only.
 */
public class Solution {
    public string CustomSortString(string S, string T) {
        int[] weight = new int[26];
        int w = S.Length;
        foreach (var c in S)
        {
            weight[c - 'a'] = w--;
        }

        char[] arr = T.ToCharArray();
        Array.Sort(arr, (a, b) => { return weight[b - 'a'] - weight[a - 'a']; });
        return new string(arr);
    }
}

// √ Accepted
//   √ 39/39 cases passed (88 ms)
//   √ Your runtime beats 53.95 % of csharp submissions
//   √ Your memory usage beats 66.67 % of csharp submissions (20.6 MB)

