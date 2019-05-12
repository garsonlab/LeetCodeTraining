/*
 * @lc app=leetcode id=738 lang=csharp
 *
 * [738] Monotone Increasing Digits

 Given a non-negative integer N, find the largest number that is less than or equal to N with monotone increasing digits.

(Recall that an integer has monotone increasing digits if and only if each pair of adjacent digits x and y satisfy x <= y.)

Example 1:
Input: N = 10
Output: 9
Example 2:
Input: N = 1234
Output: 1234
Example 3:
Input: N = 332
Output: 299
Note: N is an integer in the range [0, 10^9].
 */
public class Solution {
    public int MonotoneIncreasingDigits(int N) {
        if (N < 10) {
            return N;
        }
        
        int preVal = N % 10;   // 个位上的数
        int res = preVal;      // 保存当前的结果
        int mult = 10;         // 倍数
        N /= 10;
        
        while (N != 0) {
            
            int tempVal = N % 10;
            if (tempVal > preVal) {  
                tempVal--;
                res = mult - 1; // 如果当前位减1，则当前位右边的值都可取最大值 9
            }
            
            res += tempVal * mult; // 加上当前位
            N /= 10;
            preVal = tempVal;
            mult *= 10;
        }
        
        return res;
    }
}


// 然后从后往前扫描字符串，如果出现逆序str[index - 1] > str[index]，
// 则将str[index - 1]自减一，并且将[index, strSize)这一段全部置为’9’。比如输入"123855"，从后往前扫描，
// 第一次出现逆序"85"将‘8’置自减，并且它后面的全部置为’9’,得到结果"123799"。

// √ Accepted
//   √ 302/302 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.6 MB)

