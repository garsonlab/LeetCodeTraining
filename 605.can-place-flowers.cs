/*
 * @lc app=leetcode id=605 lang=csharp
 *
 * [605] Can Place Flowers
 *
 * https://leetcode.com/problems/can-place-flowers/description/
 *
 * algorithms
 * Easy (30.72%)
 * Total Accepted:    56K
 * Total Submissions: 182.4K
 * Testcase Example:  '[1,0,0,0,1]\n1'
 *
 * Suppose you have a long flowerbed in which some of the plots are planted and
 * some are not. However, flowers cannot be planted in adjacent plots - they
 * would compete for water and both would die.
 * 
 * Given a flowerbed (represented as an array containing 0 and 1, where 0 means
 * empty and 1 means not empty), and a number n, return if n new flowers can be
 * planted in it without violating the no-adjacent-flowers rule.
 * 
 * Example 1:
 * 
 * Input: flowerbed = [1,0,0,0,1], n = 1
 * Output: True
 * 
 * 
 * 
 * Example 2:
 * 
 * Input: flowerbed = [1,0,0,0,1], n = 2
 * Output: False
 * 
 * 
 * 
 * Note:
 * 
 * The input array won't violate no-adjacent-flowers rule.
 * The input array size is in the range of [1, 20000].
 * n is a non-negative integer which won't exceed the input array size.
 * 
 * 
 */
public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        int c = 0;
        bool h = false, f = false;
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0)
            {
                c++;
                if(i == 0 )
                    h = true;
                if(i == flowerbed.Length-1)
                    f = true;
            }
            else
            {
                if(h || f)
                    n-=c/2;
                else
                    n -= (c-1) / 2;
                c = 0;
                h = false;
            }
        }

        if(h && f)
            n-=(c+1)/2;
        else if(h || f)
            n-=c/2;
        else
            n -= (c-1) / 2;
        return n <= 0;
    }
}

// √ Accepted
//   √ 123/123 cases passed (112 ms)
//   √ Your runtime beats 79.34 % of csharp submissions
//   √ Your memory usage beats 7.69 % of csharp submissions (28.1 MB)

