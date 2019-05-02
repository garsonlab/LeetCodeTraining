/*
 * @lc app=leetcode id=398 lang=csharp
 *
 * [398] Random Pick Index

 Given an array of integers with possible duplicates, randomly output the index of a given target number. You can assume that the given target number must exist in the array.

Note:
The array size can be very large. Solution that uses too much extra space will not pass the judge.

Example:

int[] nums = new int[] {1,2,3,3,3};
Solution solution = new Solution(nums);

// pick(3) should return either index 2, 3, or 4 randomly. Each index should have equal probability of returning.
solution.pick(3);

// pick(1) should return 0. Since in the array only nums[0] is equal to 1.
solution.pick(1);
 */
public class Solution {

    int[] nums;
    Random random;

    public Solution(int[] nums) {
        this.nums = nums;
        this.random = new Random();
    }
    
    public int Pick(int target) {
        // int v = -1;

        // for (int i = 0; i < nums.Length; i++)
        // {
        //     if(nums[i] == target) {
        //         if(v == -1)
        //             v = i;
                
        //         if(random.Next(i) == 0)
        //             v = i;
        //     }
        // }
        // return v;

        int result = 0;
        int cnt = 0;
        for(int i=0; i<nums.Length; i++)
        {
            if(nums[i] == target)
            {
                cnt++;
                if(random.Next(cnt) == 0)
                {
                    result = i;
                }
            }
        }
        return result;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int param_1 = obj.Pick(target);
 */


//  √ Accepted
//   √ 13/13 cases passed (288 ms)
//   √ Your runtime beats 74.67 % of csharp submissions
//   √ Your memory usage beats 60 % of csharp submissions (47.7 MB)

