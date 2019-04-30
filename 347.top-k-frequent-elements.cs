/*
 * @lc app=leetcode id=347 lang=csharp
 *
 * [347] Top K Frequent Elements

 Given a non-empty array of integers, return the k most frequent elements.

Example 1:

Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
Example 2:

Input: nums = [1], k = 1
Output: [1]
Note:

You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
 */
public class Solution {
    public IList<int> TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            int a;
            if (!dic.TryGetValue(num, out a))
                a = 0;
            dic[num] = a + 1;
        }

        List<int> list = new List<int>(dic.Keys);
        list.Sort((a, b) => { return dic[b] - dic[a]; });

        for (int i = list.Count-1; i >= k; i--)
        {
            list.RemoveAt(i);
        }

        return list;
    }
}


// √ Accepted
//   √ 21/21 cases passed (264 ms)
//   √ Your runtime beats 94.66 % of csharp submissions
//   √ Your memory usage beats 100 % of csharp submissions (31.4 MB)
