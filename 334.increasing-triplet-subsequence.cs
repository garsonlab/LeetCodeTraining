/*
 * @lc app=leetcode id=334 lang=csharp
 *
 * [334] Increasing Triplet Subsequence

 Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array.

Formally the function should:

Return true if there exists i, j, k 
such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false.
Note: Your algorithm should run in O(n) time complexity and O(1) space complexity.

Example 1:

Input: [1,2,3,4,5]
Output: true
Example 2:

Input: [5,4,3,2,1]
Output: false
 */
public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        if (nums.Length < 3)
            return false;
        int min = Int32.MaxValue, sec = Int32.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= min)
                min = nums[i];
            else if (nums[i] <= sec)
                sec = nums[i];
            else
                return true;
        }

        return false;
    }
}
// √ Accepted
//   √ 62/62 cases passed (92 ms)
//   √ Your runtime beats 97.31 % of csharp submissions
//   √ Your memory usage beats 43.75 % of csharp submissions (22.6 MB)

