/*
 * @lc app=leetcode id=670 lang=csharp
 *
 * [670] Maximum Swap

 Given a non-negative integer, you could swap two digits at most once to get the maximum valued number. Return the maximum valued number you could get.

Example 1:
Input: 2736
Output: 7236
Explanation: Swap the number 2 and the number 7.
Example 2:
Input: 9973
Output: 9973
Explanation: No swap.
Note:
The given number is in the range [0, 108]
 */
public class Solution {
    public int MaximumSwap(int num) {
        char[] arr = num.ToString().ToCharArray();
        int[] maxs = new int[arr.Length];
        int len = arr.Length;
        maxs[len - 1] = len-1;
        for (int i = len-2; i >= 0; i--)//找到后面的最大的索引
        {
            maxs[i] = arr[i] >= arr[maxs[i + 1]] ? i : maxs[i + 1];
        }

        int res = num;
        for (int i = 0; i < arr.Length; i++)
        {
            if(maxs[i] == i)
                continue;

            for (int j = i+1; j < len; j++)
            {
                if(j > i+1 && maxs[j] == maxs[j-1])
                    continue;

                int idx = maxs[j];

                char tem = arr[i];
                arr[i] = arr[idx];
                arr[idx] = tem;

                res = Math.Max(res, int.Parse(new string(arr)));
                tem = arr[i];
                arr[i] = arr[idx];
                arr[idx] = tem;
            }
            
            break;
        }

        return res;
    }
}


// √ Accepted
//   √ 111/111 cases passed (40 ms)
//   √ Your runtime beats 57.89 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (12.6 MB)

