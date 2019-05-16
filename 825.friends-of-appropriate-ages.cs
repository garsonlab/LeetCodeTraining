/*
 * @lc app=leetcode id=825 lang=csharp
 *
 * [825] Friends Of Appropriate Ages

 Some people will make friend requests. The list of their ages is given and ages[i] is the age of the ith person. 

Person A will NOT friend request person B (B != A) if any of the following conditions are true:

age[B] <= 0.5 * age[A] + 7
age[B] > age[A]
age[B] > 100 && age[A] < 100
Otherwise, A will friend request B.

Note that if A requests B, B does not necessarily request A.  Also, people will not friend request themselves.

How many total friend requests are made?

Example 1:

Input: [16,16]
Output: 2
Explanation: 2 people friend request each other.
Example 2:

Input: [16,17,18]
Output: 2
Explanation: Friend requests are made 17 -> 16, 18 -> 17.
Example 3:

Input: [20,30,100,110,120]
Output: 
Explanation: Friend requests are made 110 -> 100, 120 -> 110, 120 -> 100.
 

Notes:

1 <= ages.length <= 20000.
1 <= ages[i] <= 120.
 */
public class Solution {
    public int NumFriendRequests(int[] ages) {
        // 映射数组
        int[] nums = new int[121], sums = new int[121];
        int res = 0;
        //计算各个年龄段的人数
        for( int i = 0;i < ages.Length;i++) {
            nums[ages[i]]++;
        }
        //计算年龄小于等于下标人数
        for(int i = 1;i<121;i++) {
            sums[i] = sums[i-1] + nums[i];
        }
        //低于15没朋友
        for(int i = 15;i < 121;i++) {
            if(nums[i] == 0) continue; 
            int count = sums[i] - sums[i/2+7];
            //不包含自己
            count--;
            res += count * nums[i];
        }
        return res;
    }
}

// √ Accepted
//   √ 83/83 cases passed (136 ms)
//   √ Your runtime beats 59.09 % of csharp submissions
//   √ Your memory usage beats 7.89 % of csharp submissions (31.4 MB)

