/*
 * @lc app=leetcode id=842 lang=csharp
 *
 * [842] Split Array into Fibonacci Sequence

 Given a string S of digits, such as S = "123456579", we can split it into a Fibonacci-like sequence [123, 456, 579].

Formally, a Fibonacci-like sequence is a list F of non-negative integers such that:

0 <= F[i] <= 2^31 - 1, (that is, each integer fits a 32-bit signed integer type);
F.length >= 3;
and F[i] + F[i+1] = F[i+2] for all 0 <= i < F.length - 2.
Also, note that when splitting the string into pieces, each piece must not have extra leading zeroes, except if the piece is the number 0 itself.

Return any Fibonacci-like sequence split from S, or return [] if it cannot be done.

Example 1:

Input: "123456579"
Output: [123,456,579]
Example 2:

Input: "11235813"
Output: [1,1,2,3,5,8,13]
Example 3:

Input: "112358130"
Output: []
Explanation: The task is impossible.
Example 4:

Input: "0123"
Output: []
Explanation: Leading zeroes are not allowed, so "01", "2", "3" is not valid.
Example 5:

Input: "1101111"
Output: [110, 1, 111]
Explanation: The output [11, 0, 11, 11] would also be accepted.
Note:

1 <= S.length <= 200
S contains only digits.
 */
public class Solution {
    public IList<int> SplitIntoFibonacci(string S) {
        List<int> res = new List<int>();
        SplitSN(res, S, 0);
        return res;
    }

    private bool SplitSN(List<int> list, string S, int idx)
    {
        if (idx >= S.Length)
        {
            return list.Count >= 3;
        }

        for (int i = idx+1; i <= S.Length; i++)
        {
            string s = S.Substring(idx, i - idx);
            if(s.Length>1 && s[0] == '0')
                break;

            int n = 0;
            long v = long.Parse(s);
            if (v > int.MaxValue)
                break;
            else
                n = (int) v;
            if (list.Count < 2)
            {
                list.Add(n);
                if (SplitSN(list, S, i))
                    return true;
                list.RemoveAt(list.Count-1);
            }
            else
            {
                if(list[list.Count-2] + list[list.Count-1] != n)
                    continue;
                list.Add(n);
                if (SplitSN(list, S, i))
                    return true;
                list.RemoveAt(list.Count - 1);
            }
        }

        return false;
    }

}

// √ Accepted
//   √ 70/70 cases passed (252 ms)
//   √ Your runtime beats 60 % of csharp submissions
//   √ Your memory usage beats 45.45 % of csharp submissions (29.7 MB)

