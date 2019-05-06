/*
 * @lc app=leetcode id=491 lang=csharp
 *
 * [491] Increasing Subsequences

 Given an integer array, your task is to find all the different possible increasing subsequences of the given array, and the length of an increasing subsequence should be at least 2 .

Example:
Input: [4, 6, 7, 7]
Output: [[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7], [4,7,7]]
Note:
The length of the given array will not exceed 15.
The range of integer in the given array is [-100,100].
The given array may contain duplicates, and two equal integers should also be considered as a special case of increasing sequence.
 */
public class Solution {
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();

        int[][] f = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++)
        {
            f[i] = new[] {nums[i], i};
        }
        Array.Sort(f, (a, b) => { return a[0] - b[0]; });
        int[] m = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            int t = f[i][1];
            if (i == 0)
                m[t] = f[i][0] - 1;
            else
                m[t] = f[i - 1][0];
        }

        SubSeq(res, new List<int>(), nums, 0, m);
        return res;
    }

    private void SubSeq(IList<IList<int>> list, List<int> cur, int[] nums, int idx, int[] mark)
    {
        for (int i = idx; i < nums.Length; i++)
        {
            if(i > idx && mark[i] == nums[i])
                continue;

            if (cur.Count == 0)
            {
                var tem = new List<int>(cur);
                tem.Add(nums[i]);
                SubSeq(list, tem, nums, i+1, mark);
            }
            else
            {
                if (nums[i] >= cur[cur.Count - 1])
                {
                    var tem = new List<int>(cur);
                    tem.Add(nums[i]);
                    list.Add(tem);
                    SubSeq(list, tem, nums, i+1, mark);
                }
            }
        }
    }


    // public IList<IList<int>> FindSubsequences(int[] nums) {
    //     IList<IList<int>> res = new List<IList<int>>();

    //     SubSeq(res, new List<int>(), nums, 0);
    //     return res;
    // }

    // private void SubSeq(IList<IList<int>> list, List<int> cur, int[] nums, int idx)
    // {
    //     for (int i = idx; i < nums.Length; i++)
    //     {
    //         if (cur.Count == 0)
    //         {
    //             var tem = new List<int>(cur);
    //             tem.Add(nums[i]);
    //             SubSeq(list, tem, nums, i+1);
    //         }
    //         else
    //         {
    //             if (nums[i] >= cur[cur.Count - 1])
    //             {
    //                 var tem = new List<int>(cur);
    //                 tem.Add(nums[i]);

    //                 // bool eq = false;
    //                 // foreach (var l in list)
    //                 // {
    //                 //     if (l.Count == tem.Count)
    //                 //     {
    //                 //         eq = true;
    //                 //         for (int j = 0; j < l.Count; j++)
    //                 //         {
    //                 //             if (l[j] != tem[j])
    //                 //             {
    //                 //                 eq = false;
    //                 //                 break;
    //                 //             }
    //                 //         }
    //                 //         if(eq)
    //                 //             break;
    //                 //     }
    //                 // }

    //                 // if(eq)
    //                 //     continue;

    //                 bool eq = false;
    //                 foreach (var l in list)
    //                 {
    //                     if (System.Linq.Enumerable.SequenceEqual(l, tem))
    //                     {
    //                         eq = true;
    //                         break;
    //                     }
    //                 }
    //                 if (eq)
    //                     continue;

    //                 list.Add(tem);
    //                 SubSeq(list, tem, nums, i+1);
    //             }
    //         }
    //     }
    // }


}

