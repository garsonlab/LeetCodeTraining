/*
 * @lc app=leetcode id=412 lang=csharp
 *
 * [412] Fizz Buzz
 *
 * https://leetcode.com/problems/fizz-buzz/description/
 *
 * algorithms
 * Easy (59.02%)
 * Total Accepted:    190.3K
 * Total Submissions: 322K
 * Testcase Example:  '1'
 *
 * Write a program that outputs the string representation of numbers from 1 to
 * n.
 * 
 * But for multiples of three it should output “Fizz” instead of the number and
 * for the multiples of five output “Buzz”. For numbers which are multiples of
 * both three and five output “FizzBuzz”.
 * 
 * Example:
 * 
 * n = 15,
 * 
 * Return:
 * [
 * ⁠   "1",
 * ⁠   "2",
 * ⁠   "Fizz",
 * ⁠   "4",
 * ⁠   "Buzz",
 * ⁠   "Fizz",
 * ⁠   "7",
 * ⁠   "8",
 * ⁠   "Fizz",
 * ⁠   "Buzz",
 * ⁠   "11",
 * ⁠   "Fizz",
 * ⁠   "13",
 * ⁠   "14",
 * ⁠   "FizzBuzz"
 * ]
 * 
 * 
 */
public class Solution {
    public IList<string> FizzBuzz(int n) {
        IList<string> list = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if(i%15 == 0)
                list.Add("FizzBuzz");
            else if(i%5 == 0)
                list.Add("Buzz");
            else if(i%3 == 0)
                list.Add("Fizz");
            else
                list.Add(i.ToString());
        }

        return list;
    }
}



// √ Accepted
//   √ 8/8 cases passed (256 ms)
//   √ Your runtime beats 68.83 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (31.9 MB)
