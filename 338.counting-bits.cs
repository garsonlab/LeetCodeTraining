/*
 * @lc app=leetcode id=338 lang=csharp
 *
 * [338] Counting Bits

 Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.

Example 1:

Input: 2
Output: [0,1,1]
Example 2:

Input: 5
Output: [0,1,1,2,1,2]
Follow up:

It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
Space complexity should be O(n).
Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
 */
public class Solution {
    public int[] CountBits(int num) {
        int[] ret = new int[num+1];
        ret[0] = 0;
        for (int i = 1; i <= num; i++)
        {
            ret[i] = ret[i & (i - 1)] + 1;
        }

        return ret;
    }
}

// i & (i - 1)可以去掉i最右边的一个1（如果有），
// 因此 i & (i - 1）是比 i 小的，而且i & (i - 1)的1的个数已经在前面算过了，所以i的1的个数就是 i & (i - 1)的1的个数加上1
// √ Accepted
//   √ 15/15 cases passed (256 ms)
//   √ Your runtime beats 44.41 % of csharp submissions
//   √ Your memory usage beats 27.27 % of csharp submissions (27.2 MB)

