/*
 * @lc app=leetcode id=299 lang=csharp
 *
 * [299] Bulls and Cows

 You are playing the following Bulls and Cows game with your friend: You write down a number and ask your friend to guess what the number is. Each time your friend makes a guess, you provide a hint that indicates how many digits in said guess match your secret number exactly in both digit and position (called "bulls") and how many digits match the secret number but locate in the wrong position (called "cows"). Your friend will use successive guesses and hints to eventually derive the secret number.

Write a function to return a hint according to the secret number and friend's guess, use A to indicate the bulls and B to indicate the cows. 

Please note that both secret number and friend's guess may contain duplicate digits.

Example 1:

Input: secret = "1807", guess = "7810"

Output: "1A3B"

Explanation: 1 bull and 3 cows. The bull is 8, the cows are 0, 1 and 7.
Example 2:

Input: secret = "1123", guess = "0111"

Output: "1A1B"

Explanation: The 1st 1 in friend's guess is a bull, the 2nd or 3rd 1 is a cow.
Note: You may assume that the secret number and your friend's guess only contain digits, and their lengths are always equal.
 */
public class Solution {
    public string GetHint(string secret, string guess) {
        if (secret.Length <= 0)
            return "0A0B";

        int a = 0, b = 0;
        int[] s = new int[10];
        int[] g = new int[10];
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
                a++;
            else
            {
                s[secret[i] - '0']++;
                g[guess[i] - '0']++;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            b += Math.Min(s[i], g[i]);
        }

        return a + "A" + b + "B";
    }
}

// √ Accepted
//   √ 152/152 cases passed (84 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 14.29 % of csharp submissions (22 MB)

