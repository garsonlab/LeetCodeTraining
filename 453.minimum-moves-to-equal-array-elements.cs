/*
 * @lc app=leetcode id=453 lang=csharp
 *
 * [453] Minimum Moves to Equal Array Elements
 *
 * https://leetcode.com/problems/minimum-moves-to-equal-array-elements/description/
 *
 * algorithms
 * Easy (49.06%)
 * Total Accepted:    55.2K
 * Total Submissions: 112.6K
 * Testcase Example:  '[1,2,3]'
 *
 * Given a non-empty integer array of size n, find the minimum number of moves
 * required to make all array elements equal, where a move is incrementing n -
 * 1 elements by 1.
 * 
 * Example:
 * 
 * Input:
 * [1,2,3]
 * 
 * Output:
 * 3
 * 
 * Explanation:
 * Only three moves are needed (remember each move increments two elements):
 * 
 * [1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
 * 
 * 
 */
public class Solution {
    public int MinMoves(int[] nums) {
        if (nums.Length <= 1)
            return 0;

        int min = int.MaxValue;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min)
                min = nums[i];
            sum += nums[i];
        }

        return sum - min * nums.Length;
    }
}

// 分析：逆向思考，每次移动让剩余的n-1个数加1，相当于每次移动让选定的那个数减1， 
// 所以最少移动次数其实就是所有元素减去最小元素的和
// √ Accepted
//   √ 84/84 cases passed (132 ms)
//   √ Your runtime beats 98.21 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (32.7 MB)


