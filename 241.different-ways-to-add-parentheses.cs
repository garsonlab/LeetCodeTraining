/*
 * @lc app=leetcode id=241 lang=csharp
 *
 * [241] Different Ways to Add Parentheses

 Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators. The valid operators are +, - and *.

Example 1:

Input: "2-1-1"
Output: [0, 2]
Explanation: 
((2-1)-1) = 0 
(2-(1-1)) = 2
Example 2:

Input: "2*3-4*5"
Output: [-34, -14, -10, -10, 10]
Explanation: 
(2*(3-(4*5))) = -34 
((2*3)-(4*5)) = -14 
((2*(3-4))*5) = -10 
(2*((3-4)*5)) = -10 
(((2*3)-4)*5) = 10
 */
public class Solution {
    public IList<int> DiffWaysToCompute(string input) {
        List<int> list = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (c == '+' || c == '-' || c == '*')
            {
                var res1 = DiffWaysToCompute(input.Substring(0, i));
                var res2 = DiffWaysToCompute(input.Substring(i + 1));
                foreach (var r1 in res1)
                {
                    foreach (var r2 in res2)
                    {
                        if(c == '+')
                            list.Add(r1+r2);
                        else if(c == '-')
                            list.Add(r1-r2);
                        else
                            list.Add(r1*r2);
                    }
                }
            }
        }
        if(list.Count == 0)
            list.Add(int.Parse(input));
        return list;
    }
}

// √ Accepted
//   √ 25/25 cases passed (240 ms)
//   √ Your runtime beats 82.69 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (29 MB)

