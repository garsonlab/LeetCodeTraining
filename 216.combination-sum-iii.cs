/*
 * @lc app=leetcode id=216 lang=csharp
 *
 * [216] Combination Sum III

    Find all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

    Note:

    All numbers will be positive integers.
    The solution set must not contain duplicate combinations.
    Example 1:

    Input: k = 3, n = 7
    Output: [[1,2,4]]
    Example 2:

    Input: k = 3, n = 9
    Output: [[1,2,6], [1,3,5], [2,3,4]]
 */
public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        IList<IList<int>> list = new List<IList<int>>();

        int max = Math.Min(n, 9);
        ComSum(list, k, max, 1, n, new List<int>());

        return list;
    }

    private void ComSum(IList<IList<int>> list, int k, int n, int s, int t, List<int> cur)
    {
        for (int i = s; i <= n; i++)
        {
            int v = t - i;
            if(v < 0)
                break;
            if (v == 0)
            {
                if (cur.Count == k - 1)
                {
                    cur.Add(i);
                    list.Add(cur);
                }
                break;
            }

            if (cur.Count < k - 1)
            {
                var tem = new List<int>(cur);
                tem.Add(i);
                ComSum(list, k, n, i+1, v, tem);
            }
        }
    }

}

// √ Accepted
//   √ 18/18 cases passed (232 ms)
//   √ Your runtime beats 40.58 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (23.4 MB)

