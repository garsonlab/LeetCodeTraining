/*
 * @lc app=leetcode id=646 lang=csharp
 *
 * [646] Maximum Length of Pair Chain
 You are given n pairs of numbers. In every pair, the first number is always smaller than the second number.

Now, we define a pair (c, d) can follow another pair (a, b) if and only if b < c. Chain of pairs can be formed in this fashion.

Given a set of pairs, find the length longest chain which can be formed. You needn't use up all the given pairs. You can select pairs in any order.

Example 1:
Input: [[1,2], [2,3], [3,4]]
Output: 2
Explanation: The longest chain is [1,2] -> [3,4]
Note:
The number of given pairs will be in the range [1, 1000].
 */
public class Solution {
    public int FindLongestChain(int[][] pairs) {
        Array.Sort(pairs, (a, b) => { return a[1] - b[1]; });
        int end = pairs[0][1], maxLen = 1;

        for (int i = 1; i < pairs.Length; i++)
        {
            //如果合法 就加入 （因为此时已经按照第二个升序排列了 所以这就是符合条件的数对）
            if (pairs[i][0] > end)
            {
                end = pairs[i][1];
                maxLen++;
            }
        }

        return maxLen;
    }
}

// √ Accepted
//   √ 202/202 cases passed (224 ms)
//   √ Your runtime beats 30.77 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (28.6 MB)

