/*
 * @lc app=leetcode id=1049 lang=csharp
 *
 * [1049] Last Stone Weight II
 */
public class Solution {
    public int LastStoneWeightII(int[] stones) {
        int sum = 0;
        foreach (var s in stones)
        {
            sum += s;
        }

        int i = sum >> 1;
        while (true)
        {
            if(DFS(stones, 0, 0, i))
                return sum-2*i;
            
            i--;
        }
    }

    private bool DFS(int[] nums, int idx, int sum, int target){
        if(sum == target)
            return true;
        if(sum > target || idx >= nums.Length)
            return false;
        
        return DFS(nums, idx+1, sum+nums[idx], target) || DFS(nums, idx+1, sum, target);
    }
}



// √ Accepted
//   √ 82/82 cases passed (108 ms)
//   √ Your runtime beats 25 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (21.8 MB)
