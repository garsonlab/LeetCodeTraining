/*
 * @lc app=leetcode id=60 lang=csharp
 *
 * [60] Permutation Sequence
 *
 * https://leetcode.com/problems/permutation-sequence/description/
 *
 * algorithms
 * Medium (32.70%)
 * Total Accepted:    133.9K
 * Total Submissions: 409.1K
 * Testcase Example:  '3\n3'
 *
 * The set [1,2,3,...,n] contains a total of n! unique permutations.
 * 
 * By listing and labeling all of the permutations in order, we get the
 * following sequence for n = 3:
 * 
 * 
 * "123"
 * "132"
 * "213"
 * "231"
 * "312"
 * "321"
 * 
 * 
 * Given n and k, return the k^th permutation sequence.
 * 
 * Note:
 * 
 * 
 * Given n will be between 1 and 9 inclusive.
 * Given k will be between 1 and n! inclusive.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 3, k = 3
 * Output: "213"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 4, k = 9
 * Output: "2314"
 * 
 * 
 */
public class Solution {
    public string GetPermutation(int n, int k)
    {
        string ret = "";
        
        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            list.Add(i+1);
        }

        int num = 0, f = 0;
        for (int i = 1; i < n; i++)//第n个有(n-1)!个排列
        {
            k -= (num - 1) * f;
            f = Factorial(n - i);
            num = (int)Math.Ceiling((double)k / f);
            ret += list[num - 1];
            list.RemoveAt(num-1);
        }

        return ret + list[0];
    }

    private int Factorial(int v)
    {
        return v == 1 ? 1 : v * Factorial(v - 1);
    }
}


// √ Accepted
//   √ 200/200 cases passed (80 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (20.8 MB)
