/*
 * @lc app=leetcode id=416 lang=csharp
 *
 * [416] Partition Equal Subset Sum

 Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

Note:

Each of the array element will not exceed 100.
The array size will not exceed 200.
 

Example 1:

Input: [1, 5, 11, 5]

Output: true

Explanation: The array can be partitioned as [1, 5, 5] and [11].
 

Example 2:

Input: [1, 2, 3, 5]

Output: false

Explanation: The array cannot be partitioned into equal sum subsets.
 */
public class Solution {
    public bool CanPartition(int[] nums) {
        if(nums.Length <= 1)
            return false;
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        if(sum%2 > 0)
            return false;

        Array.Sort(nums);
        return DFS(nums, sum>>1, nums.Length-1);
    }

    private bool DFS(int[] nums, int target, int idx)
    {
        if(target == 0)
            return true;
        
        if(target < 0 || idx < 0 || target < nums[idx])
            return false;
        
        int t = target-nums[idx];
        if(DFS(nums, t, idx-1))
            return true;
        
        return DFS(nums, target, idx-1);
    }
}

// √ Accepted
//   √ 104/104 cases passed (92 ms)
//   √ Your runtime beats 99.1 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.2 MB)

