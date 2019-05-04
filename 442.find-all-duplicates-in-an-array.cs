/*
 * @lc app=leetcode id=442 lang=csharp
 *
 * [442] Find All Duplicates in an Array

 Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

Find all the elements that appear twice in this array.

Could you do it without extra space and in O(n) runtime?

Example:
Input:
[4,3,2,7,8,2,3,1]

Output:
[2,3]
 */
public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        List<int> list = new List<int>();
        if(nums.Length <= 0)
            return list;

        for (int i = 0; i < nums.Length; i++)
        {
            int idx = Math.Abs(nums[i]);
            if (nums[idx - 1] > 0) {
                nums[idx - 1] *= -1;
            } else {
                list.Add(idx);
            }
        }
        return list;
    }
}

// √ Accepted
//   √ 28/28 cases passed (308 ms)
//   √ Your runtime beats 100 % of csharp submissions
//   √ Your memory usage beats 70 % of csharp submissions (42.3 MB)

