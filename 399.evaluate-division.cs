/*
 * @lc app=leetcode id=399 lang=csharp
 *
 * [399] Evaluate Division

 Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating point number). Given some queries, return the answers. If the answer does not exist, return -1.0.

Example:
Given a / b = 2.0, b / c = 3.0.
queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? .
return [6.0, 0.5, -1.0, 1.0, -1.0 ].

The input is: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries , where equations.size() == values.size(), and the values are positive. This represents the equations. Return vector<double>.

According to the example above:

equations = [ ["a", "b"], ["b", "c"] ],
values = [2.0, 3.0],
queries = [ ["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"] ].
 

The input is always valid. You may assume that evaluating the queries will result in no division by zero and there is no contradiction.
 */
public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        
        Dictionary<string, int> dic = new Dictionary<string, int>();
        int idx = 0;

        foreach (var equation in equations)
        {
            if(!dic.ContainsKey(equation[0]))
                dic[equation[0]] = idx++;
            if(!dic.ContainsKey(equation[1]))
                dic[equation[1]] = idx++;
        }
        double[,] map = new double[dic.Count, dic.Count];
        for(int i = 0; i < equations.Count; i++)
        {
            var equation = equations[i];
            int idxA = dic[equation[0]];
            int idxB = dic[equation[1]];

            map[idxA, idxB] = values[i];
            map[idxB, idxA] = 1.0/values[i];
            map[idxA, idxA] = 1.0;
            map[idxB, idxB] = 1.0;
        }


        int len = dic.Count;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if(i != j && map[i, j] > 0)
                {
                    for (int k = 0; k < len; k++)
                    {
                        if(map[j, k] > 0)
                        {
                            map[i, k] = map[i, j]*map[j, k];
                        }
                    }
                }
            }
        }

        double[] res = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++)
        {
            var querie = queries[i];
            if(!dic.ContainsKey(querie[0]) || !dic.ContainsKey(querie[1]))
            {
                res[i] = -1;
                continue;
            }

            int idxA = dic[querie[0]];
            int idxB = dic[querie[1]];

            res[i] = map[idxA, idxB] > 0? map[idxA, idxB] : -1.0;
        }

        return res;
    }
}

// √ Accepted
//   √ 11/11 cases passed (284 ms)
//   √ Your runtime beats 40.35 % of csharp submissions
//   √ Your memory usage beats 35.71 % of csharp submissions (28.2 MB)

