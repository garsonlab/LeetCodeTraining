/*
 * @lc app=leetcode id=319 lang=csharp
 *
 * [319] Bulb Switcher

 There are n bulbs that are initially off. You first turn on all the bulbs. Then, you turn off every second bulb. On the third round, you toggle every third bulb (turning on if it's off or turning off if it's on). For the i-th round, you toggle every i bulb. For the n-th round, you only toggle the last bulb. Find how many bulbs are on after n rounds.

Example:

Input: 3
Output: 1 
Explanation: 
At first, the three bulbs are [off, off, off].
After first round, the three bulbs are [on, on, on].
After second round, the three bulbs are [on, off, on].
After third round, the three bulbs are [on, off, off]. 

So you should return 1, because there is only one bulb is on.
 */
public class Solution {
    public int BulbSwitch(int n) {
        return (int)Math.Sqrt(n);
    }
}
/**
 * 初始有n个灯泡关闭
 * 第i轮的操作是每i个灯泡切换一次开关（开->闭，闭->开），即切换i的倍数位置的开关。
 * 求n轮后亮着的灯泡？
 * （1）第i轮时，被切换的灯泡位置是i的倍数。
 * （2）由（1）得出，对于第p个灯泡来说，只有其第“因子”轮才会切换，若其有q个因子，则最终被切换q次。因为初始状态是关闭状态，那么因子数是奇数的灯泡最终是亮着的。
 * （3）只有平方数的因子个数不是成对出现，举例：4=1*4,2*2，其因子是1,2,4。
 * （4）那么题目最终转化为1~n里平方数的个数，进而转化为对n开平方根，向下取整即可。
 */
// √ Accepted
//   √ 35/35 cases passed (48 ms)
//   √ Your runtime beats 21.98 % of csharp submissions
//   √ Your memory usage beats 20 % of csharp submissions (12.9 MB)

