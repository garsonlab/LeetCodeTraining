/*
 * @lc app=leetcode id=556 lang=csharp
 *
 * [556] Next Greater Element III
 Given a positive 32-bit integer n, you need to find the smallest 32-bit integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive 32-bit integer exists, you need to return -1.

Example 1:

Input: 12
Output: 21
 

Example 2:

Input: 21
Output: -1
 */
public class Solution {
    public int NextGreaterElement(int n) {
        char[] num = n.ToString().ToCharArray();
        int high = -1, low = -1;
        for (int i = num.Length - 2; i >= 0; i--)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (num[i] < num[j])
                {
                    high = i;
                    low = low == -1 ? j : (num[low] > num[j] ? j : low);
                }
            }
            if (high != -1)
            {
                char temp = num[high];
                num[high] = num[low];
                num[low] = temp;
                Array.Sort(num, high + 1, num.Length - high - 1);
                double newNum = double.Parse(new string(num));
                if (newNum > int.MaxValue)
                    return -1;
                else
                    return Convert.ToInt32(newNum);
            }
        }
        return -1;
    }
}

// √ Accepted
//   √ 35/35 cases passed (36 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (12.9 MB)

