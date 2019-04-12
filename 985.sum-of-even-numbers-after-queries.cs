/*
 * @lc app=leetcode id=985 lang=csharp
 *
 * [985] Sum of Even Numbers After Queries
 *
 * https://leetcode.com/problems/sum-of-even-numbers-after-queries/description/
 *
 * algorithms
 * Easy (66.89%)
 * Total Accepted:    15.7K
 * Total Submissions: 24.1K
 * Testcase Example:  '[1,2,3,4]\n[[1,0],[-3,1],[-4,0],[2,3]]'
 *
 * We have an array A of integers, and an array queries of queries.
 * 
 * For the i-th query val = queries[i][0], index = queries[i][1], we add val to
 * A[index].  Then, the answer to the i-th query is the sum of the even values
 * of A.
 * 
 * (Here, the given index = queries[i][1] is a 0-based index, and each query
 * permanently modifies the array A.)
 * 
 * Return the answer to all queries.  Your answer array should have answer[i]
 * as the answer to the i-th query.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: A = [1,2,3,4], queries = [[1,0],[-3,1],[-4,0],[2,3]]
 * Output: [8,6,2,4]
 * Explanation: 
 * At the beginning, the array is [1,2,3,4].
 * After adding 1 to A[0], the array is [2,2,3,4], and the sum of even values
 * is 2 + 2 + 4 = 8.
 * After adding -3 to A[1], the array is [2,-1,3,4], and the sum of even values
 * is 2 + 4 = 6.
 * After adding -4 to A[0], the array is [-2,-1,3,4], and the sum of even
 * values is -2 + 4 = 2.
 * After adding 2 to A[3], the array is [-2,-1,3,6], and the sum of even values
 * is -2 + 6 = 4.
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= A.length <= 10000
 * -10000 <= A[i] <= 10000
 * 1 <= queries.length <= 10000
 * -10000 <= queries[i][0] <= 10000
 * 0 <= queries[i][1] < A.length
 * 
 * 
 */
public class Solution {
    public int[] SumEvenAfterQueries(int[] A, int[][] queries) {
        int[] ret = new int[queries.Length];
        int d = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] % 2 == 0)
                d += A[i];
        }
        

        for (int i = 0; i < queries.Length; i++)
        {
            int p = A[queries[i][1]];
            int c = A[queries[i][1]] + queries[i][0];
            A[queries[i][1]] = c;

            if (p % 2 == 0)
                d -= p;
            if (c % 2 == 0)
                d += c;
            ret[i] = d;
        }

        return ret;
    }
}

// √ Accepted
//   √ 58/58 cases passed (420 ms)
//   √ Your runtime beats 93.25 % of csharp submissions
//   √ Your memory usage beats 7.69 % of csharp submissions (47 MB)

