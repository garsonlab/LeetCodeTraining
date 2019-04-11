/*
 * @lc app=leetcode id=914 lang=csharp
 *
 * [914] X of a Kind in a Deck of Cards
 *
 * https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/description/
 *
 * algorithms
 * Easy (34.48%)
 * Total Accepted:    16.2K
 * Total Submissions: 47.3K
 * Testcase Example:  '[1,2,3,4,4,3,2,1]'
 *
 * In a deck of cards, each card has an integer written on it.
 * 
 * Return true if and only if you can choose X >= 2 such that it is possible to
 * split the entire deck into 1 or more groups of cards, where:
 * 
 * 
 * Each group has exactly X cards.
 * All the cards in each group have the same integer.
 * 
 * 
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: [1,2,3,4,4,3,2,1]
 * Output: true
 * Explanation: Possible partition [1,1],[2,2],[3,3],[4,4]
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [1,1,1,2,2,2,3,3]
 * Output: false
 * Explanation: No possible partition.
 * 
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: [1]
 * Output: false
 * Explanation: No possible partition.
 * 
 * 
 * 
 * Example 4:
 * 
 * 
 * Input: [1,1]
 * Output: true
 * Explanation: Possible partition [1,1]
 * 
 * 
 * 
 * Example 5:
 * 
 * 
 * Input: [1,1,2,2,2,2]
 * Output: true
 * Explanation: Possible partition [1,1],[2,2],[2,2]
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Note:
 * 
 * 
 * 1 <= deck.length <= 10000
 * 0 <= deck[i] < 10000
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
public class Solution {
    public bool HasGroupsSizeX(int[] deck)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var i in deck)
        {
            int n;
            if (!dic.TryGetValue(i, out n))
                n = 0;
            dic[i] = n + 1;
        }

        int k = 0;
        foreach (var value in dic.Values)
        {
            if (k == 0)
                k = value;
            else
                k = GCD(k, value);
        }

        return k > 1;
    }

    private int GCD(int a, int b)
    {
        return a % b == 0 ? b : GCD(b, a % b);
    }
}

// √ Accepted
//   √ 69/69 cases passed (112 ms)
//   √ Your runtime beats 88.89 % of csharp submissions
//   √ Your memory usage beats 72.73 % of csharp submissions (26.5 MB)

