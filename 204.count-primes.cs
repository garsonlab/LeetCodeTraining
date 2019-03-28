/*
 * @lc app=leetcode id=204 lang=csharp
 *
 * [204] Count Primes
 *
 * https://leetcode.com/problems/count-primes/description/
 *
 * algorithms
 * Easy (28.43%)
 * Total Accepted:    221.1K
 * Total Submissions: 776K
 * Testcase Example:  '10'
 *
 * Count the number of prime numbers less than a non-negative number, n.
 * 
 * Example:
 * 
 * 
 * Input: 10
 * Output: 4
 * Explanation: There are 4 prime numbers less than 10, they are 2, 3, 5, 7.
 * 
 * 
 */
public class Solution {
    public int CountPrimes(int n) {
        if (n <= 2)
        {
            return 0;
        }
        
        int[] flag = new int[n];
        for (int i = 2; i < n; i++)
        {
            if (i*i >= n)
            {
                break;
            }

            bool isPre = true;
            for (int j = 2; j < i; j++)
            {
                if (i%j == 0)
                {
                    isPre = false;
                    break;
                }
            }

            if(!isPre)
                continue;

            for (int j = 2; j < n; j++)
            {
                if (j == i || flag[j] > 0)
                    continue;
                if (j%i == 0)
                {
                    flag[j] = 1;
                }
            }
        }

        int count = 0;
        for (int i = 2; i < n; i++)
        {
            if (flag[i] == 0)
            {
                count++;
            }
        }

        return count;
    }
}

//厄拉多塞筛法
// √ Accepted
//   √ 20/20 cases passed (1820 ms)
//   √ Your runtime beats 5.09 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (23.9 MB)

