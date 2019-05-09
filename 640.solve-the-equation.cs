/*
 * @lc app=leetcode id=640 lang=csharp
 *
 * [640] Solve the Equation

 Solve a given equation and return the value of x in the form of string "x=#value". The equation contains only '+', '-' operation, the variable x and its coefficient.

If there is no solution for the equation, return "No solution".

If there are infinite solutions for the equation, return "Infinite solutions".

If there is exactly one solution for the equation, we ensure that the value of x is an integer.

Example 1:
Input: "x+5-3+x=6+x-2"
Output: "x=2"
Example 2:
Input: "x=x"
Output: "Infinite solutions"
Example 3:
Input: "2x=x"
Output: "x=0"
Example 4:
Input: "2x+3x-6x=x+2"
Output: "x=-1"
Example 5:
Input: "x=x+2"
Output: "No solution"
 */
public class Solution {
    public string SolveEquation(string equation) {
        string[] funcs = equation.Split('=');
        int[] left = ParseFunc(funcs[0]);
        int[] right = ParseFunc(funcs[1]);


        right[0] -= left[0];
        left[0] = 0;

        left[1] -= right[1];
        right[1] = 0;

        if (left[1] != 0)
            return "x=" + (right[0] / left[1]);
        else if (left[1] == 0 && right[0] == 0)
            return "Infinite solutions";
        else
            return "No solution";
    }

    private int[] ParseFunc(string func)
    {
        func = func.Replace("-", "+-");
        string[] ps = func.Split('+');
        int[] m = new int[2];
        foreach (var s in ps)
        {
            if(s.Length == 0)
                continue;
            int n;
            if (int.TryParse(s, out n))
            {
                m[0] += n;
            }
            else
            {
                if (s == "x")
                    m[1] += 1;
                else if (s == "-x")
                    m[1] -= 1;
                else
                {
                    n = int.Parse(s.Substring(0, s.Length - 1));
                    m[1] += n;
                }
            }
        }

        return m;
    }

}

// √ Accepted
//   √ 52/52 cases passed (88 ms)
//   √ Your runtime beats 60.53 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (20.9 MB)

