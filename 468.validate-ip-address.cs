/*
 * @lc app=leetcode id=468 lang=csharp
 *
 * [468] Validate IP Address

 Write a function to check whether an input string is a valid IPv4 address or IPv6 address or neither.

IPv4 addresses are canonically represented in dot-decimal notation, which consists of four decimal numbers, each ranging from 0 to 255, separated by dots ("."), e.g.,172.16.254.1;

Besides, leading zeros in the IPv4 is invalid. For example, the address 172.16.254.01 is invalid.

IPv6 addresses are represented as eight groups of four hexadecimal digits, each group representing 16 bits. The groups are separated by colons (":"). For example, the address 2001:0db8:85a3:0000:0000:8a2e:0370:7334 is a valid one. Also, we could omit some leading zeros among four hexadecimal digits and some low-case characters in the address to upper-case ones, so 2001:db8:85a3:0:0:8A2E:0370:7334 is also a valid IPv6 address(Omit leading zeros and using upper cases).

However, we don't replace a consecutive group of zero value with a single empty group using two consecutive colons (::) to pursue simplicity. For example, 2001:0db8:85a3::8A2E:0370:7334 is an invalid IPv6 address.

Besides, extra leading zeros in the IPv6 is also invalid. For example, the address 02001:0db8:85a3:0000:0000:8a2e:0370:7334 is invalid.

Note: You may assume there is no extra space or special characters in the input string.

Example 1:
Input: "172.16.254.1"

Output: "IPv4"

Explanation: This is a valid IPv4 address, return "IPv4".
Example 2:
Input: "2001:0db8:85a3:0:0:8A2E:0370:7334"

Output: "IPv6"

Explanation: This is a valid IPv6 address, return "IPv6".
Example 3:
Input: "256.256.256.256"

Output: "Neither"

Explanation: This is neither a IPv4 address nor a IPv6 address.
 */
public class Solution {
    public string ValidIPAddress(string IP)
        {
            if (IP.Contains("."))
                return CheckIP4(IP) > 0? "IPv4" : "Neither";
            else
                return CheckIP6(IP) > 0 ? "IPv6" : "Neither";
        }

        private int CheckIP4(string IP)
        {
            string[] ps = IP.Split('.');
            if (ps.Length != 4)
                return -1;

            for (int i = 0; i < 4; i++)
            {
                if (ps[i].Length == 0 || ps[i].Length > 3)
                    return -1;
                if (ps[i].Length > 1 && ps[i][0] == '0')
                    return -1;
                    
                foreach (var c in ps[i])
                {
                    if (c < '0' || c > '9')
                        return -1;
                }

                int v;
                if (!int.TryParse(ps[i], out v))
                    return -1;

                if (v < 0 || v > 255)
                    return -1;
            }

            return 1;
        }

        private int CheckIP6(string IP)
        {
            string[] ps = IP.Split(':');
            if (ps.Length != 8)
                return -1;

            foreach (var s in ps)
            {
                if (s.Length <= 0 || s.Length > 4)
                    return -1;

                foreach (var c in s)
                {
                    if ((c >= '0' && c <= '9')
                        || (c >= 'a' && c <= 'f'
                            || (c >= 'A' && c <= 'F')))
                    {

                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            return 1;
        }
}


// √ Accepted
//   √ 79/79 cases passed (88 ms)
//   √ Your runtime beats 91.78 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (20.8 MB)
