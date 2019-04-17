/*
 * @lc app=leetcode id=89 lang=csharp
 *
 * [89] Gray Code
 *
 * https://leetcode.com/problems/gray-code/description/
 *
 * algorithms
 * Medium (45.35%)
 * Total Accepted:    130.7K
 * Total Submissions: 288K
 * Testcase Example:  '2'
 *
 * The gray code is a binary numeral system where two successive values differ
 * in only one bit.
 * 
 * Given a non-negative integer n representing the total number of bits in the
 * code, print the sequence of gray code. A gray code sequence must begin with
 * 0.
 * 
 * Example 1:
 * 
 * 
 * Input: 2
 * Output: [0,1,3,2]
 * Explanation:
 * 00 - 0
 * 01 - 1
 * 11 - 3
 * 10 - 2
 * 
 * For a given n, a gray code sequence may not be uniquely defined.
 * For example, [0,2,3,1] is also a valid gray code sequence.
 * 
 * 00 - 0
 * 10 - 2
 * 11 - 3
 * 01 - 1
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 0
 * Output: [0]
 * Explanation: We define the gray code sequence to begin with 0.
 * A gray code sequence of n has size = 2^n, which for n = 0 the size is 2^0 =
 * 1.
 * Therefore, for n = 0 the gray code sequence is [0].
 * 
 * 
 */
public class Solution {
    public IList<int> GrayCode(int n)
    {
        List<int> list = new List<int>();
        int len = 1 << n;//2^n个

        for (int i = 0; i < len; i++)
        {
            list.Add(i ^ (i >> 1));
        }

        return list;
    }

    //https://baike.baidu.com/item/%E6%A0%BC%E9%9B%B7%E7%A0%81/6510858?fr=aladdin
}

// √ Accepted
//   √ 12/12 cases passed (212 ms)
//   √ Your runtime beats 97.16 % of csharp submissions
//   √ Your memory usage beats 85.71 % of csharp submissions (23.3 MB)

