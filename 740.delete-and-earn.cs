/*
 * @lc app=leetcode id=740 lang=csharp
 *
 * [740] Delete and Earn

 Given an array nums of integers, you can perform operations on the array.

In each operation, you pick any nums[i] and delete it to earn nums[i] points. After, you must delete every element equal to nums[i] - 1 or nums[i] + 1.

You start with 0 points. Return the maximum number of points you can earn by applying such operations.

Example 1:

Input: nums = [3, 4, 2]
Output: 6
Explanation: 
Delete 4 to earn 4 points, consequently 3 is also deleted.
Then, delete 2 to earn 2 points. 6 total points are earned.
 

Example 2:

Input: nums = [2, 2, 3, 3, 3, 4]
Output: 9
Explanation: 
Delete 3 to earn 3 points, deleting both 2's and the 4.
Then, delete 3 again to earn 3 points, and 3 again to earn 3 points.
9 total points are earned.
 

Note:

The length of nums is at most 20000.
Each element nums[i] is an integer in the range [1, 10000].
 */
public class Solution {
    public int DeleteAndEarn(int[] nums) {
        //牺牲空间。times代表每个值的次数
        //dps代表当i为最大值时能获得的最大点数
        int []times=new int[10001];
        int []dps=new int[10001];
        for(int i=0;i<nums.Length;i++)
        {
            times[nums[i]]++;
        }
        dps[1]=times[1];
        for(int i=2;i<=10000;i++)
        {
            //两种情况，要么不要i，要么要i。
            dps[i]=Math.Max(dps[i-1],dps[i-2]+i*times[i]);
        }
        return dps[10000];
    }
}

// √ Accepted
//   √ 46/46 cases passed (96 ms)
//   √ Your runtime beats 82.14 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (26.2 MB)

