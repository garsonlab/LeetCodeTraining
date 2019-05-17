/*
 * @lc app=leetcode id=848 lang=csharp
 *
 * [848] Shifting Letters
 We have a string S of lowercase letters, and an integer array shifts.

Call the shift of a letter, the next letter in the alphabet, (wrapping around so that 'z' becomes 'a'). 

For example, shift('a') = 'b', shift('t') = 'u', and shift('z') = 'a'.

Now for each shifts[i] = x, we want to shift the first i+1 letters of S, x times.

Return the final string after all such shifts to S are applied.

Example 1:

Input: S = "abc", shifts = [3,5,9]
Output: "rpl"
Explanation: 
We start with "abc".
After shifting the first 1 letters of S by 3, we have "dbc".
After shifting the first 2 letters of S by 5, we have "igc".
After shifting the first 3 letters of S by 9, we have "rpl", the answer.
Note:

1 <= S.length = shifts.length <= 20000
0 <= shifts[i] <= 10 ^ 9
 */
public class Solution {
    public string ShiftingLetters(string S, int[] shifts) {
        char[] arr = S.ToCharArray();
        int sum = 0;
        for (int i = shifts.Length-1; i >= 0; i--)
        {
            sum = (sum + shifts[i]) % 26;
            arr[i] = (char) (((arr[i] - 'a') + sum) % 26 + 'a');
        }

        return new string(arr);
    }
}

// √ Accepted
//   √ 46/46 cases passed (144 ms)
//   √ Your runtime beats 50.85 % of csharp submissions
//   √ Your memory usage beats 27.27 % of csharp submissions (33.6 MB)

