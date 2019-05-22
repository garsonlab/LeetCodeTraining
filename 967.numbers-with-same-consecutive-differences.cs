/*
 * @lc app=leetcode id=967 lang=csharp
 *
 * [967] Numbers With Same Consecutive Differences

 Return all non-negative integers of length N such that the absolute difference between every two consecutive digits is K.

Note that every number in the answer must not have leading zeros except for the number 0 itself. For example, 01 has one leading zero and is invalid, but 0 is valid.

You may return the answer in any order.

 

Example 1:

Input: N = 3, K = 7
Output: [181,292,707,818,929]
Explanation: Note that 070 is not a valid number, because it has leading zeroes.
Example 2:

Input: N = 2, K = 1
Output: [10,12,21,23,32,34,43,45,54,56,65,67,76,78,87,89,98]
 

Note:

1 <= N <= 9
0 <= K <= 9
 */
public class Solution {
    public int[] NumsSameConsecDiff(int N, int K) {
        // if(N <= 1)
        //     return new int[0];

        List<int> res = new List<int>();
        
        if (N == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                res.Add(i);
            }

            return res.ToArray();
        }

        for (int i = 1; i <= 9; i++)
        {
            DFSNSCD(res, N - 1, K, i, i);
        }

        return res.ToArray();
    }

    private void DFSNSCD(List<int> list, int N, int K, int pre, int num)
    {
        if (N == 0)
        {
            list.Add(num);
            return;
        }
        
        if (pre + K <= 9)
            DFSNSCD(list, N - 1, K, pre + K, num * 10 + pre + K);
        if (K != 0 && pre - K >= 0)
            DFSNSCD(list, N - 1, K, pre - K, num * 10 + pre - K);
    }
}

// √ Accepted
//   √ 92/92 cases passed (228 ms)
//   √ Your runtime beats 58.62 % of csharp submissions
//   √ Your memory usage beats 30.77 % of csharp submissions (24.8 MB)

