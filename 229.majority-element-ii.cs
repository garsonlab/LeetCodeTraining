/*
 * @lc app=leetcode id=229 lang=csharp
 *
 * [229] Majority Element II

    Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

    Note: The algorithm should run in linear time and in O(1) space.

    Example 1:

    Input: [3,2,3]
    Output: [3]
    Example 2:

    Input: [1,1,1,3,3,2,2,2]
    Output: [1,2]
 */
public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        List<int> list = new List<int>();

        int x=0, xn=0, xc=0;
        int y=0, yn=0, yc=0;

        for (int i = 0; i < nums.Length; i++)
        {
            if((xn == 0 || nums[i] == x) && nums[i] != y) {
                xn++;
                x = nums[i];
            }
            else if(yn == 0 || nums[i] == y) {
                yn++;
                y = nums[i];
            }
            else {
                xn--;
                yn--;
            }

        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(x == nums[i])
                xc++;
            else if(y == nums[i])
                yc++;
        }

        if(xc > nums.Length/3)
            list.Add(x);
        if(y != x && yc > nums.Length/3)
            list.Add(y);
        
        return list;
    }
}

// 【笔记】摩尔投票法。该算法用于1/2情况，它说：“在任何数组中，出现次数大于该数组长度一半的值只能有一个。”
// 那么，改进一下用于1/3。可以着么说：“在任何数组中，出现次数大于该数组长度1/3的值最多只有两个。”
// √ Accepted
//   √ 66/66 cases passed (260 ms)
//   √ Your runtime beats 83.26 % of csharp submissions
//   √ Your memory usage beats 7.14 % of csharp submissions (31.6 MB)

