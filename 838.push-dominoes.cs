/*
 * @lc app=leetcode id=838 lang=csharp
 *
 * [838] Push Dominoes

 There are N dominoes in a line, and we place each domino vertically upright.

In the beginning, we simultaneously push some of the dominoes either to the left or to the right.



After each second, each domino that is falling to the left pushes the adjacent domino on the left.

Similarly, the dominoes falling to the right push their adjacent dominoes standing on the right.

When a vertical domino has dominoes falling on it from both sides, it stays still due to the balance of the forces.

For the purposes of this question, we will consider that a falling domino expends no additional force to a falling or already fallen domino.

Given a string "S" representing the initial state. S[i] = 'L', if the i-th domino has been pushed to the left; S[i] = 'R', if the i-th domino has been pushed to the right; S[i] = '.', if the i-th domino has not been pushed.

Return a string representing the final state. 

Example 1:

Input: ".L.R...LR..L.."
Output: "LL.RR.LLRRLL.."
Example 2:

Input: "RR.L"
Output: "RR.L"
Explanation: The first domino expends no additional force on the second domino.
Note:

0 <= N <= 10^5
String dominoes contains only 'L', 'R' and '.'
 */
public class Solution {
    public string PushDominoes(string dominoes) {
        int len = dominoes.Length;
        int[] vis = new int[len];

        char[] ans = dominoes.ToCharArray();
        for (int i = 0; i < len; i++)
            vis[i] = 0;


        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if (j < len-1 && ans[j] == 'R' && ans[j + 1] == '.' && j < len - 1)
                    vis[j + 1] += 1;
                if (j>0&& ans[j] == 'L' && ans[j - 1] == '.' && j >= 1)
                    vis[j - 1] -= 1;
            }
            int flag = 0;
            for (int j = 0; j < len; j++)
            {
                if (dominoes[j] == '.' && vis[j] != 0)
                {
                    if (vis[j] == 1)
                        ans[j] = 'R';
                    else
                        ans[j] = 'L';
                    flag = 1;
                }
            }
            for (int j = 0; j < len; j++)
                vis[j] = 0;
            if (flag == 0)
                break;
        }
        return new string(ans);
    }
}

// √ Accepted
//   √ 36/36 cases passed (292 ms)
//   √ Your runtime beats 20 % of csharp submissions
//   √ Your memory usage beats 62.5 % of csharp submissions (30.7 MB)

