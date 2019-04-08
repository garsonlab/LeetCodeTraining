/*
 * @lc app=leetcode id=728 lang=csharp
 *
 * [728] Self Dividing Numbers
 *
 * https://leetcode.com/problems/self-dividing-numbers/description/
 *
 * algorithms
 * Easy (69.27%)
 * Total Accepted:    72K
 * Total Submissions: 103.6K
 * Testcase Example:  '1\n22'
 *
 * 
 * A self-dividing number is a number that is divisible by every digit it
 * contains.
 * 
 * For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 ==
 * 0, and 128 % 8 == 0.
 * 
 * Also, a self-dividing number is not allowed to contain the digit zero.
 * 
 * Given a lower and upper number bound, output a list of every possible self
 * dividing number, including the bounds if possible.
 * 
 * Example 1:
 * 
 * Input: 
 * left = 1, right = 22
 * Output: [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22]
 * 
 * 
 * 
 * Note:
 * The boundaries of each input argument are 1 .
 * 
 */
public class Solution {
    public IList<int> SelfDividingNumbers(int left, int right) {
        IList<int> list = new List<int>();
        for (int i = left; i <= right; i++)
        {
            bool inv = true;
            int tem = i;
            while (tem > 0)
            {
                if (tem%10 == 0 || i % (tem % 10) > 0)
                {
                    inv = false;
                    break;
                }

                tem /= 10;
            }
            if(inv)
                list.Add(i);
        }

        return list;
    }
}

// √ Accepted
//   √ 31/31 cases passed (224 ms)
//   √ Your runtime beats 66.53 % of csharp submissions
//   √ Your memory usage beats 95.83 % of csharp submissions (23.1 MB)

