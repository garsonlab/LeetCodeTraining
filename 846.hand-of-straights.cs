/*
 * @lc app=leetcode id=846 lang=csharp
 *
 * [846] Hand of Straights

 Alice has a hand of cards, given as an array of integers.

Now she wants to rearrange the cards into groups so that each group is size W, and consists of W consecutive cards.

Return true if and only if she can.

 

Example 1:

Input: hand = [1,2,3,6,2,3,4,7,8], W = 3
Output: true
Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8].
Example 2:

Input: hand = [1,2,3,4,5], W = 4
Output: false
Explanation: Alice's hand can't be rearranged into groups of 4.
 

Note:

1 <= hand.length <= 10000
0 <= hand[i] <= 10^9
1 <= W <= hand.length
 */
public class Solution {
    public bool IsNStraightHand(int[] hand, int W) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int min = int.MaxValue;
        foreach (var i in hand)
        {
            int n;
            if (!dic.TryGetValue(i, out n))
                n = 0;
            dic[i] = n + 1;

            min = Math.Min(min, i);
        }

        while (min >= 0)
        {
            int count = 0;
            int tem = min;
            min = -1;
            while (count++ < W)
            {
                if (!dic.ContainsKey(tem) || dic[tem] <= 0)
                    return false;
                dic[tem]--;

                if (dic[tem] <= 0)
                    dic.Remove(tem);
                else if (min < 0)
                    min = tem;
                
                tem++;
            }

            if (min < 0 && dic.Count > 0)
            {
                min = Int32.MaxValue;
                foreach (var key in dic.Keys)
                {
                    min = Math.Min(min, key);
                }
            }
        }

        return true;
    }
}

// √ Accepted
//   √ 65/65 cases passed (304 ms)
//   √ Your runtime beats 37.21 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (35.7 MB)

