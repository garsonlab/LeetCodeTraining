/*
 * @lc app=leetcode id=658 lang=csharp
 *
 * [658] Find K Closest Elements

 Given a sorted array, two integers k and x, find the k closest elements to x in the array. The result should also be sorted in ascending order. If there is a tie, the smaller elements are always preferred.

Example 1:
Input: [1,2,3,4,5], k=4, x=3
Output: [1,2,3,4]
Example 2:
Input: [1,2,3,4,5], k=4, x=-1
Output: [1,2,3,4]
Note:
The value k is positive and will always be smaller than the length of the sorted array.
Length of the given array is positive and will not exceed 104
Absolute value of elements in the array and x will not exceed 104
UPDATE (2017/9/19):
The arr parameter had been changed to an array of integers (instead of a list of integers). Please reload the code definition to get the latest changes.
 */
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        List<int> res = new List<int>();
        if (arr.Length <= 0 || k <= 0)
            return res;
        int idx = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (Math.Abs(arr[i] - x) < Math.Abs(arr[idx] - x))
            {
                idx = i;
            }
        }

        res.Add(arr[idx]);
        if (res.Count == k)
            return res;

        for (int i = idx-1, j = idx+1; i >= 0 || j < arr.Length;)
        {
            int l = i >= 0 ? Math.Abs(x - arr[i]) : int.MaxValue;
            int r = j < arr.Length ? Math.Abs(x - arr[j]) : int.MaxValue;

            if (l <= r)
            {
                res.Insert(0, arr[i]);
                i--;
            }
            else
            {
                res.Add(arr[j]);
                j++;
            }

            if(res.Count == k)
                break;
        }
        return res;
    }
}

// √ Accepted
//   √ 55/55 cases passed (332 ms)
//   √ Your runtime beats 37.25 % of csharp submissions
//   √ Your memory usage beats 53.85 % of csharp submissions (40.7 MB)

