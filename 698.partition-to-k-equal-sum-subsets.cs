/*
 * @lc app=leetcode id=698 lang=csharp
 *
 * [698] Partition to K Equal Sum Subsets

 Given an array of integers nums and a positive integer k, find whether it's possible to divide this array into k non-empty subsets whose sums are all equal.

 

Example 1:

Input: nums = [4, 3, 2, 3, 5, 2, 1], k = 4
Output: True
Explanation: It's possible to divide it into 4 subsets (5), (1, 4), (2,3), (2,3) with equal sums.
 

Note:

1 <= k <= len(nums) <= 16.
0 < nums[i] < 10000.
 */
public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        if (nums.Length < k)
            return false;

        Dictionary<int, int> dic = new Dictionary<int, int>();
        int sum = 0, max = int.MinValue;
        foreach (var num in nums)
        {
            sum += num;
            max = Math.Max(max, num);

            if (dic.ContainsKey(num))
                dic[num]++;
            else
                dic[num] = 1;
        }

        if (sum % k > 0)
            return false;

        if (sum / k < max)
            return false;

        return dfsPKS(dic, k, 0, sum / k);

    }

    //搜索nowK个preSum，target是上一个子集剩余的需要寻找的元素
    bool dfsPKS(Dictionary<int, int> dic, int nowK, int target, int sum)
    {
        if (target == 0)
        {
            if (nowK == 0)
            {
                return true;
            }
            else
            {
                return dfsPKS(dic, nowK - 1, sum, sum);//当前子集搜索完毕，搜索下一个子集
            }
        }
        else
        {
            //搜索target
            for (int num = target; num > 0; --num)
            {
                if (dic.ContainsKey(num) && dic[num] > 0)
                {//num还有使用次数
                    dic[num] -= 1;//次数自减
                    if (dfsPKS(dic, nowK, target - num, sum))
                    {//继续搜索target - num
                        return true;
                    }
                    dic[num] += 1;
                }
            }
            return false;
        }
    }

}


// √ Accepted
//   √ 149/149 cases passed (240 ms)
//   √ Your runtime beats 12.64 % of csharp submissions
//   √ Your memory usage beats 33.33 % of csharp submissions (22.2 MB)

