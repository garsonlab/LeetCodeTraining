/*
 * @lc app=leetcode id=473 lang=csharp
 *
 * [473] Matchsticks to Square

 Remember the story of Little Match Girl? By now, you know exactly what matchsticks the little match girl has, please find out a way you can make one square by using up all those matchsticks. You should not break any stick, but you can link them up, and each matchstick must be used exactly one time.

Your input will be several matchsticks the girl has, represented with their stick length. Your output will either be true or false, to represent whether you could make one square using all the matchsticks the little match girl has.

Example 1:
Input: [1,1,2,2,2]
Output: true

Explanation: You can form a square with length 2, one side of the square came two sticks with length 1.
Example 2:
Input: [3,3,3,3,4]
Output: false

Explanation: You cannot find a way to form a square with all the matchsticks.
Note:
The length sum of the given matchsticks is in the range of 0 to 10^9.
The length of the given matchstick array will not exceed 15.
 */
public class Solution {

    int side = 0;
    public bool Makesquare(int[] nums)
    {
        if (nums.Length < 4) return false;
        int n = nums.Length;
        int minl = 0, total = 0;
        bool[] used = new bool[n];
        Array.Sort(nums);
        for (int i = 0; i < n; i++)
        {
            total += nums[i];
            minl = Math.Max(minl, nums[i]);
        }
        if (total % 4 != 0 || (total / 4) < minl) return false;
        side = total / 4;
        return dfs_1(0, 0, nums, used); ;
    }
    bool dfs_1(int tmp, int count, int[] nums, bool[] used)
    {
        if (count == 4) return true;
        if (tmp == side) return dfs_1(0, ++count, nums, used);
        for (int i = 0; i < nums.Length; i++)
        {
            if (!used[i])
            {
                if (tmp + nums[i] > side) break;
                used[i] = true;
                if (dfs_1(tmp + nums[i], count, nums, used)) return true;
                used[i] = false;
            }
        }
        return false;
    }



    public bool Makesquare_timeout(int[] nums)
    {
        if (nums.Length < 4)
            return false;

        int sum = 0, minSide = 0;
        foreach (var num in nums)
        {
            sum += num;
            minSide = Math.Max(num, minSide);
        }

        if (sum % 4 > 0 || minSide > sum/4)
            return false;

        Array.Sort(nums);
        //for (int i = 0; i < 3; i++)
        //{
        //    if (!DFS(nums, sum / 4))
        //        return false;
        //}
        //return true;

        return dfs(nums, 0, sum / 4, 0);
    }

    bool dfs(int[] nums, int count, int side, int curLen)
    {
        if (count == 4) return true;
        if (curLen == side) return dfs(nums, ++count, side, 0);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                if (curLen + nums[i] > side) break;
                nums[i] *= -1;
                if (dfs(nums, count, side, curLen - nums[i]))
                    return true;
                nums[i] *= -1;
            }
        }
        return false;
    }

    private bool DFS(int[] nums, int len)
    {
        if (len == 0)
            return true;
        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] > len) return false;
            if (nums[i] > 0)
            {
                nums[i] = -nums[i];                   //标记访问数据
                if (DFS(nums, len + nums[i]))
                    return true;
                nums[i] = -nums[i];               //恢复
            }
        }
        return false;
    }

}

