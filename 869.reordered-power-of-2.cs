/*
 * @lc app=leetcode id=869 lang=csharp
 *
 * [869] Reordered Power of 2

 Starting with a positive integer N, we reorder the digits in any order (including the original order) such that the leading digit is not zero.

Return true if and only if we can do this in a way such that the resulting number is a power of 2.

 

Example 1:

Input: 1
Output: true
Example 2:

Input: 10
Output: false
Example 3:

Input: 16
Output: true
Example 4:

Input: 24
Output: false
Example 5:

Input: 46
Output: true
 

Note:

1 <= N <= 10^9
 */
public class Solution {
    public bool ReorderedPowerOf2(int N) {
        List<string> list = new List<string>();
        for (int i = 0; i <= 32; i++)
        {
            char[] chars = (1<<i).ToString().ToCharArray();
            Array.Sort(chars);
            list.Add(new string(chars));
        }

        char[] cs = N.ToString().ToCharArray();
        Array.Sort(cs);
        string tem = new string(cs);
        foreach (var item in list)
        {
            if(item == tem)
            return true;
        }
        return false;
    }
}


// √ Accepted
//   √ 135/135 cases passed (56 ms)
//   √ Your runtime beats 22.5 % of csharp submissions
//   √ Your memory usage beats 38.89 % of csharp submissions (14 MB)
