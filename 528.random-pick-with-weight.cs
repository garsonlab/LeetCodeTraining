/*
 * @lc app=leetcode id=528 lang=csharp
 *
 * [528] Random Pick with Weight

 Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

Note:

1 <= w.length <= 10000
1 <= w[i] <= 10^5
pickIndex will be called at most 10000 times.
Example 1:

Input: 
["Solution","pickIndex"]
[[[1]],[]]
Output: [null,0]
Example 2:

Input: 
["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
[[[1,3]],[],[],[],[],[]]
Output: [null,0,1,1,1,0]
Explanation of Input Syntax:

The input is two lists: the subroutines called and their arguments. Solution's constructor has one argument, the array w. pickIndex has no arguments. Arguments are always wrapped with a list, even if there aren't any.
 */
public class Solution {

    private Random random;
        private int[] sum;
        private int total;
        public Solution(int[] w)
        {
            random = new Random();
            sum = new int[w.Length];
            int s = 0;
            for (int i = 0; i < w.Length; i++)
            {
                s += w[i];
                sum[i] = s;
            }

            total = s;
        }

        public int PickIndex()
        {
            int v = random.Next(total+1);
            for (int i = 0; i < sum.Length; i++)
            {
                if (v <= sum[i])
                    return i;
            }

            return -1;
        }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */

