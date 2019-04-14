/*
 * @lc app=leetcode id=15 lang=csharp
 *
 * [15] 3Sum
 *
 * https://leetcode.com/problems/3sum/description/
 *
 * algorithms
 * Medium (23.73%)
 * Total Accepted:    519.6K
 * Total Submissions: 2.2M
 * Testcase Example:  '[-1,0,1,2,-1,-4]'
 *
 * Given an array nums of n integers, are there elements a, b, c in nums such
 * that a + b + c = 0? Find all unique triplets in the array which gives the
 * sum of zero.
 * 
 * Note:
 * 
 * The solution set must not contain duplicate triplets.
 * 
 * Example:
 * 
 * 
 * Given array nums = [-1, 0, 1, 2, -1, -4],
 * 
 * A solution set is:
 * [
 * ⁠ [-1, 0, 1],
 * ⁠ [-1, -1, 2]
 * ]
 * 
 * 
 */
public class Solution {

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 3)
            return list;
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            if(nums[i] > 0)//第一个数大于0相加肯定大于0
                break;
            int j = i + 1, k = nums.Length - 1;
            while (j < k)
            {
                int v = nums[i] + nums[j] + nums[k];
                if (v > 0)
                    k--;
                else if (v < 0)
                    j++;
                else
                {
                    list.Add(new List<int>() { nums[i], nums[j], nums[k] });

                    while (j < k && nums[j] == nums[j + 1]) j++;
                    while (k > j && nums[k] == nums[k - 1]) k--;
                    j++;
                    k--;
                }
            }
        }

        return list;
    }

    public IList<IList<int>> ThreeSum4(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 3)
            return list;
        Array.Sort(nums);

        int[] un = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            un[i] = -nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if(i> 0 && nums[i] == nums[i-1])
                continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                if(j> i+1 && nums[j] == nums[j-1])
                    continue;

                int v = nums[i] + nums[j];
                int idx = Array.LastIndexOf(un, v);
                if (idx > j)
                {
                    List<int> t = new List<int>(){nums[i], nums[j], -v};
                    list.Add(t);
                }
            }
        }

        return list;
    }

    public IList<IList<int>> ThreeSum3(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 3)
            return list;
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if(i> 0 && nums[i] == nums[i-1])
                continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                if(j> i+1 && nums[j] == nums[j-1])
                    continue;

                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (k > j + 1 && nums[k] == nums[k - 1])
                        continue;
                    int v = nums[i] + nums[j] + nums[k];
                    if (v == 0)
                    {
                        list.Add(new List<int>() { nums[i], nums[j], nums[k] });
                    }
                    else if (v > 0)
                        break;
                }
            }
        }

        return list;
    }

    public IList<IList<int>> ThreeSum2(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 3)
            return list;

        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            List<int> t;
            if (!dic.TryGetValue(nums[i] * -1, out t))
            {
                t = new List<int>();
                dic[nums[i] * -1] = t;
            }
            t.Add(i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                int v = nums[i] + nums[j];
                if (dic.ContainsKey(v))
                {
                    var l = dic[v];
                    bool d = false;
                    foreach (var i1 in l)
                    {
                        if (i1 != i && i1 != j)
                        {
                            d = true;
                            break;
                        }
                    }

                    if (d)
                    {
                        List<int> t = new List<int>() {nums[i], nums[j], v * -1};
                        t.Sort();

                        bool c = false;
                        foreach (var tl in list)
                        {
                            if (tl[0] == t[0] && tl[1] == t[1])
                            {
                                c = true;
                                break;
                            }
                        }
                        if(!c)
                            list.Add(t);
                    }
                }
            }
        }

        return list;
    }

    public IList<IList<int>> ThreeSum1(int[] nums) {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 3)
            return list;
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                for (int k = j+1; k < nums.Length; k++)
                {
                    int v = nums[i] + nums[j] + nums[k];
                    if (v == 0)
                    {
                        list.Add(new List<int>() {nums[i], nums[j], nums[k]});
                    }
                    else if(v > 0)
                        break;
                }
            }
        }

        return list;
    }
}

// √ Accepted
//   √ 313/313 cases passed (332 ms)
//   √ Your runtime beats 70.48 % of csharp submissions
//   √ Your memory usage beats 66.98 % of csharp submissions (34.5 MB)

