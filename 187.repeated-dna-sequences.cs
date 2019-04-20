/*
 * @lc app=leetcode id=187 lang=csharp
 *
 * [187] Repeated DNA Sequences
 *
 * https://leetcode.com/problems/repeated-dna-sequences/description/
 *
 * algorithms
 * Medium (35.68%)
 * Total Accepted:    122.2K
 * Total Submissions: 342K
 * Testcase Example:  '"AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"'
 *
 * All DNA is composed of a series of nucleotides abbreviated as A, C, G, and
 * T, for example: "ACGAATTCCG". When studying DNA, it is sometimes useful to
 * identify repeated sequences within the DNA.
 * 
 * Write a function to find all the 10-letter-long sequences (substrings) that
 * occur more than once in a DNA molecule.
 * 
 * Example:
 * 
 * 
 * Input: s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
 * 
 * Output: ["AAAAACCCCC", "CCCCCAAAAA"]
 * 
 * 
 */
public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        List<string> list = new List<string>();
        Dictionary<string, int> dic = new Dictionary<string, int>();

        for (int i = 0; i <= s.Length-10; i++)
        {
            string t = s.Substring(i, 10);
            if (dic.ContainsKey(t))
            {
                if (!list.Contains(t))
                    list.Add(t);
            }
            else
                dic[t] = 1;
        }

        return list;
    }
}

// √ Accepted
//   √ 32/32 cases passed (304 ms)
//   √ Your runtime beats 66.67 % of csharp submissions
//   √ Your memory usage beats 28.57 % of csharp submissions (42.2 MB)

