/*
 * @lc app=leetcode id=937 lang=csharp
 *
 * [937] Reorder Log Files
 *
 * https://leetcode.com/problems/reorder-log-files/description/
 *
 * algorithms
 * Easy (59.09%)
 * Total Accepted:    14.7K
 * Total Submissions: 24.6K
 * Testcase Example:  '["a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"]'
 *
 * You have an array of logs.  Each log is a space delimited string of words.
 * 
 * For each log, the first word in each log is an alphanumeric identifier.
 * Then, either:
 * 
 * 
 * Each word after the identifier will consist only of lowercase letters,
 * or;
 * Each word after the identifier will consist only of digits.
 * 
 * 
 * We will call these two varieties of logs letter-logs and digit-logs.  It is
 * guaranteed that each log has at least one word after its identifier.
 * 
 * Reorder the logs so that all of the letter-logs come before any digit-log.
 * The letter-logs are ordered lexicographically ignoring identifier, with the
 * identifier used in case of ties.  The digit-logs should be put in their
 * original order.
 * 
 * Return the final order of the logs.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: ["a1 9 2 3 1","g1 act car","zo4 4 7","ab1 off key dog","a8 act zoo"]
 * Output: ["g1 act car","a8 act zoo","ab1 off key dog","a1 9 2 3 1","zo4 4
 * 7"]
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 0 <= logs.length <= 100
 * 3 <= logs[i].length <= 100
 * logs[i] is guaranteed to have an identifier, and a word after the
 * identifier.
 * 
 * 
 */
public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        if (logs.Length <= 1)
            return logs;

        string[] weight = new string[logs.Length];
        
        for (int i = 0; i < logs.Length; i++)
        {
            int idx = logs[i].IndexOf(' ');
            if (logs[i][idx + 1] >= '0' && logs[i][idx + 1] <= '9')
            {
                weight[i] = "0";
            }
            else
            {
                string s = logs[i].Substring(idx + 1);
                string l = logs[i];
                weight[i] = s;
                int j = i;

                for (; j > 0; j--)
                {
                    int a = weight[j].CompareTo(weight[j - 1]);

                    if (weight[j - 1] == "0" || a < 0)
                    {
                        weight[j] = weight[j - 1];
                        logs[j] = logs[j - 1];
                        weight[j - 1] = s;
                    }
                    else
                    {
                        break;
                    }
                }

                weight[j] = s;
                logs[j] = l;
            }

        }

        return logs;
    }
}

// √ Accepted
//   √ 61/61 cases passed (272 ms)
//   √ Your runtime beats 86.67 % of csharp submissions
//   √ Your memory usage beats 27.27 % of csharp submissions (32.4 MB)

