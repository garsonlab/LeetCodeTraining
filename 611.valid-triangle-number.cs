/*
 * @lc app=leetcode id=611 lang=csharp
 *
 * [611] Valid Triangle Number

 Given an array consists of non-negative integers, your task is to count the number of triplets chosen from the array that can make triangles if we take them as side lengths of a triangle.
Example 1:
Input: [2,2,3,4]
Output: 3
Explanation:
Valid combinations are: 
2,3,4 (using the first 2)
2,3,4 (using the second 2)
2,2,3
Note:
The length of the given array won't exceed 1000.
The integers in the given array are in the range of [0, 1000].
 */
public class Solution {
    public int TriangleNumber(int[] nums) {
        Array.Sort(nums);
        int res = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // if(i > 0 && nums[i] == nums[i-1])
            //     continue;

            for (int j = i+1; j < nums.Length; j++)
            {
                // if(j > i+1 && nums[j] == nums[j-1])
                //     continue;

                for (int k = j+1; k < nums.Length; k++)
                {
                    // if(k > j+1 && nums[k] == nums[k-1])
                    //     continue;

                    if (nums[i] + nums[j] > nums[k]
                        && nums[i] + nums[k] > nums[j]
                        && nums[j] + nums[k] > nums[i])
                        res++;
                }
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 220/220 cases passed (1508 ms)
//   √ Your runtime beats 12.77 % of csharp submissions
//   √ Your memory usage beats 25 % of csharp submissions (23 MB)

