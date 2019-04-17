/*
 * @lc app=leetcode id=93 lang=csharp
 *
 * [93] Restore IP Addresses
 *
 * https://leetcode.com/problems/restore-ip-addresses/description/
 *
 * algorithms
 * Medium (31.07%)
 * Total Accepted:    135.2K
 * Total Submissions: 434.6K
 * Testcase Example:  '"25525511135"'
 *
 * Given a string containing only digits, restore it by returning all possible
 * valid IP address combinations.
 * 
 * Example:
 * 
 * 
 * Input: "25525511135"
 * Output: ["255.255.11.135", "255.255.111.35"]
 * 
 * 
 */
public class Solution {
    public IList<string> RestoreIpAddresses(string s)
    {
        List<string> list = new List<string>();
        GetSubIp(list, s, 0, 1, "");
        return list;
    }

    private void GetSubIp(List<string> list, string s, int idx, int dep, string r)
    {
        if (dep == 4)
        {
            int len = s.Length - idx;
            if(len > 3 || idx >= s.Length)//长度超出
                return;

            if(len > 1 && s[idx] == '0')
                return;

            int t = int.Parse(s.Substring(idx));
            if(t > 255)
                return;
            list.Add(r + "." + t);
            return;
        }

        for (int i = 0; i < 3 && idx+i+1 < s.Length; i++)
        {
            if(i > 0 && s[idx] == '0')
                break;

            int t = int.Parse(s.Substring(idx, i + 1));
            if(t > 255)
                break;
            if(dep == 1)
                GetSubIp(list, s, idx+i+1, dep+1, t.ToString());
            else
                GetSubIp(list, s, idx + i + 1, dep + 1, r+"."+t);
        }
    }
}

// √ Accepted
//   √ 147/147 cases passed (252 ms)
//   √ Your runtime beats 68.31 % of csharp submissions
//   √ Your memory usage beats 80 % of csharp submissions (29.1 MB)

