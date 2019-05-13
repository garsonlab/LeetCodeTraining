/*
 * @lc app=leetcode id=756 lang=csharp
 *
 * [756] Pyramid Transition Matrix

 We are stacking blocks to form a pyramid. Each block has a color which is a one letter string.

We are allowed to place any color block C on top of two adjacent blocks of colors A and B, if and only if ABC is an allowed triple.

We start with a bottom row of bottom, represented as a single string. We also start with a list of allowed triples allowed. Each allowed triple is represented as a string of length 3.

Return true if we can build the pyramid all the way to the top, otherwise false.

Example 1:

Input: bottom = "BCD", allowed = ["BCG", "CDE", "GEA", "FFF"]
Output: true
Explanation:
We can stack the pyramid like this:
    A
   / \
  G   E
 / \ / \
B   C   D

We are allowed to place G on top of B and C because BCG is an allowed triple.  Similarly, we can place E on top of C and D, then A on top of G and E.
 

Example 2:

Input: bottom = "AABA", allowed = ["AAA", "AAB", "ABA", "ABB", "BAC"]
Output: false
Explanation:
We can't stack the pyramid to the top.
Note that there could be allowed triples (A, B, C) and (A, B, D) with C != D.
 

Note:

bottom will be a string with length in range [2, 8].
allowed will have length in range [0, 200].
Letters in all strings will be chosen from the set {'A', 'B', 'C', 'D', 'E', 'F', 'G'}.
 */
public class Solution {
    public bool PyramidTransition(string bottom, IList<string> allowed) {
        if (bottom.Length <= 1)
            return true;

        Dictionary<string, List<char>> dic= new Dictionary<string, List<char>>();
        foreach (var s in allowed)
        {
            string a = s.Substring(0, 2);
            List<char> list;
            if (!dic.TryGetValue(a, out list))
            {
                list = new List<char>();
                dic[a] = list;
            }
            list.Add(s[2]);
        }

        return PTDFS(dic, bottom, new char[bottom.Length - 1], 1);
    }

    private bool PTDFS(Dictionary<string, List<char>> dic, string bottom, char[] cs, int idx)
    {
        if (bottom.Length <= 1)
            return true;
        if (idx >= bottom.Length)
            return PTDFS(dic, new string(cs), new char[cs.Length - 1], 1);

        List<char> list;
        string t = "" + bottom[idx - 1] + bottom[idx];

        if (!dic.TryGetValue(t, out list))
            return false;

        foreach (var c in list)
        {
            cs[idx - 1] = c;

            bool ac = PTDFS(dic, bottom, cs, idx + 1);
            if (ac)
                return true;
        }

        return false;
    }

}

// √ Accepted
//   √ 63/63 cases passed (104 ms)
//   √ Your runtime beats 60 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.9 MB)

