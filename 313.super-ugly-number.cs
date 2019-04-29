/*
 * @lc app=leetcode id=313 lang=csharp
 *
 * [313] Super Ugly Number

 Write a program to find the nth super ugly number.

Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k.

Example:

Input: n = 12, primes = [2,7,13,19]
Output: 32 
Explanation: [1,2,4,7,8,13,14,16,19,26,28,32] is the sequence of the first 12 
             super ugly numbers given primes = [2,7,13,19] of size 4.
Note:

1 is a super ugly number for any given primes.
The given numbers in primes are in ascending order.
0 < k ≤ 100, 0 < n ≤ 106, 0 < primes[i] < 1000.
The nth super ugly number is guaranteed to fit in a 32-bit signed integer.
 */
public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes)
    {
        int[] q = new int[primes.Length];
        int[] uglys = new int[n];
        uglys[0] = 1;

        for (int i = 1; i < n; i++)
        {
            int min = Int32.MaxValue;
            for (int j = 0; j < primes.Length; j++)
            {
                int temp = uglys[q[j]] * primes[j];
                if (min > temp)
                {
                    min = temp;
                }
            }

            uglys[i] = min;
            for (int j = 0; j < primes.Length; j++)
            {
                if (uglys[i] == uglys[q[j]] * primes[j])
                {
                    q[j]++;
                }
            }
        }
        return uglys[n - 1];
    }


    public int NthSuperUglyNumber_timeout(int n, int[] primes) {
        List<int> prime = new List<int>(primes);
        List<int> ret = new List<int>(){1};
        prime.Sort();
        int idx = 2;
        while (ret.Count < n)
        {
            int tem = idx;
            bool ac = false;

            while (true)
            {
                if (tem == 0 || prime.Contains(tem) || ret.Contains(tem))
                {
                    ac = true;
                    break;
                }

                bool c = false;
                for (int i = 0; i < prime.Count; i++)
                {
                    if (tem % prime[i] == 0)
                    {
                        tem /= prime[i];
                        c = true;
                        break;
                    }
                }
                if(c)
                    continue;
                break;
            }

            if(ac)
                ret.Add(idx);
            idx++;
        }

        return ret[n-1];
    }
}

// √ Accepted
//   √ 83/83 cases passed (136 ms)
//   √ Your runtime beats 65.96 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (22 MB)

