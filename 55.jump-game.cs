/*
 * @lc app=leetcode id=55 lang=csharp
 *
 * [55] Jump Game
 *
 * https://leetcode.com/problems/jump-game/description/
 *
 * algorithms
 * Medium (31.62%)
 * Total Accepted:    251.1K
 * Total Submissions: 793.7K
 * Testcase Example:  '[2,3,1,1,4]'
 *
 * Given an array of non-negative integers, you are initially positioned at the
 * first index of the array.
 * 
 * Each element in the array represents your maximum jump length at that
 * position.
 * 
 * Determine if you are able to reach the last index.
 * 
 * Example 1:
 * 
 * 
 * Input: [2,3,1,1,4]
 * Output: true
 * Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last
 * index.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: [3,2,1,0,4]
 * Output: false
 * Explanation: You will always arrive at index 3 no matter what. Its
 * maximum
 * jump length is 0, which makes it impossible to reach the last index.
 * 
 * 
 */
public class Solution {
    public bool CanJump(int[] nums)
    {
        if (nums.Length <= 1)
            return true;

        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > max)
                return false;
            max = Math.Max(max, i + nums[i]);
        }

        return max >= nums.Length - 1;
    }

    //time out
    public bool CanJump22(int[] nums) {
        if (nums.Length <= 1)
            return true;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        int max = 0;

        while (queue.Count > 0)
        {
            int s = queue.Dequeue();
            for (int i = s+1; i <= s+nums[s]; i++)
            {
                if (!queue.Contains(i))
                {
                    max = i;
                    queue.Enqueue(i);

                    if (max >= nums.Length - 1)
                        return true;
                }
            }
        }

        return max >= nums.Length - 1;
    }
}

// √ Accepted
//   √ 75/75 cases passed (100 ms)
//   √ Your runtime beats 77.29 % of csharp submissions
//   √ Your memory usage beats 86.49 % of csharp submissions (24 MB)

