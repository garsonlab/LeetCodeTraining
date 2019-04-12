/*
 * @lc app=leetcode id=929 lang=csharp
 *
 * [929] Unique Email Addresses
 *
 * https://leetcode.com/problems/unique-email-addresses/description/
 *
 * algorithms
 * Easy (74.95%)
 * Total Accepted:    99.6K
 * Total Submissions: 135.3K
 * Testcase Example:  '["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]'
 *
 * Every email consists of a local name and a domain name, separated by the @
 * sign.
 * 
 * For example, in alice@leetcode.com, alice is the local name, and
 * leetcode.com is the domain name.
 * 
 * Besides lowercase letters, these emails may contain '.'s or '+'s.
 * 
 * If you add periods ('.') between some characters in the local name part of
 * an email address, mail sent there will be forwarded to the same address
 * without dots in the local name.  For example, "alice.z@leetcode.com" and
 * "alicez@leetcode.com" forward to the same email address.  (Note that this
 * rule does not apply for domain names.)
 * 
 * If you add a plus ('+') in the local name, everything after the first plus
 * sign will be ignored. This allows certain emails to be filtered, for example
 * m.y+name@email.com will be forwarded to my@email.com.  (Again, this rule
 * does not apply for domain names.)
 * 
 * It is possible to use both of these rules at the same time.
 * 
 * Given a list of emails, we send one email to each address in the list.  How
 * many different addresses actually receive mails? 
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input:
 * ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]
 * Output: 2
 * Explanation: "testemail@leetcode.com" and "testemail@lee.tcode.com" actually
 * receive mails
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= emails[i].length <= 100
 * 1 <= emails.length <= 100
 * Each emails[i] contains exactly one '@' character.
 * All local and domain names are non-empty.
 * Local names do not start with a '+' character.
 * 
 * 
 * 
 */
public class Solution {
    public int NumUniqueEmails(string[] emails) {
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        StringBuilder builder = new StringBuilder();
        int count = 0;
        foreach (var email in emails)
        {
            string[] ps = email.Split('@');
            builder.Length = 0;
            for (int i = 0; i < ps[0].Length; i++)
            {
                if(ps[0][i] == '+')
                    break;
                if (ps[0][i] != '.')
                    builder.Append(ps[0][i]);
            }

            List<string> list;
            if (!dic.TryGetValue(ps[1], out list))
            {
                list = new List<string>();
                dic[ps[1]] = list;
            }

            string s = builder.ToString();
            if (!list.Contains(s))
            {
                list.Add(s);
                count++;
            }
        }

        return count;
    }
}

// √ Accepted
//   √ 184/184 cases passed (108 ms)
//   √ Your runtime beats 95.8 % of csharp submissions
//   √ Your memory usage beats 24.81 % of csharp submissions (26.3 MB)

