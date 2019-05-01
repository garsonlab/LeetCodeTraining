/*
 * @lc app=leetcode id=373 lang=csharp
 *
 * [373] Find K Pairs with Smallest Sums

 You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

Define a pair (u,v) which consists of one element from the first array and one element from the second array.

Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.

Example 1:

Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
Output: [[1,2],[1,4],[1,6]] 
Explanation: The first 3 pairs are returned from the sequence: 
             [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
Example 2:

Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
Output: [1,1],[1,1]
Explanation: The first 2 pairs are returned from the sequence: 
             [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
Example 3:

Input: nums1 = [1,2], nums2 = [3], k = 3
Output: [1,3],[2,3]
Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]
 */
public class Solution {
    public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

        int len1 = Math.Min(nums1.Length, k);
        int len2 = Math.Min(nums2.Length, k);

        for (int i = 0; i < len1; i++)
        {
            for (int j = 0; j < len2; j++)
            {
                int v = nums1[i] + nums2[j];
                List<int> list;
                if (!dic.TryGetValue(v, out list))
                {
                    list = new List<int>();
                    dic[v] = list;
                }
                list.Add(nums1[i]);
                list.Add(nums2[j]);
            }
        }

        List<int> keys = new List<int>(dic.Keys);
        keys.Sort();

        List<int[]> res = new List<int[]>();
        foreach (var key in keys)
        {
            var list = dic[key];
            for (int i = 0; i < list.Count;)
            {
                res.Add(new[] { list[i], list[i + 1] });
                i += 2;

                if (res.Count == k)
                    return res;
            }
        }

        return res;
    }
}

// √ Accepted
//   √ 27/27 cases passed (464 ms)
//   √ Your runtime beats 25.64 % of csharp submissions
//   √ Your memory usage beats 16.67 % of csharp submissions (71.3 MB)

