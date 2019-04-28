/*
 * @lc app=leetcode id=275 lang=csharp
 *
 * [275] H-Index II

 Given an array of citations sorted in ascending order (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.

According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."

Example:

Input: citations = [0,1,3,5,6]
Output: 3 
Explanation: [0,1,3,5,6] means the researcher has 5 papers in total and each of them had 
             received 0, 1, 3, 5, 6 citations respectively. 
             Since the researcher has 3 papers with at least 3 citations each and the remaining 
             two with no more than 3 citations each, her h-index is 3.
Note:

If there are several possible values for h, the maximum one is taken as the h-index.

Follow up:

This is a follow up problem to H-Index, where citations is now guaranteed to be sorted in ascending order.
Could you solve it in logarithmic time complexity?
 */
public class Solution {
    public int HIndex(int[] citations) {
        int len = citations.Length;
        if (len == 0)
            return 0;

        if (len < citations[0])
            return len;
        for (int i = 0; i < len; ++i)
        {
            int count = len - i;
            if (count <= citations[i])
                return count;
        }

        return 0;
    }
}

// √ Accepted
//   √ 84/84 cases passed (132 ms)
//   √ Your runtime beats 34.78 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (27.4 MB)

