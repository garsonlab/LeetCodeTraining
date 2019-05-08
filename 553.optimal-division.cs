/*
 * @lc app=leetcode id=553 lang=csharp
 *
 * [553] Optimal Division

 Given a list of positive integers, the adjacent integers will perform the float division. For example, [2,3,4] -> 2 / 3 / 4.

However, you can add any number of parenthesis at any position to change the priority of operations. You should find out how to add parenthesis to get the maximum result, and return the corresponding expression in string format. Your expression should NOT contain redundant parenthesis.

Example:
Input: [1000,100,10,2]
Output: "1000/(100/10/2)"
Explanation:
1000/(100/10/2) = 1000/((100/10)/2) = 200
However, the bold parenthesis in "1000/((100/10)/2)" are redundant, 
since they don't influence the operation priority. So you should return "1000/(100/10/2)". 

Other cases:
1000/(100/10)/2 = 50
1000/(100/(10/2)) = 50
1000/100/10/2 = 0.5
1000/100/(10/2) = 2
Note:

The length of the input array is [1, 10].
Elements in the given array will be in range [2, 1000].
There is only one optimal division for each test case.
 */
public class Solution {
    public string OptimalDivision(int[] nums) {
        if (nums.Length == 0)
            return "";

        if (nums.Length == 1)
            return nums[0].ToString();

        StringBuilder builder = new StringBuilder();
        builder.Append(nums[0]);
        builder.Append("/");

        if (nums.Length == 2)
        {
            builder.Append(nums[1]);
            return builder.ToString();
        }

        builder.Append("(");
        for (int i = 1; i < nums.Length; i++)
        {
            if (i > 1)
                builder.Append("/");
            builder.Append(nums[i]);
        }

        builder.Append(")");
        return builder.ToString();
    }
}

    //都是正整数，连除的越长数值越小，分母越小值越大
// √ Accepted
//   √ 93/93 cases passed (108 ms)
//   √ Your runtime beats 35.9 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (22.3 MB)

