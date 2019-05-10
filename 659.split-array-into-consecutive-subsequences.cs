/*
 * @lc app=leetcode id=659 lang=csharp
 *
 * [659] Split Array into Consecutive Subsequences

 You are given an integer array sorted in ascending order (may contain duplicates), you need to split them into several subsequences, where each subsequences consist of at least 3 consecutive integers. Return whether you can make such a split.

Example 1:
Input: [1,2,3,3,4,5]
Output: True
Explanation:
You can split them into two consecutive subsequences : 
1, 2, 3
3, 4, 5
Example 2:
Input: [1,2,3,3,4,4,5,5]
Output: True
Explanation:
You can split them into two consecutive subsequences : 
1, 2, 3, 4, 5
3, 4, 5
Example 3:
Input: [1,2,3,4,4,5]
Output: False
Note:
The length of the input is in range of [1, 10000]
 */
public class Solution {
    public bool IsPossible(int[] nums) {
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        Dictionary<int, int> end = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (cnt.ContainsKey(num))
                cnt[num] = cnt[num] + 1;
            else
                cnt[num] = 1;
        }

        //开始访问各个元素
        foreach (var num in nums)
        {
            if (cnt[num] == 0)
            {//此元素没有剩余，已经被使用完了
                continue;
            }
            cnt[num] -= 1;//剩余个数自减
            if (end.ContainsKey(num - 1) && end[num - 1] > 0)
            {
                //存在以num - 1结尾的连续子序列（长度不小于3），则将num放入
                end[num - 1] -= 1;//以num - 1结尾的连续子序列（长度不小于3）自减，因为被num放入使用了一个
                //end[num] += 1;//以num结尾的连续子序列（长度不小于3）自增，刚刚创建了一个
                if (end.ContainsKey(num))
                    end[num]++;
                else
                    end[num] = 1;
            }
            else if (cnt.ContainsKey(num + 1) && cnt[num + 1] > 0 && cnt.ContainsKey(num + 2) && cnt[num + 2] > 0)
            {
                //否则查找后面两个元素，凑出一个合法的序列
                cnt[num + 1] -= 1;
                cnt[num + 2] -= 1;
                //end[num + 2] += 1;
                if (end.ContainsKey(num + 2))
                    end[num + 2]++;
                else
                    end[num + 2] = 1;
            }
            else
            {
                //两种方法都不行，则凑不出，比如[1,2,3,4,4,5]中的第二个4，
                return false;
            }
        }
        return true;
    }
}

// √ Accepted
//   √ 180/180 cases passed (236 ms)
//   √ Your runtime beats 18.52 % of csharp submissions
//   √ Your memory usage beats 50 % of csharp submissions (41.7 MB)

