/*
 * @lc app=leetcode id=462 lang=csharp
 *
 * [462] Minimum Moves to Equal Array Elements II

 Given a non-empty integer array, find the minimum number of moves required to make all array elements equal, where a move is incrementing a selected element by 1 or decrementing a selected element by 1.

You may assume the array's length is at most 10,000.

Example:

Input:
[1,2,3]

Output:
2

Explanation:
Only two moves are needed (remember each move increments or decrements one element):

[1,2,3]  =>  [2,2,3]  =>  [2,2,2]
 */
public class Solution {
    public int MinMoves2(int[] nums) {
        if(nums.Length <= 1)
            return 0;
        
        Array.Sort(nums);
        int i = 0, j = nums.Length-1, res = 0;
        while (i < j)
        {
            res += nums[j--] - nums[i++];
        }
        return res;
    }
}

//找中位数，求差值和
// √ Accepted
//   √ 29/29 cases passed (124 ms)
//   √ Your runtime beats 34.55 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (24.2 MB)

