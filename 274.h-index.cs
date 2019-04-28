/*
 * @lc app=leetcode id=274 lang=csharp
 *
 * [274] H-Index

 Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.

According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."

Example:

Input: citations = [3,0,6,1,5]
Output: 3 
Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had 
             received 3, 0, 6, 1, 5 citations respectively. 
             Since the researcher has 3 papers with at least 3 citations each and the remaining 
             two with no more than 3 citations each, her h-index is 3.
Note: If there are several possible values for h, the maximum one is taken as the h-index.
 */
public class Solution {
    public int HIndex(int[] citations) {
        Array.Sort(citations);
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < citations.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if(j > 0 && citations[j] == citations[j-1])
                    continue;

                if (citations[i] >= citations[j])
                {
                    dic[citations[j]] = dic[citations[j]] + 1;
                }
            }

            if (!dic.ContainsKey(citations[i]))
                dic[citations[i]] = 1;
        }

        int res = 0;
        foreach (var i in dic)
        {
            res = Math.Max(res, Math.Min(i.Key, i.Value));
        }

        return res;
    }
}

// √ Accepted
//   √ 82/82 cases passed (236 ms)
//   √ Your runtime beats 6.82 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (22.2 MB)

