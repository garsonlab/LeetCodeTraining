/*
 * @lc app=leetcode id=990 lang=csharp
 *
 * [990] Satisfiability of Equality Equations

 Given an array equations of strings that represent relationships between variables, each string equations[i] has length 4 and takes one of two different forms: "a==b" or "a!=b".  Here, a and b are lowercase letters (not necessarily different) that represent one-letter variable names.

Return true if and only if it is possible to assign integers to variable names so as to satisfy all the given equations.

 

Example 1:

Input: ["a==b","b!=a"]
Output: false
Explanation: If we assign say, a = 1 and b = 1, then the first equation is satisfied, but not the second.  There is no way to assign the variables to satisfy both equations.
Example 2:

Input: ["b==a","a==b"]
Output: true
Explanation: We could assign a = 1 and b = 1 to satisfy both equations.
Example 3:

Input: ["a==b","b==c","a==c"]
Output: true
Example 4:

Input: ["a==b","b!=c","c==a"]
Output: false
Example 5:

Input: ["c==c","b==d","x!=z"]
Output: true
 

Note:

1 <= equations.length <= 500
equations[i].length == 4
equations[i][0] and equations[i][3] are lowercase letters
equations[i][1] is either '=' or '!'
equations[i][2] is '='
 */
public class Solution {
    public bool EquationsPossible(string[] equations) {
        char l, r;
        foreach (string tmp in equations)
        {
            l = tmp[0];
            r = tmp[3];
            if (tmp[1] == '=' && find(l) != find(r))
                union(l, r);
        }
        foreach (string tmp in equations)
        if (tmp[1] == '!' && find(tmp[0]) == find(tmp[3]))
            return false;
        return true;
    }

    int[] s = new int[256];
    public int find(int x)
    {
        if (s[x] == 0) return x;
        else return find(s[x]);
    }
    public void union(int x, int y)
    {
        x = find(x);
        y = find(y);
        if (x == y) return;
        if (x < y)
            s[y] = x;
        else s[x] = y;
    }
}

// √ Accepted
//   √ 181/181 cases passed (92 ms)
//   √ Your runtime beats 92.71 % of csharp submissions
//   √ Your memory usage beats 48.19 % of csharp submissions (23.2 MB)

