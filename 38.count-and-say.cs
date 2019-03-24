/*
 * @lc app=leetcode id=38 lang=csharp
 *
 * [38] Count and Say
 *
 * https://leetcode.com/problems/count-and-say/description/
 *
 * algorithms
 * Easy (39.76%)
 * Total Accepted:    265.4K
 * Total Submissions: 667.3K
 * Testcase Example:  '1'
 *
 * The count-and-say sequence is the sequence of integers with the first five
 * terms as following:
 * 
 * 
 * 1.     1
 * 2.     11
 * 3.     21
 * 4.     1211
 * 5.     111221
 * 
 * 
 * 1 is read off as "one 1" or 11.
 * 11 is read off as "two 1s" or 21.
 * 21 is read off as "one 2, then one 1" or 1211.
 * 
 * Given an integer n where 1 ≤ n ≤ 30, generate the n^th term of the
 * count-and-say sequence.
 * 
 * Note: Each term of the sequence of integers will be represented as a
 * string.
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: 1
 * Output: "1"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: 4
 * Output: "1211"
 * 
 */
public class Solution {


    public string CountAndSay(int n) {
        if (n == 1)
        {
            return "1";
        }
        StringBuilder[] builders = new StringBuilder[2];
        builders[0] = new StringBuilder("1");
        builders[1] = new StringBuilder();
        int target = 0;
        int num = 0;
        char pre = '\0';

        while (--n > 0)
        {
            int other = (target + 1) % 2;
            builders[other].Length = 0;

            var cur = builders[target];
            num = 1;
            pre = cur[0];
            for (int i = 1; i < cur.Length; i++)
            {
                if (cur[i] != pre)
                {
                    builders[other].Append(num);
                    builders[other].Append(pre);
                    pre = cur[i];
                    num = 1;
                }
                else
                {
                    num++;
                }
            }
            builders[other].Append(num);
            builders[other].Append(pre);
            target = other;
        }

        return builders[target].ToString();
    }
}

// √ Accepted
//   √ 18/18 cases passed (96 ms)
//   √ Your runtime beats 71.2 % of csharp submissions
//   √ Your memory usage beats 67.44 % of csharp submissions (20.8 MB)

